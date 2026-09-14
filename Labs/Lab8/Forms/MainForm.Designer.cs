using System.Drawing;
using System.Windows.Forms;

namespace Lab8_Variant6.Forms
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        { if(disposing&&components!=null) components.Dispose(); base.Dispose(disposing); }
        private void InitializeComponent()
        {
            lblTitle=new Label(); lbTeachers=new ListBox();
            lblMinExp=new Label(); nudMinExp=new NumericUpDown();
            btnCheckPensioners=new Button(); btnFilter=new Button();
            btnSortLambda=new Button(); btnReset=new Button(); btnExit=new Button();
            lblStatus=new Label();
            SuspendLayout();

            lblTitle.Location=new Point(10,8); lblTitle.Size=new Size(565,26);
            lblTitle.Text="Лаб. №8. Вар. 6 — Делегаты, события, лямбда";
            lblTitle.Font=new Font("Arial",11,FontStyle.Bold);

            lbTeachers.Location=new Point(10,40); lbTeachers.Size=new Size(380,200);
            lblMinExp.Location=new Point(405,40); lblMinExp.Size=new Size(170,23); lblMinExp.Text="Мин. стаж:";
            nudMinExp.Location=new Point(405,65); nudMinExp.Size=new Size(80,23); nudMinExp.Minimum=0; nudMinExp.Maximum=60; nudMinExp.Value=15;

            btnCheckPensioners.Location=new Point(405,100); btnCheckPensioners.Size=new Size(165,30);
            btnCheckPensioners.Text="Пров. пенсионеров";
            btnCheckPensioners.BackColor=Color.Orange; btnCheckPensioners.ForeColor=Color.White;
            btnCheckPensioners.Click+=btnCheckPensioners_Click;

            btnFilter.Location=new Point(405,140); btnFilter.Size=new Size(165,30);
            btnFilter.Text="Фильтр по стажу";
            btnFilter.BackColor=Color.SteelBlue; btnFilter.ForeColor=Color.White;
            btnFilter.Click+=btnFilter_Click;

            btnSortLambda.Location=new Point(405,180); btnSortLambda.Size=new Size(165,30);
            btnSortLambda.Text="Сорт (лямбда)";
            btnSortLambda.BackColor=Color.DarkSeaGreen; btnSortLambda.ForeColor=Color.White;
            btnSortLambda.Click+=btnSortLambda_Click;

            btnReset.Location=new Point(405,220); btnReset.Size=new Size(165,30);
            btnReset.Text="Сбросить"; btnReset.Click+=btnReset_Click;
            btnExit.Location=new Point(405,260); btnExit.Size=new Size(165,30);
            btnExit.Text="Выход"; btnExit.BackColor=Color.IndianRed; btnExit.ForeColor=Color.White;
            btnExit.Click+=btnExit_Click;

            lblStatus.Location=new Point(10,250); lblStatus.Size=new Size(380,22); lblStatus.ForeColor=Color.DarkGreen;

            ClientSize=new Size(585,285); Text="Лаб. №8 — Вар. 6";
            StartPosition=FormStartPosition.CenterScreen;
            Controls.AddRange(new Control[]{lblTitle,lbTeachers,lblMinExp,nudMinExp,
                btnCheckPensioners,btnFilter,btnSortLambda,btnReset,btnExit,lblStatus});
            ResumeLayout(false);
        }
        private Label lblTitle,lblMinExp,lblStatus;
        private ListBox lbTeachers;
        private NumericUpDown nudMinExp;
        private Button btnCheckPensioners,btnFilter,btnSortLambda,btnReset,btnExit;
    }
}