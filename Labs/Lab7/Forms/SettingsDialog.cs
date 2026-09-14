using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Lab7_Variant6.Models;

namespace Lab7_Variant6.Forms
{
    public class SettingsDialog : Form
    {
        public List<GraphSettings> Result { get; private set; } = new List<GraphSettings>();
        private ListBox lbColors, lbCurves;
        private NumericUpDown nudCount, nudXMin, nudXMax, nudYMin, nudYMax;
        private Button btnOk, btnCancel;
        private Label lblCount, lblColor, lblCurve, lblRange;

        private static readonly string[] colorNames = { "Синий", "Красный", "Зеленый", "Чёрный", "Пурпурный" };
        private static readonly Color[] colorValues = { Color.Blue, Color.Red, Color.Green, Color.Black, Color.Purple };
        private static readonly string[] curveNames = { "Прямая (y=x)", "Парабола (y=x^2)", "Гипербола (y=1/x)", "Окружность", "Роза r=cos(3t)" };

        public SettingsDialog()
        {
            Text="Выбор линий"; Size=new Size(400,310);
            StartPosition=FormStartPosition.CenterParent;
            FormBorderStyle=FormBorderStyle.FixedDialog; MaximizeBox=false;

            lblCount=new Label{Location=new Point(10,15),Size=new Size(155,22),Text="Кол-во линий (1-5):"};
            nudCount=new NumericUpDown{Location=new Point(170,13),Size=new Size(60,22),Minimum=1,Maximum=5,Value=2};

            lblColor=new Label{Location=new Point(10,48),Size=new Size(170,22),Text="Цвет:"};
            lbColors=new ListBox{Location=new Point(10,70),Size=new Size(170,110)};
            foreach(var c in colorNames) lbColors.Items.Add(c);
            lbColors.SelectedIndex=0;

            lblCurve=new Label{Location=new Point(200,48),Size=new Size(170,22),Text="Тип кривой:"};
            lbCurves=new ListBox{Location=new Point(200,70),Size=new Size(170,110)};
            foreach(var c in curveNames) lbCurves.Items.Add(c);
            lbCurves.SelectedIndex=0;

            lblRange=new Label{Location=new Point(10,193),Size=new Size(360,22),Text="X: от/до      Y: от/до"};
            nudXMin=new NumericUpDown{Location=new Point(10,218),Size=new Size(72,22),Minimum=-100,Maximum=0,Value=-10};
            nudXMax=new NumericUpDown{Location=new Point(88,218),Size=new Size(72,22),Minimum=1,Maximum=100,Value=10};
            nudYMin=new NumericUpDown{Location=new Point(185,218),Size=new Size(72,22),Minimum=-100,Maximum=0,Value=-10};
            nudYMax=new NumericUpDown{Location=new Point(263,218),Size=new Size(72,22),Minimum=1,Maximum=100,Value=10};

            btnOk=new Button{Location=new Point(60,255),Size=new Size(110,32),Text="OK",
                BackColor=Color.SteelBlue,ForeColor=Color.White,DialogResult=DialogResult.OK};
            btnOk.Click+=BtnOk_Click;
            btnCancel=new Button{Location=new Point(200,255),Size=new Size(110,32),
                Text="Отмена",DialogResult=DialogResult.Cancel};

            Controls.AddRange(new Control[]{lblCount,nudCount,lblColor,lbColors,
                lblCurve,lbCurves,lblRange,nudXMin,nudXMax,nudYMin,nudYMax,btnOk,btnCancel});
            AcceptButton=btnOk; CancelButton=btnCancel;
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            Result.Clear();
            int n=(int)nudCount.Value;
            for(int i=0;i<n;i++)
            {
                int ci=(lbColors.SelectedIndex>=0?lbColors.SelectedIndex+i:i)%colorValues.Length;
                int curve=(lbCurves.SelectedIndex>=0?lbCurves.SelectedIndex+i:i)%curveNames.Length;
                Result.Add(new GraphSettings{
                    CurveType=curve, LineColor=colorValues[ci],
                    XMin=(double)nudXMin.Value, XMax=(double)nudXMax.Value,
                    YMin=(double)nudYMin.Value, YMax=(double)nudYMax.Value
                });
            }
        }
    }
}