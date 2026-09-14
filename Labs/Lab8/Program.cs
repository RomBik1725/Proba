using System;
using System.Collections.Generic;

namespace Lab8_Variant6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("=== Лабораторная работа №8. Вариант 6 ===");
            Console.WriteLine("Делегаты. События. Лямбда-выражения.");
            Console.WriteLine();

            // Подписка на событие: анонимный метод
            Console.WriteLine("--- Подписка на событие OnPensionerDetected ---");
            Person.OnPensionerDetected += delegate(Person p)
            {
                Console.WriteLine("  [СОБЫТИЕ] Пенсионер: " + p.LastName + " " + p.FirstName);
            };

            // Вторая подписка — лямбда-выражение
            Person.OnPensionerDetected += p =>
                Console.WriteLine("  [ЛЯМБДА]  Возраст: " + p.Age() + " | " + p.GetRole());

            Teacher t1 = new Teacher("Иван", "Иванов", 1950, "М", "Математика", 40);
            Teacher t2 = new Teacher("Анна", "Кузнецова", 1985, "Ж", "Физика", 15);
            Teacher t3 = new Teacher("Пётр", "Смирнов", 1960, "М", "История", 30);
            Student s1 = new Student("Мария", "Петрова", 2003, "Ж", "МГУ", 2);
            Schoolchild sc = new Schoolchild("Алексей", "Сидоров", 2010, "М", "Школа №5", 9);

            // Проверка IsPensioner — событие сработает автоматически
            Console.WriteLine("Проверяем пенсионеров:");
            Person[] people = new Person[] { t1, t2, t3, s1, sc };
            for (int i = 0; i < people.Length; i++)
            {
                bool isPensioner = people[i].IsPensioner();
                if (!isPensioner)
                    Console.WriteLine("  " + people[i].LastName + ": не пенсионер");
            }
            Console.WriteLine();

            // Делегат как переменная
            Console.WriteLine("--- Делегат как переменная ---");
            PensionerDetectedHandler myHandler = p =>
                Console.WriteLine("  Мой обработчик: " + p.GetRole());
            myHandler(t1);
            Console.WriteLine();

            // Лямбда для сортировки
            Console.WriteLine("--- Лямбда-компаратор: учителя по стажу ---");
            Teacher[] teachers = new Teacher[] { t1, t2, t3 };
            Array.Sort(teachers, (a, b) => b.Experience.CompareTo(a.Experience));
            for (int i = 0; i < teachers.Length; i++)
                Console.WriteLine("  " + teachers[i].LastName + " — стаж " + teachers[i].Experience + " л.");
            Console.WriteLine();

            // List<Person> + FindAll + лямбда
            Console.WriteLine("--- List.FindAll: только учителя ---");
            List<Person> list = new List<Person>();
            list.Add(t1); list.Add(t2); list.Add(s1); list.Add(sc); list.Add(t3);
            List<Person> onlyTeachers = list.FindAll(p => p is Teacher);
            for (int i = 0; i < onlyTeachers.Count; i++)
                Console.WriteLine("  " + onlyTeachers[i].GetRole());
            Console.WriteLine();

            Console.WriteLine("Для выхода нажмите любую клавишу...");
            Console.ReadKey();
        }
    }
}
