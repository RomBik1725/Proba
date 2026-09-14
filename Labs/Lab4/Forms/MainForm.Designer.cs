using System.Drawing;
using System.Windows.Forms;

namespace Lab4_Variant6.Forms
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        { if(disposing&&components!=null) components.Dispose(); base.Dispose(disposing); }
        private void InitializeComponent()
        {
            lblTitle=new Label(); grpP1=new GroupBox(); grpP2=new GroupBox();
            lblX1=new Label(); txtX1=new TextBox(); lblY1=new Label(); txtY1=new TextBox(); lblZ1=new Label(); txtZ1=new TextBox();
            lblX2=new Label(); txtX2=new TextBox(); lblY2=new Label(); txtY2=new TextBox(); lblZ2=new Label(); txtZ2=new TextBox();
            btnCreate=new Button(); btnColor=new Button(); btnOpenInfo=new Button(); btnExit=new Button();
            rtbResult=new RichTextBox();
            grpP1.SuspendLayout(); grpP2.SuspendLayout(); SuspendLayout();

            lblTitle.Location=new Point(10,8); lblTitle.Size=new Size(560,25);
            lblTitle.Text="Лаб. №4. Наследование. Перегрузка. Вар. 6";
            lblTitle.Font=new Font("Arial",11,FontStyle.Bold);

            grpP1.Location=new Point(10,38); grpP1.Size=new Size(270,80); grpP1.Text="Точка P1";
            lblX1.Location=new Point(5,22); lblX1.Size=new Size(20,22); lblX1.Text="X:"; txtX1.Location=new Point(25,20); txtX1.Size=new Size(60,22); txtX1.Text="1";
            lblY1.Location=new Point(93,22); lblY1.Size=new Size(20,22); lblY1.Text="Y:"; txtY1.Location=new Point(113,20); txtY1.Size=new Size(60,22); txtY1.Text="2";
            lblZ1.Location=new Point(181,22); lblZ1.Size=new Size(20,22); lblZ1.Text="Z:"; txtZ1.Location=new Point(201,20); txtZ1.Size=new Size(60,22); txtZ1.Text="3";
            grpP1.Controls.AddRange(new Control[]{lblX1,txtX1,lblY1,txtY1,lblZ1,txtZ1});

            grpP2.Location=new Point(10,125); grpP2.Size=new Size(270,80); grpP2.Text="Точка P2";
            lblX2.Location=new Point(5,22); lblX2.Size=new Size(20,22); lblX2.Text="X:"; txtX2.Location=new Point(25,20); txtX2.Size=new Size(60,22); txtX2.Text="4";
            lblY2.Location=new Point(93,22); lblY2.Size=new Size(20,22); lblY2.Text="Y:"; txtY2.Location=new Point(113,20); txtY2.Size=new Size(60,22); txtY2.Text="5";
            lblZ2.Location=new Point(181,22); lblZ2.Size=new Size(20,22); lblZ2.Text="Z:"; txtZ2.Location=new Point(201,20); txtZ2.Size=new Size(60,22); txtZ2.Text="6";
            grpP2.Controls.AddRange(new Control[]{lblX2,txtX2,lblY2,txtY2,lblZ2,txtZ2});

            btnCreate.Location=new Point(10,215); btnCreate.Size=new Size(120,32); btnCreate.Text="Создать"; btnCreate.BackColor=Color.SteelBlue; btnCreate.ForeColor=Color.White; btnCreate.Click+=btnCreate_Click;
            btnColor.Location=new Point(140,215); btnColor.Size=new Size(100,32); btnColor.Text="Цвет CP1"; btnColor.BackColor=Color.Red; btnColor.ForeColor=Color.White; btnColor.Click+=btnColor_Click;
            btnOpenInfo.Location=new Point(250,215); btnOpenInfo.Size=new Size(100,32); btnOpenInfo.Text="Инфо"; btnOpenInfo.Click+=btnOpenInfo_Click;
            btnExit.Location=new Point(360,215); btnExit.Size=new Size(80,32); btnExit.Text="Выход"; btnExit.BackColor=Color.IndianRed; btnExit.ForeColor=Color.White; btnExit.Click+=btnExit_Click;

            rtbResult.Location=new Point(10,260); rtbResult.Size=new Size(455,160); rtbResult.ReadOnly=true; rtbResult.Font=new Font("Courier New",9);

            ClientSize=new Size(480,435); Text="Лаб. №4 — Вар. 6"; StartPosition=FormStartPosition.CenterScreen;
            Controls.AddRange(new Control[]{lblTitle,grpP1,grpP2,btnCreate,btnColor,btnOpenInfo,btnExit,rtbResult});
            grpP1.ResumeLayout(false); grpP2.ResumeLayout(false); ResumeLayout(false);
        }
        private Label lblTitle,lblX1,lblY1,lblZ1,lblX2,lblY2,lblZ2;
        private TextBox txtX1,txtY1,txtZ1,txtX2,txtY2,txtZ2;
        private GroupBox grpP1,grpP2;
        private Button btnCreate,btnColor,btnOpenInfo,btnExit;
        private RichTextBox rtbResult;
    }
}