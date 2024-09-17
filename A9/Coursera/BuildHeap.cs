using System;
using System.Linq;
using System.Collections.Generic;

class BuildHeap
{
    public class Swap {
        public int index1;
        public int index2;

        public Swap(int index1, int index2, int[] h) {
            this.index1 = index1;
            this.index2 = index2;
            int tmp = h[index1];
            h[index1] = h[index2];
            h[index2] = tmp;
        }
    }

    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        var data = Console.ReadLine().Split().Select(s => int.Parse(s)).ToArray();
        List<Swap> swaps = BuildHeapF(data,n);
        Console.WriteLine(swaps.Count);
        foreach (Swap s in swaps)
        {
            Console.WriteLine(s.index1 + " " + s.index2);
        }

    }
    public static void SiftDown(int i , int size, int[] H, List<Swap> ans)
    {
        int minIndex = i;
        
        int l = 2*i + 1;// left child
        if ( l < size )
            if (H[l] < H[minIndex])
                minIndex = l;
        
        int r = 2*i + 2;// right child
        if ( r < size )
            if (H[r] < H[minIndex])
                minIndex = r;
        
        if (i != minIndex)
        {
            ans.Add(new Swap(i,minIndex,H));
            SiftDown(minIndex,size,H,ans);
        }

    }

        private static List<Swap> BuildHeapF(int[] data, int n)
        {
            List<Swap> ans = new List<Swap>(4*n);
            for (int i = (n/2) - 1; i >= 0; i--)
            {
                SiftDown(i,n,data,ans);
            }
            return ans;
        }
    }
