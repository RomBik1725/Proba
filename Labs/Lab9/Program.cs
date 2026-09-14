using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab9_Variant6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("=== Лабораторная работа №9. Вариант 6 ===");
            Console.WriteLine("Коллекции. LINQ.");
            Console.WriteLine();

            // Заполнение словаря
            Dictionary<string, Car> cars = new Dictionary<string, Car>();
            cars["A001"] = new Car("Toyota", "Camry",  2020, 210, "Седан");
            cars["A002"] = new Car("BMW",    "X5",     2021, 250, "Внедорожник");
            cars["A003"] = new Car("Lada",   "Vesta",  2019, 180, "Седан");
            cars["A004"] = new Car("Ford",   "Focus",  2018, 200, "Хетчбек");
            cars["A005"] = new Car("Toyota", "RAV4",   2022, 220, "Внедорожник");
            cars["A006"] = new Car("Kia",    "Rio",    2020, 185, "Седан");

            // Вывод всего словаря
            Console.WriteLine("--- Весь словарь ---");
            foreach (KeyValuePair<string, Car> pair in cars)
            {
                Console.Write("[" + pair.Key + "] ");
                pair.Value.Print();
            }
            Console.WriteLine();

            // LINQ: фильтр — только Седаны
            Console.WriteLine("--- LINQ: только Седаны ---");
            var sedans = from car in cars.Values
                         where car.BodyType == "Седан"
                         select car;
            foreach (Car c in sedans) c.Print();
            Console.WriteLine();

            // LINQ: сортировка по скорости убывание
            Console.WriteLine("--- LINQ: сортировка по скорости (убывание) ---");
            var bySpeed = cars.Values.OrderByDescending(c => c.MaxSpeed);
            foreach (Car c in bySpeed) c.Print();
            Console.WriteLine();

            // LINQ: год > 2019 И скорость > 200
            Console.WriteLine("--- LINQ: год > 2019 И скорость > 200 ---");
            var fast = from car in cars.Values
                       where car.Year > 2019 && car.MaxSpeed > 200
                       select car;
            foreach (Car c in fast) c.Print();
            Console.WriteLine();

            // LINQ: группировка по типу кузова
            Console.WriteLine("--- LINQ: группировка по типу кузова ---");
            var groups = cars.Values.GroupBy(c => c.BodyType);
            foreach (var group in groups)
            {
                Console.WriteLine("  " + group.Key + ":");
                foreach (Car c in group)
                    Console.WriteLine("    " + c.Brand + " " + c.Model);
            }
            Console.WriteLine();

            // LINQ: средняя скорость по марке
            Console.WriteLine("--- LINQ: средняя скорость по марке ---");
            var avgSpeed = cars.Values
                               .GroupBy(c => c.Brand)
                               .Select(g => new { Brand = g.Key, Avg = g.Average(c => c.MaxSpeed) });
            foreach (var a in avgSpeed)
                Console.WriteLine("  " + a.Brand + " — " + a.Avg + " км/ч");
            Console.WriteLine();

            Console.WriteLine("Для выхода нажмите любую клавишу...");
            Console.ReadKey();
        }
    }
}
