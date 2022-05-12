using System;
using System.Collections.Generic;
using System.Text;

namespace LabirentCozme
{
    class PrintMatrix //matrisi ekrana yazdırır
    {
        public static void Show(string[,] data)
        {
            LabyrinthCounter.Counter();

            for (int i = 0; i < 30; i++)
            {
                for (int j = 0; j < 63; j++)
                {
                    Console.Write(data[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine("[****************************]");
            Console.WriteLine("Diğer Labirentleri görmek için ENTER basın.");
        }
    }
}
