using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Collections;

namespace IanAQ2IntAns
{
    class Program
    {
        static void Main(string[] args)
        {
            Fix_Solution test = new Fix_Solution();
            Fish_Solution test2 = new Fish_Solution();
            Tree_Solution test3 = new Tree_Solution();
            Random RndA = new Random();
            Random RndB = new Random();
            int X = 0, Y = 3, Z = 100000000, response = -1, response2 = -1;
            //int[] A = { 13, 13, 6, 8, 4, 7, 14, 8, 7, 7, 6 };
            int[] A = { 0, 13, 13, 7, 3, 6, 8, 4, 7, 14, 8, 3, 7, 7, 0, 13, 5, 13, 3, 8, 4, 1, 6 };

            Stopwatch _stopwatch = new Stopwatch();
            Tree TreeA = new Tree();
            TreeA = test3.AddNewNode(5);
            TreeA.l = test3.AddNewNode(4);
            TreeA.r = test3.AddNewNode(14);
            TreeA.l.l = test3.AddNewNode(4);
            TreeA.l.r = test3.AddNewNode(3);
            TreeA.l.r.r = test3.AddNewNode(2);
            TreeA.l.r.l = test3.AddNewNode(12);
            TreeA.l.r.l.r = test3.AddNewNode(5);
            TreeA.l.r.r.l = test3.AddNewNode(32);
            TreeA.l.r.r.r = test3.AddNewNode(42);



            // Run first test
            response = test.Solution(X, Y, A);
            if (response == -1)
            {
                Console.WriteLine("The equal occurances in the array have not been established");
            }
            else
            {
                Console.WriteLine("The longest leading fragment of array in which there is an equal number of occurrences is {0}", response);
            }
            //int[] C = new int[Z];
            //int[] D = new int[Z];

            //for (int i = 0; i < Z; i++)
            //{
            //    C[i] = RndA.Next(1, 100000);
            //    D[i] = RndB.Next(0, 2);
            //}

            //_stopwatch.Start();
            //response2 = test2.Solution(C, D);
            //_stopwatch.Stop();
            //if (response2 == -1)
            //{
            //    Console.WriteLine("looks like either no fish where killed or I got an error");
            //}
            //else
            //{
            //    Console.WriteLine("The number of fish that survived this trip where {0}. This to {1} to work out", response2, _stopwatch.Elapsed.ToString());
            //}
            response = test3.Solution(TreeA);

            Console.WriteLine("Number of nodes is {0}", response);

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
                if (nX == nY && nX != 0)    // ICA Ensure that no correct matchs are not part of the prefix
                    result = i + 1;         // ICA As array starts at 0, add 1 to get the length
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
    public class Fish_Solution
    {
        public int Solution(int[] A, int[] B)
        {
            Stack<int> NoOfFishAlive = new Stack<int>();
            for (int i = 0; i < A.Length; i++)
            {
                if (NoOfFishAlive.Count == 0)
                {
                    NoOfFishAlive.Push(i);
                }
                else
                {
                    while (NoOfFishAlive.Count != 0 &&
                        B[i] - B[NoOfFishAlive.Peek()] == -1 &&
                        A[NoOfFishAlive.Peek()] < A[i])
                    {
                        NoOfFishAlive.Pop();
                    }

                    if (NoOfFishAlive.Count != 0)
                    {
                        if (B[i] - B[NoOfFishAlive.Peek()] != -1)
                        {
                            NoOfFishAlive.Push(i);
                        }
                    }
                    else { NoOfFishAlive.Push(i); }
                }
            }
            return NoOfFishAlive.Count;
        }
    }
    public class Tree_Solution
    {
        public int Solution(Tree A)
        {
            Hashtable t = new Hashtable();
            if (A != null)
            {
                getMaxNumberOfNodes(A, t);
                return t.Count;
            }
            else return 0;
        }
        public void getMaxNumberOfNodes(Tree node, Hashtable t)
        {
            if (node != null)
            {
                if (!t.ContainsKey(node.x))
                {
                    t.Add(node.x, node);
                }
                getMaxNumberOfNodes(node.r, t);
                getMaxNumberOfNodes(node.l, t);
            }
        }
        public Tree AddNewNode(int value)
        {
            Tree A = new Tree();
            A.x = value;
            return A;
        }
    }

    public class Tree
    {
        public int x;
        public Tree l;
        public Tree r;
    }
}