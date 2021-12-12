using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace key
{
    class BEISCH : Algorihms
    {
        public int[,] Initialize(int[] keys,int pf)
        {
            int[,] table = MakeEmpty(pf);
            bool dimension = true;
            
            for (int i = 0; i < keys.Length; i++)
            {
                addKey(keys[i], ref table, ref dimension, pf);
            }
            Show(table, pf);
            int probe = TotalProbe(table, keys, pf);
            Console.WriteLine("Beisch Algorithm");
            Console.WriteLine("Total Probe:" + probe);
            Performance(keys.Length, probe);

            return table;

        }


        
        void addKey(int key, ref int[,] table, ref bool dimension, int pf)
        {

            int home = key % pf;
            if (table[home, 0] != -1)
            {
                if (dimension == true)
                {
                    Insert(ref table, home, key, pf, 0, 1);
                }
                else
                {
                    Insert(ref table, home, key, pf, pf - 1, -1);
                }
                dimension = !dimension;
            }
            else
            {
                table[home, 0] = key;
            }

        }

        void Insert(ref int[,] table, int home, int key, int pf, int start, int inordown)
        {
            bool full = false;
            int i = start;
            while (table[i, 0] != -1)
            {
                i = i + inordown;
                if (i == pf || i == -1)
                {
                    full = true;
                    Console.WriteLine("Table is full");
                    break;
                }

            }
            if (!full)
            {
                table[i, 0] = key;
                table[i, 1] = table[home, 1];
                table[home, 1] = i;
            }
        }

       public override int Search(int[,] table, int key, int pf,bool search)
        {
            int probe = 0;
            int i = key % pf;
            while (i != -1)
            {
                probe++;
                if (table[i, 0] == key)
                {
                    if(search)
                    {
                        Console.WriteLine("\n\nBeisch Algorithm:");
                        Console.WriteLine("Value of " + key + " found in " + i + ", probe: " + probe);
                    }
                    return probe;
                }
                else
                {
                    i = table[i, 1];
                }
            }
            Console.WriteLine("Couldn't fould");
            return 0;

        }
        

        protected int[,] MakeEmpty(int size)
        {
            int[,] table = null;
            table = new int[size, 3];

            for (int j = 0; j < size; j++)
            {
                table[j, 0] = -1;
                table[j, 1] = -1;
                table[j, 2] = j;
            }

            return table;
        }
        protected void Show(int[,] table, int pf)
        {
            for (int i = 0; i < pf; i++)
            {
                Console.Write("\n" + table[i, 2] + ". ");
                if (table[i, 0] == -1)
                {
                    Console.Write("__");
                }
                else
                {
                    Console.Write(table[i, 0]);
                }
                Console.Write(",");
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
