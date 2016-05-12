using Personal.Health.Care.DesktopApp.Pages.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal.Health.Care.DesktopApp.Utills
{
    public static class Messenger
    {
        public static void ShowMessage(string title, string message)
        {
            MessageWindow messageWindow = new MessageWindow(title, message);
            messageWindow.ShowDialog();
        }

        public static void ShowMessage(string message)
        {
            MessageWindow messageWindow = new MessageWindow("Opps...", message);
            messageWindow.ShowDialog();
        }
    }
}
