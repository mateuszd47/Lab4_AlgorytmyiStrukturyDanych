using System;

namespace równaie_sześcienne
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Podaj ax^3: ");
            double a = double.Parse(Console.ReadLine());
            Console.Write("Podaj bx^2: ");
            double b = double.Parse(Console.ReadLine());
            Console.Write("Podaj cx: ");
            double c = double.Parse(Console.ReadLine());
            Console.Write("Podaj d: ");
            double d = double.Parse(Console.ReadLine());

            Console.Write("Ilość miejsc po przecinku: ");
            int ilosc = int.Parse(Console.ReadLine());

            double w = -(b / (3 * a));
            double p = ((3 * a * Math.Pow(w, 2)) + (2 * b * w) + c) / a;
            double q = ((a * Math.Pow(w, 3)) + (b * Math.Pow(w, 2)) + (c * w) + d) / a;
            double delta = (Math.Pow(q, 2) / 4) + (Math.Pow(p, 3) / 27);
            Console.Write($"delta: {delta} ");

            if (delta > 0)
            {
                double u = Math.Cbrt((-q / 2.0) + Math.Sqrt(delta));
                double v = Math.Cbrt((-q / 2.0) - Math.Sqrt(delta));

                double x1 = u + v + w;
                double x2 = (-0.5 * (u + v)) + w;
                double x3 = x2;
                double urojona = (Math.Sqrt(3) / 2.0) * (u - v);
                Console.WriteLine($"urojona: {urojona} ");

                
                Console.WriteLine("Jeden pierowstek rzeczyswisty i dwa zespolone.");
                Console.WriteLine($"x1= {Math.Round(x1, ilosc)}");
                Console.WriteLine($"x2= {Math.Round(x2, ilosc)} + {Math.Round(urojona, ilosc)}i");
                Console.WriteLine($"x3= {Math.Round(x3, ilosc)} - {Math.Round(urojona, ilosc)}i");
             
               
            }
            else if (delta < 0)
            {
                Console.WriteLine("Trzy pierowstki rzeczyswiste.");

                double fi = Math.Acos((3 * q) / (2 * p * Math.Sqrt(-p / 3.0)));
                Console.WriteLine($"fi= {fi}");

                double x1 = (w + (2 * Math.Sqrt(-p / 3.0)) * Math.Cos(fi / 3.0));
                double x2 = (w + 2 * Math.Sqrt(-p / 3.0) * Math.Cos(fi / 3.0 + (2.0 * Math.PI) / 3.0));
                double x3 = (w + 2 * Math.Sqrt(-p / 3.0) * Math.Cos(fi / 3.0 + (4.0 * Math.PI) / 3.0));
                Console.WriteLine($"x1= {Math.Round(x1, ilosc)}");
                Console.WriteLine($"x2= {Math.Round(x2, ilosc)}");
                Console.WriteLine($"x3= {Math.Round(x3, ilosc)}");
            }
            else if (delta == 0)
            {
                double x1 = w - 2 * Math.Cbrt(q / 2);
                double x23 = w + Math.Cbrt(q / 2);

                Console.WriteLine("Dwa pierowstki rzeczyswiste (z czego jedn podwójny).");
                Console.WriteLine($"x1= {Math.Round(x1, ilosc)} ");
                Console.WriteLine($"x2,3= {Math.Round(x23, ilosc)} ");
            }
        }
    }
}
