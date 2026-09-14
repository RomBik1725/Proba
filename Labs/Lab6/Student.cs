using System;

namespace Lab6_Variant6
{
    class Student : Person, IComparable<Student>
    {
        private string university;
        private int course;

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

        // IComparable: сортировка по курсу возрастание
        public int CompareTo(Student other)
        {
            return this.course.CompareTo(other.course);
        }

        public override object Clone()
        {
            return this.MemberwiseClone();
        }

        public override void Print()
        {
            base.Print();
            Console.WriteLine("  Вуз      : " + university);
            Console.WriteLine("  Курс     : " + course);
        }
    }
}
