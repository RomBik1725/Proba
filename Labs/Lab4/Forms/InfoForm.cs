using System.Drawing;
using System.Windows.Forms;
using Lab4_Variant6.Classes;

namespace Lab4_Variant6.Forms
{
    public class InfoForm : Form
    {
        public InfoForm(Point3D? p1, Point3D? p2)
        {
            Text="Информация"; Size=new Size(400,250); StartPosition=FormStartPosition.CenterParent;
            var rtb=new RichTextBox{Dock=DockStyle.Fill,ReadOnly=true,Font=new Font("Courier New",9)};
            if(p1!=null&&p2!=null)
            { rtb.AppendText($"P1: {p1.GetInfo()}\n"); rtb.AppendText($"P2: {p2.GetInfo()}\n"); rtb.AppendText($"Расстояние: {(p1-p2).DistanceToOrigin():F4}\n"); }
            else rtb.Text="Не созданы точки";
            Controls.Add(rtb);
        }
    }
}