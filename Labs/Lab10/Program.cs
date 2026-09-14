using System;
using System.IO;

namespace Lab10_Variant6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("=== Лабораторная работа №10. Вариант 6 ===");
            Console.WriteLine("Файлы. Потоки. Бинарное чтение/запись.");
            Console.WriteLine();

            string fileName = "points.bin";

            // Точки из ЛР №2 (объект + координаты)
            Point3D[] points = new Point3D[]
            {
                new Point3D(1.0, 2.0, 3.0),
                new Point3D(4.5, 0.0, -1.5),
                new Point3D(0.0, 0.0,  0.0),
                new Point3D(7.2, 3.1,  8.8)
            };

            // --- Запись в бинарный файл ---
            Console.WriteLine("--- Запись " + points.Length + " точек в " + fileName + " ---");
            using (BinaryWriter bw = new BinaryWriter(File.Open(fileName, FileMode.Create)))
            {
                bw.Write(points.Length);
                for (int i = 0; i < points.Length; i++)
                    points[i].WriteToStream(bw);
            }
            Console.WriteLine("Запись выполнена.");
            Console.WriteLine();

            // --- Чтение из бинарного файла ---
            Console.WriteLine("--- Чтение из " + fileName + " ---");
            Point3D[] loaded;
            using (BinaryReader br = new BinaryReader(File.Open(fileName, FileMode.Open)))
            {
                int count = br.ReadInt32();
                loaded = new Point3D[count];
                for (int i = 0; i < count; i++)
                    loaded[i] = Point3D.ReadFromStream(br);
            }

            for (int i = 0; i < loaded.Length; i++)
                Console.WriteLine("  Точка " + (i + 1) + ": " + loaded[i]);
            Console.WriteLine();

            // --- Расстояние от начала координат ---
            Console.WriteLine("--- Расстояния до начала координат ---");
            Point3D origin = new Point3D(0, 0, 0);
            for (int i = 0; i < loaded.Length; i++)
                Console.WriteLine("  |" + loaded[i] + "| = " + Math.Round(loaded[i].DistanceTo(origin), 4));
            Console.WriteLine();

            // --- Текстовый файл — запись / чтение ---
            string textFile = "points.txt";
            Console.WriteLine("--- Запись в текстовый файл " + textFile + " ---");
            using (StreamWriter sw = new StreamWriter(textFile))
            {
                sw.WriteLine(loaded.Length);
                for (int i = 0; i < loaded.Length; i++)
                    sw.WriteLine(loaded[i].X + " " + loaded[i].Y + " " + loaded[i].Z);
            }

            Console.WriteLine("Чтение из текстового файла:");
            using (StreamReader sr = new StreamReader(textFile))
            {
                int n = int.Parse(sr.ReadLine());
                for (int i = 0; i < n; i++)
                {
                    string line = sr.ReadLine();
                    string[] parts = line.Split(' ');
                    double px = double.Parse(parts[0], System.Globalization.CultureInfo.InvariantCulture);
                    double py = double.Parse(parts[1], System.Globalization.CultureInfo.InvariantCulture);
                    double pz = double.Parse(parts[2], System.Globalization.CultureInfo.InvariantCulture);
                    Console.WriteLine("  " + new Point3D(px, py, pz));
                }
            }
            Console.WriteLine();

            Console.WriteLine("Для выхода нажмите любую клавишу...");
            Console.ReadKey();
        }
    }
}
