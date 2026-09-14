using System;

namespace Lab9_Variant6
{
    // Класс «Автомобиль» — для работы с коллекциями и LINQ
    class Car
    {
        private string brand;     // марка
        private string model;     // модель
        private int    year;      // год выпуска
        private double maxSpeed;  // максимальная скорость, км/ч
        private string bodyType;  // тип кузова

        public Car(string brand, string model, int year, double maxSpeed, string bodyType)
        {
            Brand    = brand;
            Model    = model;
            Year     = year;
            MaxSpeed = maxSpeed;
            BodyType = bodyType;
        }

        public string Brand
        {
            get { return brand; }
            set { brand = (value == null) ? "" : value; }
        }

        public string Model
        {
            get { return model; }
            set { model = (value == null) ? "" : value; }
        }

        public int Year
        {
            get { return year; }
            set { year = (value < 1900) ? 1900 : value; }
        }

        public double MaxSpeed
        {
            get { return maxSpeed; }
            set { maxSpeed = (value < 0) ? 0 : value; }
        }

        public string BodyType
        {
            get { return bodyType; }
            set { bodyType = (value == null) ? "" : value; }
        }

        public void Print()
        {
            Console.WriteLine("  " + brand + " " + model +
                " | год: " + year +
                " | " + maxSpeed + " км/ч" +
                " | " + bodyType);
        }
    }
}
