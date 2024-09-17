using System;
using System.Linq;
using System.Collections.Generic;
using TestCommon;

namespace A9
{
    public class Q3ParallelProcessing : Processor
    {
        public Q3ParallelProcessing(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], Tuple<long, long>[]>)Solve);

        public Tuple<long, long>[] Solve(long threadCount, long[] jobDuration)
        {
            long nWorkers = threadCount;
            long nJobs = jobDuration.Length;
            List<AssignedJob> assignedJob = AssignJobs(nWorkers,jobDuration);
            return assignedJob.Select(aj => aj.asTuple()).ToArray();
        }

        public static List<AssignedJob> AssignJobs(long numWorkers,long[] jobs)
        {
            List<AssignedJob> ans = new List<AssignedJob>(jobs.Length);
            MinHeap threads = new MinHeap(numWorkers);
            // for (long i = 0; i < numWorkers; i++)
            // {
            //     ans.Add(new AssignedJob(i,0));
            //     threads.Insert(new thread(i,jobs[i]));
            // }
            
            // for (long i = numWorkers; i < jobs.Length ; i++)
            // {
            //     var t = threads.ExtractMin();
            //     ans.Add(new AssignedJob(t.id,t.freeTime));
            //     threads.Insert(new thread(t.id,t.freeTime + jobs[i]));
            // }
            for (long i = 0; i < numWorkers; i++)
            {
                threads.Insert(new thread(i,0));
            }
            
            for (long i = 0; i < jobs.Length ; i++)
            {
                var t = threads.ExtractMin();
                ans.Add(new AssignedJob(t.id,t.freeTime));
                threads.Insert(new thread(t.id,t.freeTime + jobs[i]));
            }

            return ans;
            // TODO: replace this code with a faster algorithm.
            // long[] assignedWorker = new long[jobs.Length];
            // long[] startTime = new long[jobs.Length];
            // long[] nextFreeTime = new long[numWorkers];
            // for (long i = 0; i < jobs.Length; i++) {
            //     long duration = jobs[i];
            //     long bestWorker = 0;
            //     for (long j = 0; j < numWorkers; ++j) {
            //         if (nextFreeTime[j] < nextFreeTime[bestWorker])
            //             bestWorker = j;
            //     }
            //     assignedWorker[i] = bestWorker;
            //     startTime[i] = nextFreeTime[bestWorker];
            //     nextFreeTime[bestWorker] += duration;
            // }
            // for (long i = 0; i < jobs.Length; i++)
            //     Console.WriteLine(assignedWorker[i] + " " + startTime[i]);
        }


        public class AssignedJob
        {
            public long worker;
            public long startedTime;

            public AssignedJob(long worker, long startedTime)
            {
                this.worker = worker;
                this.startedTime = startedTime;
            }

            public Tuple<long, long> asTuple() => new Tuple<long, long>(worker,startedTime);
        }

        public class MinHeap
        {
            private readonly thread[] _elements;
            private long _size;
            private long _maxSize;

            public MinHeap(long maxSize)
            {
                _elements = new thread[maxSize];
                _maxSize = maxSize;
            }

            private long GetLeftChildIndex(long elementIndex) => 2 * elementIndex + 1;
            private long GetRightChildIndex(long elementIndex) => 2 * elementIndex + 2;
            private long GetParentIndex(long elementIndex) => (elementIndex - 1) / 2;

            private bool HasLeftChild(long elementIndex) => GetLeftChildIndex(elementIndex) < _size;
            private bool HasRightChild(long elementIndex) => GetRightChildIndex(elementIndex) < _size;
            private bool IsRoot(long elementIndex) => elementIndex == 0;

            private thread GetLeftChild(long elementIndex) => _elements[GetLeftChildIndex(elementIndex)];
            private thread GetRightChild(long elementIndex) => _elements[GetRightChildIndex(elementIndex)];
            private thread GetParent(long elementIndex) => _elements[GetParentIndex(elementIndex)];

            private void Swap(long firstIndex, long secondIndex)
            {
                var temp = _elements[firstIndex];
                _elements[firstIndex] = _elements[secondIndex];
                _elements[secondIndex] = temp;
            }

            public bool IsEmpty()
            {
                return _size == 0;
            }

            public thread Peek()
            {
                if (_size == 0)
                    throw new IndexOutOfRangeException();

                return _elements[0];
            }

            public thread ExtractMin()
            {
                if (_size == 0)
                    throw new IndexOutOfRangeException();

                var result = _elements[0];
                _elements[0] = _elements[_size - 1];
                _size--;

                SiftDown(0);

                return result;
            }

            public void Insert(thread element)
            {
                if (_size == _maxSize)
                    throw new IndexOutOfRangeException();

                _elements[_size] = element;
                _size++;

                SiftUp(_size-1);
            }

            private void SiftDown(long index)
            {
                while (HasLeftChild(index))
                {
                    var smallerIndex = GetLeftChildIndex(index);
                    if (HasRightChild(index) && GetRightChild(index).freeTime < GetLeftChild(index).freeTime)
                    {
                        smallerIndex = GetRightChildIndex(index);
                    }
                    if (HasRightChild(index) && GetRightChild(index).freeTime == GetLeftChild(index).freeTime && GetRightChild(index).id < GetLeftChild(index).id)
                    {
                        smallerIndex = GetRightChildIndex(index);
                    }

                    // if (_elements[smallerIndex].freeTime >= _elements[index].freeTime)
                    // {
                    //     break;
                    // }
                    if (_elements[smallerIndex].freeTime > _elements[index].freeTime)
                    {
                        break;
                    }
                    if (_elements[smallerIndex].freeTime == _elements[index].freeTime && _elements[smallerIndex].id > _elements[index].id)
                    {
                        break;
                    }

                    Swap(smallerIndex, index);
                    index = smallerIndex;
                }
            }

            private void SiftUp(long i)
            {
                bool con1 = !IsRoot(i) && _elements[i].freeTime < GetParent(i).freeTime;
                bool con2 = !IsRoot(i) && _elements[i].freeTime == GetParent(i).freeTime && _elements[i].id < GetParent(i).id;
                // while (!IsRoot(i) && _elements[i].freeTime < GetParent(i).freeTime)
                while (con1 || con2)
                {
                    var parentIndex = GetParentIndex(i);
                    Swap(parentIndex, i);
                    i = parentIndex;

                    con1 = !IsRoot(i) && _elements[i].freeTime < GetParent(i).freeTime;
                    con2 = !IsRoot(i) && _elements[i].freeTime == GetParent(i).freeTime && _elements[i].id < GetParent(i).id;
                }
            }
        }

        public class thread
        {
            public long id;
            public long freeTime;

            public thread(long id, long freeTime)
            {
                this.id = id;
                this.freeTime = freeTime;
            }
        }
    }
}
