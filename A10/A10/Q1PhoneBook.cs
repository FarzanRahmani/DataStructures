using System;
using System.Linq;
using System.Collections.Generic;
using TestCommon;

namespace A10
{
    // public class Contact
    // {
    //     public string Name;
    //     public int Number;

    //     public Contact(string name, int number)
    //     {
    //         Name = name;
    //         Number = number;
    //     }
    // }

    public class Q1PhoneBook : Processor
    {
        public Q1PhoneBook(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<string[], string[]>)Solve);

        // protected List<Contact> PhoneBookList;

        public string[] Solve(string [] commands)
        {
            // contacts = new string[10000000];
            contacts = new Dictionary<int, string>();
            int queryCount = commands.Length;
            // contacts = new Dictionary<int, string>(queryCount);
            List<string> ans = new List<string>(queryCount);
            for (int i = 0; i < queryCount; ++i)
                processQuery(readQuery(commands[i]),ans);
            return ans.ToArray();



            // PhoneBookList = new List<Contact>(commands.Length);
            // List<string> result = new List<string>();
            // foreach(var cmd in commands)
            // {
            //     var toks = cmd.Split();
            //     var cmdType = toks[0];
            //     var args = toks.Skip(1).ToArray();
            //     int number = int.Parse(args[0]);
            //     switch (cmdType)
            //     {
            //         case "add":
            //             Add(args[1], number);
            //             break;
            //         case "del":
            //             Delete(number);
            //             break;
            //         case "find":
            //             result.Add(Find(number));
            //             break;
            //     }
            // }
            // return result.ToArray();
        }

        // Keep list of all existing (i.e. not deleted yet) contacts.
        // private static List<Contact> contacts = new List<Contact>();
        public static Dictionary<int,string> contacts;
        // public static string[] contacts = new string[10000000];

        public static Query readQuery(string v) {
            string[] toks = v.Split();
            string type = toks[0];
            int number = int.Parse(toks[1]);
            if (type.Equals("add")) {
                String name = toks[2];
                return new Query(type, name, number);
            } else {
                return new Query(type, number);
            }
        }

        private static void processQuery(Query query, List<string> ans) {
            if (query.type.Equals("add")) {
                // contacts.Add(query.number,query.name);
                contacts[query.number] = query.name;
                // contacts[query.number] = query.name; // direct addressing

                // if we already have contact with such number,
                // we should rewrite contact's name
            } else if (query.type.Equals("del")) {
                contacts.Remove(query.number);
                // contacts[query.number] = null; // direct addressing

            } else {
                String response = "not found";
                if (contacts.ContainsKey(query.number))
                {
                    response = contacts[query.number];
                }
                // if(contacts[query.number] != null) // direct addressing
                //     response = contacts[query.number];
                
                ans.Add(response);
            }
        }


        public class Query {
            public string name;
            public string type;
            public int number;

            public Query(String type, String name, int number) {
                this.type = type;
                this.name = name;
                this.number = number;
            }

            public Query(String type, int number) {
                this.type = type;
                this.number = number;
            }
        }

        // public class Contact {
        //     public String name;
        //     public int number;

        //     public Contact(String name, int number) {
        //         this.name = name;
        //         this.number = number;
        //     }
        // }

        // public void Add(string name, int number)
        // {
        //     for(int i=0; i<PhoneBookList.Count; i++)
        //     {
        //         if (PhoneBookList[i].Number == number)
        //         {
        //             PhoneBookList[i].Name = name;
        //             return;
        //         }
        //     }
        //     PhoneBookList.Add(new Contact(name, number));
        // }

        // public string Find(int number)
        // {
        //     for (int i = 0; i < PhoneBookList.Count; i++)
        //     {
        //         if (PhoneBookList[i].Number == number)
        //             return PhoneBookList[i].Name;             
        //     }
        //     return "not found";
        // }

        // public void Delete(int number)
        // {
        //     for (int i = 0; i < PhoneBookList.Count; i++)
        //     {
        //         if (PhoneBookList[i].Number == number)
        //         {
        //             PhoneBookList.RemoveAt(i);
        //             return;
        //         }
        //     }
        // }
    }
}
