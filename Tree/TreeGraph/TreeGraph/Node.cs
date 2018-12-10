using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeGraph
{
    public class Node : INode
    {

        #region Properties
        //=======================================
        public int Depth { get; set; }

        public int Height { get; set; }

        public string NodeName { get; private set; }

        public string NodeValue { get; set; }

        public string KeyIdentifier { get; private set; }

        public INode ParentNode { get; private set; }

        public List<INode> NodeChildren { get; private set; }

        //=======================================
        #endregion

        #region Constructors
        //=======================================
        public Node(string Value) : this("", Value, "", null) { }
        public Node(string Name, string Value) :this(Name, Value, "", null) { }
        public Node(string Name, string Value, string Key) :this(Name, Value, Key, null) { }
        public Node(string Name, string Value, string Key, INode Parent)
        {

            NodeName = Name;
            NodeValue = Value;
            KeyIdentifier = Key;
            ParentNode = Parent;
            NodeChildren = new List<INode>();

        }
        //=======================================
        #endregion

        #region Functions
        //=======================================
        public void ChangeParentNode(INode NewParent)
        {
            
            if (ParentNode != null)
            {

                ParentNode.RemoveNodeChild(this);

            }
            ParentNode = NewParent;

        }

        public INode GetParentNode(INode Node)
        {

            return Node.ParentNode;

        }


        public void AddNodeChild(INode NewNode)
        {

            NewNode.ChangeParentNode(this);
            NodeChildren.Add(NewNode);
            
        }

        public List<INode> GetChildrenList()
        {

            return NodeChildren;
        }

        public void RemoveNodeChild(INode RemoveNode)
        {
            
            if (NodeChildren.Contains(RemoveNode))
            {

                RemoveNodeChild(RemoveNode.NodeName);

            }

        }

        public void RemoveNodeChild(string Name)
        {

            int NodeIndex = -1;

            for (int i = 0; i < NodeChildren.Count; i++)
            {

                if (NodeChildren[i].NodeName == Name)
                {

                    NodeIndex = i;

                }

            }

            if (NodeIndex != -1)
            {

                NodeChildren[NodeIndex].ChangeParentNode(null);
                NodeChildren.RemoveAt(NodeIndex);

            }

        }

        //=======================================
        #endregion

    }
}
