using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Lab10_Variant6.Forms
{
    public partial class MainForm : Form
    {
        private string dataFile = "points3d.dat";
        public MainForm() { InitializeComponent(); }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            int n = (int)nudCount.Value;
            var rnd = new Random();
            using (var bw = new BinaryWriter(File.Open(dataFile, FileMode.Create)))
            {
                bw.Write(n);
                for (int i = 0; i < n; i++)
                { bw.Write((rnd.NextDouble()-0.5)*20); bw.Write((rnd.NextDouble()-0.5)*20); bw.Write((rnd.NextDouble()-0.5)*20); }
            }
            var sb = new StringBuilder();
            sb.AppendLine($"Файл '{dataFile}' создан. Точек: {n}");
            sb.AppendLine();
            using (var br = new BinaryReader(File.Open(dataFile, FileMode.Open)))
            { int cnt=br.ReadInt32(); for(int i=0;i<cnt;i++){double x=br.ReadDouble(),y=br.ReadDouble(),z=br.ReadDouble(); sb.AppendLine($"  P{i+1}: ({x:F3}; {y:F3}; {z:F3})");} }
            rtbOutput.Text=sb.ToString(); lblStatus.Text=$"Файл сгенерирован: {n} точек";
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            if (!File.Exists(dataFile)){MessageBox.Show("Сначала сгенерируйте файл");return;}
            double cx=(double)nudCX.Value, cy=(double)nudCY.Value, cz=(double)nudCZ.Value, r=(double)nudRadius.Value;
            var sb=new StringBuilder();
            sb.AppendLine($"Сфера: центр=({cx};{cy};{cz}), R={r}"); sb.AppendLine();
            int inside=0, total=0;
            using (var br=new BinaryReader(File.Open(dataFile,FileMode.Open)))
            { total=br.ReadInt32(); for(int i=0;i<total;i++){double x=br.ReadDouble(),y=br.ReadDouble(),z=br.ReadDouble(); double dx=x-cx,dy=y-cy,dz=z-cz; double dist=Math.Sqrt(dx*dx+dy*dy+dz*dz); if(dist<=r){inside++; sb.AppendLine($"  [IN] P{i+1}: ({x:F3};{y:F3};{z:F3}) dist={dist:F4}");}} }
            sb.AppendLine(); sb.AppendLine($"Итог: {inside} из {total} точек внутри сферы");
            if(inside==0) sb.AppendLine("Точек внутри сферы не найдено");
            rtbOutput.Text=sb.ToString(); lblStatus.Text=$"Внутри сферы: {inside} из {total}";
        }
    }
}