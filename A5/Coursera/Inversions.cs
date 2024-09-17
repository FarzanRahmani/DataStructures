using System;
using System.Linq;
class Invversions
{
    public class InvAndArray
    {
        public long num;
        public int[] array;

        public InvAndArray(long num, int[] array)
        {
            this.num = num;
            this.array = array;
        }
    }
    public static InvAndArray Merge(int[] b,int[] c)
    {
        int bLength = b.Length;
        int cLength = c.Length;
        int size = bLength + cLength;
        int[] d = new int[size];
        int b_i = 0,c_i = 0;
        long ans = 0;

        for (int i = 0; i < size; i++)
        {
            if (b_i == bLength)
            {
                for (int j = c_i; j < cLength; j++)
                {
                    d[i] = c[j];i++;
                }
                break;
            }

            if (c_i == cLength)
            {
                for (int j = b_i; j < bLength; j++)
                {
                    d[i] = b[j];i++;
                }
                break;
            }

            int tempB = b[b_i];
            int tempC = c[c_i];
            if ( tempB <= tempC)
            {
                d[i] = tempB;
                b_i++;
            }
            else // tempB > tempC
            {
                ans += bLength - b_i;
                d[i] = tempC;
                c_i++;
            }
        }
        return new InvAndArray(ans,d);
    }

    // getNumberOfInversions MergeSort
    public static InvAndArray GetNumberOfInversions(int[] a,int n)
    {
        if (n == 1)
            return new InvAndArray(0,a);
        int m = n / 2;
        // InvAndArray b = MergeSort(a[0..m],m);
        // InvAndArray c = MergeSort(a[m..n],n-m);// n-m
        InvAndArray b = MergeSort(a.Take(m).ToArray(),m);
        InvAndArray c = MergeSort(a.Skip(m).ToArray(),n-m);// n-m
        InvAndArray ans = Merge(b.array,c.array);
        ans.num += b.num;
        ans.num += c.num;
        return ans;
    }


    public static void Main(string[] args) 
    {
    int n = int.Parse(Console.ReadLine());
    int[] a = new int[n];
    string[] tokens = Console.ReadLine().Split();
    for (int i = 0; i < n; i++) {
        a[i] = int.Parse(tokens[i]);
    }
    Console.WriteLine(GetNumberOfInversions(a,n).num);
    Console.ReadKey();
    }
}

