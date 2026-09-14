using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Lab6_Variant6.Classes;

namespace Lab6_Variant6.Forms
{
    public partial class MainForm : Form
    {
        private List<IPerson> persons = new List<IPerson>();

        public MainForm() { InitializeComponent(); LoadData(); RefreshList(); }

        private void LoadData()
        {
            persons.Add(new Teacher("Анна", "Иванова", "Ж", 1965, 30, "Профессор"));
            persons.Add(new Teacher("Сергей", "Петров", "М", 1958, 38, "Доцент"));
            persons.Add(new Teacher("Ольга", "Зайцева", "Ж", 1985, 8, "Ст. преп."));
            persons.Add(new Student("Мария", "Петрова", "Ж", 2002, "Программист", 3));
            persons.Add(new Student("Иван", "Сидоров", "М", 2003, "Экономика", 2));
        }

        private void RefreshList(IEnumerable<IPerson>? src = null)
        {
            lbPersons.Items.Clear();
            foreach (var p in src ?? persons) lbPersons.Items.Add(p.ToString());
            lblCount.Text = $"Записей: {lbPersons.Items.Count}";
        }

        private void btnSort_Click(object sender, EventArgs e)
        { persons.Sort(); RefreshList(); lblStatus.Text = "Отсортировано по фамилии (IComparable)"; }

        private void btnClone_Click(object sender, EventArgs e)
        {
            if (lbPersons.SelectedIndex < 0) { lblStatus.Text = "Выберите запись"; return; }
            var original = persons[lbPersons.SelectedIndex];
            var clone = (IPerson)original.Clone();
            persons.Add(clone);
            RefreshList();
            lblStatus.Text = $"Клонировано (ICloneable): {clone.LastName} {clone.FirstName}";
        }

        private void btnUpcast_Click(object sender, EventArgs e)
        {
            var teacher = new Teacher("Тест", "Тестов", "М", 1970, 15, "Преп.");
            IPerson p = teacher;
            Teacher? back = p as Teacher;
            string msg = $"Teacher -> IPerson (upcast):\n{p}\n\nIPerson -> Teacher? (downcast):\n{back?.GetRole() ?? "null"}";
            MessageBox.Show(msg, "Приведение типов");
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        { RefreshList(); lblStatus.Text = "Все записи"; }

        private void btnExit_Click(object sender, EventArgs e) => Application.Exit();
    }
}