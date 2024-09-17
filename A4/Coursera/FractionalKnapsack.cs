using System;
using System.Linq;
public class FractionalKnapsack {
    private class VaI
    {
    public int index;
    public double VpU;

        public VaI(int index, double vpU)
        {
            this.index = index;
            VpU = vpU;
        }
    }
    private static double getOptimalValue(int n,double capacity, double[] values, double[] weights) {
        double value = 0;
        //write your code here
        // (double VpU,int index)[] ValueperUnit = new (double VpU,int index)[n];
        VaI[] ValueperUnit = new VaI[n];
        for (int i = 0; i < n; i++)
        {
            // ValueperUnit[i] = ((values[i] / weights[i]),i);
            ValueperUnit[i] = new VaI(i,(values[i] / weights[i]));
        }
        ValueperUnit = ValueperUnit.OrderByDescending(t => t.VpU).ToArray();

        double a;
        for (int i = 0; i < n; i++)
        {
            if (capacity == 0)
                return value;
            a = System.Math.Min(capacity,weights[ValueperUnit[i].index]);
            value += a*ValueperUnit[i].VpU;
            weights[ValueperUnit[i].index] -= a;
            capacity -= a;
        }
        return value;
    }

    public static void Main(string[] args) {
        string[] tokens = Console.ReadLine().Split();
        int n = int.Parse(tokens[0]);
        double capacity = double.Parse(tokens[1]);

        double[] values = new double[n];
        double[] weights = new double[n];

        for (int i = 0; i < n; i++) {
            tokens = Console.ReadLine().Split();
            values[i] = double.Parse(tokens[0]);
            weights[i] = double.Parse(tokens[1]);
        }
        System.Console.WriteLine(getOptimalValue(n,capacity, values, weights));
        Console.ReadKey();
    }
} 