using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using TestCommon;

namespace C7
{
    public class Q1TopView : Processor
    {
        public Q1TopView(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) => C7Processors.ProcessQ1TopView(inStr, Solve);
        

        public string Solve(long n, BinarySearchTree tree)
        {
            if (tree.root == null)
                return " ";
            Queue<Node> q = new Queue<Node>();
            tree.root.level =0;
            tree.root.xCordinate = 0;
            q.Enqueue(tree.root);
            Node node;
            Dictionary<long,long> D = new Dictionary<long, long>();
            while (q.Count > 0)
            {
                node = q.Dequeue();
                long? nodeLevel = node.level;
                long nodeXCordinate = node.xCordinate;
                if (!D.ContainsKey(nodeXCordinate))
                {
                    D[nodeXCordinate] = node.info;
                }
                if (node.left != null)
                {
                    node.left.level = nodeLevel + 1;
                    node.left.xCordinate = nodeXCordinate - 1;
                    q.Enqueue(node.left);
                }

                if (node.right != null)
                {
                    node.right.level = nodeLevel +1;
                    node.right.xCordinate = nodeXCordinate + 1;
                    q.Enqueue(node.right);
                }
            }
            var res = D.OrderBy(t => t.Key).Select(t => t.Value.ToString()).Aggregate((a , b) => a + " " + b);
            return res;
        }
    }
}
