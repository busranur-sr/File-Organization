using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace key
{
    class Algorihms
    {
        public virtual int Search(int[,] table, int key, int pf,bool search)
        {
            return 0;
        }
        public int TotalProbe(int[,] table, int[] key, int pf)
        {
            int totalprobe = 0;
            int probe;
            for (int i = 0; i < key.Length; i++)
            {
                probe = Search(table, key[i], pf,false);
                Console.WriteLine("Probe for " + key[i] + ": " + probe);
                totalprobe += probe;
            }
            return totalprobe;
        }

        protected double Performance(int keylength, int probe)
        {
            double pfmc = Convert.ToDouble(probe) / Convert.ToDouble(keylength);
            Console.WriteLine("Performance of Algorithm is: " + pfmc);
            return pfmc;
        }
        
        
            
    }

}
