using System;
using System.Linq;
using TestCommon;

namespace A9
{
    public class Q2MergingTables : Processor
    {

        public Q2MergingTables(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[], long[], long[], long[]>)Solve);

        static long maximumNumberOfRows = -1;

        public class Table {
            public Table parent;
            public long rank; // union by rank
            public long numberOfRows; // ri

            public Table(long numberOfRows) { // makeSet
                this.numberOfRows = numberOfRows;
                rank = 0;
                parent = this;
            }
            public Table getParent() { // find
                // find super parent and compress path
                if (this.parent != this)
                    this.parent = this.parent.getParent();
                
                return parent;
            }
        }

        public static void merge(Table destination, Table source) { // union
            Table realDestination = destination.getParent();
            Table realSource = source.getParent();
            if (realDestination == realSource) 
                return;
            
            // merge two components here
            // use rank heuristic
            // update maximumNumberOfRows
            if (realDestination.rank > realSource.rank )
            {
                realSource.parent = realDestination;
                realDestination.numberOfRows += realSource.numberOfRows;
                realSource.numberOfRows = 0;
                if (realDestination.numberOfRows > maximumNumberOfRows)
                    maximumNumberOfRows = realDestination.numberOfRows;
            }
            else
            {
                realDestination.parent = realSource.parent;
                realSource.numberOfRows += realDestination.numberOfRows;
                realDestination.numberOfRows = 0;
                if (realSource.numberOfRows > maximumNumberOfRows)
                    maximumNumberOfRows = realSource.numberOfRows;
                
                if (realDestination.rank == realSource.rank)
                    realSource.rank++;
            }
        }
        public long[] Solve(long[] tableSizes, long[] targetTables, long[] sourceTables)
        { 
            long n = tableSizes.Length;// num of tables
            Table[] tables = new Table[tableSizes.Length];
            for (long i = 0; i < n; i++) {
                long numberOfRows = tableSizes[i];
                tables[i] = new Table(numberOfRows);
                maximumNumberOfRows = Math.Max(maximumNumberOfRows, numberOfRows);
            }

            long m = targetTables.Length; // num of merge queries
            long[] ans = new long[m];
            for (long i = 0; i < m; i++) {
                long destination = targetTables[i] - 1; // 0-based
                long source = sourceTables[i] - 1;
                merge(tables[destination], tables[source]);
                ans[i] = maximumNumberOfRows;
            }

            maximumNumberOfRows = 0;
            return ans;
        }

    }
}
