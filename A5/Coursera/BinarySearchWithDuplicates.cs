using System;
public class binarySearchDuplicates {

        static long binarySearchWithDuplicates(long[] a, long low, long high, long x) 
        {
            int startIndex = -1;
            while (high >= low)
            {
                long mid = low + (high - low)/2;
                if (x == a[mid])
                {
                    // mid--;
                    // if (mid >= 0)
                    //     while (x == a[mid])
                    //         mid--;
                    // return ++mid;
                    // startIndex = mid;
                    // high = mid - 1;
                    for(int i = 0; i < mid; i++)
                        if(a[i] == x)
                            return i;
                    return mid;
                }
                else if (x < a[mid])
                    high = mid - 1;
                else
                    low = mid + 1;
            }
            return startIndex; // -1
        }

        static long linearSearch(long[] a, long x) 
        {
            for (long i = 0; i < a.Length; i++) 
                if (a[i] == x) return i;
            
            return -1;
        }

        public static void Main(string[] args) 
        {
            long n = long.Parse(Console.ReadLine());
            string[] tokens = Console.ReadLine().Split();
            long[] a = new long[n];
            for (long i = 0; i < n; i++) 
                a[i] = long.Parse(tokens[i]);
            
            long m = long.Parse(Console.ReadLine());
            tokens = Console.ReadLine().Split();
            long[] b = new long[m];
            for (long i = 0; i < m; i++) 
                b[i] = long.Parse(tokens[i]);
            
            for (long i = 0; i < m; i++) {
                //replace with the call to binarySearchWithDuplicates when implemented
                Console.Write(binarySearchWithDuplicates(a,0,n-1, b[i]) + " ");
            }
            Console.ReadKey();
        }
}