using System;
using System.Collections.Generic;
using System.Linq;


public class tree_orders {

	public class TreeOrders {
		int n;
		int[] key, left, right;

		public List<int> ans;
		
		public void read(){
			n = int.Parse(Console.ReadLine());
			key = new int[n];
			left = new int[n];
			right = new int[n];
            int[] toks;
			for (int i = 0; i < n; i++) { 
                toks = Console.ReadLine().Split().Select(s => int.Parse(s)).ToArray();
				key[i] = toks[0];
				left[i] = toks[1];
				right[i] = toks[2];
			}
		}
		
		public void dfsInOrder(int node)
		{
			if (left[node] != -1)
				dfsInOrder(left[node]);
			ans.Add(key[node]);
			if (right[node] != -1)
				dfsInOrder(right[node]);
		}
		public List<int> inOrder() {
			// List<int> result = new List<int>();
                        // Finish the implementation
                        // You may need to add a new recursive method to do that
			
			ans = new List<int>(n);
			dfsInOrder(0);
			return ans;
			// ----------------------------------
			// Stack<int> s = new Stack<int>();
			// int curr = 0;
	
			// // traverse the tree
			// while (curr != -1 || s.Count > 0)
			// {
	
			// 	/* Reach the left most Node of the
			// 	curr Node */
			// 	while (curr != -1)
			// 	{
			// 		/* place pointer to a tree node on
			// 		the stack before traversing
			// 		the node's left subtree */
			// 		s.Push(curr);
			// 		curr = left[curr];
			// 		// curr = curr.left;
			// 	}
	
			// 	/* Current must be NULL at this point */
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


                // Stack<int> s = new Stack<int>(n);
				// s.Push(0);
				// while (s.Count != n)
				// {
				// 	int tmpIndex = s.Pop();
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

		public void dfsPreOrder(int node)
		{
			ans.Add(key[node]);
			if (left[node] != -1)
				dfsPreOrder(left[node]);
			if (right[node] != -1)
				dfsPreOrder(right[node]);
		}

		public List<int> preOrder() {
			ans = new List<int>(n);
			dfsPreOrder(0);
			return ans;
			// List<int> result = new List<int>();
            //             // Finish the implementation
            //             // You may need to add a new recursive method to do that
			// 	Stack<int> s = new Stack<int>(n);
			// 	s.Push(0);
			// 	while (s.Count > 0)
			// 	{
			// 		int tmpIndex = s.Pop();
			// 		result.Add(key[tmpIndex]);
			// 		if (right[tmpIndex] != -1)
			// 			result.Add(right[tmpIndex]);
			// 		if (left[tmpIndex] != -1)
			// 			result.Add(left[tmpIndex]);
			// 	}
			// return result;
		}

		public void dfsPostOrder(int node)
		{
			if (left[node] != -1)
				dfsPostOrder(left[node]);
			if (right[node] != -1)
				dfsPostOrder(right[node]);
			ans.Add(key[node]);
		}

		public List<int> postOrder() {
			ans = new List<int>(n);
			dfsPostOrder(0);
			return ans;
			// List<int> result = new List<int>();
            //             // Finish the implementation
            //             // You may need to add a new recursive method to do that
            //     Stack<int> s = new Stack<int>(n);
			// 	s.Push(0);
			// 	while (s.Count != n)
			// 	{
			// 		int tmpIndex = s.Pop();
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

	static public void Main(string[] args) {
        TreeOrders tree = new TreeOrders();
		tree.read();
		print(tree.inOrder());
		print(tree.preOrder());
		print(tree.postOrder());
		Console.ReadKey();
	}

	public static void print(List<int> x) {
		foreach (int item in x)
        {
            System.Console.Write(item + " ");
        }
        System.Console.WriteLine();
    }

}