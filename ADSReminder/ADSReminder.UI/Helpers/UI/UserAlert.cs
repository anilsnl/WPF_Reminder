using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADSReminder.UI.Helpers.UI
{
    public class UserAlert
    {
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
            MessageBox.Show(argMessage, argTitle, MessageBoxButtons.OK,lcIconType);
        }
    }
    public enum UserInformType
    {
        Info,
        Error,
        Warning
    }
}
