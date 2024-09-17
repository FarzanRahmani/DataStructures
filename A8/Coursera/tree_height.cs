using System;
using System.Collections.Generic;
using System.Linq;

public class tree_height {


    public static int computeHeight(Tree t) {
        // if (t == null)
        //     return 0;
        int max = 0;
        foreach (Tree child in t.children)
        {
            max = Math.Max(computeHeight(child),max);
        }
        return max + 1;

        // Replace this code with a faster implementation
        // int maxHeight = 0;
        // for (int vertex = 0; vertex < n; vertex++) {
        // 	int height = 0;
        // 	for (int i = vertex; i != -1; i = parent[i])
        // 		height++;
        // 	maxHeight = Math.max(maxHeight, height);
        // }
        // return maxHeight;
    }
    public class Tree
    {
        public Tree(int k)
        {
            children = new List<Tree>();
            key = k;
        }
        public int key;
        public List<Tree> children;

        // int parent;
    }

	static public void Main(string[] args) {
        int numOfNodes = int.Parse(Console.ReadLine());
        Tree[] nodes = new Tree[numOfNodes];
        for (int i = 0; i < numOfNodes; i++)
            nodes[i] = new Tree(i);
        
        int root = 0;
        int[] parentIndeces = Console.ReadLine().Split().Select(s => int.Parse(s)).ToArray();
        for (int childIndex = 0; childIndex < numOfNodes; childIndex++)
        {
            int parentIndex = parentIndeces[childIndex];
            if (parentIndex == -1)
                root = childIndex;
            else
                nodes[parentIndex].children.Add(nodes[childIndex]);
        }
        
        System.Console.WriteLine(computeHeight(nodes[root]));
	}
}