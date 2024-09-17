using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace A11
{
    public class Q4SetWithRangeSums : Processor
    {
        public Q4SetWithRangeSums(string testDataName) : base(testDataName)
        {
            // CommandDict =
            //             new Dictionary<char, Func<string, string>>()
            //             {
            //                 ['+'] = Add,
            //                 ['-'] = Del,
            //                 ['?'] = Find,
            //                 ['s'] = Sum
            //             };
        }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<string[], string[]>)Solve);

        // public readonly Dictionary<char, Func<string, string>> CommandDict;

        // public const long M = 1_000_000_001;

        // public long X = 0;

        // protected List<long> Data;

        public string[] Solve(string[] lines)
        {
            root = null;
            return solve(lines);
        }

        // Splay tree implementation

        // Vertex of a splay tree
        public class Vertex {
            public long key;
            // Sum of all the keys in the subtree - remember to update
            // it after each operation that changes the tree.
            public long sum;
            public Vertex left;
            public Vertex right;
            public Vertex parent;

            public Vertex(long key, long sum, Vertex left, Vertex right, Vertex parent) {
                this.key = key;
                this.sum = sum;
                // this.sum = sum % MODULO;
                this.left = left;
                this.right = right;
                this.parent = parent;
            }
        }

        public static void update(Vertex v) { // update the sum (sum of its children is always true because it comes from bottom to top)
            if (v == null) 
                return;
            v.sum = v.key + (v.left != null ? v.left.sum : 0) + (v.right != null ? v.right.sum : 0);
            if (v.left != null) {
                v.left.parent = v;
            }
            if (v.right != null) {
                v.right.parent = v;
            }
        }

        public static void smallRotation(Vertex v) { // rotateRighte and rotateLeft depend on it is leftChild or rightChild
            Vertex parent = v.parent;
            if (parent == null) { // already root
                return;
            }
            Vertex grandparent = v.parent.parent;
            if (parent.left == v) { // v is left child (rotate right)
                Vertex m = v.right;
                v.right = parent;   //parent.parent = v; // line 58 & 59 in kar ro anjam mide khoedsh
                parent.left = m;    //m.parent = parent;
            } else { // v is right child (rotate left)
                Vertex m = v.left;
                v.left = parent;    //parent.parent = v; // line 58 & 59 in kar ro anjam mide khoedsh
                parent.right = m;   //m.parent = parent;
            }
            update(parent); // just sum of v and parent is changed because the other's subtrees are unchanged
            update(v);
            v.parent = grandparent;
            if (grandparent != null) // P wasnt root
            {
                if (grandparent.left == parent) {
                    grandparent.left = v;
                } else {
                    grandparent.right = v;
                }
            }
        }

        public static void bigRotation(Vertex v) {
            if (v.parent.left == v && v.parent.parent.left == v.parent) {
                // Zig-zig
                smallRotation(v.parent);
                smallRotation(v);
            } else if (v.parent.right == v && v.parent.parent.right == v.parent) {
                // Zig-zig
                smallRotation(v.parent);
                smallRotation(v);
            } else {
                // Zig-zag
                smallRotation(v);
                smallRotation(v);
            }
        }

        // Makes splay of the given vertex and returns the new root.
        public static Vertex splay(Vertex v) {
            if (v == null) 
                return null;
            while (v.parent != null) { // ta vaghti ke be root beresim
                if (v.parent.parent == null) {
                    smallRotation(v); // zig
                    break;
                }
                bigRotation(v); // zig-zig , zig-zag
            }
            return v; // new root
        }

        public class VertexPair {
            public Vertex left;
            public Vertex right;
            public VertexPair() {}
            public VertexPair(Vertex left, Vertex right) {
                this.left = left;
                this.right = right;
            }
        }

        // Searches for the given key in the tree with the given root
        // and calls splay for the deepest visited node after that.
        // Returns pair of the result and the new root.
        // If found, result is a pointer to the node with the given key.
        // Otherwise, result is a pointer to the node with the smallest
        // bigger key (next value in the order).
        // If the key is bigger than all keys in the tree,
        // then result is null.
        public static VertexPair find(Vertex root, long key) {
            Vertex v = root;
            Vertex last = root;
            Vertex next = null;
            while (v != null) {
                if (v.key >= key &&  // chon next bayad az key bozorg tar ya mosavi bashe
                (next == null || v.key < next.key)) { // next fe'li nadarim ya(||) v be key az next nazdik tare
                    next = v; // next = nearest node after key (next >= v)
                }
                last = v; // akharin vertex i ast ke bad az oon dige v null mishe (last visited node)
                if (v.key == key) {
                    break;
                }
                if (v.key < key) {
                    v = v.right;
                } else {
                    v = v.left;
                }
            }
            // in root local hast na oon static ee
            root = splay(last); // v=null , last = v.parent  || v.key = last.key = key (deepest visited node)
            return new VertexPair(next, root);
        }

        public static VertexPair split(Vertex root, long key) {
            VertexPair result = new VertexPair();
            VertexPair findAndRoot = find(root, key); // return new VertexPair(next, root)
            root = findAndRoot.right;
            result.right = findAndRoot.left; // find (subtree >= key)
            if (result.right == null) { // key is maximum
                result.left = root;
                return result;
            }
            result.right = splay(result.right);
            result.left = result.right.left; // split
            result.right.left = null;
            if (result.left != null) {
                result.left.parent = null;
            }
            update(result.left);  // subtree < key
            update(result.right); // subtree >= key
            return result;
        }

        public static Vertex merge(Vertex left, Vertex right) {
            if (left == null) 
                return right;
            if (right == null) 
                return left;
            while (right.left != null) {
                right = right.left;
            } // right --> min in right tree
            right = splay(right); // right.left = null
            right.left = left;
            update(right); // update right and its ancestors sum
            return right;
        }

        public static Vertex Next(Vertex v)
        {
            if ( v == null)
                return null;
            if (v.right != null)
                return LeftDecendant(v.right);
            else
                return RightAncestor(v);
        }

        private static Vertex LeftDecendant(Vertex v)
        {
            if (v.left == null)
                return v;
            else
                return LeftDecendant(v.left);
        }

        private static Vertex RightAncestor(Vertex v)
        {
            if (v == null)
                return null;
            if (v.parent == null)
                return null;
            if (v.key < v.parent.key)
                return v.parent;
            else
                return RightAncestor(v.parent);
        }

        // Code that uses splay tree to solve the problem

        public static Vertex root = null;

        public static void insert(long x) {
            Vertex left = null;
            Vertex right = null;
            Vertex new_vertex = null;

            VertexPair leftRight = split(root, x);
            left = leftRight.left;
            right = leftRight.right;

            if (right == null || right.key != x) { // x isn't in tree  (left < x) (right >= x)
                new_vertex = new Vertex(x, x, null, null, null);
            }
            root = merge(merge(left, new_vertex), right);
        }

        public static void erase(long x) { // ba split(left,mid,right) va merge(left,right) ham mishe
            // Implement erase yourself

            VertexPair LeftRight = split(root, x);
            Vertex left = LeftRight.left;
            Vertex right = LeftRight.right;
            // if (right != null && right.key == x)
            if (right != null )
                if (right.key == x)
                {
                    Vertex newRight = right.right;
                    right = newRight;
                    if ( right != null)
                        right.parent = null;
                }
            root = merge(left,right);

            // ----------------

            // VertexPair nextAndRoot = find(root,x);
            // Vertex next = nextAndRoot.left;
            // root = nextAndRoot.right; // root
            // if(next == null)
            //     return;
            // if (next.key != x)
            //     return;
            // else
            // {
            //     // Vertex Nextofx = Next(next); // find(root,x+1)

            //     VertexPair NextofxAndRoot = find(root,x+1);
            //     Vertex Nextofx = NextofxAndRoot.left;
            //     root = NextofxAndRoot.right;

            //     if (Nextofx != null)
            //     {
            //         root = splay(Nextofx);
            //         root = splay(next);
            //         // delete
            //         Nextofx.parent = null;
            //         Nextofx.left = next.left;
            //         next.left.parent = Nextofx;
            //         root = Nextofx;
            //         update(root);
            //     }
            //     else
            //     {
            //         root = splay(next); // next = key
            //         if (next.left != null)
            //         {
            //             next.left.parent = null;
            //             root = next.left;
            //         }
            //         else
            //         {
            //             root = null;
            //         }
            //         update(root);
            //     }
            // }

        }

        public static bool find(long x) {
            // Implement find yourself
            VertexPair leftRight = split(root, x);
            Vertex left = leftRight.left;
            Vertex right = leftRight.right;
            bool ans = true;
            if (right == null)
                ans = false;
            else if (right.key != x)
                ans = false;
            root = merge(left,right);
            return ans;
            // ------------

            // VertexPair nextAndRoot = find(root,x);
            // Vertex next = nextAndRoot.left;
            // root = nextAndRoot.right; // ***
            // if (next == null)
            //     return false;
            // else if (next.key == x)
            //     return true;
            // else
            //     return false;
        }

        public static long sum(long from, long to) {
            VertexPair leftMiddle = split(root, from);
            Vertex left = leftMiddle.left;
            Vertex middle = leftMiddle.right;
            VertexPair middleRight = split(middle, to + 1);
            middle = middleRight.left;
            Vertex right = middleRight.right;
            long ans = 0;
            // Complete the implementation of sum
            if (middle != null)
                ans = middle.sum;
                // ans = middle.sum % MODULO;
            // Vertex MergeLeftMiddle = merge(left,middle);
            // root = merge(MergeLeftMiddle,right);
            root = merge(merge(left,middle),right);
            return ans;
        }

        public static long MODULO = 1000000001;

        public static string[] solve(string[] lines) {
            int n = lines.Length;
            List<string> ans = new List<string>(n);
            long last_sum_result = 0;// x
            string[] toks;
            for (int i = 0; i < n; i++) {
                toks = lines[i].Split();// "+ i" ,"- i" , "? i" , "s l r"
                char type = toks[0][0];
                switch (type) {
                    case '+' : {
                        int x = int.Parse(toks[1]);
                        insert((x + last_sum_result) % MODULO);
                    } break;
                    case '-' : {
                        int x = int.Parse(toks[1]);
                        erase((x + last_sum_result) % MODULO);
                    } break;
                    case '?' : {
                        int x = int.Parse(toks[1]);
                        // Console.ForegroundColor = ConsoleColor.Green;
                        // Console.WriteLine(find((x + last_sum_result) % MODULO) ? "Found" : "Not found");
                        if (find((x + last_sum_result) % MODULO))
                            ans.Add("Found");
                        else
                            ans.Add("Not found");
                        // Console.ForegroundColor = ConsoleColor.White;
                    } break;
                    case 's' : {
                        int l = int.Parse(toks[1]);
                        int r = int.Parse(toks[2]);
                        long res = sum((l + last_sum_result) % MODULO, (r + last_sum_result) % MODULO);
                        // long res = sum((l + last_sum_result) % MODULO, (r + last_sum_result) % MODULO) % MODULO;
                        // Console.ForegroundColor = ConsoleColor.Green;
                        // Console.WriteLine(res);
                        ans.Add(res.ToString());
                        // Console.ForegroundColor = ConsoleColor.White;
                        // last_sum_result = (int)(res % MODULO);
                        last_sum_result = res;
                        break;
                    }
                }
            }
            return ans.ToArray();
        }
    }
}
