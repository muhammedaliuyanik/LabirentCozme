using System;
using System.IO;
using System.Linq;

namespace LabirentCozme
{
    class Matris
    {
        public static void LabirentSayisi()
        {
            Console.WriteLine("[******** {0}. Labirent ********]", program.SayacArttır());
            Console.BufferWidth = 130;
            Console.SetWindowSize(Console.BufferWidth, 35);
        }
        public static void MatrisYaz(string adress)
        {
            try
            {
                Matris.LabirentSayisi();

                char[][] data = File.ReadLines(adress).Select(line => line.ToCharArray()).ToArray();

                foreach (var line in data)
                {
                    foreach (char c in line)
                    {
                        Console.Write(c.ToString().Trim(new char[] { ' ', ',', '{', '}' }));
                    }
                    Console.WriteLine();
                }
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
                Console.WriteLine("[****************************]");
                Console.WriteLine("Diğer Labirentleri görmek için ENTER basın.");
                Console.ReadLine();
                Console.Clear();
            }
        }
    }
}
