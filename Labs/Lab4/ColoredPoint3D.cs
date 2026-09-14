using System;

namespace Lab4_Variant6
{
    // Наследник Point3D — добавляет цвет и размер точки
    class ColoredPoint3D : Point3D
    {
        // Дополнительные поля
        private string color;
        private int size;

        // Конструктор по умолчанию
        public ColoredPoint3D() : base()
        {
            color = "Чёрный";
            size = 3;
        }

        // Конструктор с параметрами
        public ColoredPoint3D(double x, double y, double z, string color, int size)
            : base(x, y, z)
        {
            Color = color;
            Size = size;
        }

        // Свойства
        public string Color
        {
            get { return color; }
            set { color = (value == null) ? "Чёрный" : value; }
        }

        public int Size
        {
            get { return size; }
            set { size = (value < 1) ? 1 : value; }
        }

        // Переопределяем Print — вызываем базовый, добавляем цвет/размер
        public override void Print()
        {
            base.Print();
            Console.WriteLine("  Цвет      : " + color);
            Console.WriteLine("  Размер    : " + size);
        }

        // Перегрузка + для ColoredPoint3D (цвет берётся у левого операнда)
        public static ColoredPoint3D operator +(ColoredPoint3D a, ColoredPoint3D b)
        {
            return new ColoredPoint3D(a.X + b.X, a.Y + b.Y, a.Z + b.Z, a.Color, a.Size);
        }
    }
}
