using System;

namespace Lab6_Variant6
{
    // Учитель — дополнен IComparable<Teacher> (сортировка по стажу убывание)
    class Teacher : Person, IComparable<Teacher>
    {
        private string subject;
        private int experience;

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

        // IComparable: сортировка по убыванию стажа
        public int CompareTo(Teacher other)
        {
            return other.experience.CompareTo(this.experience);
        }

        // ICloneable: поверхностная копия
        public override object Clone()
        {
            return this.MemberwiseClone();
        }

        public override void Print()
        {
            base.Print();
            Console.WriteLine("  Предмет  : " + subject);
            Console.WriteLine("  Стаж     : " + experience + " л.");
        }
    }
}
