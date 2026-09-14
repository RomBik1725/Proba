using System.Drawing;
using System.Windows.Forms;

namespace Lab7_Variant6.Forms
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        { if(disposing&&components!=null) components.Dispose(); base.Dispose(disposing); }
        private void InitializeComponent()
        {
            mainMenu=new MenuStrip();
            miSelectLines=new ToolStripMenuItem();
            miPlot=new ToolStripMenuItem();
            miClear=new ToolStripMenuItem();
            miInfo=new ToolStripMenuItem();
            miExit=new ToolStripMenuItem();
            pnlDraw=new Panel();
            mainMenu.SuspendLayout(); SuspendLayout();

            mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[]{miSelectLines,miPlot,miClear,miInfo,miExit});
            miSelectLines.Text="Выбор линий"; miSelectLines.Click+=miSelectLines_Click;
            miPlot.Text="Построить"; miPlot.Click+=miPlot_Click;
            miClear.Text="Очистить"; miClear.Click+=miClear_Click;
            miInfo.Text="Инфо"; miInfo.Click+=miInfo_Click;
            miExit.Text="Выход"; miExit.Click+=miExit_Click;

            pnlDraw.Dock=DockStyle.Fill; pnlDraw.BackColor=Color.White;
            pnlDraw.Paint+=pnlDraw_Paint;

            MainMenuStrip=mainMenu; ClientSize=new Size(800,600);
            Text="Лаб. №7. Графика. Вар. 6"; StartPosition=System.Windows.Forms.FormStartPosition.CenterScreen;
            Controls.AddRange(new System.Windows.Forms.Control[]{pnlDraw,mainMenu});
            mainMenu.ResumeLayout(false); mainMenu.PerformLayout();
            ResumeLayout(false); PerformLayout();
        }
        private MenuStrip mainMenu;
        private ToolStripMenuItem miSelectLines,miPlot,miClear,miInfo,miExit;
        private Panel pnlDraw;
    }
}