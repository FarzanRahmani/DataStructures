using System;

public class MajorityElement {
    class Program
    {

        private static int getMajorityElement(int[] a, int left, int right) {
            // Array.Sort(a);
            // int temp = a[0],cnt = 1;
            // int majority = (a.Length / 2) + 1;
            // for (int i = 1; i < a.Length; i++)
            // {
            //     if (cnt >= majority)
            //         return 1;
                
            //     if (a[i] == temp)
            //         cnt++;
            //     else
            //     {
            //         temp = a[i];
            //         cnt = 0;
            //     }
            // }
            // if (cnt >= majority)
            // {
            //     return 1;
            // }
            // return 0;

            // ----------------
            int n = a.Length;
            Dictionary<int,int> records = new Dictionary<int, int>(n);
            for (int i = 0; i < n; i++)
                records[a[i]] = 0;

            for (int i = 0; i < n; i++)
                records[a[i]]++;
            
            int max_cnt = records.Values.Max(); 
            int majority = (a.Length / 2) + 1;
            if ( max_cnt >= majority)
                return 1;
            else
                return 0;

            // ----------------
            // recursive
            // if (left == right) {
            //     return -1;
            // }
            // if (left + 1 == right) {
            //     return a[left];
            // }
            // //write your code 
            // int mid = (right - left)/2 + left;
            // // getMajorityElement(a,left,mid);
            // // getMajorityElement(a,mid+1,right);
            
            // int leftDiv = getMajorityElement(a,left,mid);
            // int rightDiv = getMajorityElement(a,mid+1,right);
            // if (leftDiv == rightDiv)
            //     return leftDiv;

            // // if (getMajorityElement(a,left,mid) + getMajorityElement(a,mid+1,right) <= mid)
            // //     return -1;
            // return -1;
        }

        public static void Main(string[] args) 
        {
            int n = int.Parse(Console.ReadLine());
            int[] a = new int[n];
            string[] tokens = Console.ReadLine().Split();
            for (int i = 0; i < n; i++) {
                a[i] = int.Parse(tokens[i]);
            }
            Console.WriteLine(getMajorityElement(a, 0, a.Length));
            Console.ReadKey();
        }


    }
}

