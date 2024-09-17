using System;
using System.Collections.Generic;

namespace E2.Helper
{
    public struct Portal
    {
        public Cell FirstCell { get; set; }
        public Cell SecondCell { get; set; }

        public Portal(Cell firstCell, Cell secondCell)
        {
            FirstCell = firstCell;
            SecondCell = secondCell;
        }
    }

    public struct Cell
    {
        public int Row { get; set; }
        public int Col { get; set; }

        public Cell(int row, int col)
        {
            Row = row;
            Col = col;
        }
        public Tuple<int, int> ToTuple()
        {
            return Tuple.Create(Row, Col);
        }
    }
}
