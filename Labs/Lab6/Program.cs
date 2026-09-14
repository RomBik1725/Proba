using System;

namespace Lab6_Variant6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("=== Лабораторная работа №6. Вариант 6 ===");
            Console.WriteLine("Интерфейсы: IPerson, ICloneable, IComparable.");
            Console.WriteLine();

            Teacher t1 = new Teacher("Иван",  "Иванов",    1975, "М", "Математика", 20);
            Teacher t2 = new Teacher("Анна",  "Кузнецова", 1980, "Ж", "Физика",      15);
            Teacher t3 = new Teacher("Пётр",  "Смирнов",   1965, "М", "История",     30);
            Student s1 = new Student("Мария", "Петрова",   2003, "Ж", "МГУ",           2);
            Student s2 = new Student("Дмитрий","Волков",    2001, "М", "СПбГУ",         4);
            Schoolchild sc1 = new Schoolchild("Алексей","Сидоров",  2010, "М", "Школа №5", 9);
            Schoolchild sc2 = new Schoolchild("Лена",   "Новикова",2012, "Ж", "Школа №3", 7);

            // ICloneable
            Console.WriteLine("--- ICloneable: клонирование объекта ---");
            Teacher t1copy = (Teacher)t1.Clone();
            t1copy.Experience = 99;
            Console.WriteLine("Оригинал: " + t1.GetRole());
            Console.WriteLine("Клон    : " + t1copy.GetRole());
            Console.WriteLine();

            // IComparable: сортировка учителей по стажу
            Console.WriteLine("--- Учителя отсортированы по стажу (убывание) ---");
            Teacher[] teachers = new Teacher[] { t1, t2, t3 };
            Array.Sort(teachers);
            for (int i = 0; i < teachers.Length; i++)
                Console.WriteLine(teachers[i].LastName + " — стаж " + teachers[i].Experience + " л.");
            Console.WriteLine();

            // IComparable: сортировка студентов по курсу
            Console.WriteLine("--- Студенты отсортированы по курсу (возрастание) ---");
            Student[] students = new Student[] { s1, s2 };
            Array.Sort(students);
            for (int i = 0; i < students.Length; i++)
                Console.WriteLine(students[i].LastName + " — курс " + students[i].Course);
            Console.WriteLine();

            // IComparable: школьники по классу
            Console.WriteLine("--- Школьники отсортированы по классу (возрастание) ---");
            Schoolchild[] schoolchildren = new Schoolchild[] { sc1, sc2 };
            Array.Sort(schoolchildren);
            for (int i = 0; i < schoolchildren.Length; i++)
                Console.WriteLine(schoolchildren[i].LastName + " — класс " + schoolchildren[i].Grade);
            Console.WriteLine();

            // IPerson: обращение через интерфейс
            Console.WriteLine("--- IPerson: доступ через интерфейс ---");
            IPerson[] persons = new IPerson[] { t1, s1, sc1, t2 };
            for (int i = 0; i < persons.Length; i++)
                Console.WriteLine(persons[i].LastName + " | возраст " + persons[i].Age() + " | " + persons[i].GetRole());
            Console.WriteLine();

            Console.WriteLine("Для выхода нажмите любую клавишу...");
            Console.ReadKey();
        }
    }
}
