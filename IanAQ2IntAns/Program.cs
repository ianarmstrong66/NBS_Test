using System;

namespace IanAQ2IntAns
{
    class Program
    {
        static void Main(string[] args)
        {
            Fix_Solution test = new Fix_Solution();
            int X = 7, Y = 3, response = -1;
            //int[] A = { 13, 13, 6, 8, 4, 7, 14, 8, 7, 7, 6 };
            int[] A = {0, 13, 13, 7, 3, 6, 8, 4, 7, 14, 8, 3, 7, 7, 13, 5, 13, 3, 8, 4, 1, 6 };
            response = test.Solution(X, Y, A);
            if (response == -1)
            {
                Console.WriteLine("The equal occurances in the array have not been established");
            }
            else
            {
                Console.WriteLine("The longest leading fragment of array in which there is an equal number of occurrences is {0}", response);
            }
            Console.WriteLine("Press Enter to close");
            Console.ReadLine();
        }
    }
    public class Fix_Solution
    {
        public int Solution(int X, int Y, int[] A)
        {
            int N = A.Length;
            int nX = 0;
            int nY = 0;
            int result = -1;
            for (int i = 0; i < N; i++)
            {
                if (A[i] == X)
                    nX += 1;
                else if (A[i] == Y)
                    nY += 1;
                if (nX == nY && nX != 0)  // Ensure that no correct matchs are not part of the prefix
                    result = i;
            }
            return result;
            //int N = A.Length;         //The original with bugs.
            //int nX = 0;
            //int nY = 0;
            //int result = -1;
            //for (int i = 0; i < N; i++)
            //{
            //    if (A[i] == X)
            //        nX += 1;
            //    else if (A[i] == Y)
            //        nY += 1;
            //    if (nX == nY)
            //        result = i;
            //}
            //return result;
        }
    }
}