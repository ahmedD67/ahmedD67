using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WorkoutTracker
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// The goal of this project is to create a recipe book which allows the user several options:
        /// From a programming perspective, this will include all the windows forms from last assignment
        /// as well as enums, listboxes, string arrays, dropdown menus, as well as opening
        /// new menus.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
