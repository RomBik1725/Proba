namespace Lab6_Variant6.Classes
{
    public class Teacher : PersonBase
    {
        public int Experience { get; set; }
        public string Position { get; set; } = "";

        public Teacher() { }
        public Teacher(string fn, string ln, string g, int by, int exp, string pos)
        {
            FirstName = fn; LastName = ln; Gender = g; BirthYear = by;
            Experience = exp; Position = pos;
        }

        public override string GetRole() => $"Преп. | {Position} | {Experience} л. ст.";
        public override object Clone() =>
            new Teacher(FirstName, LastName, Gender, BirthYear, Experience, Position);
    }
}