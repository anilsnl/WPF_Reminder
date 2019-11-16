using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace ADSReminder.UI.Helpers.Messager
{
    public class Messager
    {
        private static readonly object mCreationLock = new object();
        private static readonly ConcurrentDictionary<MessengerKey, object> mDictionary = new ConcurrentDictionary<MessengerKey, object>();

        #region Default property

        private static Messager mInstance;

        /// <summary>
        /// Gets the single instance of the Messenger.
        /// </summary>
        public static Messager gDefault
        {
            get
            {
                if (mInstance == null)
                {
                    lock (mCreationLock)
                    {
                        if (mInstance == null)
                        {
                            mInstance = new Messager();
                        }
                    }
                }

                return mInstance;
            }
        }

        #endregion

        /// <summary>
        /// Initializes a new instance of the Messenger class.
        /// </summary>
        private Messager()
        {
        }

        /// <summary>
        /// Registers a recipient for a type of message T. The action parameter will be executed
        /// when a corresponding message is sent.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="argRecipient"></param>
        /// <param name="fnAction"></param>
        public void fnRegister<T>(object argRecipient, Action<T> fnAction)
        {
            fnRegister(argRecipient, fnAction, null);
        }

        /// <summary>
        /// Registers a recipient for a type of message T and a matching context. The action parameter will be executed
        /// when a corresponding message is sent.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="argRecipient"></param>
        /// <param name="argAction"></param>
        /// <param name="argContext"></param>
        public void fnRegister<T>(object argRecipient, Action<T> argAction, object argContext)
        {
            var lcKey = new MessengerKey(argRecipient, argContext);
            mDictionary.TryAdd(lcKey, argAction);
        }

        /// <summary>
        /// Unregisters a messenger recipient completely. After this method is executed, the recipient will
        /// no longer receive any messages.
        /// </summary>
        /// <param name="argRecipient"></param>
        public void fnUnregister(object argRecipient)
        {
            fnUnregister(argRecipient, null);
        }

        /// <summary>
        /// Unregisters a messenger recipient with a matching context completely. After this method is executed, the recipient will
        /// no longer receive any messages.
        /// </summary>
        /// <param name="argRecipient"></param>
        /// <param name="argContext"></param>
        public void fnUnregister(object argRecipient, object argContext)
        {
            object lcAction;
            var lcKey = new MessengerKey(argRecipient, argContext);
            mDictionary.TryRemove(lcKey, out lcAction);
        }

        /// <summary>
        /// Sends a message to registered recipients. The message will reach all recipients that are
        /// registered for this message type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="argMessage"></param>
        public void fnSend<T>(T argMessage)
        {
            fnSend(argMessage, null);
        }

        /// <summary>
        /// Sends a message to registered recipients. The message will reach all recipients that are
        /// registered for this message type and matching context.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="message"></param>
        /// <param name="context"></param>
        public void fnSend<T>(T message, object context)
        {
            IEnumerable<KeyValuePair<MessengerKey, object>> result;

            if (context == null)
            {
                // Get all recipients where the context is null.
                result = from r in mDictionary where r.Key.Context == null select r;
            }
            else
            {
                // Get all recipients where the context is matching.
                result = from r in mDictionary where r.Key.Context != null && r.Key.Context.Equals(context) select r;
            }

            foreach (var action in result.Select(x => x.Value).OfType<Action<T>>())
            {
                // Send the message to all recipients.
                action(message);
            }
        }

        protected class MessengerKey
        {
            public object Recipient { get; private set; }
            public object Context { get; private set; }

            /// <summary>
            /// Initializes a new instance of the MessengerKey class.
            /// </summary>
            /// <param name="argRecipient"></param>
            /// <param name="argContext"></param>
            public MessengerKey(object argRecipient, object argContext)
            {
                Recipient = argRecipient;
                Context = argContext;
            }

            /// <summary>
            /// Determines whether the specified MessengerKey is equal to the current MessengerKey.
            /// </summary>
            /// <param name="other"></param>
            /// <returns></returns>
            protected bool Equals(MessengerKey other)
            {
                return Equals(Recipient, other.Recipient) && Equals(Context, other.Context);
            }

            /// <summary>
            /// Determines whether the specified MessengerKey is equal to the current MessengerKey.
            /// </summary>
            /// <param name="obj"></param>
            /// <returns></returns>
            public override bool Equals(object obj)
            {
                if (ReferenceEquals(null, obj)) return false;
                if (ReferenceEquals(this, obj)) return true;
                if (obj.GetType() != GetType()) return false;

                return Equals((MessengerKey)obj);
            }

            /// <summary>
            /// Serves as a hash function for a particular type. 
            /// </summary>
            /// <returns></returns>
            public override int GetHashCode()
            {
                unchecked
                {
                    return ((Recipient != null ? Recipient.GetHashCode() : 0) * 397) ^ (Context != null ? Context.GetHashCode() : 0);
                }
            }
        }
    }
}

