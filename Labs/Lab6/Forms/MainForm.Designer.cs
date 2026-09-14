using System;
using System.Drawing;
using System.Windows.Forms;

namespace Lab6_Variant6.Forms
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        { if (disposing && components != null) components.Dispose(); base.Dispose(disposing); }
        private void InitializeComponent()
        {
            lblTitle = new Label(); lbPersons = new ListBox();
            grpOps = new GroupBox();
            btnSort = new Button(); btnClone = new Button();
            btnUpcast = new Button(); btnShowAll = new Button(); btnExit = new Button();
            lblCount = new Label(); lblStatus = new Label();
            grpOps.SuspendLayout(); SuspendLayout();

            lblTitle.Location=new Point(10,8); lblTitle.Size=new Size(580,26);
            lblTitle.Text="Лаб. №6. Вар. 6 — IPerson : ICloneable + IComparable";
            lblTitle.Font=new Font("Arial",11,FontStyle.Bold);

            lbPersons.Location=new Point(10,40); lbPersons.Size=new Size(400,260);

            grpOps.Location=new Point(425,40); grpOps.Size=new Size(170,260); grpOps.Text="Операции";

            btnSort.Location=new Point(8,25); btnSort.Size=new Size(150,30);
            btnSort.Text="Сорт (IComparable)"; btnSort.BackColor=Color.SteelBlue; btnSort.ForeColor=Color.White;
            btnSort.Click+=btnSort_Click;
            btnClone.Location=new Point(8,65); btnClone.Size=new Size(150,30);
            btnClone.Text="Клон (ICloneable)"; btnClone.BackColor=Color.MediumSeaGreen; btnClone.ForeColor=Color.White;
            btnClone.Click+=btnClone_Click;
            btnUpcast.Location=new Point(8,105); btnUpcast.Size=new Size(150,30);
            btnUpcast.Text="Прив. типов"; btnUpcast.BackColor=Color.Purple; btnUpcast.ForeColor=Color.White;
            btnUpcast.Click+=btnUpcast_Click;
            btnShowAll.Location=new Point(8,145); btnShowAll.Size=new Size(150,30);
            btnShowAll.Text="Все"; btnShowAll.Click+=btnShowAll_Click;
            btnExit.Location=new Point(8,185); btnExit.Size=new Size(150,30);
            btnExit.Text="Выход"; btnExit.BackColor=Color.IndianRed; btnExit.ForeColor=Color.White;
            btnExit.Click+=btnExit_Click;

            grpOps.Controls.AddRange(new Control[]{btnSort,btnClone,btnUpcast,btnShowAll,btnExit});

            lblCount.Location=new Point(10,310); lblCount.Size=new Size(200,22); lblCount.ForeColor=Color.DarkBlue;
            lblStatus.Location=new Point(220,310); lblStatus.Size=new Size(375,22); lblStatus.ForeColor=Color.DarkGreen;

            ClientSize=new Size(610,345); Text="Лаб. №6 — Вар. 6";
            StartPosition=FormStartPosition.CenterScreen;
            Controls.AddRange(new Control[]{lblTitle,lbPersons,grpOps,lblCount,lblStatus});
            grpOps.ResumeLayout(false); ResumeLayout(false);
        }
        private Label lblTitle, lblCount, lblStatus;
        private ListBox lbPersons;
        private GroupBox grpOps;
        private Button btnSort, btnClone, btnUpcast, btnShowAll, btnExit;
    }
}