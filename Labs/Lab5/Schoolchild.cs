using System;

namespace Lab5_Variant6
{
    // Школьник — наследник Person
    class Schoolchild : Person
    {
        private string school;  // название школы
        private int grade;      // класс (1–11)

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

        public override void Print()
        {
            base.Print();
            Console.WriteLine("  Школа    : " + school);
            Console.WriteLine("  Класс    : " + grade);
        }
    }
}
