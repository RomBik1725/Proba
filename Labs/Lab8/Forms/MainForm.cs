using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Lab8_Variant6.Classes;

namespace Lab8_Variant6.Forms
{
    public partial class MainForm : Form
    {
        private List<Teacher> teachers = new();
        public MainForm() { InitializeComponent(); LoadTeachers(); RefreshList(); }

        private void LoadTeachers()
        {
            teachers.Add(new Teacher("Анна","Иванова","Ж",1965,30,"Профессор"));
            teachers.Add(new Teacher("Сергей","Петров","М",1958,38,"Доцент"));
            teachers.Add(new Teacher("Наталья","Зайцева","Ж",1985,10,"Преподаватель"));
            teachers.Add(new Teacher("Владимир","Семенов","М",1950,45,"Профессор"));
            teachers.Add(new Teacher("Ольга","Краснова","Ж",1978,18,"Ст. преп."));
        }

        private void RefreshList(IEnumerable<Teacher>? src=null)
        { lbTeachers.Items.Clear(); foreach(var t in src??teachers) lbTeachers.Items.Add(t.ToString()); }

        private void btnCheckPensioners_Click(object sender, EventArgs e)
        {
            foreach(var t in teachers)
            {
                t.OnPensionerDetected += t2 => MessageBox.Show($"Пенсионер: {t2.LastName} {t2.FirstName} ({t2.Age} л.)","Обнаружено");
                t.CheckPensioner();
                t.OnPensionerDetected=null;
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            int minExp=(int)nudMinExp.Value;
            var filter=Teacher.GetExperienceFilter(minExp);
            var filtered=teachers.Where(t=>filter(t)).ToList();
            RefreshList(filtered); lblStatus.Text=$"Стаж >= {minExp}: {filtered.Count} преп.";
        }

        private void btnSortLambda_Click(object sender, EventArgs e)
        { teachers.Sort((a,b)=>string.Compare(a.LastName,b.LastName)); RefreshList(); lblStatus.Text="Отсортировано по фамилии"; }

        private void btnReset_Click(object sender, EventArgs e)
        { RefreshList(); lblStatus.Text="Список восстановлен"; }

        private void btnExit_Click(object sender, EventArgs e) => Application.Exit();
    }
}