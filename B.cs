using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// returning 1 means the cube is not a magic cube

namespace B
{
    class B
    {
        public static int Main(String[] args)
        {
            int sizeN;
            int sizeM;
            if (args.Length == 0)
            {
                System.Console.WriteLine("Please enter a numeric argument.");
                return 1;
            }
            try
            {
                sizeN = int.Parse(args[0]);
                sizeM = int.Parse(args[1]);
            }
            catch (System.FormatException)
            {
                System.Console.WriteLine("Please enter a numeric argument.");
                return 1;
            }

            int[,] square = new int[sizeN, sizeM];
            int i = 2;
            int total = 0;

            //setting up an 2d int array to make checking easier

            for (int x = 0; x < sizeN; x++)
            {
                for (int y = 0; y < sizeM; y++)
                {
                    square[x, y] = int.Parse(args[i]);
                    i++;
                }
            }

            //calculating the total 1 row

            for (int y = 0; y < sizeN; y++)
            {
                total += square[0, y];
            }

            //checking if all rows match total
            if (checker(square, sizeN, sizeM, total).Equals(1))
            {
                return 1;
            }
                //checking if all colums match total
            else if (checker(square, sizeM, sizeN, total).Equals(1))
            {
                return 1;
            }

            else
            {
                return 0;
            }
        }

        //method for checking array

        public static int checker(int[,] array, int row, int col, int total)
        {
            int temp = 0;
            for (int i = 0; i < row; i++)
            {
                for (int y = 0; y < col; y++)
                {
                    temp += array[i, y];

                }
                if (total != temp)
                {
                    return 1;
                }
                temp = 0;
            }
            return 0;
        }
    }
}
