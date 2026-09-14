namespace Lab6_Variant6.Classes
{
    public class Student : PersonBase
    {
        public string Specialty { get; set; } = "";
        public int Course { get; set; }

        public Student() { }
        public Student(string fn, string ln, string g, int by, string spec, int course)
        {
            FirstName = fn; LastName = ln; Gender = g; BirthYear = by;
            Specialty = spec; Course = course;
        }

        public override string GetRole() => $"Студ. | {Specialty} | курс {Course}";
        public override object Clone() =>
            new Student(FirstName, LastName, Gender, BirthYear, Specialty, Course);
    }
}