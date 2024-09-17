using System;

public class Sorting {
    private static Random random = new Random();
    private static int partition2(int[] a, int l, int r) { // Unique
        int x = a[l];
        int j = l,t;
        for (int i = l + 1; i < r; i++) {
            if (a[i] <= x) {
                j++;
                t = a[i];
                a[i] = a[j];
                a[j] = t;
            }
        }
        t = a[l];
        a[l] = a[j];
        a[j] = t;
        return j;
    }

    // _# choose pivot_
    // swap a[n,rand(1,n)]

    // _# 3-way partition_
    // i = 1(larger) , j = 1(smaller) , p = n(equals)
    // while i < p,
    // if a[i] < a[n], swap a[i++,j++]
    // else if a[i] == a[n], swap a[i,--p]
    // else i++
    // end
    // _→ invariant: a[p..n] all equal_
    // _→ invariant: a[1..j-1] < a[p..n] < a[j..p-1]_

    // _# move pivots to center_
    // m = min(p-j,n-p+1) // وسطی ها نیاز به عوض شدن ندارند
    // swap a[j..j+m-1 , n-m+1..n]

    // _# recursive sorts_
    // sort a[1..j-1]
    // sort a[n-p+j+1,n]
    private static int[] partition3(int[] a, int l, int r) 
    {   // not unique
        //write your code here
        // int k = random.Next(r - l + 1);
        // // swap
        // int t = a[r];
        // a[r] = a[k];
        // a[k] = t;
        
        int pivot = a[r];
        int i = l,j = l,p = r,t;
        while (i < p)
        {
            if (a[i] < pivot)
            {
                t = a[i];
                a[i] = a[j];
                a[j] = t;
                i++;j++;
            }
            else if (a[i] == pivot)
            {
                p--;
                t = a[i];
                a[i] = a[p];
                a[p] = t;
            }
            else
                i++;
        }
        int m = Math.Min(p-j,r-p+1);
        for (int z = 0; z < m; z++)
        {
            t = a[j+z];
            a[j+z] = a[r-m+1+z];
            a[r-m+1+z] = t;
        }
        int pivot1 = j;// 

        int pivot2 = r-p+j;// r-(p-j)

        return new int[2] { pivot1, pivot2 };
    }


    private static void randomizedQuickSort(int[] a, int l, int r) {
        if (l >= r) {
            return;
        }
        // int k = random.Next(r - l + 1);
        // // swap
        // int t = a[r];
        // a[r] = a[k];
        // a[k] = t;
        //use partition3
        // int[] m = partition3(a, l, r);
        // randomizedQuickSort(a, l, m[0] - 1);
        // randomizedQuickSort(a, m[1] + 1, r);
        while (l<r)
        {
            int[] m = partition3(a, l, r);
            if (m[0]-l < r-m[1])
            {
                randomizedQuickSort(a,l, m[0] -1 ); // m[0] - 1
                l = m[1] + 1;
            }
            else
            {
                randomizedQuickSort(a, m[1] + 1 , r); // m[1] + 1
                r = m[0] - 1;
            }
        }
    }

    public static void Main(string[] args) 
    {
        int n = int.Parse(Console.ReadLine());
        int[] a = new int[n];
        string[] tokens = Console.ReadLine().Split();
        for (int i = 0; i < n; i++) {
            a[i] = int.Parse(tokens[i]);
        }
        randomizedQuickSort(a, 0, n - 1);
        for (int i = 0; i < n; i++) {
            Console.Write(a[i] + " ");
        }
        Console.ReadKey();

        // int N = 15,M = 20;
        // int n;
        // Random r = new Random();
        // while (true )
        // {
        //     n = r.Next(2,N);
        //     int[] A = new int[n];
        //     for (int i = 0; i < n; i++)
        //         A[i] = r.Next(0,M);
        //     for (int i = 0; i < n; i++)
        //         Console.Write(A[i] + " ");
        //     Console.WriteLine();
        //     var result1 = A.OrderBy(n => n).ToArray();
        //     randomizedQuickSort(A,0,n-1);
        //     for (int i = 0; i < n; i++)
        //     {
        //         if (result1[i] == A[i])
        //             System.Console.WriteLine("OK");
        //         else
        //         {
        //             System.Console.WriteLine("Wrong answer: " + result1.ToString() + A.ToString());
        //             return;
        //         }
        //     }
            
        // }
        // Console.ReadKey();
        //8 
        // 8 7 6 5 4 3 2 1
        // 14 
        // 18 14 4 19 7 6 11 11 16 16 0 7 2 18
        // 13
        // 4 19 6 18 3 3 3 14 15 1 3 7 2

        // 1 0 0 11 13 14 13 2
    }
}