namespace Lab5_Variant6.Classes
{
    public class Schoolchild : Person
    {
        public string SchoolNumber { get; set; } = "";
        public string ClassName { get; set; } = "";

        public Schoolchild(string fn, string ln, string g, int by,
            string school, string cls)
        {
            FirstName = fn; LastName = ln; Gender = g; BirthYear = by;
            SchoolNumber = school; ClassName = cls;
        }

        public override string GetRole() =>
            $"Школьник | Шк.: {SchoolNumber} | Кл.: {ClassName}";
    }
}