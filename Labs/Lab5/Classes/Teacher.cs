namespace Lab5_Variant6.Classes
{
    public class Teacher : Person
    {
        public int Experience { get; set; }
        public string Position { get; set; } = "";

        public Teacher(string fn, string ln, string g, int by,
            int exp, string pos)
        {
            FirstName = fn; LastName = ln; Gender = g; BirthYear = by;
            Experience = exp; Position = pos;
        }

        public override string GetRole() =>
            $"Преподаватель | {Position} | {Experience} л. ст.";
    }
}