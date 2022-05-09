using System;

namespace LabirentCozme
{ 
    public class program
    {
        public static int sayac = 1;
        public static int SayacArttır() {
           return sayac++;
        }
        public static void Main()
        {
            Matris.MatrisYaz(@"C:\Users\Ali\source\repos\LabirentCozme\labirentler\Lab1Yol0.txt");
            Matris.MatrisYaz(@"C:\Users\Ali\source\repos\LabirentCozme\labirentler\Lab1Yol1.txt");
            Matris.MatrisYaz(@"C:\Users\Ali\source\repos\LabirentCozme\labirentler\Lab2Yol0.txt");
            Matris.MatrisYaz(@"C:\Users\Ali\source\repos\LabirentCozme\labirentler\Lab2Yol1.txt");

        }
    }
    
}