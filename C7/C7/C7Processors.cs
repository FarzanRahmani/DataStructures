using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C7
{
    public class C7Processors
    {
        
        public static string ProcessQ1TopView(string inStr, Func<long, BinarySearchTree, string> Solve)
        {
            var lines = inStr.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            var n = lines[0].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(d => int.Parse(d)).ToArray()[0];
            var arr = lines[1].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(d => int.Parse(d)).ToArray();
            BinarySearchTree tree = new BinarySearchTree();
            for (int i=0;i<n;i++)
            {
                tree.Create(arr[i]);
            }
            
            return Solve(n,tree);
        }
    }
}



