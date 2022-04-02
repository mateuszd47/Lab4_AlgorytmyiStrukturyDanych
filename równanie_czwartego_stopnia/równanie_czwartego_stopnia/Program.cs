using System;

namespace równanie_czwartego_stopnia
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Podaj ax^4: ");
            double a = double.Parse(Console.ReadLine());
            Console.Write("Podaj bx^3: ");
            double b = double.Parse(Console.ReadLine());
            Console.Write("Podaj cx^2: ");
            double c = double.Parse(Console.ReadLine());
            Console.Write("Podaj dx: ");
            double d = double.Parse(Console.ReadLine());
            Console.Write("Podaj e: ");
            double e = double.Parse(Console.ReadLine());

            double f = (c / a) - ((3 * Math.Pow(b, 2)) / (8 * Math.Pow(a, 2)));
            double g = (d / a) + (Math.Pow(b, 3) / (8 * Math.Pow(a, 3))) - ((b * c) / (2 * Math.Pow(a, 2)));
            double h = (e / a) - ((3 * Math.Pow(b, 4)) / (256 * Math.Pow(a, 4))) + ((Math.Pow(b, 2) * c) / (16 * Math.Pow(a, 3))) - ((b * d) / (4 * Math.Pow(a, 2)));

            double aprim = 1;
            double bprim = f/2;
            double cprim = (Math.Pow(f, 2) - (4 * h)) / 16;
            double dprim = Math.Pow(g, 2) / 64;

            Console.WriteLine($"{aprim}y^3 + {bprim} + {cprim} - {dprim} = 0");

            double w = -(bprim / (3 * aprim));
            double p = ((3 * aprim * Math.Pow(w, 2)) + (2 * bprim * w) + cprim) / aprim;
            double q = ((aprim * Math.Pow(w, 3)) + (bprim * Math.Pow(w, 2)) + (cprim * w) + dprim) / aprim;
            double delta = (Math.Pow(q, 2) / 4) + (Math.Pow(p, 3) / 27);
            Console.Write($"delta: {delta} ");

            Console.Write("Ilość miejsc po przecinku: ");
            int ilosc = int.Parse(Console.ReadLine());

            if (delta > 0)
            {
                DeltaWieksza(w, p, q, delta, ilosc);
            }
            else if (delta < 0)
            {
                DeltaMniejsza(w, p, q, delta, ilosc);
            }
            else if (delta == 0)
            {
                DeltaRowna(w, p, q, delta, ilosc);
            }

        }

        static void DeltaWieksza(double w, double p, double q, double delta, double ilosc)
        {
            double u = Math.Cbrt((-q / 2.0) + Math.Sqrt(delta));
            double v = Math.Cbrt((-q / 2.0) - Math.Sqrt(delta));

            double x1 = u + v + w;
            double x2 = (-0.5 * (u + v)) + w;
            double x3 = x2;
            double urojona = (Math.Sqrt(3) / 2.0) * (u - v);
            Console.WriteLine($"urojona: {urojona} ");


            //Console.WriteLine("Jeden pierowstek rzeczyswisty i dwa zespolone.");
            //Console.WriteLine($"x1= {Math.Round(x1, ilosc)}");
            //Console.WriteLine($"x2= {Math.Round(x2, ilosc)} + {Math.Round(urojona, ilosc)}i");
            //Console.WriteLine($"x3= {Math.Round(x3, ilosc)} - {Math.Round(urojona, ilosc)}i");
        }

        static void DeltaRowna(double w, double p, double q, double delta, double ilosc)
        {
            double x1 = w - 2 * Math.Cbrt(q / 2);
            double x23 = w + Math.Cbrt(q / 2);

            //Console.WriteLine("Dwa pierowstki rzeczyswiste (z czego jedn podwójny).");
            //Console.WriteLine($"x1= {Math.Round(x1, ilosc)} ");
            //Console.WriteLine($"x2,3= {Math.Round(x23, ilosc)} ");
        }

        static void DeltaMniejsza(double w, double p, double q, double delta, double ilosc)
        {
            Console.WriteLine("Trzy pierowstki rzeczyswiste.");

            double fi = Math.Acos((3 * q) / (2 * p * Math.Sqrt(-p / 3.0)));
            Console.WriteLine($"fi= {fi}");

            double x1 = (w + (2 * Math.Sqrt(-p / 3.0)) * Math.Cos(fi / 3.0));
            double x2 = (w + 2 * Math.Sqrt(-p / 3.0) * Math.Cos(fi / 3.0 + (2.0 * Math.PI) / 3.0));
            double x3 = (w + 2 * Math.Sqrt(-p / 3.0) * Math.Cos(fi / 3.0 + (4.0 * Math.PI) / 3.0));
            //Console.WriteLine($"x1= {Math.Round(x1, ilosc)}");
            //Console.WriteLine($"x2= {Math.Round(x2, ilosc)}");
            //Console.WriteLine($"x3= {Math.Round(x3, ilosc)}");
        }
    }
}
