using System;
public class BinarySearch {

        static int binarySearch(int[] a, int low, int high, int x) 
        {
            // if (high < low) // bad az high == low (faghat 1 element dare mirese be inja)
            //     return - 1;
            // int mid = low + (high - low)/2;
            // if (x == a[mid])
            //     return mid;
            // else if (x < a[mid])
            //     return binarySearch(a,low,mid -1,x);
            // else
            //     return binarySearch(a,mid+1,high,x);

            while (high >= low)
            {
                int mid = low + (high - low)/2;
                if (x == a[mid])
                    return mid;
                else if (x < a[mid])
                    high = mid - 1;
                else
                    low = mid + 1;
            }
            return -1;
        }

        static int linearSearch(int[] a, int x) 
        {
            for (int i = 0; i < a.Length; i++) 
                if (a[i] == x) return i;
            
            return -1;
        }

        public static void Main(string[] args) 
        {
            int n = int.Parse(Console.ReadLine());
            string[] tokens = Console.ReadLine().Split();
            int[] a = new int[n];
            for (int i = 0; i < n; i++) 
                a[i] = int.Parse(tokens[i]);
            
            int m = int.Parse(Console.ReadLine());
            tokens = Console.ReadLine().Split();
            int[] b = new int[m];
            for (int i = 0; i < m; i++) 
                b[i] = int.Parse(tokens[i]);
            
            for (int i = 0; i < m; i++) {
                //replace with the call to binarySearch when implemented
                Console.Write(binarySearch(a,0,n-1, b[i]) + " ");
            }
            Console.ReadKey();
        }
}
