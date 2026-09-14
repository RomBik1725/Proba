namespace Lab5_Variant6.Classes
{
    public class Student : Person
    {
        public string Specialty { get; set; } = "";
        public int Course { get; set; }

        public Student(string fn, string ln, string g, int by,
            string specialty, int course)
        {
            FirstName = fn; LastName = ln; Gender = g; BirthYear = by;
            Specialty = specialty; Course = course;
        }

        public override string GetRole() =>
            $"Студент | Спец.: {Specialty} | Курс: {Course}";
    }
}