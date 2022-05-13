using System;
using System.Collections.Generic;
using System.Text;

namespace LabirentCozme
{
    public class Move //labirent içerisinde hareket etme algoritması
    {
        public static void LabyrinthMove(string[,] matrix)
        {
            for (int i = 0; i < 30; i++)
            {
                for (int j = 1; j < 63; j++)
                {
                    string temp = matrix[i, j];

                    if (temp != "1" || temp != "-")
                    {
                        matrix[i, j] = "-";
                        while (j == 0)
                        {
                            j--;
                        }
                    }   
                }
            }
            PrintMatrix.Show(matrix);
        }
    }
}
