using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

namespace LabirentCozme
{
    public class Labyrinth
    {
        string path;
        List<int> xPos;
        List<int> yPos;
        int i = 0, j = 0;
        Random Random;
        char[][] matrix;
        char[,] matrix1;
        char[] matrixElement = { '0', '1' };

        public Labyrinth(string path) // Constructor
        {
            this.path = path; //bilgisayardan okunan labirent dosyasının bulunduğu konumu tutan değişken.
            matrix = new char[30][]; //klasörden okunan labirentin kaydedildiği matris.
            matrix1 = new char[30, 63]; //CreateLabyrinth fonksiyonu için kullanılan matris.
            Random = new Random();
            xPos = new List<int>(); // matrisin i ve j kordinatlarının tutulduğu list.
            yPos = new List<int>();
        }

        public void Bomb()
        {
            for (int i = 0; i < 3; i++)
            {
                int column = Random.Next(0, 30);
                int row = Random.Next(0, 30);

                char temp2 = matrix[row][column];

                if (temp2 == '0')
                    this.matrix[row][column] = '2';
            }

        }

        public void CreateLabyrinth() //labirent oluşturmak için kullanılıyor.
        {
            int i = 0, j = 0, c;

            matrix1[0, 0] = '{'; // ilk '{' ekliyor.
            for (int a = 0; a < 30; a++)
            {
                matrix1[a, 1] = '{'; // her satırın başına '{' ekliyor.
                for (j = 2; j < 61; j += 2) // döngü satırın başından sonuna kadar '0','1' ve ',' ekliyor.
                {
                    int element = Random.Next(0, matrixElement.Length); // '0' veya '1' random belirleniyor.
                    matrix1[a, j] = matrixElement[element];
                    if (j != 60)
                    {
                        matrix1[a, j + 1] = ',';
                    }
                }
                matrix1[a, 61] = '}';
                matrix1[a, 62] = ','; // her satır bitiminde '}' ve ',' ekleniyor.
            }
            matrix1[29, 62] = '}'; // son '}' ekleniyor ve labirent tamamlanıyor.

            //********* labirent çözümü labirente ekleniyor ************//
            i = 0;
            var startX = Random.Next(30, 62);
            var firstDown = Random.Next(1, 10);
            var firstLeft = Random.Next(1, 9);

            int x = startX, y = 0;

            if (matrix1[1, startX] == ',')
            {
                startX++;
            }

            matrix1[0, startX] = 'X';

            x = startX;
            y = 0;

            for (int a = 0; a < firstDown; a++)
            {
                 matrix1[a, startX] = 'X';
            }

            x = startX;
            y = firstDown;

            for (int cc = 0; cc < firstLeft; cc++)
            {
                 matrix1[y, x] = 'X';
                x -= 2;
            }

            for (int b = 0; b < 99; b++)
            {
                matrix1[y, x] = 'X';
                if (y == 29) break;
                y++; 
            }

            //oluşturulan labirent matrisi txt belgesine kaydediliyor.
            using (TextWriter tw = new StreamWriter(program.workingDir + @"/../../../labirentler/YeniLabirent.txt"))
            {
                for (j = 0; j < 30; j++)
                {
                    for (i = 0; i < 63; i++)
                    {
                        tw.Write(matrix1[j, i]);
                    }
                    tw.WriteLine();
                }
            }
        }

        public void RoadMap() // Gidilen yol listeye i=y(dikey eksen) ve j=x(yatay eksen) olarak kayıt ediliyor.
        {
            xPos.Add(j);
            yPos.Add(i);
        }

        public void Move(System.ConsoleKey direction)
        {
            int x = 0, y = 0; // gitmek istediğim kordinatlar

            switch (direction)
            {
                case ConsoleKey.UpArrow:
                    {
                        x = j;
                        y = i - 1;
                        break;
                    }
                case ConsoleKey.DownArrow:
                    {
                        x = j;
                        y = i + 1;
                        break;
                    }
                case ConsoleKey.RightArrow:
                    {
                        x = j + 1;
                        y = i;
                        break;
                    }
                case ConsoleKey.LeftArrow:
                    {
                        x = j - 1;
                        y = i;
                        break;
                    }
            }

            if (x > 30) x = 30;
            if (y > 30) y = 30;

            if (x < 0) x = 0;
            if (y < 0) y = 0;

            char temp = this.matrix[y][x];

            if (temp == '1') return;

            matrix[y][x] = '*';
            matrix[i][j] = '0';
            j = x;
            i = y;

            RoadMap();
        }


