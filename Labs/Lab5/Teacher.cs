using System;

namespace Lab5_Variant6
{
    // Учитель — наследник Person
    class Teacher : Person
    {
        private string subject;    // преподаваемый предмет
        private int experience;   // педагогический стаж (лет)

        public Teacher(string firstName, string lastName, int birthYear,
                       string gender, string subject, int experience)
            : base(firstName, lastName, birthYear, gender)
        {
            Subject    = subject;
            Experience = experience;
        }

        public string Subject
        {
            get { return subject; }
            set { subject = (value == null) ? "" : value; }
        }

        public int Experience
        {
            get { return experience; }
            set { experience = (value < 0) ? 0 : value; }
        }

        public override string GetRole()
        {
            return "Учитель (" + subject + ", стаж " + experience + " л.)";
        }

        public override void Print()
        {
            base.Print();
            Console.WriteLine("  Предмет  : " + subject);
            Console.WriteLine("  Стаж     : " + experience + " л.");
        }
    }
}
