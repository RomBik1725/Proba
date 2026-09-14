using System;
using System.Drawing;
using System.Windows.Forms;

namespace Lab3_Variant6
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        { if (disposing && components != null) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            lblTitle = new Label();
            lblXLabel = new Label(); lblYLabel = new Label(); lblZLabel = new Label();
            txtX = new TextBox(); txtY = new TextBox(); txtZ = new TextBox();
            btnCalculate = new Button(); btnClear = new Button(); btnExit = new Button();
            lblResult = new Label();
            SuspendLayout();

            lblTitle.Location = new Point(12, 12); lblTitle.Size = new Size(460, 28);
            lblTitle.Text = "Лаб. №3. Вар. 6 — Точка в 3D (исключения)";
            lblTitle.Font = new Font("Arial", 12, FontStyle.Bold);

            lblXLabel.Location = new Point(12, 52); lblXLabel.Size = new Size(80, 24);
            lblXLabel.Text = "Коорд. X:"; lblXLabel.TextAlign = ContentAlignment.MiddleLeft;
            txtX.Location = new Point(100, 52); txtX.Size = new Size(150, 24);
            txtX.KeyPress += new KeyPressEventHandler(txtNum_KeyPress);

            lblYLabel.Location = new Point(12, 86); lblYLabel.Size = new Size(80, 24);
            lblYLabel.Text = "Коорд. Y:"; lblYLabel.TextAlign = ContentAlignment.MiddleLeft;
            txtY.Location = new Point(100, 86); txtY.Size = new Size(150, 24);
            txtY.KeyPress += new KeyPressEventHandler(txtNum_KeyPress);

            lblZLabel.Location = new Point(12, 120); lblZLabel.Size = new Size(80, 24);
            lblZLabel.Text = "Коорд. Z:"; lblZLabel.TextAlign = ContentAlignment.MiddleLeft;
            txtZ.Location = new Point(100, 120); txtZ.Size = new Size(150, 24);
            txtZ.KeyPress += new KeyPressEventHandler(txtNum_KeyPress);

            btnCalculate.Location = new Point(12, 160); btnCalculate.Size = new Size(110, 36);
            btnCalculate.Text = "Вычислить";
            btnCalculate.BackColor = Color.SteelBlue; btnCalculate.ForeColor = Color.White;
            btnCalculate.Font = new Font("Arial", 10, FontStyle.Bold);
            btnCalculate.Click += new EventHandler(btnCalculate_Click);
            btnCalculate.MouseEnter += new EventHandler(btnCalculate_MouseEnter);
            btnCalculate.MouseLeave += new EventHandler(btnCalculate_MouseLeave);

            btnClear.Location = new Point(134, 160); btnClear.Size = new Size(110, 36);
            btnClear.Text = "Очистить";
            btnClear.Click += new EventHandler(btnClear_Click);

            btnExit.Location = new Point(256, 160); btnExit.Size = new Size(110, 36);
            btnExit.Text = "Выход";
            btnExit.BackColor = Color.IndianRed; btnExit.ForeColor = Color.White;
            btnExit.Click += new EventHandler(btnExit_Click);

            lblResult.Location = new Point(12, 210); lblResult.Size = new Size(460, 80);
            lblResult.Font = new Font("Courier New", 10);
            lblResult.BorderStyle = BorderStyle.FixedSingle;
            lblResult.BackColor = Color.WhiteSmoke;

            ClientSize = new Size(492, 312);
            Text = "Лаб. №3 — Вар. 6";
            FormBorderStyle = FormBorderStyle.FixedSingle;
            StartPosition = FormStartPosition.CenterScreen;
            Controls.AddRange(new Control[] {
                lblTitle, lblXLabel, txtX, lblYLabel, txtY,
                lblZLabel, txtZ, btnCalculate, btnClear, btnExit, lblResult });
            ResumeLayout(false); PerformLayout();
        }

        private Label lblTitle, lblXLabel, lblYLabel, lblZLabel, lblResult;
        private TextBox txtX, txtY, txtZ;
        private Button btnCalculate, btnClear, btnExit;
    }
}