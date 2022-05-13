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
            Console.WriteLine("[******** {0}. Labirent ********]", Counter2());
            Console.BufferWidth = 130;
            Console.SetWindowSize(Console.BufferWidth, 35);
        }

        public static int Counter2()
        {
            return counter++;
        }
    }

    class Labyrinth
    {
        public static void LabyrinthMove(char[][] matrix)
        {
            for (int i = 0; i < 30; i++)
            {
                for (int j = 0; j < 30; j++)
                {
                    char temp = matrix[i][j];



                }
            }
            Show(matrix);
        }
        public static void input()
        {
            string _filePath = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory);

            CreateMatrix(_filePath + @"/../../../labirentler/Lab1Yol0.txt");
            //Matrix.CreateMatrix(_filePath + @"/../../../labirentler/Lab1Yol1.txt");
            // Matrix.CreateMatrix(_filePath + @"/../../../labirentler/Lab2Yol0.txt");
            //Matrix.CreateMatrix(_filePath + @"/../../../labirentler/Lab2Yol1.txt");

        }
        public static void CreateMatrix(string adress) //matris oluşturulur
        {
            try
            {
                char[][] data = File.ReadLines(adress).Select(line => line.ToCharArray()).ToArray();

                LabyrinthTransfer(data);

                //PrintMatrix.Show(data);
            }
            catch (UnauthorizedAccessException uAEx)
            {
                Console.WriteLine(uAEx.Message);
            }
            catch (PathTooLongException pathEx)
            {
                Console.WriteLine(pathEx.Message);
            }
            finally
            {
                Console.ReadLine();
                Console.Clear();
            }
        }
        public static void LabyrinthTransfer(char[][] data)
        {
            for (int i = 0; i < 30; i++)
            {
                data[i] = Array.FindAll(data[i], c => (c == '1' || c == '0'));

            }

            //PrintMatrix.Show(temp1);
            LabyrinthMove(data);
        }
        public static void Show(char[][] data)
        {
            LabyrinthCounter.Counter();

            for (int i = 0; i < 30; i++)
            {
                for (int j = 0; j < 30; j++)
                {
                    Console.Write(data[i][j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine("[****************************]");
            Console.WriteLine("Diğer Labirentleri görmek için ENTER basın.");
        }
    }
}
