using System;

namespace Lab4_Variant6
{
    // Класс «Точка в 3D» — перенесён из ЛР №2, дополнен:
    //   virtual у свойств и Print() — для переопределения в наследнике
    //   операторы +, -, ==, !=
    class Point3D
    {
        // Закрытые поля
        private double x;
        private double y;
        private double z;
        private string name;

        // Цепочка конструкторов (как в ЛР №2)
        public Point3D() : this(0.0, 0.0, 0.0) { }

        public Point3D(double x, double y, double z) : this(x, y, z, "Точка") { }

        public Point3D(double x, double y, double z, string name)
        {
            X = x;
            Y = y;
            Z = z;
            Name = name;
        }

        // Свойства — virtual, чтобы наследник мог переопределить
        public virtual double X
        {
            get { return x; }
            set
            {
                if (!double.IsFinite(value))
                    throw new ArgumentException("X должно быть конечным числом");
                x = value;
            }
        }

        public virtual double Y
        {
            get { return y; }
            set
            {
                if (!double.IsFinite(value))
                    throw new ArgumentException("Y должно быть конечным числом");
                y = value;
            }
        }

        public virtual double Z
        {
            get { return z; }
            set
            {
                if (!double.IsFinite(value))
                    throw new ArgumentException("Z должно быть конечным числом");
                z = value;
            }
        }

        public string Name
        {
            get { return name; }
            set { name = (value == null) ? "Неизвестно" : value; }
        }

        // Расстояние до начала координат
        public double DistanceToOrigin()
        {
            return Math.Sqrt(x * x + y * y + z * z);
        }

        // virtual — наследник переопределяет для добавления своих полей
        public virtual void Print()
        {
            Console.WriteLine("  Имя       : " + name);
            Console.WriteLine("  Координаты: (" + x + "; " + y + "; " + z + ")");
            Console.WriteLine("  Расстояние: " + DistanceToOrigin());
        }

        // ── Перегрузка операторов ────────────────────────────────────────────────
        public static Point3D operator +(Point3D a, Point3D b)
        {
            return new Point3D(a.x + b.x, a.y + b.y, a.z + b.z);
        }

        public static Point3D operator -(Point3D a, Point3D b)
        {
            return new Point3D(a.x - b.x, a.y - b.y, a.z - b.z);
        }

        public static bool operator ==(Point3D a, Point3D b)
        {
            if (object.ReferenceEquals(a, null) && object.ReferenceEquals(b, null)) return true;
            if (object.ReferenceEquals(a, null) || object.ReferenceEquals(b, null)) return false;
            return a.x == b.x && a.y == b.y && a.z == b.z;
        }

        public static bool operator !=(Point3D a, Point3D b)
        {
            return !(a == b);
        }

        public override bool Equals(object obj)
        {
            if (obj is Point3D p)
                return this == p;
            return false;
        }

        public override int GetHashCode()
        {
            return (x, y, z).GetHashCode();
        }

        public override string ToString()
        {
            return "(" + x + "; " + y + "; " + z + ")";
        }
    }
}
