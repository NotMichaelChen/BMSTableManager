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
            Application.Init();
            MainWindow win = new MainWindow();
            win.Show();
            Application.Run();
        }
    }
}
