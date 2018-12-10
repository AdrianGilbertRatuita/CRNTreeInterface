using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeGraph
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] Data0 = TreeGraph.LoadText("people.txt");
            //string[] Data1 = TreeGraph.LoadText("places.txt");
            //string[] Data2 = TreeGraph.LoadText("unknownTaxonomy.txt");

            TreeGraph NewTree0 = TreeGraph.CreateTree(Data0);
            //TreeGraph NewTree1 = TreeGraph.CreateTree(Data1);
            //TreeGraph NewTree2 = TreeGraph.CreateTree(Data2);

            TreeGraph.DisplayTree(NewTree0);
            //TreeGraph.DisplayTree(NewTree1);
            //TreeGraph.DisplayTree(NewTree2);

            Console.ReadLine();

        }
    }
}
