using System;
using Gtk;

namespace BMSTableManager.WindowTools
{
    //Contains static functions to help with running a dialog message box
    public static class MessageDialogHelper
    {
        public static int InfoDialog(Window parent, ButtonsType button, string text)
        {
            MessageDialog dialog = new MessageDialog(parent, DialogFlags.DestroyWithParent, MessageType.Info, 
                                                     button, text);
            int result = dialog.Run();
            dialog.Destroy();

            return result;
        }

        public static int WarningDialog(Window parent, ButtonsType button, string text)
        {
            MessageDialog dialog = new MessageDialog(parent, DialogFlags.DestroyWithParent, MessageType.Warning, 
                                                     button, text);
            int result = dialog.Run();
            dialog.Destroy();

            return result;
        }

        public static int QuestionDialog(Window parent, ButtonsType button, string text)
        {
            MessageDialog dialog = new MessageDialog(parent, DialogFlags.DestroyWithParent, MessageType.Question, 
                                                     button, text);
            int result = dialog.Run();
            dialog.Destroy();

            return result;
        }

        public static int ErrorDialog(Window parent, ButtonsType button, string text)
        {
            MessageDialog dialog = new MessageDialog(parent, DialogFlags.DestroyWithParent, MessageType.Error, 
                                                     button, text);
            int result = dialog.Run();
            dialog.Destroy();

            return result;
        }

        public static int OtherDialog(Window parent, ButtonsType button, string text)
        {
            MessageDialog dialog = new MessageDialog(parent, DialogFlags.DestroyWithParent, MessageType.Other, 
                                                     button, text);
            int result = dialog.Run();
            dialog.Destroy();

            return result;
        }
    }
}
