using System;

public class Change {
    private static int getChange(int m) {
        int ans = 0;
        while (m >= 10)
        {
            m -= 10;
            ans++;
        }
        while (m >= 5)
        {
            m -= 5;
            ans++;
        }
        ans += m;
        return ans;
    }

    public static void Main(string[] args) {
        int m = int.Parse(Console.ReadLine());
        System.Console.WriteLine(getChange(m));

    }
}