using System;
using System.Windows.Input;

namespace ADSReminder.UI.BaseClasses
{
    public class CommandExcuter : ICommand
    {
        public event EventHandler CanExecuteChanged;
        Action<object> mExecteMethod;

        public CommandExcuter(Action<object> argExecteMethod)
        {
            mExecteMethod = argExecteMethod;
        }
        public bool CanExecute(object argPatam)
        {
            return true;
        }
        public void Execute(object argParam)
        {
            mExecteMethod(argParam);
        }
    }
}
