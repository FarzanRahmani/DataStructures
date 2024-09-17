using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Priority_Queue;
using TestCommon;

namespace C9
{
    public class Q1Median : Processor
    {
        public Q1Median(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) => C7Processors.ProcessQ1Median(inStr, Solve);


        public String Solve(long n, long[] arr)
        {
            double[] res = new double[n];
            // -------------------
            // your code here
            // SimplePriorityQueue<long> MinHeap=new SimplePriorityQueue<long>();
            // StablePriorityQueue<StablePriorityQueueNode> MinHeap = new StablePriorityQueue<StablePriorityQueueNode>(n);
            // GenericPriorityQueue<long,> MaxHeap = new GenericPriorityQueue<long,>();
            SimplePriorityQueue<long> MaxHeap = new SimplePriorityQueue<long>(); // smaller half / enqueue(-n) , n = -1 * dequeue()
            SimplePriorityQueue<long> MinHeap = new SimplePriorityQueue<long>(); // bigger half
            if (n > 0)
            {
                MaxHeap.Enqueue(arr[0], -1 * arr[0]);
                res[0] = arr[0];
            }
            if (n > 1)
            {
                long first = MaxHeap.Dequeue();
                long second = arr[1];
                res[1] = (double)(first+second)/2;
                if (first > second)
                {
                    MaxHeap.Enqueue(second,-1*second);
                    MinHeap.Enqueue(first,first);
                }
                else
                {
                    MaxHeap.Enqueue(first,-1*first);
                    MinHeap.Enqueue(second,second);
                }
            }
            for (int i = 2; i < n; i++)
            {
                if (MinHeap.Count == MaxHeap.Count)
                {
                    long maxLeft = MaxHeap.Dequeue();
                    long minRight = MinHeap.Dequeue();
                    if (arr[i] <= maxLeft)
                    {
                        MaxHeap.Enqueue(arr[i], -1 * arr[i]);
                        MaxHeap.Enqueue(maxLeft, -1 * maxLeft);
                        MinHeap.Enqueue(minRight, minRight);
                    }
                    else if (arr[i] >= minRight)
                    {
                        MinHeap.Enqueue(arr[i], arr[i]);
                        MaxHeap.Enqueue(maxLeft, -1 * maxLeft);
                        MaxHeap.Enqueue(minRight, -1 * minRight);
                    }
                    else if (arr[i] > maxLeft && arr[i] < minRight)
                    {
                        MaxHeap.Enqueue(maxLeft, -1 * maxLeft);
                        MaxHeap.Enqueue(arr[i], -1 * arr[i]);
                        MinHeap.Enqueue(minRight, minRight);
                    }
                    res[i] = MaxHeap.First;
                }
                else if (MinHeap.Count > MaxHeap.Count) // len(MinHeap) = len(MaxHeap) + 1
                {
                    long maxLeft = MaxHeap.Dequeue();
                    long minRight = MinHeap.Dequeue();
                    if (arr[i] <= maxLeft)
                    {
                        MaxHeap.Enqueue(arr[i], -1 * arr[i]);
                        MaxHeap.Enqueue(maxLeft, -1 * maxLeft);
                        MinHeap.Enqueue(minRight, minRight);
                    }
                    else if (arr[i] >= minRight)
                    {
                        MinHeap.Enqueue(arr[i], arr[i]);
                        MaxHeap.Enqueue(minRight, -1 * minRight);
                        MaxHeap.Enqueue(maxLeft, -1 * maxLeft);
                    }
                    else if (arr[i] > maxLeft && arr[i] < minRight)
                    {
                        MaxHeap.Enqueue(maxLeft, -1 * maxLeft);
                        MaxHeap.Enqueue(arr[i], arr[i] * -1);
                        MinHeap.Enqueue(minRight, minRight);
                    }
                    res[i] = (double)(MaxHeap.First + MinHeap.First) / 2;
                }
                else if (MinHeap.Count < MaxHeap.Count)// len(MinHeap) + 1 = len(MaxHeap) 
                {
                    long maxLeft = MaxHeap.Dequeue();
                    long minRight = MinHeap.Dequeue();
                    if (arr[i] <= maxLeft)
                    {
                        MaxHeap.Enqueue(arr[i], -1 * arr[i]);
                        MinHeap.Enqueue(maxLeft, maxLeft);
                        MinHeap.Enqueue(minRight, minRight);
                    }
                    else if (arr[i] >= minRight)
                    {
                        MinHeap.Enqueue(arr[i], arr[i]);
                        MinHeap.Enqueue(minRight, minRight);
                        MaxHeap.Enqueue(maxLeft, -1 * maxLeft);
                    }
                    else if (arr[i] > maxLeft && arr[i] < minRight)
                    {
                        MaxHeap.Enqueue(maxLeft, -1 * maxLeft);
                        MinHeap.Enqueue(minRight, minRight);
                        MinHeap.Enqueue(arr[i], arr[i]);
                    }
                    res[i] = (double)(MaxHeap.First + MinHeap.First) / 2;
                }
            }
            // -------------------
            var ans = res.Select(x => String.Format("{0:0.0}", x));
            return String.Join('\n', ans);
        }
    }
}
