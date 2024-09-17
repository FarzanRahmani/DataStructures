using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A11
{
    public class Q1BinaryTreeTraversals : Processor
    {
        public Q1BinaryTreeTraversals(string testDataName) : base(testDataName) { }
        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[][], long[][]>)Solve);

        public long[][] Solve(long[][] nodes)
        {
            TreeOrders tree = new TreeOrders();
            tree.read(nodes);
            var inAns = tree.inOrder();
            var preAns = tree.preOrder();
            var postAns = tree.postOrder();
            long[][] ans = new long[3][];
            ans[0] = new long[nodes.Length];
            ans[1] = new long[nodes.Length];
            ans[2] = new long[nodes.Length];
            for (int i = 0; i < nodes.Length; i++)
            {
                ans[0][i] = inAns[i];
                ans[1][i] = preAns[i];
                ans[2][i] = postAns[i];
            }
            return ans;
        }

        public class TreeOrders {
            long n;
            long[] key, left, right;

            public List<long> ans;
            
            public void read(long[][] nodes){
                n = nodes.Length;
                key = new long[n];
                left = new long[n];
                right = new long[n];
                for (long i = 0; i < n; i++) { 
                    key[i] = nodes[i][0];
                    left[i] = nodes[i][1];
                    right[i] = nodes[i][2];
                }
            }
            
            public void dfsInOrder(long node)
            {
                if (left[node] != -1)
                    dfsInOrder(left[node]);
                ans.Add(key[node]);
                if (right[node] != -1)
                    dfsInOrder(right[node]);
            }
            public List<long> inOrder() {
                // List<long> result = new List<long>();
                            // Finish the implementation
                            // You may need to add a new recursive method to do that
                
                ans = new List<long>((int)n);
                dfsInOrder(0);
                return ans;
                // ----------------------------------
                // Stack<long> s = new Stack<long>();
                // long curr = 0;
        
                // // traverse the tree
                // while (curr != -1 || s.Count > 0)
                // {
        
                // 	/* Reach the left most Node of the
                // 	curr Node */
                // 	while (curr != -1)
                // 	{
                // 		/* place polonger to a tree node on
                // 		the stack before traversing
                // 		the node's left subtree */
                // 		s.Push(curr);
                // 		curr = left[curr];
                // 		// curr = curr.left;
                // 	}
        
                // 	/* Current must be NULL at this polong */
                // 	curr = s.Pop();
        
                // 	// Console.Write(curr.data + " ");
                // 	result.Add(key[curr]);
        
                // 	/* we have visited the node and its
                // 	left subtree.  Now, it's right
                // 	subtree's turn */
                // 	// curr = curr.right;
                // 	curr = right[curr];
                // }

                // -------------------------------


                    // Stack<long> s = new Stack<long>(n);
                    // s.Push(0);
                    // while (s.Count != n)
                    // {
                    // 	long tmpIndex = s.Pop();
                    // 	if (right[tmpIndex] != -1)
                    // 		// result.Add(right[tmpIndex]);
                    // 		s.Push(right[tmpIndex]);
                    // 	// result.Add(tmpIndex);
                    // 	s.Push(tmpIndex);
                    // 	if (left[tmpIndex] != -1)
                    // 		// result.Add(left[tmpIndex]);
                    // 		s.Push(left[tmpIndex]);
                    // }
                    // foreach (var item in s)
                    // {
                    // 	result.Add(key[item]);
                    // }
                
                // return result;
            }

            public void dfsPreOrder(long node)
            {
                ans.Add(key[node]);
                if (left[node] != -1)
                    dfsPreOrder(left[node]);
                if (right[node] != -1)
                    dfsPreOrder(right[node]);
            }

            public List<long> preOrder() {
                ans = new List<long>((int)n);
                dfsPreOrder(0);
                return ans;
                // List<long> result = new List<long>();
                //             // Finish the implementation
                //             // You may need to add a new recursive method to do that
                // 	Stack<long> s = new Stack<long>(n);
                // 	s.Push(0);
                // 	while (s.Count > 0)
                // 	{
                // 		long tmpIndex = s.Pop();
                // 		result.Add(key[tmpIndex]);
                // 		if (right[tmpIndex] != -1)
                // 			result.Add(right[tmpIndex]);
                // 		if (left[tmpIndex] != -1)
                // 			result.Add(left[tmpIndex]);
                // 	}
                // return result;
            }

            public void dfsPostOrder(long node)
            {
                if (left[node] != -1)
                    dfsPostOrder(left[node]);
                if (right[node] != -1)
                    dfsPostOrder(right[node]);
                ans.Add(key[node]);
            }

            public List<long> postOrder() {
                ans = new List<long>((int)n);
                dfsPostOrder(0);
                return ans;
                // List<long> result = new List<long>();
                //             // Finish the implementation
                //             // You may need to add a new recursive method to do that
                //     Stack<long> s = new Stack<long>(n);
                // 	s.Push(0);
                // 	while (s.Count != n)
                // 	{
                // 		long tmpIndex = s.Pop();
                // 		if (right[tmpIndex] != -1)
                // 			// result.Add(right[tmpIndex]);
                // 			s.Push(right[tmpIndex]);
                // 		if (left[tmpIndex] != -1)
                // 			// result.Add(left[tmpIndex]);
                // 			s.Push(left[tmpIndex]);
                // 		// result.Add(tmpIndex);
                // 		s.Push(tmpIndex);
                // 	}
                // 	foreach (var item in s)
                // 	{
                // 		result.Add(key[item]);
                // 	}
                // return result;
            }
        }
    }
}

