using System;

namespace OM_L1_v1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double start = -2;
            double end = 20;
            int pointer = 0;
            string input = "";

            Console.WriteLine("Enter command: 1 - Dichotomy, 2 - Gold section, 3 - Minimum find, q - quit");
            input = Console.ReadLine();
            while (input != "q")
            {
                pointer = Convert.ToInt32(input);


                Solver(pointer, start, end);
                Console.WriteLine("Enter command: 1 - Dichotomy, 2 - Gold section, 3 - Minimum find, q - quit");
                input = Console.ReadLine();
            }
        }

        static double func(double arg)
        {
            return Math.Pow((arg - 6), 2);
        }

        static void IntervalSearch(double x0)
        {
            const double DELTA = 1;
            double h = 0;
            double xk = 0;

            if (func(x0) > func(x0 + DELTA))
            {
                xk = x0 + DELTA;
                h = DELTA;
            }
            else if(func(x0) > func(x0 - DELTA))
            {
                xk = x0 - DELTA;
                h = -DELTA;
            }

            double xk1 = xk;
            double xmk = x0;
            int k = 1;

            do
            {
                xk = xk1;
                h = h * 2;
                xk1 = xk + h;
                Console.WriteLine("x" + k + "\t" + xmk + "\t" + xk1);
                k++;
                xmk = xk;
            } while (func(xk) > func(xk1));

        }

        static void Solver(int pointer, double start,double end)
        {
            const double EPS = 0.1;
            const double DELTA = 1;
            double x1 = 0, x2 = 0;
            int n = 0;

            #region N_solver
            switch (pointer)
            {
                case 1:
                    n = Convert.ToInt32(Math.Ceiling(Math.Log((end - start) / EPS) / Math.Log(2.0)));
                    break;

                case 2:
                    n = Convert.ToInt32(Math.Ceiling(Math.Log((end - start) / EPS) /
                                                    Math.Log((Math.Sqrt(5) + 1) / 2)));
                    break;
                case 3:
                    n = 0;
                    IntervalSearch(start);
                    break;
            }
            #endregion

            Console.WriteLine(n);

            #region Main_Solver
            for (int i = 0; i < n; i++)
            {
                switch (pointer)
                {
                    case 1:
                        x1 = (start + end - DELTA) / 2;
                        x2 = (start + end + DELTA) / 2;
                        break;

                    case 2:
                        x1 = start + ((3 - Math.Sqrt(5)) / 2) * (end - start);
                        x2 = start + ((Math.Sqrt(5) - 1) / 2) * (end - start);
                        break;
                }

                Console.WriteLine("Iter = " + (i + 1) + " [" + start + "\t" + end + "]");

                if (func(x1) < func(x2))
                {
                    end = x2;
                }
                else if (func(x1) > func(x2))
                {
                    start = x1;
                }
                else
                {
                    start = x1;
                    end = x2;
                }

            }
            #endregion
        }
    }
}
