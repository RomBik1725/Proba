using System;

namespace Lab3_Variant6
{
    public class Point3D
    {
        private double x = 0.0;
        private double y = 0.0;
        private double z = 0.0;

        public Point3D() : this(0, 0, 0) { }
        public Point3D(double x, double y) : this(x, y, 0) { }
        public Point3D(double x, double y, double z) { X = x; Y = y; Z = z; }

        public double X
        {
            get { return x; }
            set
            {
                if (double.IsNaN(value) || double.IsInfinity(value))
                    throw new ArgumentException("X должно быть действительным числом");
                x = value;
            }
        }
        public double Y
        {
            get { return y; }
            set
            {
                if (double.IsNaN(value) || double.IsInfinity(value))
                    throw new ArgumentException("Y должно быть действительным числом");
                y = value;
            }
        }
        public double Z
        {
            get { return z; }
            set { z = double.IsNaN(value) ? 0.0 : value; }
        }

        public double DistanceToOrigin() => Math.Sqrt(x * x + y * y + z * z);
        public override string ToString() => $"({x:F4}; {y:F4}; {z:F4})";
        public string GetInfo() => $"Координаты: {ToString()}\nРасстояние до O: {DistanceToOrigin():F4}";
    }
}