using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeGraph
{
    public class TreeGraph
    {

        public int MaximumHeight;
        public INode DefaultRootNode;

        public TreeGraph()
        {

            DefaultRootNode = new Node("Root", "RootNode", "Root", null);

        }

        public TreeGraph(INode Root)
        {

            DefaultRootNode = Root;

        }

        public static string[] LoadText(string Path)
        {

            return System.IO.File.ReadAllLines(Path);

        }

        public static void WriteOutLineFile(string Path)
        {

            //ystem.IO.File.WriteAllLines(Path, Lines);

        }

        /// <summary>
        /// Add a node to the tree nodes list
        /// </summary>
        /// <param name="NewNode"></param>
        public void AddNode(INode NewNode)
        {

            DefaultRootNode.AddNodeChild(NewNode);

        }

        /// <summary>
        /// Add node to a node with the passed given name
        /// </summary>
        /// <param name="NodeName"></param>
        /// <param name="NewNode"></param>
        //public void AddNodeToNodeChild(string NodeName, INode NewNode)
        //{

        //    for (int i = 0; i < Nodes.Count; i ++)
        //    {

        //        if (Nodes[i].NodeName == NodeName)
        //        {

        //            AddNodeToNodeChild(Nodes[i], NewNode);
        //        }

        //    }

        //}

        /// <summary>
        /// Add node to a node with the passed name and value
        /// </summary>
        /// <param name="NodeName"></param>
        /// <param name="Value"></param>
        /// <param name="NewNode"></param>
        //public void AddNodeToNodeChild(string NodeName, string Value, INode NewNode)
        //{

        //    for (int i = 0; i < Nodes.Count; i++)
        //    {

        //        if (Nodes[i].NodeName == NodeName && Nodes[i].NodeValue == Value)
        //        {

        //            AddNodeToNodeChild(Nodes[i], NewNode);
        //        }

        //    }

        //}

        /// <summary>
        /// Add node to a node with the passed given name, value and key
        /// </summary>
        /// <param name="NodeName"></param>
        /// <param name="Value"></param>
        /// <param name="Key"></param>
        /// <param name="NewNode"></param>
        //public void AddNodeToNodeChild(string NodeName, string Value, string Key, INode NewNode)
        //{

        //    for (int i = 0; i < Nodes.Count; i++)
        //    {

        //        if (Nodes[i].NodeName == NodeName)
        //        {

        //            AddNodeToNodeChild(Nodes[i], NewNode);
        //        }

        //    }

        //}

        /// <summary>
        /// Make the passed node a child of the given node
        /// </summary>
        /// <param name="ChildNode"></param>
        /// <param name="NewNode"></param>
        public void AddNodeToNodeChild(INode ChildNode, INode NewNode)
        {

            ChildNode.AddNodeChild(NewNode);
            ChildNode.ChangeParentNode(NewNode);

        }

        /// <summary>
        /// Remove a node with the tree node list
        /// </summary>
        /// <param name="NodeToRemove"></param>
        public void RemoveNode(INode NodeToRemove)
        {

            if (DefaultRootNode.NodeChildren.Contains(NodeToRemove))
            {

                DefaultRootNode.RemoveNodeChild(NodeToRemove);

            }

        }

        /// <summary>
        /// Remove a node within the tree node list by passed name
        /// </summary>
        /// <param name="Name"></param>
        public void RemoveNode(string Name)
        {

            DefaultRootNode.RemoveNodeChild(Name);

        }

        /// <summary>
        /// Get Tree List Nodes
        /// </summary>
        /// <param name="Nodes"></param>
        /// <returns></returns>
        public List<INode> GetNodes(string Nodes)
        {

            return new List<INode>();

        }

        /// <summary>
        /// Get all nodes with the same name
        /// </summary>
        /// <param name="Nodes"></param>
        /// <returns></returns>
        public List<INode> GetNodes(INode Nodes)
        {

            List<INode> NodesOfTheSameName;

            for (int i = 0; i < DefaultRootNode.NodeChildren.Count; i++)
            {


            }

            return new List<INode>();

        }

        /// <summary>
        /// Get all the child of a specific node
        /// </summary>
        /// <param name="Node"></param>
        /// <returns></returns>
        public List<INode> GetChildrenNodes(INode Node)
        {

            return Node.NodeChildren;

        }

        public int GetRootNodeSize()
        {

            return DefaultRootNode.NodeChildren.Count;

        }

        public static void DisplayTree(TreeGraph Tree)
        {


            for (int i = 0; i < Tree.GetRootNodeSize(); i++)
            {

                Console.WriteLine(Tree.DefaultRootNode.NodeChildren[i].NodeValue);

            }
            
            Console.ReadLine();

        }

        public static void DisplayChild()
        {


        }

        public static TreeGraph CreateTree(string[] TreeData)
        {

            TreeGraph NewTree = new TreeGraph();

            List<int> Depth = new List<int>();
            List<INode> Nodes = new List<INode>();

            for (int i = 0; i < TreeData.Length; i++)
            {

                Depth.Add(TreeData[i].Count(x => x == '\t'));
                Nodes.Add(new Node(TreeData[i].Replace("\t", "")));

            }

            int CurrentHighestDepth = 0;

            for (int i = 0; i < Depth.Count; i++)
            {

                if (Depth[i] > Depth[i - 1])
                {

                    CurrentHighestDepth = Depth[i];

                }
                else if (Depth[i] < Depth[i - 1])
                {

                    CurrentHighestDepth = Depth[i];

                }
                else if (Depth[i] == Depth[i - 1])
                {

                    //NewTree.DefaultRootNode.GetChildrenList().Last().ParentNode.AddNodeChild(Nodes[i]);

                }
                else if (Depth[i] == 0)
                {

                    NewTree.AddNode(Nodes[i]);

                }

            }

            return NewTree;

        }

    }

    public INode RecursiveReturn(int i, INode Node)
    {

        if (i > 0)
        {

            

        }

    }

}
