using System;
using System.IO;
namespace LabirentCozme
{
    public class program
    {
        public static string workingDir = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory);
        public static void Main()
        {
            Labyrinth firstLabyrinth = new Labyrinth(workingDir + @"/../../../labirentler/Lab2Yol0.txt");

            firstLabyrinth.ReadLabyrinth(); //Labirent txt dosyasından okunup matrise atılıyor.
            firstLabyrinth.CreateLabyrinth(); // labirent oluşturma fonksiyonu
            firstLabyrinth.Menu();
            //firstLabyrinth.MoveThread(); // labirent içerisinde manuel hareket algoritması
            

        } 
    }
}
    