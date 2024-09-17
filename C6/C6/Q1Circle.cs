using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using TestCommon;

namespace C6
{
    public class Q1Circle : Processor
    {
        public Q1Circle(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) => C6Processors.ProcessQ1Circle(inStr, Solve);
        

        public long Solve(SinglyLinkedList llist)
        {
            // if (llist.tail.next == null)
            //     return 0;
            // else
            //     return 1;
            if (llist.head == null)
                return 0;
            
            SinglyLinkedListNode red = llist.head;
            if (red == null)
                return 0;
            
            SinglyLinkedListNode blue = llist.head.next;
            if (blue.next == null)
                return 0;
            
            while (true)
            {
                if(blue == red)
                    return 1;
                
                if (blue.next == null)
                    return 0;
                
                if (blue.next.next == null)
                    return 0;
                
                blue = blue.next.next;
                red = red.next;
            }
        }
    }
}
