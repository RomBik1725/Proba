using System;

namespace Lab5_Variant6.Classes
{
    public abstract class Person
    {
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public int BirthYear { get; set; }
        public string Gender { get; set; } = "М";

        public virtual int Age() => DateTime.Now.Year - BirthYear;
        public bool IsPensioner() =>
            (Gender == "М" && Age() >= 65) || (Gender == "Ж" && Age() >= 60);

        public abstract string GetRole();
        public override string ToString() =>
            $"{LastName} {FirstName} | {Gender} | {BirthYear} | {Age()} л. | {GetRole()}";
    }
}