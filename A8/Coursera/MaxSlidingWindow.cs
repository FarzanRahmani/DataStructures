using System;
using System.Collections.Generic;
using System.Linq;

class SlidingWindow
{
    public static void max_sliding_window_naive(List<int>  A, int w) {
        // for (int i = 0; i < A.Count - w + 1; ++i) {
        //     int window_max = A[i];
        //     for (int j = i + 1; j < i + w; ++j)
        //         window_max = Math.Max(window_max, A[j]);

        //     Console.Write(window_max + " ");
        // }

        Stack<int> MainStack = new Stack<int>();
        List<int> maxIMainStack = new List<int>(w+1);
        maxIMainStack.Add(0);
        int maxMainStack = 0;

        Stack<int> Stack2 = new Stack<int>();
        List<int> maxIStack2 = new List<int>(w+1);
        maxIStack2.Add(0);
        int maxStack2 = 0;

        int tmp = 0, cnt1 = 0 , cnt2 = 0;
        for (int i = 0; i < w-1; i++)
        {
            tmp = A[i];
            MainStack.Push(tmp);
            if (tmp > maxMainStack)
                maxMainStack = tmp;
            maxIMainStack.Add(maxMainStack); 
        }

        for (int i = w-1; i < A.Count; i++)
        {
            tmp = A[i];
            MainStack.Push(tmp);
            if (tmp > maxMainStack)
                maxMainStack = tmp;
            maxIMainStack.Add(maxMainStack);

            if (Stack2.Count < 1)
            {
                cnt2 = MainStack.Count;
                for (int j = 0; j < cnt2; j++)
                {
                    tmp = MainStack.Pop();
                    Stack2.Push(tmp);

                    cnt1 = MainStack.Count;
                    maxMainStack = maxIMainStack[cnt1]; // MainStack Pop()
                    maxIMainStack.RemoveAt(cnt1+1);

                    if (tmp > maxStack2)// Stack2 Push()
                        maxStack2 = tmp;
                    maxIStack2.Add(maxStack2);
                }
            }

            Console.Write(Math.Max(maxMainStack,maxStack2)  +  " ");

            Stack2.Pop();
            cnt1 = Stack2.Count;
            maxStack2 = maxIStack2[cnt1]; // MainStack Pop()
            maxIStack2.RemoveAt(cnt1+1);

        }
    }

    static void Main(string[] args) {
        int n = int.Parse(Console.ReadLine());

        List<int> A = new List<int>(n); // ArrayList
        int[] tokens = Console.ReadLine().Split().Select(s => int.Parse(s)).ToArray();
        for (int i = 0; i < n; ++i)
            A.Add(tokens[i]);

        int m = int.Parse(Console.ReadLine());

        max_sliding_window_naive(A, m);
        // ConsoleKeyInfo ckin = Console.ReadKey();
        // System.Console.WriteLine(ckin.Key);
    }

}