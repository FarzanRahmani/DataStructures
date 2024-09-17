using System;
using System.Collections.Generic;
using System.Linq;

public class is_bst {

	public class Node {
            public int key;
            public int left;
            public int right;

            public Node(int key, int left, int right) {
                this.left = left;
                this.right = right;
                this.key = key;
            }
        }
	
    public class IsBST {
        int nodes;
        Node[] tree;
		bool isEmpty;
		bool isNotNST;

        public void read() {
            nodes = int.Parse(Console.ReadLine());
			if (nodes == 0)
				isEmpty = true;
			else
				isEmpty = false;
            tree = new Node[nodes];
			int[] toks;
            for (int i = 0; i < nodes; i++) {
				toks = Console.ReadLine().Split().Select(s => int.Parse(s)).ToArray();
                tree[i] = new Node(toks[0], toks[1], toks[2]);
            }
        }

		public List<int> ans;
		public void CheckDFS(int r)
		{
			if (tree[r].left != -1)
			{
				if(tree[tree[r].left].key == tree[r].key)
					{
						isNotNST = true;
						return;
					}
				CheckDFS(tree[r].left);
			}
			ans.Add(tree[r].key);
			if (tree[r].right != -1)
				CheckDFS(tree[r].right);
		}
        public bool isBinarySearchTree() {
          	// Implement correct algorithm here
			isNotNST = false;
			if (isEmpty)
				return true;
			
			ans = new List<int>(nodes);
			CheckDFS(0);
			
			if (isNotNST)
				return false;

			for (int i = 0; i < nodes-1; i++)
			{
				if (ans[i] > ans[i+1])
					return false;
			}
			return true;
        }
    }

    public static void Main(string[] args) {
        run();
		Console.ReadKey();
    }
    public static void run(){
        IsBST tree = new IsBST();
        tree.read();
        if (tree.isBinarySearchTree()) {
            Console.WriteLine("CORRECT");
        } else {
            Console.WriteLine("INCORRECT");
        }
    }

}
