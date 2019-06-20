using SortExtravaganza.Common;
using System;
using System.Linq;

namespace TreeSort
{
    public class Node
    {
        public int Key { get; set; }
        public Node LeftNode, RightNode;

        public Node(int item)
        {
            Key = item;
            LeftNode = RightNode = null;
        }
    }

    class TreeSort
    {
        // Root of Binary Search Tree
        Node Root = null;

        
        Node Insert(Node root, int key)
        {

            /* If the tree is empty, 
            return a new node */
            if (root == null)
            {
                root = new Node(key);
                return root;
            }

            /* Otherwise, recur 
            down the tree */
            if (key < root.Key)
            {
                root.LeftNode = Insert(root.LeftNode, key);
            }
            else if (key > root.Key)
            {
                root.RightNode = Insert(root.RightNode, key);
            }

            return root;
        }

        void inorderRec(Node root)
        {
            if (root != null)
            {
                inorderRec(root.LeftNode);
                Console.Write(root.Key + " ");
                inorderRec(root.RightNode);
            }
        }

        void InsertToTree(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Root = Insert(Root, arr[i]);
            }

        }

        public static void Main(String[] args)
        {
            TreeSort tree = new TreeSort();
            int[] arr = { 41, 93, 18, 2, 74, 56, 60, 19, 24, 63, 29 };
            CommonFunctions.PrintInitial(arr);

            tree.InsertToTree(arr);
            tree.inorderRec(tree.Root);

            Console.WriteLine("Root value: " + tree.Root.Key);
        }
    }
}
