using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace A11
{
    public class Q3IsItBSTHard : Processor
    {
        public Q3IsItBSTHard(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[][], bool>)Solve);

        public bool Solve(long[][] nodes)
        {
            IsBST tree = new IsBST();
            tree.read(nodes);
            return tree.isBinarySearchTree();
        }

        public class Node {
            public long key;
            public long left;
            public long right;

            public Node(long key, long left, long right) {
                this.left = left;
                this.right = right;
                this.key = key;
            }
        }
	
        public class IsBST {
            long nodes;
            Node[] tree;
            bool isEmpty;
            // bool isNotNST;

            public void read(long[][] ns) {
                nodes = ns.Length;
                if (nodes == 0)
                    isEmpty = true;
                else
                    isEmpty = false;
                tree = new Node[nodes];
                for (long i = 0; i < nodes; i++) {
                    tree[i] = new Node(ns[i][0], ns[i][1], ns[i][2]);
                }
            }

            // public List<long> ans;
            // public void CheckDFS(long r)
            // {
            //     if (tree[r].left != -1)
            //     {
            //         if(tree[tree[r].left].key == tree[r].key)
            //             {
            //                 isNotNST = true;
            //                 return;
            //             }
            //         // if (tree[tree[r].left].right != -1)
            //         // {
            //         //     if (tree[tree[tree[r].left].right].key == tree[r].key)
            //         //     {
            //         //         isNotNST = true;
            //         //         return;
            //         //     }
            //         // }
            //         CheckDFS(tree[r].left);
            //     }
            //     ans.Add(tree[r].key);
            //     if (tree[r].right != -1)
            //         CheckDFS(tree[r].right);
            // }

            public bool CheckDFS(long r,long min,long max)
            {
                if (tree[r].key < min || tree[r].key > max)
                    return false;
                bool bLeft = true , bRight = true;
                if (tree[r].left != -1)
                    bLeft = CheckDFS(tree[r].left,min,tree[r].key-1);
                if (tree[r].right != -1)
                    bRight = CheckDFS(tree[r].right,tree[r].key,max);
                return bLeft && bRight;
            }
            public bool isBinarySearchTree() {
                // Implement correct algorithm here
                // isNotNST = false;
                if (isEmpty)
                    return true;
                
                // ans = new List<long>((int)nodes);
                // CheckDFS(0);
                
                // if (isNotNST)
                //     return false;

                // for (long i = 0; i < nodes-1; i++)
                // {
                //     if (ans[(int)i] > ans[(int)i+1])
                //         return false;
                // }
                // return true;
                return CheckDFS(0,long.MinValue,long.MaxValue);
            }
        }

    }
}
