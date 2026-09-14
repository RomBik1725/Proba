using System;

namespace Lab5_Variant6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("=== Лабораторная работа №5. Вариант 6 ===");
            Console.WriteLine("Абстрактные классы. Виртуальные методы. Полиморфизм.");
            Console.WriteLine();

            Teacher     t  = new Teacher    ("Иван",   "Иванов",  1975, "М", "Математика", 20);
            Student     s  = new Student    ("Мария",  "Петрова", 2003, "Ж", "МГУ", 2);
            Schoolchild sc = new Schoolchild("Алексей","Сидоров", 2010, "М", "Школа №5", 9);

            Console.WriteLine("--- Учитель ---");
            t.Print();
            Console.WriteLine();

            Console.WriteLine("--- Студент ---");
            s.Print();
            Console.WriteLine();

            Console.WriteLine("--- Школьник ---");
            sc.Print();
            Console.WriteLine();

            // Полиморфизм через массив Person[]
            Console.WriteLine("--- Полиморфизм (массив Person[]) ---");
            Person[] people = new Person[] { t, s, sc };
            for (int i = 0; i < people.Length; i++)
            {
                Console.WriteLine(people[i].GetRole());
            }
            Console.WriteLine();

            // Пенсионеры
            Console.WriteLine("--- Пенсионеры ---");
            for (int i = 0; i < people.Length; i++)
            {
                Console.WriteLine(people[i].LastName + ": " +
                    (people[i].IsPensioner() ? "Пенсионер" : "Не пенсионер"));
            }
            Console.WriteLine();

            Console.WriteLine("Для выхода нажмите любую клавишу...");
            Console.ReadKey();
        }
    }
}
