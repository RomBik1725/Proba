using System;

namespace Lab5_Variant6
{
    // Студент — наследник Person
    class Student : Person
    {
        private string university;  // название вуза
        private int course;         // курс (1–6)

        public Student(string firstName, string lastName, int birthYear,
                       string gender, string university, int course)
            : base(firstName, lastName, birthYear, gender)
        {
            University = university;
            Course     = course;
        }

        public string University
        {
            get { return university; }
            set { university = (value == null) ? "" : value; }
        }

        public int Course
        {
            get { return course; }
            set { course = (value < 1 || value > 6) ? 1 : value; }
        }

        public override string GetRole()
        {
            return "Студент (" + university + ", " + course + " курс)";
        }

        public override void Print()
        {
            base.Print();
            Console.WriteLine("  Вуз      : " + university);
            Console.WriteLine("  Курс     : " + course);
        }
    }
}
