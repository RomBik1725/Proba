using System;

namespace Lab2_Variant6
{
    // UML:
    // +----------------------------------+
    // |            Point3D               |
    // +----------------------------------+
    // | - x : double = 0.0              |
    // | - y : double = 0.0              |
    // | - z : double = 0.0              |
    // | - name : string = "Неизвестно"  |
    // +----------------------------------+
    // | + Point3D()                      |
    // | + Point3D(x, y, z)               |
    // | + Point3D(x, y, z, name)         |
    // | + X : double                     |
    // | + Y : double                     |
    // | + Z : double                     |
    // | + Name : string                  |
    // | + DistanceToOrigin() : double    |
    // | + Print() : void                 |
    // +----------------------------------+

    class Point3D
    {
        // Закрытые поля с инициализацией значением по умолчанию (способ 1)
        private double x = 0.0;
        private double y = 0.0;
        private double z = 0.0;
        private string name = "Неизвестно"; // значение по умолчанию в поле (способ 1)

        // ── Конструкторы ──────────────────────────────────────────────

        // Конструктор по умолчанию — вызывает следующий через this (цепочка)
        public Point3D() : this(0.0, 0.0, 0.0) { }

        // Конструктор с тремя параметрами — вызывает основной
        public Point3D(double x, double y, double z)
            : this(x, y, z, "Точка") { }

        // Основной конструктор (с валидацией)
        public Point3D(double x, double y, double z, string name = "Точка")
        {
            X = x;    // используем свойства с валидацией
            Y = y;
            Z = z;
            Name = name;
        }

        // ── Свойства (без автоматических, с валидацией) ───────────────

        public double X
        {
            get { return x; }
            set
            {
                if (!double.IsFinite(value))
                    throw new ArgumentException("X должно быть конечным числом");
                x = value;
            }
        }

        public double Y
        {
            get { return y; }
            set
            {
                if (!double.IsFinite(value))
                    throw new ArgumentException("Y должно быть конечным числом");
                y = value;
            }
        }

        public double Z
        {
            get { return z; }
            set
            {
                if (!double.IsFinite(value))
                    throw new ArgumentException("Z должно быть конечным числом");
                z = value;
            }
        }

        // Свойство с дефолтным значением по умолчанию через ??
        // (значение по умолчанию в свойстве — способ 2)
        public string Name
        {
            get { return name; }
            set { name = value ?? "Неизвестно"; } // null → «Неизвестно»
        }

        // ── Методы ───────────────────────────────────────────────────

        public double DistanceToOrigin()
        {
            return Math.Sqrt(x * x + y * y + z * z);
        }

        public void Print()
        {
            Console.WriteLine($"  Имя : {name}");
            Console.WriteLine($"  Координаты: ({x}; {y}; {z})");
            Console.WriteLine($"  Расстояние до O: {DistanceToOrigin():F4}");
        }
    }
}