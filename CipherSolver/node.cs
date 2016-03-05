using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CipherSolver
{
    public class node
    {
        public char letter;
        public List<node> nodes = new List<node>();

        public node(char l, List<List<char>> other_nodes, int position)
        {
            letter = l;
            if (position >= other_nodes.Count)
            {
                nodes = null;
            }
            else
            {
                foreach (char c in other_nodes[position])
                {
                    nodes.Add(new node(c, other_nodes, position+1));
                }
            }
        }
    }
}
