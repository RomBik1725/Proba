using System;
using System.Windows.Forms;
using Lab5_Variant6.Forms;

namespace Lab5_Variant6
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm());
        }
    }
}