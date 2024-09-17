using System;
using System.Linq;
using System.Collections.Generic;
public class CoveringSegments {

    private static int[] optimalPoints(Segment[] segments) {
        List<int> points = new List<int>();
        int pointer;
        while (segments.Length > 0)
        {
            pointer = segments.First().end;
            points.Add(pointer);
            segments = segments.Where(s => s.start > pointer).ToArray();
            // segments = segments.Where(s => (s.start > pointer) || (s.end < pointer)).ToArray();
        }
        return points.ToArray();
    }

    public class Segment {
        public int start, end;

        public Segment(int start, int end) {
            this.start = start;
            this.end = end;
        }
    }
    public static void Main(string[] args) {
        int n = int.Parse(Console.ReadLine());
        Segment[] segments = new Segment[n];
        for (int i = 0; i < n; i++) {
            int start, end;
            string[] tokens = Console.ReadLine().Split();
            start = int.Parse(tokens[0]);
            end = int.Parse(tokens[1]);
            segments[i] = new Segment(start, end);
        }
        segments = segments.OrderBy(s => s.end).ToArray();
        int[] points = optimalPoints(segments);
        System.Console.WriteLine(points.Length);
        foreach (int p in points)
        {
            Console.Write(p + " ");
        }
        Console.ReadKey();
    }
}

