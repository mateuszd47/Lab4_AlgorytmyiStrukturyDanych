using System;
using System.Numerics;

namespace rowanie_4stopnia
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Enter a (different than 0):");
            double a = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter b:");
            double b = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter c:");
            double c = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter d:");
            double d = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter e:");
            double e = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine($"\nA fourth degree polynomial:\n{a}x^4 + {b}x^3 + {c}x^2 + {d}x + {e}\n");

            // checking for the parameters for which the formula does not work
            if (b == 0 && c == 0 && d == 0 && e == 0)
            {
                Console.WriteLine("Fourth degree polynomial roots (real, imaginary):");
                Console.WriteLine("x1 = 0");
                return;
            }
            else if (b == 1 && c == 0 && d == 0 && e == 0)
            {
                Console.WriteLine("Fourth degree polynomial roots (real, imaginary):");
                Console.WriteLine("x1 = 0\nx2 = -1");
                return;
            }


            // declaring variables for the final solution
            Complex j = new Complex();
            Complex k = new Complex();
            Complex l = new Complex();
            Complex m = new Complex();

            // calculating powers of a & b
            double a2 = Math.Pow(a, 2);
            double b2 = Math.Pow(b, 2);
            double a3 = Math.Pow(a, 3);
            double b3 = Math.Pow(b, 3);
            double a4 = Math.Pow(a, 4);
            double b4 = Math.Pow(b, 4);

            // calculating variables
            double f = (c / a) - ((3.0 * b2) / (8.0 * a2));
            double g = (d / a) + (b3 / (8 * a3)) - ((b * c) / (2.0 * a2));
            double h = (e / a) - ((3.0 * b4) / (256.0 * a4)) + ((b2 * c) / (16.0 * a3)) - ((b * d) / (4.0 * a2));

            // calculating powers of f & g
            double f2 = Math.Pow(f, 2);
            double g2 = Math.Pow(g, 2);

            // transforming into third degree polynomial
            double a1 = 1.0;
            double b1 = f / 2.0;
            double c1 = (f2 - (4.0 * h)) / 16.0;
            double d1 = -g2 / 64.0;

            Console.WriteLine($"Transformed into a third degree polynomial:\n{a1:F4}y^3 + {b1:F4}y^2 + {c1:F4}y + {d1:F4}\n");

            //solving 3rd order polynomial
            double w = -b1 / (3.0 * a1);
            double w2 = Math.Pow(w, 2);
            double w3 = Math.Pow(w, 3);
            double p = (((3.0 * a1 * w2) + (2.0 * b1 * w) + c1) / a1);
            double q = (((a1 * w3) + (b1 * w2) + (c1 * w) + d1) / a1);
            double delta = ((q * q) / 4.0) + ((p * p * p) / 27.0);

            Console.WriteLine($"The discriminant of the third degree polynomial = {delta:F4}\n");

            if (delta > 0)
            {
                double u = Math.Cbrt((-q / 2.0) + Math.Sqrt(delta));
                double v = Math.Cbrt((-q / 2.0) - Math.Sqrt(delta));
                double x1 = (u + v + w);
                double x2re = ((-1.0 / 2.0) * (u + v)) + w;
                double x2im = (Math.Sqrt(3.0) / 2.0) * (u - v);
                double x3re = (-1.0 / 2.0) * (u + v) + w;
                double x3im = (Math.Sqrt(3.0) / -2.0) * (u - v);

                Console.WriteLine($"Third degree polynomial roots:\nx1 = {x1:F4}\nx2 = {x2re:F4} + {x2im:F4}i\nx3 = {x3re:F4} + {x3im:F4}i\n");

                Complex n = new Complex(x2re, x2im);
                Complex o = new Complex(x3re, x3im);

                j = Complex.Sqrt(n);
                k = Complex.Sqrt(o);
                l = Complex.Multiply(Complex.Multiply(8, j), k);
                l = Complex.Divide(-g, l);
                m = b / (4 * a);
            }
            else if (delta < 0)
            {
                double fi = Math.Acos(3 * q / (2.0 * p * (Math.Sqrt(-p / 3.0))));
                double x1 = w + 2 * Math.Sqrt(-p / 3.0) * Math.Cos(fi / 3.0);
                double x2 = w + 2 * Math.Sqrt(-p / 3.0) * Math.Cos((fi / 3.0) + (2.0 / 3.0) * Math.PI);
                double x3 = w + 2 * Math.Sqrt(-p / 3.0) * Math.Cos((fi / 3.0) + (4.0 / 3.0) * Math.PI);

                Console.WriteLine($"Third degree polynomial roots:\nx1 = {x1:F4}\nx2 = {x2:F4}\nx3 = {x3:F4}\n");

                if ((x1 != 0 && x2 != 0 && x3 != 0) || (x1 != 0 && x2 != 0 && x3 == 0))
                {
                    j = Complex.Sqrt(x1);
                    k = Complex.Sqrt(x2);
                    l = Complex.Multiply(Complex.Multiply(8, j), k);
                    l = Complex.Divide(-g, l);
                    m = b / (4 * a);
                }
                else if (x1 != 0 && x2 == 0 && x3 != 0)
                {
                    j = Complex.Sqrt(x1);
                    k = Complex.Sqrt(x3);
                    l = Complex.Multiply(Complex.Multiply(8, j), k);
                    l = Complex.Divide(-g, l);
                    m = b / (4 * a);
                }
                else if (x1 == 0 && x2 != 0 && x3 != 0)
                {
                    j = Complex.Sqrt(x2);
                    k = Complex.Sqrt(x3);
                    l = Complex.Multiply(Complex.Multiply(8, j), k);
                    l = Complex.Divide(-g, l);
                    m = b / (4 * a);
                }
            }
            else
            {
                double x1 = Math.Sqrt(w - (2 * Math.Cbrt(q / 2.0)));
                double x2 = Math.Sqrt(w + Math.Cbrt(q / 2.0));

                Console.WriteLine($"Third degree polynomial roots:\nx1 = {x1:F4}\nx2 = {x2:F4}\n");

                j = Complex.Sqrt(x1);
                k = Complex.Sqrt(x2);
                l = Complex.Multiply(Complex.Multiply(8, j), k);
                l = Complex.Divide(-g, l);
                m = b / (4 * a);
            }

            Complex z1 = j + k + l - m;
            Complex z2 = j - k - l - m;
            Complex z3 = -j + k - l - m;
            Complex z4 = -j - k + l - m;

            Console.WriteLine("Fourth degree polynomial roots (real, imaginary):");
            Console.WriteLine($"x1 = {z1:F4}\nx2 = {z2:F4}\nx3 = {z3:F4}\nx4 = {z4:F4}");


        }
    }
}
