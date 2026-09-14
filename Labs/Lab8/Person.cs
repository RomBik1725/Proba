using System;

namespace Lab8_Variant6
{
    // Делегат — сигнатура обработчика события
    delegate void PensionerDetectedHandler(Person person);

    // Person из ЛР №6 — добавлено статическое событие OnPensionerDetected
    abstract class Person : IPerson, ICloneable
    {
        // Событие: срабатывает внутри IsPensioner(), если человек является пенсионером
        public static event PensionerDetectedHandler OnPensionerDetected;

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
            bool result;
            if (gender == "М")
                result = Age() >= 65;
            else
                result = Age() >= 60;

            // Вызываем событие, если человек — пенсионер и есть подписчики
            if (result && OnPensionerDetected != null)
                OnPensionerDetected(this);

            return result;
        }

        public abstract string GetRole();
        public abstract object Clone();

        public virtual void Print()
        {
            Console.WriteLine("  ФИО      : " + lastName + " " + firstName);
            Console.WriteLine("  Пол      : " + gender);
            Console.WriteLine("  Год рожд.: " + birthYear);
            Console.WriteLine("  Возраст  : " + Age());
            Console.WriteLine("  Роль     : " + GetRole());
        }
    }
}
