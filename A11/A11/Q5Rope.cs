using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A11
{
    public class Q5Rope : Processor
    {
        public Q5Rope(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<string, long[][], string>)Solve);

        public string Solve(string text, long[][] queries)
        {
            // create tree
            for (int i = 0; i < text.Length; i++)
            {
                insertSpecific(root,text[i]); // root --> tree
            }
            for (int i = 0; i < queries.Length; i++)
            {
                Process(root,queries[i][0],queries[i][1],queries[i][2]);
            }
            string ans = InOrder(root);
            root = null;//destroy tree
            return ans;
            throw new NotImplementedException();
        }

        // Code that uses splay tree to solve the problem

        public static Vertex root = null;

        private void Process(Vertex root, long i, long j, long k)
        {
            throw new NotImplementedException();
        }

        private string InOrder(Vertex root)
        {
            throw new NotImplementedException();
        }

        private void insertSpecific(Vertex root, char v)
        {
            Vertex newV = new Vertex(v);
            if (root != null)
                root.parent = newV;
            newV.left = root;
            newV.size = ((newV.left != null) ? newV.left.size : 0) + 1;
            root = newV;
        }

        // public static void insert(long x) {
        //     Vertex left = null;
        //     Vertex right = null;
        //     Vertex new_vertex = null;

        //     VertexPair leftRight = split(root, x);
        //     left = leftRight.left;
        //     right = leftRight.right;

        //     if (right == null || right.key != x) { // x isn't in tree  (left < x) (right >= x)
        //         new_vertex = new Vertex(x, x, null, null, null);
        //     }
        //     root = merge(merge(left, new_vertex), right);
        // }

        // Splay tree implementation

        // Vertex of a splay tree
        public class Vertex {
            public char key; // value
            public long size;
            public Vertex left;
            public Vertex right;
            public Vertex parent;

            public Vertex(char k)
            {
                size = 1;
                key = k;
            }

            public Vertex(char key, long size, Vertex left, Vertex right, Vertex parent) {
                this.key = key;
                this.size = size;
                this.left = left;
                this.right = right;
                this.parent = parent;
            }
        }

        public static void update(Vertex v) { // update the size (sum of its children is always true because it comes from bottom to top)
            if (v == null) 
                return;
            v.size = 1 + (v.left != null ? v.left.size : 0) + (v.right != null ? v.right.size : 0);
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
                v.right = parent;  // parent.parent = v; // line 58 & 59 in kar ro anjam mide khoedsh
                parent.left = m;   // m.parent = parent;
            } else { // v is right child (rotate left)
                Vertex m = v.left;
                v.left = parent;   // parent.parent = v; // line 58 & 59 in kar ro anjam mide khoedsh
                parent.right = m;  // m.parent = parent;
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

        public static Vertex orderStatisticZeroBasedRanking(Vertex root,long k)
        {
            long s = root.left.size;
            if (s + 1 == k)
                return root;
            else if (s + 1 > k)
                return orderStatisticZeroBasedRanking(root.left,k);
            else
                return orderStatisticZeroBasedRanking(root.right,k - s - 1);
            // splay
        }

    }
}
