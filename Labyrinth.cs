using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace LabirentCozme
{
    class LabyrinthCounter //matris sayısını tutar
    {
        public static int counter = 1;
        public static void Counter()
        {
            Console.WriteLine("[******** {0}. Labirent ********]", counter++);
            Console.BufferWidth = 130;
            Console.SetWindowSize(Console.BufferWidth, 35);
        }
        public void Print()
        {
            Console.WriteLine("[****************************]");
            Console.WriteLine("Diğer Labirentleri görmek için ENTER basın.");
        }
    }

    public class Labyrinth
    {
        char[][] matrix;
        string path;
        int x, y;
        public Labyrinth(string path)
        {
            this.path = path;
            this.matrix = new char[30][];
        }
        public void CanMoveRight()
        {

        }
        public void Move() //button press,
        {
            Console.Clear();
            for (int i = 0; i < 30; i++)
            {
                for (int j = 0; j < 30; j++)
                {
                    char temp = this.matrix[i][j];
                    x = i;
                    y = j;
                }
            }
            
            //Print();
        }
        public void ReadLabyrinth() //matris oluşturulur
        {
            char[][] data = File.ReadLines(this.path).Select(line => line.ToCharArray()).ToArray();

            for (int i = 0; i < 30; i++)
            {
                data[i] = Array.FindAll(data[i], c => (c == '1' || c == '0'));
            }
            this.matrix = data;

        }
        public void Print()
        {
            for (int i = 0; i < 30; i++)
            {
                for (int j = 0; j < 30; j++)
                {
                    Console.Write(this.matrix[i][j]);
                }
                Console.WriteLine();
            }
        }
    }
}
