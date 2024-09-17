using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A8
{
    public class Q2TreeHeight : Processor
    {
        public Q2TreeHeight(string testDataName) : base(testDataName)
        {}

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long>)Solve);

        public class Tree
        {
            public Tree(long k)
            {
                children = new List<Tree>();
                key = k;
            }
            public long key;
            public List<Tree> children;
            // long parent;
        }

        public class TreeAndHeight
        {
            public Tree tree;
            public long height;

            public TreeAndHeight(Tree tree, long height)
            {
                this.tree = tree;
                this.height = height;
            }
        }

        public static long computeHeight(Tree t) {
            // if (t == null)
            //     return 0;
            // long max = 0;
            // foreach (Tree child in t.children)
            // {
            //     max = Math.Max(computeHeight(child),max);
            // }
            // return max + 1;


            Stack<TreeAndHeight> heights = new Stack<TreeAndHeight>();
            heights.Push(new TreeAndHeight(t,1));
            long maxH = 0;
            while (heights.Count > 0) // condition : hame node ha visit she
            {
                TreeAndHeight tmp = heights.Pop();
                long nextH = tmp.height + 1;
                if (tmp.tree.children.Count != 0)
                {
                    foreach (Tree child in tmp.tree.children)
                    {
                        heights.Push(new TreeAndHeight(child,nextH));
                    }
                    maxH = Math.Max(maxH,nextH);
                }
            }
            return maxH;
            // Replace this code with a faster implementation
            // long maxHeight = 0;
            // for (long vertex = 0; vertex < n; vertex++) {
            // 	long height = 0;
            // 	for (long i = vertex; i != -1; i = parent[i])
            // 		height++;
            // 	maxHeight = Math.Max(maxHeight, height);
            // }
            // return maxHeight;

            // *****
            // recursive dfs --> with stack implement it as iterative
            // recursive bfs --> with queue implement it as iterative
            // ****
        }

        public long Solve(long nodeCount, long[] tree)
        {
            Tree[] nodes = new Tree[nodeCount];
            for (long i = 0; i < nodeCount; i++)
                nodes[i] = new Tree(i);
            
            long root = 0;
            // long[] parentIndeces = tree
            for (long childIndex = 0; childIndex < nodeCount; childIndex++)
            {
                long parentIndex = tree[childIndex];
                if (parentIndex == -1)
                    root = childIndex;
                else
                    nodes[parentIndex].children.Add(nodes[childIndex]);
            }
            
            return computeHeight(nodes[root]);
        }
    }
}
