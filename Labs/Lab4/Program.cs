using System;

namespace Lab4_Variant6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("=== Лабораторная работа №4. Вариант 6 ===");
            Console.WriteLine("Наследование. Перегрузка операторов.");
            Console.WriteLine();

            // ── Объекты базового класса Point3D ──────────────────────────────────────
            Console.WriteLine("--- Объекты Point3D ---");
            Point3D p1 = new Point3D(1, 2, 3, "Точка А");
            Point3D p2 = new Point3D(4, 5, 6, "Точка Б");
            Console.WriteLine("p1:");
            p1.Print();
            Console.WriteLine();
            Console.WriteLine("p2:");
            p2.Print();
            Console.WriteLine();

            // ── Перегруженные операторы ────────────────────────────────────────────────
            Console.WriteLine("--- Перегруженные операторы Point3D ---");
            Point3D sum = p1 + p2;
            Console.WriteLine("p1 + p2 = " + sum.ToString());
            Point3D diff = p2 - p1;
            Console.WriteLine("p2 - p1 = " + diff.ToString());
            Console.WriteLine("p1 == p2: " + (p1 == p2));
            Console.WriteLine("p1 != p2: " + (p1 != p2));
            Console.WriteLine();

            // ── Объекты наследника ColoredPoint3D ──────────────────────────────────────
            Console.WriteLine("--- Объекты ColoredPoint3D ---");
            ColoredPoint3D cp1 = new ColoredPoint3D(0, 0, 0, "Красный", 5);
            ColoredPoint3D cp2 = new ColoredPoint3D(1, 1, 1, "Синий", 3);
            Console.WriteLine("cp1:");
            cp1.Print();
            Console.WriteLine();
            Console.WriteLine("cp2:");
            cp2.Print();
            Console.WriteLine();

            // ── Сложение ColoredPoint3D ────────────────────────────────────────────────
            Console.WriteLine("--- Сложение ColoredPoint3D ---");
            ColoredPoint3D cpSum = cp1 + cp2;
            Console.WriteLine("cp1 + cp2 = " + cpSum.ToString() + " цвет: " + cpSum.Color);
            Console.WriteLine();

            // ── Полиморфизм: массив Point3D[] хранит объекты обоих типов ─
            Console.WriteLine("--- Полиморфизм (массив Point3D[]) ---");
            Point3D[] points = new Point3D[] { p1, p2, cp1, cp2 };
            for (int i = 0; i < points.Length; i++)
            {
                Console.WriteLine("Элемент " + i + ":");
                points[i].Print();
                Console.WriteLine();
            }

            Console.WriteLine("Для выхода нажмите любую клавишу...");
            Console.ReadKey();
        }
    }
}
