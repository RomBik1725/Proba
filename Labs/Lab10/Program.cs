using System;
using System.Windows.Forms;
using Lab10_Variant6.Forms;

namespace Lab10_Variant6
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