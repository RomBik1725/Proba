using System;
using System.Drawing;
using System.Windows.Forms;
using Lab4_Variant6.Classes;

namespace Lab4_Variant6.Forms
{
    public partial class MainForm : Form
    {
        private Point3D? p1, p2;
        private ColoredPoint3D? cp1, cp2;
        private Color selectedColor = Color.Red;
        public MainForm() { InitializeComponent(); }

        private double ParseField(TextBox tb, string name)
        {
            if (!double.TryParse(tb.Text.Replace(",","."),
                System.Globalization.NumberStyles.Float,
                System.Globalization.CultureInfo.InvariantCulture, out double v))
                throw new FormatException($"Поле {name} содержит некорректное число");
            return v;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                p1=new Point3D(ParseField(txtX1,"X1"),ParseField(txtY1,"Y1"),ParseField(txtZ1,"Z1"));
                p2=new Point3D(ParseField(txtX2,"X2"),ParseField(txtY2,"Y2"),ParseField(txtZ2,"Z2"));
                cp1=new ColoredPoint3D(p1.X,p1.Y,p1.Z,selectedColor);
                cp2=new ColoredPoint3D(p2.X,p2.Y,p2.Z,Color.Blue);
                var sb=new System.Text.StringBuilder();
                sb.AppendLine("=== Point3D ==="); sb.AppendLine("P1: "+p1.GetInfo()); sb.AppendLine("P2: "+p2.GetInfo());
                sb.AppendLine($"P1+P2={(p1+p2).GetInfo()}"); sb.AppendLine($"P1-P2={(p1-p2).GetInfo()}"); sb.AppendLine($"P1==P2: {p1==p2}");
                sb.AppendLine(); sb.AppendLine("=== ColoredPoint3D ===");
                sb.AppendLine("CP1: "+cp1.GetInfo()); sb.AppendLine("CP2: "+cp2.GetInfo());
                sb.AppendLine("Сумма CP1+CP2="+(cp1+cp2).GetInfo());
                rtbResult.Text=sb.ToString();
            }
            catch(Exception ex){rtbResult.Text="Ошибка: "+ex.Message;}
        }

        private void btnColor_Click(object sender, EventArgs e)
        { using var dlg=new ColorDialog(); if(dlg.ShowDialog()==DialogResult.OK){selectedColor=dlg.Color; btnColor.BackColor=selectedColor;} }

        private void btnOpenInfo_Click(object sender, EventArgs e)
        { using var info=new InfoForm(p1,p2); info.ShowDialog(); }

        private void btnExit_Click(object sender, EventArgs e) => Application.Exit();
    }
}