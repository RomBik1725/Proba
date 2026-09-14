using System;

namespace Lab2_Variant6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("=== Лабораторная работа №2. Вариант 6 ===");
            Console.WriteLine("Конструкторы. Свойства. Валидация.");
            Console.WriteLine();

            // ── Способ 1: значение по умолчанию в поле класса ────────
            Console.WriteLine("--- Объект 1: конструктор по умолчанию (x=y=z=0) ---");
            Point3D p1 = new Point3D();
            p1.Print();
            Console.WriteLine();

            // ── Способ 2: значение по умолчанию через свойство ───────
            Console.WriteLine("--- Объект 2: конструктор Point3D(x,y,z) ---");
            Point3D p2 = new Point3D(3, 4, 12);
            p2.Print();
            Console.WriteLine();

            // ── Способ 3: значение по умолчанию в параметре конструктора
            Console.WriteLine("--- Объект 3: Point3D(x,y,z, name=\"Точка\") ---");
            Point3D p3 = new Point3D(-1.5, 2.5, -3.5);
            p3.Print();
            Console.WriteLine();

            // ── Способ 4: инициализатор объекта ──────────────────────
            Console.WriteLine("--- Объект 4: инициализатор объекта ---");
            Point3D p4 = new Point3D { X = 1, Y = 2, Z = 2, Name = "Особая точка" };
            p4.Print();
            Console.WriteLine();

            // ── Цепочка конструкторов (демонстрация) ─────────────────
            Console.WriteLine("--- Цепочка конструкторов this ---");
            Console.WriteLine("Point3D() → Point3D(0,0,0) → Point3D(0,0,0,\"Точка\")");
            Console.WriteLine();

            // ── Демонстрация валидации свойств ────────────────────────
            Console.WriteLine("--- Валидация: попытка присвоить NaN ---");
            try
            {
                p2.X = double.NaN;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"  Ошибка: {ex.Message}");
            }

            Console.WriteLine();
            Console.WriteLine("--- Валидация: имя = null → \"Неизвестно\" ---");
            p3.Name = null!;
            p3.Print();
            Console.WriteLine();

            Console.WriteLine("Для выхода нажмите любую клавишу...");
            Console.ReadKey();
        }
    }
}