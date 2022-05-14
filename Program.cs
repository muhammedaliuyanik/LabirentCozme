using System;
using System.IO;
namespace LabirentCozme
{ 
    
    public class program
    {       
        public static void Main()
        {
            string workingDir = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory);

            Labyrinth firstLabyrinth = new Labyrinth(workingDir + @"/../../../labirentler/Lab1Yol0.txt");

            firstLabyrinth.ReadLabyrinth();
            firstLabyrinth.Print();
           
            //Matrix.CreateMatrix(_filePath + @"/../../../labirentler/Lab1Yol1.txt");
            // Matrix.CreateMatrix(_filePath + @"/../../../labirentler/Lab2Yol0.txt");
            //Matrix.CreateMatrix(_filePath + @"/../../../labirentler/Lab2Yol1.txt");


        }
    }
    
}