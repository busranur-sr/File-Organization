using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace key
{
    class Node
    {
        public Node LeftNode;
        public Node RigthNode;
        public Node ParentNode=null;
        public int[] data;
    }
    class BinaryTree : Algorihms
    {
        Queue<Node> levelorder = new Queue<Node>();
        public int[,] Initialize(int[] keys, int pf)
        {
            int[,] table = MakeEmpty(pf);
            for(int i = 0; i < keys.Length; i++)
            {
                AddKey(ref table,keys[i], pf);
            }
            Show(table, pf);
            int probe = TotalProbe(table, keys, pf);
            Console.WriteLine("Binary Tree Algorithm");
            Console.WriteLine("Total Probe:" + probe);
            Performance(keys.Length, probe);

            return table;
        }
        
        public override int Search(int[,] table, int key,int pf,bool search)
        {
            bool found = false;
            int probe = 0;
            int index = key % pf;
            int inc = (key / pf) % pf;
            while (table[index,1]!=-1 && probe<pf)
            {
                probe++;
                if (table[index,1]==key)
                {
                    found = true;
                    break;
                }
                index = (index + inc) % pf;
                
            }
            if(!found)
            {
                Console.WriteLine("Couldn't Found");
                return -1;
            }
            if(search)
            {
                Console.WriteLine("\nBinary Tree Algorithm:");
                Console.WriteLine("Value of " + key + " found in " + index + ", probe: " + probe);
                
            }
            
            return probe;
        }


        void AddKey(ref int[,] table, int key, int pf)
        {
            Node root = new Node();
            root.data = new int[3];
            root.data[0] = key;
            root.data[1] = key % pf;
            root.data[2] = table[root.data[1], 1];

            if (root.data[2] == -1)
            {
                table[root.data[1], 1] = key;
            }
            else
            {
                levelorder.Enqueue(root);
                insert(ref table, key, pf);
            }
        }
        
        void insert(ref int[,] table, int key, int pf)
        {
            Node node = new Node();
            while (true)
            {                
                node = levelorder.Dequeue();
                node.LeftNode = AddNode(ref table, pf, node.data[1], node, true);
                if (node.LeftNode.data[2] == -1)
                {
                    node = node.LeftNode;
                    break;
                }
                levelorder.Enqueue(node.LeftNode);
                node.RigthNode = AddNode(ref table, pf, node.data[1], node, false);
                if (node.RigthNode.data[2] == -1)
                {
                    node = node.RigthNode;
                    break;
                }
                levelorder.Enqueue(node.RigthNode);
            }
            levelorder.Clear();
            Rearrange(node, ref table, key, pf);
        }

        void Rearrange(Node node, ref int[,] table, int key, int pf)
        {
            int value = node.data[0];
            table[node.data[1], 1] = node.data[0];
            node = node.ParentNode;
            
            while (node!=null)
            {
                if (value!=node.data[0])
                {
                    table[node.data[1], 1] = node.data[0];
                    value = node.data[0];
                }
                node = node.ParentNode; 
            }
        }
       
        Node AddNode(ref int[,] table, int pf, int index, Node Parent, bool lef_ri)
        {

            Node node = new Node();
            node.data = new int[3];
            node.ParentNode = Parent;
            if (lef_ri)
            {
                node.data[0] = Parent.data[0];
            }
            else
            {
                node.data[0] = Parent.data[2];
            }
            int inc = (node.data[0] / pf) % pf;
            node.data[1] = (index + inc) % pf;
            node.data[2] = table[node.data[1], 1];

            return node;
        }
        
        protected int[,] MakeEmpty(int size)
        {
            int[,] table = null;
            table = new int[size, 2];

            for (int j = 0; j < size; j++)
            {
                table[j, 0] = j;
                table[j, 1] = -1;
            }

            return table;
        }
        protected void Show(int[,] table, int pf)
        {
            for (int i = 0; i < pf; i++)
            {
                Console.Write("\n" + table[i, 0] + ". ");
                if (table[i, 1] == -1)
                {
                    Console.Write("__");
                }
                else
                {
                    Console.Write(table[i, 1]);
                }
            }
            Console.WriteLine("\n-------------------------");
        }
    }
}
