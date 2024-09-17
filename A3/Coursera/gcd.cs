
public class GCD {
    private static int gcd(int a, int b) {
        // int current_gcd = 1;
        // for(int d = 2; d <= a && d <= b; ++d) {
        //     if (a % d == 0 && b % d == 0) {
        //         if (d > current_gcd) {
        //             current_gcd = d;
        //         }
        //     }
        // }
        // return current_gcd;
        if ( b == 0)
            return a;
        return gcd(b,a%b);
    }

    public static void Main(string[] args) {
        string[] tokens = System.Console.ReadLine().Split();
        int a = int.Parse(tokens[0]);
        int b = int.Parse(tokens[1]);
        System.Console.WriteLine(gcd(a,b));
    }
}
