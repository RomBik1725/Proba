using System;
using System.Windows.Forms;

namespace Lab3_Variant6
{
    public partial class MainForm : Form
    {
        public MainForm() { InitializeComponent(); }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtX.Text) ||
                    string.IsNullOrWhiteSpace(txtY.Text) ||
                    string.IsNullOrWhiteSpace(txtZ.Text))
                    throw new ArgumentNullException("", "Заполните все поля");

                double x = double.Parse(txtX.Text.Replace(",","."),
                    System.Globalization.CultureInfo.InvariantCulture);
                double y = double.Parse(txtY.Text.Replace(",","."),
                    System.Globalization.CultureInfo.InvariantCulture);
                double z = double.Parse(txtZ.Text.Replace(",","."),
                    System.Globalization.CultureInfo.InvariantCulture);

                Point3D p = new Point3D(x, y, z);
                lblResult.Text = p.GetInfo();
                lblResult.ForeColor = System.Drawing.Color.DarkGreen;
            }
            catch (FormatException)
            {
                lblResult.Text = "Ошибка: Введите корректное число";
                lblResult.ForeColor = System.Drawing.Color.Red;
            }
            catch (OverflowException)
            {
                lblResult.Text = "Ошибка: Число слишком большое";
                lblResult.ForeColor = System.Drawing.Color.Red;
            }
            catch (ArgumentNullException ex)
            {
                lblResult.Text = "Ошибка: " + ex.Message;
                lblResult.ForeColor = System.Drawing.Color.Red;
            }
            catch (ArgumentException ex)
            {
                lblResult.Text = "Ошибка: " + ex.Message;
                lblResult.ForeColor = System.Drawing.Color.Red;
            }
            catch (Exception ex)
            {
                lblResult.Text = "Неизвестная ошибка: " + ex.Message;
                lblResult.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtX.Clear(); txtY.Clear(); txtZ.Clear();
            lblResult.Text = "";
            txtX.Focus();
        }

        private void btnExit_Click(object sender, EventArgs e) => Application.Exit();

        private void txtNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != ','
                && e.KeyChar != '-' && e.KeyChar != (char)8)
                e.Handled = true;
        }

        private void btnCalculate_MouseEnter(object sender, EventArgs e)
            => btnCalculate.BackColor = System.Drawing.Color.DodgerBlue;
        private void btnCalculate_MouseLeave(object sender, EventArgs e)
            => btnCalculate.BackColor = System.Drawing.Color.SteelBlue;
    }
}