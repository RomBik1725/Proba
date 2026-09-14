using System;
using System.Windows.Forms;

namespace Lab8_Variant6.Classes
{
    public delegate void TeacherDelegate(Teacher t);

    public class Teacher
    {
        public string FirstName { get; set; } = "";
        public string LastName  { get; set; } = "";
        public string Gender    { get; set; } = "М";
        public int    BirthYear { get; set; }
        public int    Experience{ get; set; }
        public string Position  { get; set; } = "";

        public int Age => DateTime.Now.Year - BirthYear;
        public bool IsPensioner() =>
            (Gender == "М" && Age >= 65) || (Gender == "Ж" && Age >= 60);

        public event TeacherDelegate? OnPensionerDetected;

        public Teacher(string fn,string ln,string g,int by,int exp,string pos)
        { FirstName=fn; LastName=ln; Gender=g; BirthYear=by; Experience=exp; Position=pos; }

        public void CheckPensioner()
        { if(IsPensioner()) OnPensionerDetected?.Invoke(this); }

        public static Func<Teacher,bool> GetExperienceFilter(int minExp) => t => t.Experience >= minExp;

        public override string ToString() =>
            $"{LastName} {FirstName} | {Gender} | {BirthYear} | {Age} л. | {Position} | {Experience} л. ст.";
    }
}