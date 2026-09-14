using System.Drawing;

namespace Lab7_Variant6.Models
{
    public class GraphSettings
    {
        public int CurveType { get; set; } = 0;
        public Color LineColor { get; set; } = Color.Blue;
        public float LineWidth { get; set; } = 2f;
        public double XMin { get; set; } = -10;
        public double XMax { get; set; } = 10;
        public double YMin { get; set; } = -10;
        public double YMax { get; set; } = 10;
    }
}