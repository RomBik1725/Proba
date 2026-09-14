using System;

namespace Lab4_Variant6.Classes
{
    public class Point3D
    {
        private double x = 0, y = 0, z = 0;
        public Point3D() { }
        public Point3D(double x, double y, double z) { X = x; Y = y; Z = z; }
        public virtual double X { get { return x; } set { if (!double.IsFinite(value)) throw new ArgumentException("X"); x = value; } }
        public virtual double Y { get { return y; } set { if (!double.IsFinite(value)) throw new ArgumentException("Y"); y = value; } }
        public virtual double Z { get { return z; } set { if (!double.IsFinite(value)) throw new ArgumentException("Z"); z = value; } }
        public double DistanceToOrigin() => Math.Sqrt(x*x+y*y+z*z);
        public static Point3D operator +(Point3D a, Point3D b) => new Point3D(a.x+b.x,a.y+b.y,a.z+b.z);
        public static Point3D operator -(Point3D a, Point3D b) => new Point3D(a.x-b.x,a.y-b.y,a.z-b.z);
        public static bool operator ==(Point3D a, Point3D b) => a.x==b.x&&a.y==b.y&&a.z==b.z;
        public static bool operator !=(Point3D a, Point3D b) => !(a==b);
        public override bool Equals(object? obj) => obj is Point3D p && this==p;
        public override int GetHashCode() => HashCode.Combine(x,y,z);
        public override string ToString() => $"({x:F2}; {y:F2}; {z:F2})";
        public virtual string GetInfo() => $"Point3D {ToString()}  |р.: {DistanceToOrigin():F4}";
    }
}