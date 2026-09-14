using System;
using System.IO;

namespace Lab10_Variant6
{
    // Класс Point3D из ЛР №2 + методы записи/чтения бинарных файлов
    class Point3D
    {
        private double x;
        private double y;
        private double z;

        public Point3D(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public Point3D() : this(0, 0, 0) { }

        public double X
        {
            get { return x; }
            set { x = value; }
        }

        public double Y
        {
            get { return y; }
            set { y = value; }
        }

        public double Z
        {
            get { return z; }
            set { z = value; }
        }

        // Расстояние до начала координат
        public double DistanceTo(Point3D other)
        {
            double dx = x - other.x;
            double dy = y - other.y;
            double dz = z - other.z;
            return Math.Sqrt(dx * dx + dy * dy + dz * dz);
        }

        // Запись точки в бинарный поток
        public void WriteToStream(BinaryWriter bw)
        {
            bw.Write(x);
            bw.Write(y);
            bw.Write(z);
        }

        // Чтение точки из бинарного потока
        public static Point3D ReadFromStream(BinaryReader br)
        {
            double rx = br.ReadDouble();
            double ry = br.ReadDouble();
            double rz = br.ReadDouble();
            return new Point3D(rx, ry, rz);
        }

        public override string ToString()
        {
            return "(" + x + "; " + y + "; " + z + ")";
        }
    }
}
