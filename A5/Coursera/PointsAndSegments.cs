using System;
using System.Collections.Generic;
using System.Linq;
public class PointsAndSegments 
{

    static int[] fastCountSegments(int[] starts, int[] ends, int[] points)
    {
        int NumberOfPoints = points.Length;
        int NumberOfSegments = starts.Length;

        List<int[]> pts = new List<int[]>(NumberOfPoints);
        List<int[]> seg = new List<int[]>(NumberOfSegments);
        
        for(int i = 0; i < NumberOfPoints; i++)
            pts.Add(new int[]{points[i], i});
        
        for(int i = 0; i < NumberOfSegments; i++)
        {
            seg.Add(new int[]{starts[i], 1});
            
            seg.Add(new int[]{ends[i] + 1, -1});
        }
        
        seg.Sort( (a,b) => b[0] - a[0]);

        pts.Sort( (a,b) => a[0] - b[0]);
        
        int count = 0;
        int[] ans = new int[NumberOfPoints];
        
        for(int i = 0; i < NumberOfPoints; i++)
        {
            int x = pts[i][0];
            
            while (seg.Count() != 0 &&
                    seg[seg.Count - 1][0] <= x)
            {
                count += seg[seg.Count - 1][1];
                seg.RemoveAt(seg.Count - 1);
            }
            ans[pts[i][1]] = count;
        }
        
        return ans;
    }


    // public static int binarySearchWithDuplicates(int[] a, int low, int high, int x) 
    // {
    //     int endIndex = 0;
    //     while (high >= low)
    //     {
    //         int mid = low + (high - low)/2;
    //         if (x == a[mid])
    //         {
    //             for(int i = mid; i < high; i++)
    //                 if(a[i] != x)
    //                     return i-1;
    //             return mid;
    //         }
    //         else if (x < a[mid])
    //         {
    //             high = mid - 1;
    //             endIndex = mid-1;
    //         }
    //         else
    //         {
    //             low = mid + 1;
    //         }
    //     }
    //     return endIndex; // -1
    // }


    // private static int[] fastCountSegments(int[] starts, int[] ends, int[] points) {
    //     int[] cnt = new int[points.Length];
    //     int n = starts.Length;
    //     Dictionary<int,int> sortedByStart = new Dictionary<int, int>(n);
    //     for (int i = 0; i < n; i++)
    //         sortedByStart[starts[i]] = ends[i];
    //     Array.Sort(starts);
    //     for (int i = 0; i < points.Length; i++)
    //     {
    //         for (int j = 0; j <= binarySearchWithDuplicates(starts,0,n,points[i]); j++)
    //         {
    //             if (starts[j] <= points[i] && sortedByStart[starts[j]] <= ends[j]) {
    //                 cnt[i]++;
    //             }
    //         }
    //     }
    //     //write your code here
    //     return cnt;
    // }

    // private static int[] fastCountSegments(int[] starts, int[] ends, int[] points) {
    //     int numberOfSegments = starts.Length;
    //     int numberOfPoints = points.Length;
    //     Array.Sort(starts);
    //     Array.Sort(ends);

    //     int firstOfStart = starts[0];
    //     int lastOfEnds = ends[numberOfSegments-1];

    //     int len = lastOfEnds - firstOfStart + 2;
    //     int[] answers = new int[len];

    //     int temp = 0,startIndex = 0,endIndex = 0;
    //     // for (int i = 0; i < len; i++)
        
    //     for (int i = firstOfStart; i <= lastOfEnds; i++)
    //     {
    //         if (startIndex < numberOfSegments)
    //             if (starts[startIndex] == i )
    //             {
    //                 temp++;
    //                 startIndex++;
    //                 if (startIndex < numberOfSegments)
    //                     while (starts[startIndex] == i)
    //                     {
    //                         temp++;
    //                         startIndex++;
    //                         if(startIndex >= numberOfSegments)
    //                             break;
    //                     }
    //             }
            
    //         if(i<0)
    //             answers[i+len-1] = temp;//answers[i]
    //         else
    //             answers[i] = temp;
            
    //         if(endIndex < numberOfSegments)
    //             if (ends[endIndex] == i )
    //             {
    //                 temp--;
    //                 endIndex++;
    //                 if(endIndex < numberOfSegments)
    //                     while (ends[endIndex] == i)
    //                     {
    //                         temp--;
    //                         endIndex++;
    //                         if(endIndex >= numberOfSegments)
    //                             break;
    //                     }
    //             }
    //     }
    //     // answers[firstOfStart] = 1;
    //     // answers[lastOfEnds] = 1;

    //     int[] cnt = new int[numberOfPoints];
    //     for (int i = 0; i < numberOfPoints; i++)
    //     {
    //         if (points[i] < firstOfStart || points[i] > lastOfEnds)
    //             cnt[i] = 0;
    //         else
    //         {
    //             if ( i < 0)
    //                 cnt[i] = answers[points[i]+len-1];//answers[i]
    //             else
    //                 cnt[i] = answers[points[i]];
    //         }
    //     }
    //     //write your code here
    //     return cnt;
    // }

    private static int[] naiveCountSegments(int[] starts, int[] ends, int[] points) 
    {
        int[] cnt = new int[points.Length];
        for (int i = 0; i < points.Length; i++) 
            for (int j = 0; j < starts.Length; j++) 
                if (starts[j] <= points[i] && points[i] <= ends[j]) 
                    cnt[i]++;
        
        return cnt;
    }

    public static void Main(string[] args) {

// 4 4
// 1 5
// 2 5
// 3 5
// 4 5
// 2 3 5 5

// 3 4
// 1 2
// 1 3
// 1 4
// 1 2 3 4

        int n, m;
        int[] tokens = Console.ReadLine().Split().Select(s => int.Parse(s)).ToArray();
        n = tokens[0];
        m = tokens[1];

        int[] starts = new int[n];
        int[] ends = new int[n];
        int[] points = new int[m];
        for (int i = 0; i < n; i++) {
            tokens = Console.ReadLine().Split().Select(s => int.Parse(s)).ToArray();
            starts[i] = tokens[0];
            ends[i] = tokens[1];
        }

        tokens = Console.ReadLine().Split().Select(s => int.Parse(s)).ToArray();
        for (int i = 0; i < m; i++) {
            points[i] =tokens[i];
        }
        //use fastCountSegments
        int[] cnt = fastCountSegments(starts, ends, points);
        foreach (var x in cnt)
            Console.Write(x + " ");

        Console.ReadKey();
    }
}