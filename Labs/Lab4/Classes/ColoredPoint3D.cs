using System;
using System.Drawing;

namespace Lab4_Variant6.Classes
{
    public class ColoredPoint3D : Point3D
    {
        public Color Color { get; set; } = Color.Black;
        public int Size { get; set; } = 3;
        public ColoredPoint3D() { }
        public ColoredPoint3D(double x, double y, double z, Color color, int size = 3)
            : base(x, y, z) { Color = color; Size = size; }
        public override string GetInfo() =>
            $"ColoredPoint3D {ToString()}  | цв.: {Color.Name}  | р.: {DistanceToOrigin():F4}";
        public static ColoredPoint3D operator +(ColoredPoint3D a, ColoredPoint3D b)
            => new ColoredPoint3D(a.X + b.X, a.Y + b.Y, a.Z + b.Z, a.Color, a.Size);
    }
}