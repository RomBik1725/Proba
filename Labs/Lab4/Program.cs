using System;
using System.Windows.Forms;
using Lab4_Variant6.Forms;

namespace Lab4_Variant6
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