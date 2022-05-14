using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace LabirentCozme
{
    public class LabyrinthCounter //matris sayısını tutar
    {
        public static int counter = 1;
        public void Counter()
        {
            Console.WriteLine("[******** {0}. Labirent ********]", counter++);
            Console.BufferWidth = 130;
            Console.SetWindowSize(Console.BufferWidth, 35);
        }
        public void PrintCounter()
        {
            Console.WriteLine("[****************************]");
            Console.WriteLine("Diğer Labirentleri görmek için ENTER basın.");
        }
    }

    public class Labyrinth
    {
        char[][] matrix;
        string path;
        List<int> x = new List<int>();
        List<int> y = new List<int>();
        int i = 0, j = 0;
        char temp;

        public Labyrinth(string path)
        {
            this.path = path;
            this.matrix = new char[30][];
        }
        public bool CanMoveRight(bool check)
        {
            if (check)
            {
                if (j != 30)
                {
                    j++;
                    temp = this.matrix[i][j];
                    if (temp == '0')
                    {
                        RoadMapX();
                        this.matrix[i][j] = '*';
                        CanMoveRight(true);
                    }
                    else
                    {
                        j--;
                        return false;
                    }
                }
            
            }
            return false;
        }
        public bool CanMoveLeft(bool check)
        {
            if (check)
            {
                if (j != 0)
                {
                    j--;
                    temp = this.matrix[i][j];
                    if (temp == '0')
                    {
                            RoadMapX();
                            this.matrix[i][j] = '*';
                            CanMoveLeft(true);
                    }
                    else
                    {
                        j++;
                        return false;
                    }
                }
            }
            return false;
        }
        public bool CanMoveUp(bool check)
        {
            if (check)
            {
                if (i != 0)
                {
                    i--;
                    temp = this.matrix[i][j];
                    if (temp == '0')
                    {
                            RoadMapY();
                            this.matrix[i][j] = '*';
                            CanMoveUp(true);
                    }
                    else
                    {
                        i++;
                        return false;
                    }
                }
            }
            return false;
        }
        public bool CanMoveDown(bool check)
        {
            if (check)
            {
                if (i != 30)
                {
                    i++;
                    temp = this.matrix[i][j];
                    if (temp == '0')
                    {
                            RoadMapY();
                            this.matrix[i][j] = '*';
                            CanMoveDown(true);
                    }
                    else
                    {
                        i--;
                        return false;
                    }
                }
            }
            return false;
        }
        public void RoadMapX()
        {
            x.Add(j);
        }
        public void RoadMapY()
        {
            y.Add(i);
        }
        public void Move() //button press,
        {
            temp = this.matrix[i][j];

            while (true)
            {
                while (false != CanMoveRight(true))
                    CanMoveRight(true);

                while (false != CanMoveLeft(true))
                    CanMoveLeft(true);

                while (false != CanMoveUp(true))
                    CanMoveUp(true);

                while (false != CanMoveDown(true))
                    CanMoveDown(true);

                Thread.Sleep(200);
                Console.Clear();
                Print();
            }
            
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
            LabyrinthCounter C = new LabyrinthCounter();
            C.Counter();

            for (int i = 0; i < 30; i++)
            {
                for (int j = 0; j < 30; j++)
                {
                    Console.Write(this.matrix[i][j]);
                }
                Console.WriteLine();
            }

            C.PrintCounter();

            foreach (int item in x)
            {
                Console.Write(item);
            }

            foreach (int item in y)
            {
                Console.Write(item);
            }
        }
    }
}
