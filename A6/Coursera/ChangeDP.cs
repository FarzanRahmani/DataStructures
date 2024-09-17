using System;
public class ChangeDP {
    private static int getChange(int money,int[] coins) {
        //write your code here
        int[] MinNumCoins = new int[money+1];
        MinNumCoins[0] = 0;
        int NumCoins = 0;
        for (int m = 1; m <= money; m++)
        {
            MinNumCoins[m] = 1000;
            for (int i = 0; i < coins.Length; i++)
            {
                if (m >= coins[i])
                {
                    NumCoins = MinNumCoins[m - coins[i]] + 1;
                    if (NumCoins < MinNumCoins[m])
                        MinNumCoins[m] = NumCoins;
                }
            }
        }
        return MinNumCoins[money];
    }

    public static void Main(string[] args) {
        // coins : 1 - 3 - 4
        int[] coins = new int[]{1,3,4};
        int money = int.Parse(Console.ReadLine());
        Console.WriteLine(getChange(money,coins));
    }
}