namespace Lab9_Variant6.Classes
{
    public class Car
    {
        public string Brand   { get; set; } = "";
        public string Model   { get; set; } = "";
        public int    Year    { get; set; }
        public string Color   { get; set; } = "";
        public double Mileage { get; set; }
        public Car() { }
        public Car(string brand,string model,int year,string color,double mileage)
        { Brand=brand; Model=model; Year=year; Color=color; Mileage=mileage; }
        public string GetKey() => $"{Brand}_{Model}_{Year}";
        public override string ToString() =>
            $"{Brand} {Model} ({Year}) | {Color} | {Mileage:F0} км";
    }
}