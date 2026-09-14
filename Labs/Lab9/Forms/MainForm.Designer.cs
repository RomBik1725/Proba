using System;
using System.Drawing;
using System.Windows.Forms;

namespace Lab9_Variant6.Forms
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        { if(disposing&&components!=null) components.Dispose(); base.Dispose(disposing); }
        private void InitializeComponent()
        {
            lblTitle=new Label(); lbCars=new ListBox();
            grpAdd=new GroupBox(); grpOps=new GroupBox(); grpSearch=new GroupBox();
            lblBrand=new Label(); txtBrand=new TextBox(); lblModel=new Label(); txtModel=new TextBox();
            lblYear=new Label(); nudYear=new NumericUpDown(); lblColor=new Label(); txtColor=new TextBox();
            lblMileage=new Label(); nudMileage=new NumericUpDown();
            btnAdd=new Button(); btnRemoveSelected=new Button();
            lblOldYears=new Label(); nudOldYears=new NumericUpDown();
            btnRemoveOld=new Button(); btnSortYear=new Button(); btnSortMileage=new Button();
            btnShowAll=new Button(); txtSearch=new TextBox(); btnSearch=new Button();
            btnLinq=new Button(); lblCount=new Label(); lblStatus=new Label();
            grpAdd.SuspendLayout(); grpOps.SuspendLayout(); grpSearch.SuspendLayout(); SuspendLayout();

            lblTitle.Location=new Point(10,8); lblTitle.Size=new Size(700,26);
            lblTitle.Text="Лаб. №9. Вар. 6 — Dictionary<string,Car> + LINQ";
            lblTitle.Font=new Font("Arial",10,FontStyle.Bold);

            lbCars.Location=new Point(10,38); lbCars.Size=new Size(440,355);

            grpAdd.Location=new Point(465,35); grpAdd.Size=new Size(220,210); grpAdd.Text="Добавить";
            lblBrand.Location=new Point(5,22); lblBrand.Size=new Size(55,20); lblBrand.Text="Марка:";
            txtBrand.Location=new Point(65,20); txtBrand.Size=new Size(145,22);
            lblModel.Location=new Point(5,50); lblModel.Size=new Size(55,20); lblModel.Text="Модель:";
            txtModel.Location=new Point(65,48); txtModel.Size=new Size(145,22);
            lblYear.Location=new Point(5,78); lblYear.Size=new Size(55,20); lblYear.Text="Год:";
            nudYear.Location=new Point(65,76); nudYear.Size=new Size(145,22); nudYear.Minimum=1980; nudYear.Maximum=DateTime.Now.Year; nudYear.Value=2020;
            lblColor.Location=new Point(5,106); lblColor.Size=new Size(55,20); lblColor.Text="Цвет:";
            txtColor.Location=new Point(65,104); txtColor.Size=new Size(145,22);
            lblMileage.Location=new Point(5,134); lblMileage.Size=new Size(55,20); lblMileage.Text="Проб.:";
            nudMileage.Location=new Point(65,132); nudMileage.Size=new Size(145,22); nudMileage.Maximum=1000000;
            btnAdd.Location=new Point(60,165); btnAdd.Size=new Size(100,30);
            btnAdd.Text="Добавить"; btnAdd.BackColor=Color.SteelBlue; btnAdd.ForeColor=Color.White;
            btnAdd.Click+=btnAdd_Click;
            grpAdd.Controls.AddRange(new Control[]{lblBrand,txtBrand,lblModel,txtModel,lblYear,nudYear,lblColor,txtColor,lblMileage,nudMileage,btnAdd});

            grpOps.Location=new Point(465,255); grpOps.Size=new Size(220,140); grpOps.Text="Операции";
            btnRemoveSelected.Location=new Point(5,22); btnRemoveSelected.Size=new Size(205,26); btnRemoveSelected.Text="Удалить выбранный"; btnRemoveSelected.Click+=btnRemoveSelected_Click;
            lblOldYears.Location=new Point(5,55); lblOldYears.Size=new Size(100,22); lblOldYears.Text="Уд. старше (лет):";
            nudOldYears.Location=new Point(108,53); nudOldYears.Size=new Size(55,22); nudOldYears.Value=10; nudOldYears.Minimum=1; nudOldYears.Maximum=50;
            btnRemoveOld.Location=new Point(5,83); btnRemoveOld.Size=new Size(205,26); btnRemoveOld.Text="Удалить старые"; btnRemoveOld.Click+=btnRemoveOld_Click;
            btnSortYear.Location=new Point(5,115); btnSortYear.Size=new Size(98,26); btnSortYear.Text="По году"; btnSortYear.Click+=btnSortYear_Click;
            btnSortMileage.Location=new Point(112,115); btnSortMileage.Size=new Size(98,26); btnSortMileage.Text="По пробегу"; btnSortMileage.Click+=btnSortMileage_Click;
            grpOps.Controls.AddRange(new Control[]{btnRemoveSelected,lblOldYears,nudOldYears,btnRemoveOld,btnSortYear,btnSortMileage});

            grpSearch.Location=new Point(10,400); grpSearch.Size=new Size(440,52); grpSearch.Text="Поиск";
            txtSearch.Location=new Point(8,20); txtSearch.Size=new Size(250,22);
            btnSearch.Location=new Point(265,18); btnSearch.Size=new Size(80,26); btnSearch.Text="Найти"; btnSearch.Click+=btnSearch_Click;
            btnShowAll.Location=new Point(350,18); btnShowAll.Size=new Size(80,26); btnShowAll.Text="Все"; btnShowAll.Click+=btnShowAll_Click;
            grpSearch.Controls.AddRange(new Control[]{txtSearch,btnSearch,btnShowAll});

            btnLinq.Location=new Point(465,410); btnLinq.Size=new Size(220,32);
            btnLinq.Text="LINQ статистика"; btnLinq.BackColor=Color.Purple; btnLinq.ForeColor=Color.White; btnLinq.Click+=btnLinq_Click;

            lblCount.Location=new Point(10,460); lblCount.Size=new Size(200,22); lblCount.ForeColor=Color.DarkBlue;
            lblStatus.Location=new Point(220,460); lblStatus.Size=new Size(465,22); lblStatus.ForeColor=Color.DarkGreen;

            ClientSize=new Size(700,490); Text="Лаб. №9 — Вар. 6"; StartPosition=FormStartPosition.CenterScreen;
            Controls.AddRange(new Control[]{lblTitle,lbCars,grpAdd,grpOps,grpSearch,btnLinq,lblCount,lblStatus});
            grpAdd.ResumeLayout(false); grpOps.ResumeLayout(false); grpSearch.ResumeLayout(false); ResumeLayout(false);
        }
        private Label lblTitle,lblBrand,lblModel,lblYear,lblColor,lblMileage,lblOldYears,lblCount,lblStatus;
        private TextBox txtBrand,txtModel,txtColor,txtSearch;
        private NumericUpDown nudYear,nudMileage,nudOldYears;
        private ListBox lbCars;
        private GroupBox grpAdd,grpOps,grpSearch;
        private Button btnAdd,btnRemoveSelected,btnRemoveOld,btnSortYear,btnSortMileage,btnSearch,btnShowAll,btnLinq;
    }
}