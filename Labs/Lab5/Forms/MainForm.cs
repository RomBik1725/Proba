using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using Lab5_Variant6.Classes;

namespace Lab5_Variant6.Forms
{
    public partial class MainForm : Form
    {
        private List<Person> persons = new List<Person>();

        public MainForm()
        {
            InitializeComponent();
            SetNonRectangularShape();
            LoadData();
            RefreshList();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            SetNonRectangularShape();
        }

        private void SetNonRectangularShape()
        {
            var path = new GraphicsPath();
            int r = 30;
            int w = ClientSize.Width, h = ClientSize.Height;
            path.AddArc(0, 0, r, r, 180, 90);
            path.AddArc(w - r, 0, r, r, 270, 90);
            path.AddArc(w - r, h - r, r, r, 0, 90);
            path.AddArc(0, h - r, r, r, 90, 90);
            path.CloseAllFigures();
            this.Region = new Region(path);
        }

        private void LoadData()
        {
            persons.Add(new Schoolchild("Аня", "Козлова", "Ж", 2010, "℡10", "8А"));
            persons.Add(new Schoolchild("Денис", "Мальцев", "М", 2008, "№5", "9Б"));
            persons.Add(new Student("Мария", "Петрова", "Ж", 2002, "Программист", 3));
            persons.Add(new Student("Иван", "Сидоров", "М", 2003, "Экономика", 2));
            persons.Add(new Teacher("Надежда", "Иванова", "Ж", 1958, 35, "Профессор"));
            persons.Add(new Teacher("Алексей", "Смирнов", "М", 1952, 42, "Доцент"));
            persons.Add(new Teacher("Ольга", "Семёнова", "Ж", 1980, 18, "Ст. преп."));
        }

        private void RefreshList(IEnumerable<Person>? source = null)
        {
            lbPersons.Items.Clear();
            foreach (var p in source ?? persons) lbPersons.Items.Add(p.ToString());
        }

        private void btnShowTeachers_Click(object sender, EventArgs e)
        {
            var teachers = persons.OfType<Teacher>().ToList();
            RefreshList(teachers);
            lblStatus.Text = $"Преподавателей: {teachers.Count}";
        }

        private void btnRemovePensioners_Click(object sender, EventArgs e)
        {
            int before = persons.Count;
            persons.RemoveAll(p => p is Teacher t && t.IsPensioner());
            RefreshList();
            lblStatus.Text = $"Удалено пенсионеров: {before - persons.Count}";
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        { RefreshList(); lblStatus.Text = "Все записи"; }

        private void btnExit_Click(object sender, EventArgs e) => Application.Exit();
    }
}