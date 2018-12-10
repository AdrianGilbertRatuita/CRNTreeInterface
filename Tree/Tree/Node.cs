using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
    public class Node : INode
    {

        public float Depth { get; set; }
        public string Value { get; set;}
        public string Identifier { get; private set; }
        public bool IsReady { get { return ReadyCheck(Value); } set { IsReady = value; } }
        public INode ParentNode { get; set; }
        public List<INode> NodeChildren { get; private set; }

        // Function delegate for checking if node is ready
        Func<string, bool> ReadyCheck = delegate(string S) { if (S == string.Empty) return false; else return true; };

        public Node(string _Value, float _Depth) : this (_Value, _Depth, "") { }

        public Node(string _Value, float _Depth, string _Identifier)
        {

            //
            Depth = _Depth;
            Value = _Value;
            Identifier = _Identifier;

            //
            ParentNode = null;
            NodeChildren = new List<INode>();

        }

        public static void ChangeParentNode(INode Child, INode NewParent)
        {

            if (Child.ParentNode != null)
            {

                Child.ParentNode.NodeChildren.Remove(Child);

            }
            Child.ParentNode = NewParent;
            NewParent.NodeChildren.Add(Child);



            UpdateChildrenDepth(Child, NewParent);

        }

        private static void UpdateChildrenDepth(INode Child, INode Parent)
        {

            //
            if (Parent.Identifier != "Root" && Parent.Value != "Root")
            {

                Child.Depth = Parent.Depth + 1;

            }
            else
            {

                Child.Depth = 0;

            }

            if(Child.NodeChildren.Count != 0)
            {

                for (int i = 0; i < Child.NodeChildren.Count; i++)
                {

                    UpdateChildrenDepth(Child.NodeChildren[i], Child);

                }

            }

        }

    }

}
