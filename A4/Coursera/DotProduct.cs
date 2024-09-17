using System;
using System.Linq;
public class DotProduct {
    private static long maxDotProduct(long[] a, long[] b) {
        a = a.OrderBy(n => n).ToArray();
        b = b.OrderBy(n => n).ToArray();
        long result = 0;
        for (long i = 0; i < a.Length; i++) 
            result += a[i] * b[i];
        return result;
    }

    public static void Main(string[] args) {
        long n = long.Parse(Console.ReadLine());
        long[] a = new long[n];
        string[] tokens = Console.ReadLine().Split();
        for (long i = 0; i < n; i++) {
            a[i] = long.Parse(tokens[i]);
        }
        long[] b = new long[n];
        tokens = Console.ReadLine().Split();
        for (long i = 0; i < n; i++) {
            b[i] = long.Parse(tokens[i]);
        }
        System.Console.WriteLine(maxDotProduct(a, b));
    }
}
