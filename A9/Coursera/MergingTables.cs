using System;
using System.Linq;

public class MergingTables {

    static int maximumNumberOfRows = -1;

    public static void Main(string[] args) {
        int[] toks = Console.ReadLine().Split().Select(s => int.Parse(s)).ToArray();
        int n = toks[0]; // num of tables
        int m = toks[1]; // num of merge queries

        Table[] tables = new Table[n];
        toks = Console.ReadLine().Split().Select(s => int.Parse(s)).ToArray();
        for (int i = 0; i < n; i++) {
            int numberOfRows = toks[i];
            tables[i] = new Table(numberOfRows);
            maximumNumberOfRows = Math.Max(maximumNumberOfRows, numberOfRows);
        }

        for (int i = 0; i < m; i++) {
            toks = Console.ReadLine().Split().Select(s => int.Parse(s)).ToArray();
            int destination = toks[0] - 1; // 0-based
            int source = toks[1] - 1;
            merge(tables[destination], tables[source]);
            System.Console.WriteLine(maximumNumberOfRows);
        }

        Console.ReadKey();
    }

    public class Table {
        public Table parent;
        public int rank; // union by rank
        public int numberOfRows; // ri

        public Table(int numberOfRows) { // makeSet
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



}