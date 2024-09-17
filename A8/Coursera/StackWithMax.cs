using System;
using System.Collections.Generic;
using System.Linq;

public class StackWithMax {
    public void solve()  {
        int queries = int.Parse(Console.ReadLine());
        Stack<int> stack = new Stack<int>();
        List<int> maxI = new List<int>(queries);
        // maxI[0] = null;
        maxI.Add(0);
        int max = 0;

        for (int qi = 0; qi < queries; ++qi) {
            string operation = Console.ReadLine();
            if (operation.Contains("push")) {
                int value = int.Parse(operation.Split().ToArray()[1]);
                stack.Push(value);
                if (value > max)
                    max = value;
                // maxI[stack.Count] = max; 
                maxI.Add(max); // mishod stack bashe maxI va inja push(max) konim
            } else if ("pop" == operation) {
                stack.Pop();
                max = maxI[stack.Count]; // max = maxI.Pop()
                maxI.RemoveAt(stack.Count+1);
            } else if ("max" == operation) {
                System.Console.WriteLine(maxI[stack.Count]); // maxI.Peek()
            }
        }
    }

    static public void Main(string[] args) {
        new StackWithMax().solve();
    }
}