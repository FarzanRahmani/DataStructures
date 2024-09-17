using System;
public class CarFueling {
    static int computeMinRefills(int dist, int tank, int n, int[] stops) {
        int numRefills = 0;
        int currentRefill = 0;
        int lastRefill;
        while (currentRefill <= n)
        {
            lastRefill = currentRefill;
            while (currentRefill <= n && stops[currentRefill + 1] - stops[lastRefill] <= tank) // geddy choice which is a safe move
                currentRefill++;
            if (currentRefill == lastRefill)
                return -1;
            if (currentRefill <= n)
                numRefills++;
        }
        return numRefills;
    }

    public static void Main(string[] args) {
        int dist = int.Parse(Console.ReadLine());
        int tank = int.Parse(Console.ReadLine());
        int n = int.Parse(Console.ReadLine());

        int[] stops = new int[n+2];
        stops[0] = 0;
        string[] tokens = Console.ReadLine().Split();
        for (int i = 1; i <= n; i++) {
            stops[i] = int.Parse(tokens[i-1]);
        }
        stops[n+1] = dist;

        System.Console.WriteLine(computeMinRefills(dist, tank, n, stops));
    }
}