        // {{0,0,1,*,0,0,1,0,0,0,1,0,0,1,0,1,1,0,1,0,0,0,0,0,0,1,1,1,0,1},
        //  {0,1,1,1,1,*,1,1,0,0,0,1,0,0,0,0,0,0,1,1,0,1,0,1,0,1,0,1,1,1},
        //  {1,1,0,1,1,0,0,*,1,1,0,0,1,0,1,0,0,1,0,1,1,0,0,0,0,1,1,1,1,1},
        //  {1,0,1,1,1,0,1,0,0,*,1,1,0,1,1,0,1,1,1,1,1,0,0,0,0,0,1,0,1,0},
        //  {1,1,1,0,0,0,0,0,1,1,0,*,1,1,1,1,0,0,0,1,1,1,1,1,1,0,1,1,1,0},
        //  {1,1,1,0,1,0,0,1,1,1,1,1,0,0,0,0,1,1,0,0,0,0,1,1,0,1,1,1,1,1},

        public bool canGoDown()
        {
            if (i > 28)
                i = 28;  
            
            return matrix[i + 1][j] == '0';
        }

        public void FindSolution() // i = y yani kordinat düzleminde yukarı
        {

            while (i < 30)
            {
                for (var a = 0; a < 30; a++) // satırı gez
                {
                    j = a;
                    if (canGoDown()) // her satırda assayı kontrol et
                    {
                        matrix[i][j] = 'X';
                        i = i + 1;
                        break;
                    };
                }
                Thread.Sleep(500);
                Print();
            }
        }


        public void Menu()
        {
            Console.Clear();
            Console.WriteLine("************************ \n Lütfen seçim yapınız: \n [Yol Kordinatları için 'X']" +
                "\n [Bombaların kordinatları için 'B'] \n [Labirentin orjinal hali için 'L'] \n" +
                "seçip ENTER tuşuna basın. \n ************************");
            var select = Console.ReadLine();
            switch (select)
            {
                case "X":
                case "x":
                    PrintRoadMap();
                    break;
                case "B":
                case "b":
                    break;
                case "L":
                case "l":
                    FindSolution();
                    break;
                default:
                    Console.WriteLine("Yanlış bir seçim yaptınız.");
                    break;
            }
        }

        public void MoveThread() //hareket yönetimi
        {
            matrix[0][0] = '*';

            while (true)
            {
                var command = Console.ReadKey().Key;

                if (ConsoleKey.DownArrow == command)
                    Move(ConsoleKey.DownArrow);
                if (ConsoleKey.RightArrow == command)
                    Move(ConsoleKey.RightArrow);
                if (ConsoleKey.LeftArrow == command)
                    Move(ConsoleKey.LeftArrow);
                if (ConsoleKey.UpArrow == command)
                    Move(ConsoleKey.UpArrow);

                Print();
            }

            // while (true)
            // {
            //     if (wall != 1)
            //     {
            //         MoveRight();
            //         Print();
            //         if (wall != 1)
            //         {
            //             MoveDown();
            //             Print();
            //             if (i != -1 && wall != 1)
            //             {
            //                 MoveUp();
            //                 Print();
            //             }

            //         }

            //     }

            // }



        }

        public void ReadLabyrinth() //matris oluşturuluyor.
        {
            char[][] data = File.ReadLines(this.path).Select(line => line.ToCharArray()).ToArray();

            for (int i = 0; i < 30; i++)
            {
                data[i] = Array.FindAll(data[i], c => (c == '1' || c == '0'));
            }
            this.matrix = data; // matrisler kopyalanıyor.
        }

        private void CheckAndResetWindowSize()
        {
            if (Console.WindowHeight != 50 || Console.WindowWidth != 45)
            {
                Console.SetWindowSize(50, 45);
            }
        }

        public void PrintRoadMap() // gidilen yolu matris üzerine ekliyor
        {
            foreach (int item2 in yPos) // dikey eksen matrisin i değeri
            {
                foreach (int item1 in xPos) // yatay eksen matrisin j değeri
                {
                    matrix[item2][item1] = 'X';
                }
            }
            Print();
        }
        public void Print() // matrisi ekrana yazdırıyor
        {
            Console.Clear();

            CheckAndResetWindowSize();

            for (int i = 0; i < 30; i++)
            {
                for (int j = 0; j < 30; j++)
                {
                    Console.Write(this.matrix[i][j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine("*****************************");
        }

    }
}
