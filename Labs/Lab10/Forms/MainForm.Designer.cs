using System;
using System.Drawing;
using System.Windows.Forms;

namespace Lab10_Variant6.Forms
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        { if (disposing && components != null) components.Dispose(); base.Dispose(disposing); }
        private void InitializeComponent()
        {
            lblTitle=new Label();
            grpFile=new GroupBox(); lblCnt=new Label(); nudCount=new NumericUpDown(); btnGenerate=new Button();
            grpSphere=new GroupBox();
            lblCX=new Label(); nudCX=new NumericUpDown();
            lblCY=new Label(); nudCY=new NumericUpDown();
            lblCZ=new Label(); nudCZ=new NumericUpDown();
            lblR=new Label(); nudRadius=new NumericUpDown();
            btnCheck=new Button();
            rtbOutput=new RichTextBox();
            lblStatus=new Label();
            grpFile.SuspendLayout(); grpSphere.SuspendLayout(); SuspendLayout();

            lblTitle.Location=new Point(10,8); lblTitle.Size=new Size(670,26);
            lblTitle.Text="Лаб. №10. Вар. 6 — 3D-точки в бинарном файле | поиск внутри сферы";
            lblTitle.Font=new Font("Arial",11,FontStyle.Bold);

            grpFile.Location=new Point(10,40); grpFile.Size=new Size(330,65); grpFile.Text="Генерация файла";
            lblCnt.Location=new Point(8,25); lblCnt.Size=new Size(140,23); lblCnt.Text="Кол-во точек:";
            nudCount.Location=new Point(150,23); nudCount.Size=new Size(70,23); nudCount.Minimum=5; nudCount.Maximum=100; nudCount.Value=20;
            btnGenerate.Location=new Point(230,21); btnGenerate.Size=new Size(90,27);
            btnGenerate.Text="Сгенерировать";
            btnGenerate.BackColor=Color.SteelBlue; btnGenerate.ForeColor=Color.White;
            btnGenerate.Click+=btnGenerate_Click;
            grpFile.Controls.AddRange(new Control[]{lblCnt,nudCount,btnGenerate});

            grpSphere.Location=new Point(355,40); grpSphere.Size=new Size(325,65); grpSphere.Text="Сфера";
            lblCX.Location=new Point(5,25); lblCX.Size=new Size(25,23); lblCX.Text="CX:";
            nudCX.Location=new Point(30,23); nudCX.Size=new Size(55,23); nudCX.Minimum=-50; nudCX.Maximum=50; nudCX.Value=0;
            lblCY.Location=new Point(90,25); lblCY.Size=new Size(25,23); lblCY.Text="CY:";
            nudCY.Location=new Point(115,23); nudCY.Size=new Size(55,23); nudCY.Minimum=-50; nudCY.Maximum=50; nudCY.Value=0;
            lblCZ.Location=new Point(175,25); lblCZ.Size=new Size(25,23); lblCZ.Text="CZ:";
            nudCZ.Location=new Point(200,23); nudCZ.Size=new Size(55,23); nudCZ.Minimum=-50; nudCZ.Maximum=50; nudCZ.Value=0;
            lblR.Location=new Point(5,50); lblR.Size=new Size(25,23); lblR.Text="R:";
            nudRadius.Location=new Point(30,48); nudRadius.Size=new Size(70,23); nudRadius.Minimum=1; nudRadius.Maximum=100; nudRadius.Value=5;
            btnCheck.Location=new Point(110,46); btnCheck.Size=new Size(205,27);
            btnCheck.Text="Проверить точки в сфере";
            btnCheck.BackColor=Color.DarkSeaGreen; btnCheck.ForeColor=Color.White;
            btnCheck.Click+=btnCheck_Click;
            grpSphere.Controls.AddRange(new Control[]{lblCX,nudCX,lblCY,nudCY,lblCZ,nudCZ,lblR,nudRadius,btnCheck});

            rtbOutput.Location=new Point(10,118); rtbOutput.Size=new Size(670,315);
            rtbOutput.ReadOnly=true; rtbOutput.Font=new Font("Courier New",9);

            lblStatus.Location=new Point(10,440); lblStatus.Size=new Size(670,23);
            lblStatus.ForeColor=Color.DarkGreen; lblStatus.Font=new Font("Arial",9,FontStyle.Bold);

            ClientSize=new Size(694,473);
            Text="Лаб. №10 — Вар. 6"; StartPosition=FormStartPosition.CenterScreen;
            Controls.AddRange(new Control[]{lblTitle,grpFile,grpSphere,rtbOutput,lblStatus});
            grpFile.ResumeLayout(false); grpSphere.ResumeLayout(false); ResumeLayout(false);
        }
        private Label lblTitle,lblCnt,lblCX,lblCY,lblCZ,lblR,lblStatus;
        private NumericUpDown nudCount,nudCX,nudCY,nudCZ,nudRadius;
        private Button btnGenerate,btnCheck;
        private RichTextBox rtbOutput;
        private GroupBox grpFile,grpSphere;
    }
}