using E2.Helper;
using TestCommon;
using System;
using System.Collections.Generic;

namespace E2
{
    public class Q6PortalsB : Processor
    {
        public Q6PortalsB(string testDataName) : base(testDataName)
        {
        }

        public override string Process(string inStr) => E2Processors.ProcessQ6PortalsB(inStr, Solve);

        public int Solve(int n, int m, int a_row, int a_col, int b_row, int b_col, char[,] board, List<Portal> portals)
        {
            Node[,] nodes = new Node[n,m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    nodes[i,j] = new Node(i,j);
                }
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (board[i, j] != '#')
                    {
                        if (i > 0) // up
                        {
                            if (board[i - 1, j] != '#')
                                merge(nodes[i,j],nodes[i-1,j]);
                        }
                        if (j > 0) // left
                        {
                            if (board[i, j - 1] != '#')
                                merge(nodes[i,j],nodes[i,j-1]);
                        }
                        if (i < n - 1) // down
                        {
                            if (board[i + 1, j] != '#')
                                merge(nodes[i,j],nodes[i+1,j]);
                        }
                        if (j < m - 1) // right
                        {
                            if (board[i, j + 1] != '#')
                                merge(nodes[i,j],nodes[i,j+1]);
                        }
                    }
                }
            }
            
            if (nodes[a_row,a_col].getParent() == nodes[b_row,b_col].getParent())
                return 0;
            
            for (int i = 0; i < portals.Count; i++)
            {
                Portal p = portals[i];
                merge(nodes[p.FirstCell.Row,p.FirstCell.Col],nodes[p.SecondCell.Row,p.SecondCell.Col]);
                if (nodes[a_row,a_col].getParent() == nodes[b_row,b_col].getParent())
                    return i+1;
            }
            
            return -1;
        }

        public class Node
        {
            public Node parent;
            public int rank; // union by rank
            public int row;
            public int col;

            public Node(int row, int col)
            { // makeSet
                this.row = row;
                this.col = col;
                rank = 0;
                parent = this;
            }
            public Node getParent()
            { // find
              // find super parent and compress path
                if (this.parent != this)
                    this.parent = this.parent.getParent();

                return parent;
            }
        }

        public static void merge(Node destination, Node source)
        { // union
            Node realDestination = destination.getParent();
            Node realSource = source.getParent();
            if (realDestination == realSource)
                return;

            if (realDestination.rank > realSource.rank)
            {
                realSource.parent = realDestination;
            }
            else
            {
                realDestination.parent = realSource.parent;

                if (realDestination.rank == realSource.rank)
                    realSource.rank++;
            }
        }

    }
}
