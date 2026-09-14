using System;

namespace Lab6_Variant6.Classes
{
    public interface IPerson : ICloneable, IComparable<IPerson>
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        int BirthYear { get; set; }
        string Gender { get; set; }
        int Age { get; }
        bool IsPensioner();
        string GetRole();
    }
}