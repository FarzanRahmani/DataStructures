
public class FibonacciLastDigit {
    private static int getFibonacciLastDigitNaive(int n) {
        if (n <= 1)
            return n;

        int previous = 0;
        int current  = 1;

        for (int i = 0; i < n - 1; ++i) {
            int tmp_previous = previous;
            previous = current;
            current = (tmp_previous + current)%10;
        }

        return current;
    }
    
    public static void Main(string[] args) {
        int n = int.Parse(System.Console.ReadLine());
        int c = getFibonacciLastDigitNaive(n);
        System.Console.WriteLine(c);
    }
}

