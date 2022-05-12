using System;
using System.IO;
using System.Linq;

namespace LabirentCozme
{
    class Matrix
    {
        public static void CreateMatrix(string adress) //matris oluşturulur
        {
            try
            {
                char[][] data = File.ReadLines(adress).Select(line => line.ToCharArray()).ToArray();

                Transfer.LabyrinthTransfer(data);

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
    }
}
