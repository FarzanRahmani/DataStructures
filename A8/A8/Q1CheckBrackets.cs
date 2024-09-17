using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace A8
{
    public class Q1CheckBrackets : Processor
    {
        public Q1CheckBrackets(string testDataName) : base(testDataName)
        {}

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<string, long>)Solve);

        public class Bracket {
        public Bracket(char type, int position) {
            this.type = type;
            this.position = position;
        }

        public bool Match(char c) {
            if (this.type == '[' && c == ']')
                return true;
            if (this.type == '{' && c == '}')
                return true;
            if (this.type == '(' && c == ')')
                return true;
            return false;
        }

        public char type;
        public int position;
    }

        public long Solve(string text)
        {
            Stack<Bracket> opening_brackets_stack = new Stack<Bracket>();
            for (int position = 0; position < text.Length; ++position) {
                char next = text[position];

                // Process opening bracket
                if (next == '(' || next == '[' || next == '{') 
                    opening_brackets_stack.Push(new Bracket(next,position));
                
                // Process closing bracket
                else if (next == ')' || next == ']' || next == '}') {
                    if (opening_brackets_stack.Count == 0)
                        // Console.WriteLine($"{position + 1}");
                        return position + 1;
                    
                    Bracket top = opening_brackets_stack.Pop();
                    if (!top.Match(next))
                    {
                        // Console.WriteLine($"{position + 1}");
                        return position + 1;
                    }
                }
            }
            // Printing answer
            if (opening_brackets_stack.Count == 0)
                // Console.WriteLine("Success");
                return -1;
            
            else
            {
                for (int i = 1; i < opening_brackets_stack.Count; i++)
                    opening_brackets_stack.Pop();
                
                Bracket b = opening_brackets_stack.Pop();
                // Console.WriteLine(b.position + 1);
                return b.position + 1;
            }
        }
    }
}
