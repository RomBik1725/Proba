using System;

namespace Lab8_Variant6
{
    class Schoolchild : Person, IComparable<Schoolchild>
    {
        private string school;
        private int grade;

        public Schoolchild(string firstName, string lastName, int birthYear,
                           string gender, string school, int grade)
            : base(firstName, lastName, birthYear, gender)
        {
            School = school;
            Grade  = grade;
        }

        public string School
        {
            get { return school; }
            set { school = (value == null) ? "" : value; }
        }

        public int Grade
        {
            get { return grade; }
            set { grade = (value < 1 || value > 11) ? 1 : value; }
        }

        public override string GetRole()
        {
            return "Школьник (школа " + school + ", " + grade + " класс)";
        }

        public int CompareTo(Schoolchild other)
        {
            return this.grade.CompareTo(other.grade);
        }

        public override object Clone()
        {
            return this.MemberwiseClone();
        }

        public override void Print()
        {
            base.Print();
            Console.WriteLine("  Школа    : " + school);
            Console.WriteLine("  Класс    : " + grade);
        }
    }
}
