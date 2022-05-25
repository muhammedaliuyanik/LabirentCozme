using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

namespace LabirentCozme
{
    public class Labyrinth
    {
        char temp2;
        string path;
        List<int> xPos;
        List<int> yPos;
        int i = 0, j = 0, column, row;
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
        
        public bool RandomBombColumnRow() // bombanın kordinatlarını random belirliyor.
        {
            column = Random.Next(0, 28);
            row = Random.Next(0, 28);

            if (matrix[row][column] == '0')
            {
                matrix[row][column] = 'B';
            }
                
            return matrix[row][column] == 'B';
        }

        public void Bomb() // labirentte yol üzerinde Rastgele 3 yere bomba yerleştiriyor.
        {
            for (int i = 0; i < 4; i++)
            {
                while (RandomBombColumnRow() != true);     
            }
            
            Print();
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

        public void Move(System.ConsoleKey direction) // hareketler up down left right
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

        public bool canGoDown() // FindSolution a bağlı aşağı gidilebilir mi kontrolü
        {
            if (i > 28)
                return false;

            if (matrix[i + 1][j] == '0')
                return true;
            else
            return false;
        }

        public void FindSolution() // labirent çözüm algoritması
        {

            while (i < 30)
            {
                for (var a = 0; a < 30; a++) // satırı gez
                {
                    j = a;
                    int tempi = i;
                    if (canGoDown()) // her satırda assayı kontrol et
                    {
                        matrix[i][j] = 'X';
                        RoadMap();
                        i = i + 1;
                        break;
                    }
                    else if (!canGoDown())
                    {
                        i = tempi;
                        matrix[i][j] = 'X';
                        RoadMap();
                        break;
                    }
                }
                Thread.Sleep(1000);
                Print();
            }
        }

        public void Menu()
        {
            Console.Clear();
            Console.WriteLine("************************ \n Lütfen seçim yapınız: \n [Yol Kordinatları için 'X']" +
                "\n [Bombaların kordinatları için 'B'] \n [Labirentin orjinal hali için 'L'] \n" +
                " seçip ENTER tuşuna basın. \n ************************");
            var select = Console.ReadLine();
            switch (select)
            {
                case "X":
                case "x":
                    FindSolution(); // Labirent çözümü bulunuyor.
                    PrintRoadMap();
                    break;
                case "B":
                case "b":
                    Bomb();
                    break;
                case "L":
                case "l":
                    Print();
                    break;
                default:
                    Console.WriteLine("Yanlış bir seçim yaptınız.");
                    return;
            }
        }

        public void MoveThread() //hareket yönetimi manuel
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

        }

        public void ReadLabyrinth() // labirent okunup matris oluşturuluyor.
        {
            char[][] data = File.ReadLines(this.path).Select(line => line.ToCharArray()).ToArray();

            for (int i = 0; i < 30; i++)
            {
                data[i] = Array.FindAll(data[i], c => (c == '1' || c == '0'));
            }
            this.matrix = data; // matrisler kopyalanıyor.
        }

        public void RoadMap() // Gidilen yol listeye i=y(dikey eksen) ve j=x(yatay eksen) olarak kayıt ediliyor.
        {
            xPos.Add(j);
            yPos.Add(i);
        }

        public void PrintRoadMap() // gidilen yolu matris üzerine ekliyor ve ekrana yazdırıyor.
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

        private void CheckAndResetWindowSize()
        {
            if (Console.WindowHeight != 50 || Console.WindowWidth != 45)
            {
                Console.SetWindowSize(50, 45);
            }
        } // console ekranı boyutunu ayarlıyor

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

