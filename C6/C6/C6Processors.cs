using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C6
{
    public class C6Processors
    {
        
        public static string ProcessQ1Circle(string inStr, Func<SinglyLinkedList,long> Solve)
        {
            var lines = inStr.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            var first = lines[0].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(d => int.Parse(d)).ToArray()[0];
            var second = lines[1].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(d => int.Parse(d)).ToArray()[0];
            SinglyLinkedList llist = new SinglyLinkedList();
            for(int i=2;i<lines.Length;i++)
            {
                llist.Insert(int.Parse(lines[i]));
            }
            SinglyLinkedListNode extra = new SinglyLinkedListNode(-1);
            SinglyLinkedListNode temp = llist.head;
            for (int i=0;i<second;i++)
            {
                if (i == first)
                {
                    extra = temp;
                }

                if (i != second-1)
                {
                    temp = temp.next;
                }
            }
            temp.next = extra;

            return Solve(llist).ToString();
        }

        public static string ProcessQ2Truck(string inStr, Func<long, long[], long[], long> Solve)
        {
            var lines = inStr.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            var n = lines[0].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(d => long.Parse(d)).ToArray()[0];
            
            long[] petr = new long[n];
            long[] dist = new long[n];

            for (int i=1;i<lines.Length;i++)
            {
                long[] temp=lines[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(d => long.Parse(d)).ToArray();
                petr[i-1]=temp[0];
                dist[i-1]=temp[1];
            }

            return Solve(n,petr,dist).ToString();
        }
    }
}



