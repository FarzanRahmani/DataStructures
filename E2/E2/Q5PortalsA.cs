using TestCommon;
using System;
using System.Collections.Generic;

namespace E2
{
    public class Q5PortalsA : Processor
    {
        public Q5PortalsA(string testDataName) : base(testDataName)
        {
        }

        public override string Process(string inStr) => E2Processors.ProcessQ5PortalsA(inStr, Solve);

        public override Action<string, string> Verifier => E2Verifiers.VerifyQ5PortalsA;

        public bool Solve(int n, int m, int a_row, int a_col, int b_row, int b_col, char[,] board)
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
            return nodes[a_row,a_col].getParent() == nodes[b_row,b_col].getParent();
            // ----

            // HashSet<(int, int)>[,] t = new HashSet<(int, int)>[n, m];
            // for (int i = 0; i < n; i++)
            // {
            //     for (int j = 0; j < m; j++)
            //     {
            //         t[i, j] = new HashSet<(int, int)>();
            //         t[i, j].Add((i, j));
            //     }
            // }
            // for (int i = 0; i < n; i++)
            // {
            //     for (int j = 0; j < m; j++)
            //     {
            //         if (board[i, j] != '#')
            //         {
            //             if (i > 0) // up
            //             {
            //                 if (board[i - 1, j] != '#')
            //                     t[i, j].UnionWith(t[i - 1, j]);
            //             }
            //             if (j > 0) // left
            //             {
            //                 if (board[i, j - 1] != '#')
            //                     t[i, j].UnionWith(t[i, j - 1]);
            //             }
            //             if (i < n - 1) // down
            //             {
            //                 if (board[i + 1, j] != '#')
            //                     t[i, j].UnionWith(t[i + 1, j]);
            //             }
            //             if (j < m - 1) // right
            //             {
            //                 if (board[i, j + 1] != '#')
            //                     t[i, j].UnionWith(t[i, j + 1]);
            //             }
            //         }
            //     }
            // }

            // for (int j = 0; j < m; j++)
            // {
            //     for (int i = 0; i < n; i++)
            //     {
            //         if (board[i, j] != '#')
            //         {
            //             if (i > 0) // up
            //             {
            //                 if (board[i - 1, j] != '#')
            //                     t[i, j].UnionWith(t[i - 1, j]);
            //             }
            //             if (j > 0) // left
            //             {
            //                 if (board[i, j - 1] != '#')
            //                     t[i, j].UnionWith(t[i, j - 1]);
            //             }
            //             if (i < n - 1) // down
            //             {
            //                 if (board[i + 1, j] != '#')
            //                     t[i, j].UnionWith(t[i + 1, j]);
            //             }
            //             if (j < m - 1) // right
            //             {
            //                 if (board[i, j + 1] != '#')
            //                     t[i, j].UnionWith(t[i, j + 1]);
            //             }
            //         }
            //     }
            // }

            // if (t[a_row, a_col].Contains((b_row, b_col)))
            //     return true;
            // if (t[b_row, b_col].Contains((a_row, a_col)))
            //     return true;
            // return false;
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
