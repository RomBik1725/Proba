using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Lab9_Variant6.Classes;

namespace Lab9_Variant6.Forms
{
    public partial class MainForm : Form
    {
        private Dictionary<string,Car> cars = new();
        public MainForm() { InitializeComponent(); LoadSampleData(); RefreshList(); }

        private void LoadSampleData()
        {
            foreach(var c in new[]{
                new Car("Toyota","Camry",2018,"Белый",85000),
                new Car("BMW","X5",2020,"Чёрный",42000),
                new Car("Honda","Civic",2017,"Серебристый",110000),
                new Car("Lada","Vesta",2021,"Синий",35000),
                new Car("Hyundai","Solaris",2019,"Красный",67000),
                new Car("Kia","Rio",2016,"Белый",145000),
                new Car("Mercedes","C-Class",2021,"Чёрный",25000),
                new Car("Volkswagen","Polo",2018,"Серый",78000),
                new Car("Renault","Logan",2015,"Белый",168000),
                new Car("Mazda","3",2019,"Красный",55000)
            })
            { var k=c.GetKey(); if(!cars.ContainsKey(k)) cars[k]=c; }
        }

        private void RefreshList(IEnumerable<Car>? src=null)
        { lbCars.Items.Clear(); foreach(var c in src??cars.Values) lbCars.Items.Add(c.ToString()); lblCount.Text=$"Авт.: {lbCars.Items.Count}"; }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                var car=new Car(txtBrand.Text.Trim(),txtModel.Text.Trim(),(int)nudYear.Value,txtColor.Text.Trim(),(double)nudMileage.Value);
                if(string.IsNullOrEmpty(car.Brand)||string.IsNullOrEmpty(car.Model)) throw new Exception("Заполните марку и модель");
                cars[car.GetKey()]=car; RefreshList(); txtBrand.Clear(); txtModel.Clear(); txtColor.Clear();
                lblStatus.Text=$"Добавлен: {car}";
            }
            catch(Exception ex){lblStatus.Text="Ошибка: "+ex.Message;}
        }

        private void btnRemoveSelected_Click(object sender, EventArgs e)
        {
            if(lbCars.SelectedIndex<0) return;
            var keys=cars.Keys.ToList();
            if(lbCars.SelectedIndex<keys.Count){string k=keys[lbCars.SelectedIndex]; lblStatus.Text=$"Удалён: {cars[k]}"; cars.Remove(k); RefreshList();}
        }

        private void btnRemoveOld_Click(object sender, EventArgs e)
        {
            int cutYear=DateTime.Now.Year-(int)nudOldYears.Value; int removed=0;
            foreach(var k in cars.Keys.ToList()) if(cars[k].Year<cutYear){cars.Remove(k);removed++;}
            RefreshList(); lblStatus.Text=$"Удалено {removed} авт.";
        }

        private void btnSortYear_Click(object sender, EventArgs e)
        { RefreshList(cars.Values.OrderBy(c=>c.Year)); lblStatus.Text="Сорт по году"; }

        private void btnSortMileage_Click(object sender, EventArgs e)
        { RefreshList(cars.Values.OrderBy(c=>c.Mileage)); lblStatus.Text="Сорт по пробегу"; }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string q=txtSearch.Text.Trim().ToLower();
            var found=cars.Values.Where(c=>c.Brand.ToLower().Contains(q)||c.Model.ToLower().Contains(q)).ToList();
            RefreshList(found); lblStatus.Text=$"Найдено: {found.Count}";
        }

        private void btnLinq_Click(object sender, EventArgs e)
        {
            if(cars.Count==0){lblStatus.Text="Список пуст";return;}
            double avg=cars.Values.Average(c=>c.Mileage);
            int brands=cars.Values.Select(c=>c.Brand).Distinct().Count();
            var newest=cars.Values.MaxBy(c=>c.Year);
            MessageBox.Show($"Ср. пробег: {avg:F0} км\nУник. марок: {brands}\nНовейший: {newest}","LINQ");
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        { RefreshList(); lblStatus.Text="Все автомобили"; }
    }
}