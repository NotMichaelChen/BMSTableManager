using System;
using Gtk;

namespace BMSTableManager
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            TableDownloader table = new TableDownloader("http://3228monsta.web.fc2.com/monstajoy.html");

            Application.Init();
            MainWindow win = new MainWindow();
            win.Show();
            Application.Run();
        }
    }
}
