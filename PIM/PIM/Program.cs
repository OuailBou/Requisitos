﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PIM
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
           
            

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            
            

            // Inicia la aplicación de Windows Forms
            Application.Run(new Form1());
            
        }
    }
}