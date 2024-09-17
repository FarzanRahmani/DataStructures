using System;

public class LCM {
    private static int gcd(int a, int b) {
        if ( b == 0)
            return a;
        return gcd(b,a % b);
    }
    private static long lcm(int a, int b) {
        long ans = (long) a * b;
        return ans / gcd(a,b);
    }

    public static void Main(string[] args) {

        string[] tokens = System.Console.ReadLine().Split();
        int a = int.Parse(tokens[0]);
        int b = int.Parse(tokens[1]);
        System.Console.WriteLine(lcm(a,b));
    }
}
