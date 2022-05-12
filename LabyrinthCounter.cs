using System;
using System.Collections.Generic;
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
}
