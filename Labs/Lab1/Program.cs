using System;

namespace Lab1_Variant6
{
    // Класс, описывающий точку в трехмерном пространстве
    class Point3D
    {
        // Закрытые поля класса (инкапсуляция)
        private double x;
        private double y;
        private double z;

        // Конструктор по умолчанию
        public Point3D()
        {
            x = 0;
            y = 0;
            z = 0;
        }

        // Конструктор с параметрами
        public Point3D(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        // Свойства для доступа к полям
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

        // Метод ввода полей с клавиатуры
        public void Input()
        {
            Console.Write("Введите координату X: ");
            x = double.Parse(Console.ReadLine());

            Console.Write("Введите координату Y: ");
            y = double.Parse(Console.ReadLine());

            Console.Write("Введите координату Z: ");
            z = double.Parse(Console.ReadLine());
        }

        // Метод вычисления расстояния от точки до начала координат
        public double DistanceToOrigin()
        {
            return Math.Sqrt(x * x + y * y + z * z);
        }

        // Метод вывода значений полей на экран
        public void Print()
        {
            Console.WriteLine("Координаты точки: (" + x + "; " + y + "; " + z + ")");
        }
    }

    // Главный класс программы
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Лабораторная работа №1. Вариант 6 ===");
            Console.WriteLine("Класс \"Точка в трехмерном пространстве\"");
            Console.WriteLine();

            // Объект 1: создан конструктором по умолчанию, поля вводятся с клавиатуры
            Console.WriteLine("--- Объект 1 (ввод с клавиатуры) ---");
            Point3D p1 = new Point3D();
            p1.Input();
            Console.WriteLine();
            Console.WriteLine("Поля объекта 1:");
            p1.Print();
            Console.WriteLine("Расстояние до начала координат: " + p1.DistanceToOrigin());
            Console.WriteLine();

            // Объект 2: создан конструктором с параметрами
            Console.WriteLine("--- Объект 2 (создан конструктором) ---");
            Point3D p2 = new Point3D(3, 4, 12);
            Console.WriteLine("Поля объекта 2:");
            p2.Print();
            Console.WriteLine("Расстояние до начала координат: " + p2.DistanceToOrigin());
            Console.WriteLine();

            // Объект 3: создан конструктором с параметрами
            Console.WriteLine("--- Объект 3 (создан конструктором) ---");
            Point3D p3 = new Point3D(-1.5, 2.5, -3.5);
            Console.WriteLine("Поля объекта 3:");
            p3.Print();
            Console.WriteLine("Расстояние до начала координат: " + p3.DistanceToOrigin());
            Console.WriteLine();

            // Демонстрация работы свойств
            Console.WriteLine("--- Изменение координат через свойства ---");
            p2.X = 1;
            p2.Y = 2;
            p2.Z = 2;
            Console.WriteLine("Новые поля объекта 2:");
            p2.Print();
            Console.WriteLine("Расстояние до начала координат: " + p2.DistanceToOrigin());
            Console.WriteLine();

            Console.WriteLine("Для выхода нажмите любую клавишу...");
            Console.ReadKey();
        }
    }
}