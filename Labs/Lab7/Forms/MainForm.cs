using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Lab7_Variant6.Models;

namespace Lab7_Variant6.Forms
{
    public partial class MainForm : Form
    {
        private List<GraphSettings> graphSettings = new List<GraphSettings>();
        public MainForm() { InitializeComponent(); }

        private void miSelectLines_Click(object sender, EventArgs e)
        { using var dlg=new SettingsDialog(); if(dlg.ShowDialog()==DialogResult.OK){graphSettings=dlg.Result; pnlDraw.Invalidate();} }

        private void miPlot_Click(object sender, EventArgs e)
        { if(graphSettings.Count==0){MessageBox.Show("Сначала выберите линии");return;} pnlDraw.Invalidate(); }

        private void miClear_Click(object sender, EventArgs e)
        { graphSettings.Clear(); pnlDraw.Invalidate(); }

        private void miInfo_Click(object sender, EventArgs e)
        {
            string[] types={"y=x","y=x^2","y=1/x","Окружность","Роза r=cos(3t)"};
            string info=graphSettings.Count>0
                ?string.Join("\n",graphSettings.ConvertAll(g=>$"  {types[g.CurveType]} | {g.LineColor.Name}"))
                :"Нет графиков";
            MessageBox.Show("Графики:\n"+info,"Инфо");
        }

        private void miExit_Click(object sender, EventArgs e) => Application.Exit();

        private void pnlDraw_Paint(object sender, PaintEventArgs e)
        {
            var g=e.Graphics; g.Clear(Color.White);
            if(graphSettings.Count==0) return;
            int W=pnlDraw.Width,H=pnlDraw.Height,cx=W/2,cy=H/2;
            var gs=graphSettings[0];
            double sx=W/(gs.XMax-gs.XMin),sy=H/(gs.YMax-gs.YMin);
            using(var axisPen=new Pen(Color.Gray,1))
            { g.DrawLine(axisPen,0,cy,W,cy); g.DrawLine(axisPen,cx,0,cx,H); }
            using var fnt=new Font("Arial",8); using var br=new SolidBrush(Color.Gray);
            g.DrawString("X",fnt,br,W-15,cy+4); g.DrawString("Y",fnt,br,cx+4,4);
            foreach(var s in graphSettings)
            { using var pen=new Pen(s.LineColor,s.LineWidth); DrawCurve(g,pen,s,W,H,cx,cy,sx,sy); }
        }

        private void DrawCurve(Graphics g,Pen pen,GraphSettings s,int W,int H,int cx,int cy,double sx,double sy)
        {
            int steps=1200;
            var pts=new List<System.Drawing.Point>();
            if(s.CurveType==3)
            {
                double r=Math.Min(Math.Abs(s.XMax),Math.Abs(s.YMax))*0.5;
                for(int i=0;i<=steps;i++){double t=2*Math.PI*i/steps; pts.Add(WS(r*Math.Cos(t),r*Math.Sin(t),cx,cy,sx,sy));}
                if(pts.Count>=2) g.DrawLines(pen,pts.ToArray()); return;
            }
            if(s.CurveType==4)
            {
                double a=Math.Min(Math.Abs(s.XMax),Math.Abs(s.YMax))*0.7;
                for(int i=0;i<=steps;i++){double t=2*Math.PI*i/steps; double r=a*Math.Cos(3*t); pts.Add(WS(r*Math.Cos(t),r*Math.Sin(t),cx,cy,sx,sy));}
                if(pts.Count>=2) g.DrawLines(pen,pts.ToArray()); return;
            }
            var seg=new List<System.Drawing.Point>();
            for(int i=0;i<=steps;i++)
            {
                double x=s.XMin+(s.XMax-s.XMin)*i/steps; double y;
                if(s.CurveType==0) y=x;
                else if(s.CurveType==1) y=x*x;
                else{if(Math.Abs(x)<1e-4){if(seg.Count>=2)g.DrawLines(pen,seg.ToArray());seg.Clear();continue;} y=1.0/x;}
                if(y<s.YMin*2||y>s.YMax*2){if(seg.Count>=2)g.DrawLines(pen,seg.ToArray());seg.Clear();continue;}
                var pt=WS(x,y,cx,cy,sx,sy);
                if(seg.Count>0&&Math.Abs(pt.Y-seg[seg.Count-1].Y)>H){if(seg.Count>=2)g.DrawLines(pen,seg.ToArray());seg.Clear();}
                seg.Add(pt);
            }
            if(seg.Count>=2) g.DrawLines(pen,seg.ToArray());
        }

        private System.Drawing.Point WS(double x,double y,int cx,int cy,double sx,double sy)
            => new System.Drawing.Point(cx+(int)(x*sx),cy-(int)(y*sy));
    }
}