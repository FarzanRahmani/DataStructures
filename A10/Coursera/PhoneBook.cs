using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

public class PhoneBook {

    // Keep list of all existing (i.e. not deleted yet) contacts.
    // private static List<Contact> contacts = new List<Contact>();
    // public static Dictionary<int,string> contacts;
    public static string[] contacts = new string[10000000];

    public static void Main(string[] args) {
        int queryCount = int.Parse(Console.ReadLine());
        // contacts = new Dictionary<int, string>(queryCount);
        for (int i = 0; i < queryCount; ++i)
            processQuery(readQuery());
        Console.ReadKey();
    }

    public static Query readQuery() {
        string[] toks = Console.ReadLine().Split();
        string type = toks[0];
        int number = int.Parse(toks[1]);
        if (type.Equals("add")) {
            String name = toks[2];
            return new Query(type, name, number);
        } else {
            return new Query(type, number);
        }
    }

    private static void processQuery(Query query) {
        if (query.type.Equals("add")) {
            // contacts.Add(query.number,query.name);
            // contacts[query.number] = query.name;
            contacts[query.number] = query.name; // direct addressing

            // // if we already have contact with such number,
            // // we should rewrite contact's name
            // bool wasFound = false;
            // foreach (var contact in contacts)
            // {
            //     if (contact.number == query.number) {
            //         contact.name = query.name;
            //         wasFound = true;
            //         break;
            //     }
            // }
            // // otherwise, just add it
            // if (!wasFound)
            //     contacts.Add(new Contact(query.name, query.number));

        } else if (query.type.Equals("del")) {
            // contacts.Remove(query.number);
            contacts[query.number] = null; // direct addressing

            // for (Iterator<Contact> it = contacts.iterator(); it.hasNext(); )
            //     if (it.next().number == query.number) {
            //         it.remove();
            //         break;
            //     }

        } else {
            String response = "not found";
            // if (contacts.ContainsKey(query.number))
            // {
            //     response = contacts[query.number];
            // }
            if(contacts[query.number] != null) // direct addressing
                response = contacts[query.number];
            
            // foreach (Contact contact in contacts)
            //     if (contact.number == query.number) {
            //         response = contact.name;
            //         break;
            //     }
            System.Console.WriteLine(response);
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


}