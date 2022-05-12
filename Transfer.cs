using System;
using System.Collections.Generic;
using System.Text;

namespace LabirentCozme
{
    public class Transfer //matriste transfer işlemleri yapar
    {
        public static void LabyrinthTransfer(char[][] data)
        {
            string[,] temp = new string[30, 63];

            for (int i = 0; i < 30; i++)
            {
                for (int j = 0; j < 63; j++)
                {
                    temp[i, j] = data[i][j].ToString().Trim(new char[] { ' ', ',', '{', '}' });
                }
            }
            //PrintMatrix.Show(temp);
            Move.LabyrinthMove(temp);
        }
    }
}
