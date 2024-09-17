using E2.Helper;
using E2.Input;
using E2.Output;
using System.Linq;
using System;
using System.Collections.Generic;

namespace E2
{
    namespace Input
    {
        public struct Q2TestInput
        {
            public long n { get; set; }
            public long x { get; set; }
            public long[] a { get; set; }

            public Q2TestInput GenerateFromString(string str)
            {
                throw new NotImplementedException();
            }
        }
    }

    namespace Output
    {
        public struct Q2TestOutput
        {
            public Tuple<int, int> indices { get; set; }
        }
    }

    public class E2Processors
    {

        public static string ProcessQ1Reverse(string inStr, Func<long, LinkedList<long>, LinkedList<long>> Solve)
        {
            var lines = inStr.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            var n = lines[0].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(d => long.Parse(d)).ToArray()[0];
            long[] arr = new long[n];
            LinkedList<long> ll = new LinkedList<long>();
            for (int i = 0; i < n; i++)
            {
                ll.AddLast(lines[i + 1].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(d => long.Parse(d)).ToArray()[0]);
                arr[i] = lines[i + 1].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(d => long.Parse(d)).ToArray()[0];
            }

            LinkedList<long> resultList = Solve(n, ll);
            var iterator = resultList.Head;
            List<long> result = new List<long>();

            while (iterator != null)
            {
                result.Add(iterator.Value);
                iterator = iterator.Next;
            }
            return string.Join(" ", result);
        }

        public static Q2TestInput GetInputQ2Passcode(string inStr)
        {
            var lines = inStr.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            var first = lines[0].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(d => long.Parse(d)).ToArray();
            long n = first[0];
            long x = first[1];

            long[] arr = lines[1].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(d => long.Parse(d)).ToArray();

            return new Q2TestInput
            {
                n = n,
                x = x,
                a = arr
            };
        }
        public static Q2TestOutput GetOutputQ2Passcode(string outStr)
        {
            if (outStr == "-1")
            {
                return new Q2TestOutput
                {
                    indices = null
                };
            }
            else
            {
                var indices = outStr.Split(new char[] { ' ' }).Select(st => int.Parse(st)).ToArray();
                int idx_i = indices[0];
                int idx_j = indices[1];
                return new Q2TestOutput
                {
                    indices = Tuple.Create(idx_i, idx_j)
                };
            }
        }

        public static string ProcessQ2Passcode(string inStr, Func<long, long, long[], Tuple<int, int>> Solve)
        {
            var input = GetInputQ2Passcode(inStr);
            var result = Solve(input.n, input.x, input.a);

            if (result == null)
            {
                return "-1";
            }
            else
            {
                return $"{result.Item1} {result.Item2}";
            }
        }

        public static string ProcessQ3RedBlackTree(string inStr, Func<long, long[], List<long>> Solve)
        {
            var lines = inStr.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            var n = lines[0].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(d => long.Parse(d)).ToArray()[0];
            long[] arr = new long[n];
            for (int i = 0; i < n; i++)
            {
                arr[i] = lines[i + 1].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(d => long.Parse(d)).ToArray()[0];
            }
            var values = Solve(n, arr);
            return string.Join(" ", values);
        }

        private static string FormatDouble(double val, int decimalPlaces)
        {
            double rnd = Math.Round(val, decimalPlaces);
            string s = string.Format("{0:N" + decimalPlaces + "}", rnd);

            return s;
        }

        public static string ProcessQ4ChainingProfiler(string inStr, Func<int, int, string[], Tuple<double, List<LinkedList<string>>>> Solve)
        {
            var lines = inStr.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            var first = lines[0].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(d => int.Parse(d)).ToArray();
            int n = first[0];
            int bucketCount = first[1];
            string[] s = lines.Skip(1).ToArray();

            var result = Solve(n, bucketCount, s);

            double variance = result.Item1;
            var table = result.Item2;

            string varianceRepr = FormatDouble(variance, 6);

            List<List<string>> tableAsList = new List<List<string>>();
            foreach (var linkedList in table)
            {
                List<string> tmp = new List<string>();
                var iter = linkedList.Head;
                while (iter != null)
                {
                    tmp.Add(iter.Value);
                    iter = iter.Next;
                }
                tableAsList.Add(tmp);
            }

            string listRepr = string.Join('\n', table.Select((bucket, i) => $"{i} : {string.Join(" -> ", tableAsList[i])}".Trim()));
            return $"{varianceRepr}\n{listRepr}";
        }
        public static string ProcessQ5PortalsA(string inStr, Func<int, int, int, int, int, int, char[,], bool> Solve)
        {
            var lines = inStr.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            var first = lines[0].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(d => int.Parse(d)).ToArray();
            int n = first[0];
            int m = first[1];
            int a_row = first[2];
            int a_col = first[3];
            int b_row = first[4];
            int b_col = first[5];
            char[,] board = new char[n, m];
            for (int i = 1; i < 1 + n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    board[i - 1, j] = lines[i][j];
                }
            }
            return Solve(n, m, a_row, a_col, b_row, b_col, board) ? "YES" : "NO";
        }

        public static string ProcessQ6PortalsB(string inStr, Func<int, int, int, int, int, int, char[,], List<Portal>, int> Solve)
        {
            var lines = inStr.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            var first = lines[0].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(d => int.Parse(d)).ToArray();
            int n = first[0];
            int m = first[1];
            int a_row = first[2];
            int a_col = first[3];
            int b_row = first[4];
            int b_col = first[5];
            char[,] board = new char[n, m];
            for (int i = 1; i < 1 + n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    board[i - 1, j] = lines[i][j];
                }
            }
            int portalCount = int.Parse(lines[n + 1]);
            List<Portal> portals = new List<Portal>();
            for (int i = n + 2; i < n + 2 + portalCount; i++)
            {
                string s = lines[i];
                s = s.Replace("<=>", " ");
                s = s.Replace("(", " ");
                s = s.Replace(")", " ");
                s = s.Replace(",", " ");
                var numbers = s.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(d => int.Parse(d)).ToArray();
                int firstEndRow = numbers[0];
                int firstEndCol = numbers[1];
                int secondEndRow = numbers[2];
                int secondEndCol = numbers[3];
                portals.Add(new Portal
                {
                    FirstCell = new Cell(firstEndRow, firstEndCol),
                    SecondCell = new Cell(secondEndRow, secondEndCol)
                });
            }
            return Solve(n, m, a_row, a_col, b_row, b_col, board, portals).ToString();
        }
    }
}
