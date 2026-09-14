using System;

namespace Lab6_Variant6
{
    // Абстрактный класс «Человек» — расширен: реализует IPerson и ICloneable
    abstract class Person : IPerson, ICloneable
    {
        private string firstName;
        private string lastName;
        private int birthYear;
        private string gender;

        public Person(string firstName, string lastName, int birthYear, string gender)
        {
            FirstName = firstName;
            LastName  = lastName;
            BirthYear = birthYear;
            Gender    = gender;
        }

        public string FirstName
        {
            get { return firstName; }
            set { firstName = (value == null) ? "" : value; }
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = (value == null) ? "" : value; }
        }

        public int BirthYear
        {
            get { return birthYear; }
            set { birthYear = value; }
        }

        public string Gender
        {
            get { return gender; }
            set { gender = (value == "Ж") ? "Ж" : "М"; }
        }

        public virtual int Age()
        {
            return DateTime.Now.Year - birthYear;
        }

        public bool IsPensioner()
        {
            if (gender == "М")
                return Age() >= 65;
            else
                return Age() >= 60;
        }

        public abstract string GetRole();

        // ICloneable — каждый наследник реализует сам
        public abstract object Clone();

        public virtual void Print()
        {
            Console.WriteLine("  ФИО      : " + lastName + " " + firstName);
            Console.WriteLine("  Пол      : " + gender);
            Console.WriteLine("  Год рожд.: " + birthYear);
            Console.WriteLine("  Возраст  : " + Age());
            Console.WriteLine("  Роль     : " + GetRole());
            Console.WriteLine("  Пенсионер: " + (IsPensioner() ? "Да" : "Нет"));
        }
    }
}
