using System;
using System.Drawing;
using System.Windows.Forms;

namespace Lab5_Variant6.Forms
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        { if (disposing && components != null) components.Dispose(); base.Dispose(disposing); }
        private void InitializeComponent()
        {
            lblTitle = new Label(); lbPersons = new ListBox();
            btnShowTeachers = new Button(); btnRemovePensioners = new Button();
            btnShowAll = new Button(); btnExit = new Button();
            lblStatus = new Label();
            SuspendLayout();

            lblTitle.Location=new Point(10,10); lblTitle.Size=new Size(560,28);
            lblTitle.Text="Лаб. №5. Вар. 6 — Иерархия: Person -> Schoolchild, Student, Teacher";
            lblTitle.Font=new Font("Arial",10,FontStyle.Bold);

            lbPersons.Location=new Point(10,45); lbPersons.Size=new Size(560,250);

            btnShowTeachers.Location=new Point(10,308); btnShowTeachers.Size=new Size(170,32);
            btnShowTeachers.Text="Показать преподавателей";
            btnShowTeachers.BackColor=Color.SteelBlue; btnShowTeachers.ForeColor=Color.White;
            btnShowTeachers.Click+=btnShowTeachers_Click;

            btnRemovePensioners.Location=new Point(190,308); btnRemovePensioners.Size=new Size(170,32);
            btnRemovePensioners.Text="Удалить пенсионеров";
            btnRemovePensioners.BackColor=Color.Orange; btnRemovePensioners.ForeColor=Color.White;
            btnRemovePensioners.Click+=btnRemovePensioners_Click;

            btnShowAll.Location=new Point(370,308); btnShowAll.Size=new Size(100,32);
            btnShowAll.Text="Все"; btnShowAll.Click+=btnShowAll_Click;

            btnExit.Location=new Point(480,308); btnExit.Size=new Size(90,32);
            btnExit.Text="Выход"; btnExit.BackColor=Color.IndianRed; btnExit.ForeColor=Color.White;
            btnExit.Click+=btnExit_Click;

            lblStatus.Location=new Point(10,350); lblStatus.Size=new Size(560,22);
            lblStatus.ForeColor=Color.DarkGreen;

            ClientSize=new Size(582,382); Text="Лаб. №5 — Вар. 6";
            StartPosition=FormStartPosition.CenterScreen;
            BackColor=Color.FromArgb(230,240,255);
            Controls.AddRange(new Control[]{lblTitle,lbPersons,btnShowTeachers,
                btnRemovePensioners,btnShowAll,btnExit,lblStatus});
            ResumeLayout(false);
        }
        private Label lblTitle, lblStatus;
        private ListBox lbPersons;
        private Button btnShowTeachers, btnRemovePensioners, btnShowAll, btnExit;
    }
}