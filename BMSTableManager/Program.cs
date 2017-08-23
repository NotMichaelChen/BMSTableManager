﻿using System;
using Gtk;

using BMSTableManager.TableInfo;

namespace BMSTableManager
{
    class MainClass
    {
        [STAThread]
        public static void Main(string[] args)
        {
            BMSTable table = new BMSTable("http://3228monsta.web.fc2.com/monstajoy.html");

            Application.Init();
            MainWindow win = new MainWindow();
            win.Show();
            Application.Run();
        }
    }
}
