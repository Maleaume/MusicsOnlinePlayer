﻿using System;
using System.Windows.Forms;

namespace Musics___Client
{
    static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm());
           // Application.Run(new LoginPage());

            // Application.Run(new Client());
            //
        }

     
    }
}
