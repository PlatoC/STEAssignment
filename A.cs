using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// B.exe must be place in C:\

namespace A
{
    public class A
    {
        public static int Main(String[] args)
        {
            //String cubestring = " sizeN, sizeM, values......."
            String test_1 = "2 2 1 1 1 1";
            String test_2 = "2 2 1 2 2 1";
            String test_3 = "2 2 1 2 2 3";
            String fileName = "C:\\";
            System.Diagnostics.Process process = new System.Diagnostics.Process();


            if (args.Length == 0)
            {
                System.Console.WriteLine("Please enter a filename.");
                return 1;
            }

            try
            {
                fileName += args[0];
                //System.Console.WriteLine(fileName);

            }
            catch (System.FormatException)
            {
                System.Console.WriteLine("Please enter a filename.");
                return 1;
            }

            process.StartInfo.FileName = fileName;

            // to add another cube to test add aother else if (Tester(process,cube string, expected)) Tester will return false if B is working as intented

            if (Tester(process, test_1, true)) return 0;
            else if (Tester(process, test_2, true)) return 0;
            else if (Tester(process, test_3, false))
                return 0;
            else
            {
                System.Console.WriteLine("ok");
                return 1;
            }
        }

        //function for printing the cube

        public static string printcube(string cube)
        {
            string returnstring = " ";
            int temp = 2;
            string[] temp1 = cube.Split(new Char[] { ' ' });
            int sizeN = System.Convert.ToInt16(temp1[0]);
            int sizeM = System.Convert.ToInt16(temp1[1]);
            for (int i = 0; i < sizeN; i++)
            {
                for (int y = 0; y < sizeM; y++)
                {
                    returnstring += " " + temp1[temp];
                    temp++;
                }
                returnstring += " \n ";
            }
            return returnstring;
        }

        //tester method to check if B.exe is working

        public static bool Tester(System.Diagnostics.Process process, string cube, bool expected)
        {
            int result;
            string tempCube;
            process.StartInfo.Arguments = cube;
            process.Start();
            process.WaitForExit();
            result = process.ExitCode;
            if (result == 1 && expected == true)
            {
                System.Console.WriteLine("not ok:");
                tempCube = printcube(cube);
                System.Console.WriteLine(tempCube);
                System.Console.WriteLine("returned:no");
                System.Console.WriteLine("expected:yes");
                return true;
            }
            else if (result == 0 && expected == false)
            {
                System.Console.WriteLine("not ok:");
                tempCube = printcube(cube);
                System.Console.WriteLine(tempCube);
                System.Console.WriteLine("returned:yes");
                System.Console.WriteLine("expected:no");
                return true;
            }
            else
                return false;
        }

    }
}
