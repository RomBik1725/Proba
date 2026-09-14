using System;

namespace Lab6_Variant6.Classes
{
    public abstract class PersonBase : IPerson
    {
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public int BirthYear { get; set; }
        public string Gender { get; set; } = "М";
        public int Age => DateTime.Now.Year - BirthYear;
        public bool IsPensioner() =>
            (Gender == "М" && Age >= 65) || (Gender == "Ж" && Age >= 60);
        public abstract string GetRole();
        public abstract object Clone();
        public int CompareTo(IPerson? other) =>
            other == null ? 1 : string.Compare(LastName, other.LastName, StringComparison.Ordinal);
        public override string ToString() =>
            $"{LastName} {FirstName} | {Gender} | {BirthYear} | {Age} л. | {GetRole()}";
    }
}