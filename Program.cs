using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace LabirentCozme
{
    public class program
    {
        public class Matris
        {
            public static void MatrisYaz(string[] arr)
            {
                String[,] matris = new String[30, 30];

                for (int i = 0; i < 30; i++)
                {
                    for (int j = 0; j < 30; j++)
                    {
                       matris[i, j] = "";
                    }
                }
            }
        }
        public static void Main()
        {
            string Lab1Yol0 = System.IO.File.ReadAllText(@"C:\Users\Ali\source\repos\LabirentCozme\labirentler\Lab1Yol0.txt");
            string[] Lab1Yol1 = System.IO.File.ReadAllLines(@"C:\Users\Ali\source\repos\LabirentCozme\labirentler\Lab1Yol1.txt");
            string[] Lab2Yol0 = System.IO.File.ReadAllLines(@"C:\Users\Ali\source\repos\LabirentCozme\labirentler\Lab2Yol0.txt");
            string[] Lab2Yol1 = System.IO.File.ReadAllLines(@"C:\Users\Ali\source\repos\LabirentCozme\labirentler\Lab2Yol1.txt");

            foreach (var item in Lab1Yol0)
            {
                Console.WriteLine(item);
            }

            //Matris.MatrisYaz(Lab1Yol0);
            Matris.MatrisYaz(Lab1Yol1);
            Matris.MatrisYaz(Lab2Yol0);
            Matris.MatrisYaz(Lab2Yol1);


            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
    
}