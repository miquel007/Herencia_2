using System;
using System.Collections.Generic;

namespace ConsoleApp50
{
    class Program7
    {
        public class Raices
        {
            private int _a;
            private int _b;
            private int _c;

            public int A
            {
                get { return _a; }
                set { _a = value; }
            }

            public int B
            {
                get { return _b; }
                set { _b = value; }
            }

            public int C
            {
                get { return _c; }
                set { _c = value; }
            }

            public Raices(int num1, int num2,int num3)
            {
                A = num1;
                B = num2;
                C = num3;
            }

            private double getDiscriminante()
            {
                double num;

                num = Math.Pow(B, 2) - (4*A*C);

                return num;
            }

            public bool tieneRaices()
            {
                double num;

                num = getDiscriminante();

                if (num < 0)
                    return false;
                else
                    return true;
            }

            public bool tieneRaiz()
            {
                double num;

                num = getDiscriminante();

                if (num == 0)
                    return true;
                else
                    return false;
            }

            public List<double> obtenerRaices()
            {
                List<double> array = new List<double>();

                double num = 0;

                if (B != 0 && C != 0)
                {
                    num = (-B + Math.Sqrt(Math.Pow(B, 2) - (4 * A * C))) / (2 * A);
                    array.Add(num);
                    num = (-B - Math.Sqrt(Math.Pow(B, 2) - (4 * A * C))) / (2 * A);
                    array.Add(num);
                }
                else if (C == 0)
                {
                    array.Add(0);
                    num = -(B / A);
                    array.Add(num);
                }
                    
                return array;
            }

            public double obtenerRaiz()
            {
                if (B == 0 && C == 0)
                    return 0;
                else
                    return (-B + Math.Sqrt(Math.Pow(B, 2) - (4 * A * C))) / (2 * A);
            }

        }

        static void Main(string[] args)
        {
            Console.WriteLine("Escribe A B C");
            string kfake = Console.ReadLine();
            string lfake = Console.ReadLine();
            string pfake = Console.ReadLine();

            int num1 = Convert.ToInt32(kfake);
            int num2 = Convert.ToInt32(lfake);
            int num3 = Convert.ToInt32(pfake);

            Raices novo = new Raices(num1, num2, num3);

            if (novo.tieneRaices())
            {
                if (novo.tieneRaiz())
                    Console.WriteLine("La raiz solo tiene una solucion : " + novo.obtenerRaiz());
                else
                {
                    List<double> array = novo.obtenerRaices();
                    Console.WriteLine("La raiz mas de una solucion : ");
                    foreach (double n in array)
                        Console.WriteLine(n);
                }
            }
            else
                Console.WriteLine("La solucio no es real, es compleja");
        }
    }
}
