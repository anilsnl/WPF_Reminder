using ADSReminder.UI.CustomControls;
using Microsoft.VisualBasic;
using System.Windows.Forms;

namespace ADSReminder.UI.Helpers.UI
{
    public class UserAlert
    {
        /// <summary>
        /// Informs user with a message box.
        /// </summary>
        /// <param name="argUserInformType"></param>
        /// <param name="argTitle"></param>
        /// <param name="argMessage"></param>
        public static void fnInformUser(UserInformType argUserInformType,string argTitle,string argMessage)
        {
            MessageBoxIcon lcIconType=MessageBoxIcon.Error;
            switch (argUserInformType)
            {
                case UserInformType.Info:
                    lcIconType = MessageBoxIcon.Information;
                    break;
                case UserInformType.Warning:
                    lcIconType = MessageBoxIcon.Warning;
                    break;
                case UserInformType.Error:
                    lcIconType = MessageBoxIcon.Error;
                    break;
            }
            System.Windows.Forms.MessageBox.Show(argMessage, argTitle, MessageBoxButtons.OK,lcIconType);
        }
        /// <summary>
        /// Prompt user a confirmation.
        /// </summary>
        /// <param name="argUserInformType"></param>
        /// <param name="argTitle"></param>
        /// <param name="argMessage"></param>
        /// <returns></returns>
        public static UserConfirmResult fnAskToConfirmUser(UserInformType argUserInformType, string argTitle, string argMessage)
        {
            MessageBoxIcon lcIconType = MessageBoxIcon.Error;
            switch (argUserInformType)
            {
                case UserInformType.Info:
                    lcIconType = MessageBoxIcon.Information;
                    break;
                case UserInformType.Warning:
                    lcIconType = MessageBoxIcon.Warning;
                    break;
                case UserInformType.Error:
                    lcIconType = MessageBoxIcon.Error;
                    break;
            }
            var lcResult =  System.Windows.Forms.MessageBox.Show(argMessage, argTitle, MessageBoxButtons.YesNo, lcIconType);
            return lcResult == DialogResult.Yes ? UserConfirmResult.Confirmed : UserConfirmResult.Rejected;
        }
        /// <summary>
        /// Gets input from user.
        /// </summary>
        /// <param name="argTitle"></param>
        /// <param name="argDetail"></param>
        /// <returns></returns>
        public static string fnGetInputFromUser(string argTitle,string argDetail)
        {
            var lcResult = Interaction.InputBox(argDetail, argTitle);
            return lcResult;
        }
    }
    public enum UserInformType
    {
        Info,
        Error,
        Warning
    }
    public enum UserConfirmResult
    {
        Confirmed,
        Rejected
    }
}
