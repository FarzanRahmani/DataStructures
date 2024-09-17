using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A8
{
    public class Q3PacketProcessing : Processor
    {
        public Q3PacketProcessing(string testDataName) : base(testDataName)
        {}

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long[], long[]>)Solve);

        class Request {
            public Request(int arrival_time, int process_time) {
                this.arrival_time = arrival_time;
                this.process_time = process_time;
            }

            public int arrival_time; // Ai
            public int process_time; // Pi
        }

        class Response {
            public Response(bool dropped, int start_time) {
                this.dropped = dropped;
                this.start_time = start_time;
            }

            public bool dropped;
            public int start_time;
        }

        class Buffer {
            public Buffer(int size) {
                this._size = size;
                this.finish_time_ = new List<int>();
                // this.finish_time_ = new Queue<int>(size);
            }

            public Response Process(Request request) {
                // write your code here
                // int t = finish_time_.Peek();
                int t = 0;
                if (finish_time_.Count > 0)
                    t = finish_time_.First();
                while (finish_time_.Count > 0 && t <= request.arrival_time)
                {
                    // t = finish_time_.Dequeue();
                    // finish_time_.TryDequeue(out t);
                    finish_time_.RemoveAt(0);
                    if(finish_time_.Count > 0)
                        t = finish_time_.First();
                }

                if (finish_time_.Count >= _size)
                    return new Response(true,-1);
                // int temp = finish_time_.Peek();
                int temp = 0;
                // finish_time_.TryPeek(out temp);
                if (finish_time_.Count > 0)
                    temp = finish_time_.Last();
                if (request.arrival_time > temp)
                    temp = request.arrival_time;
                // finish_time_.Enqueue(temp + request.process_time);
                finish_time_.Add(temp + request.process_time);
                return new Response(false,temp);
            }

            private int _size;
            private List<int> finish_time_;
            // private Queue<int> finish_time_;
            
        }

        public long[] Solve(long bufferSize, 
            long[] arrivalTimes, 
            long[] processingTimes)
        {
            Buffer buffer = new Buffer((int)bufferSize);

            // int requests_count = tokens[1]; // n
            int requests_count = arrivalTimes.Length; // n
            List<Request> requests = new List<Request>(requests_count);
            for (int i = 0; i < requests_count; ++i) {
                // tokens = Console.ReadLine().Split().Select(s => int.Parse(s)).ToArray();
                requests.Add(new Request((int)arrivalTimes[i], (int)processingTimes[i]));
            }

            List<Response> responses = new List<Response>(requests_count);
            for (int i = 0; i < requests_count; ++i) 
                responses.Add(buffer.Process(requests[i]));

            long[] ans = new long[requests_count];
            for (int i = 0; i < requests_count; ++i) {
                Response response = responses[i];
                if (response.dropped) 
                    // System.Console.WriteLine(-1);
                    ans[i] = -1;
                else 
                    // Console.WriteLine(response.start_time);
                    ans[i] = response.start_time;
            }
            return ans;
        }
    }
}