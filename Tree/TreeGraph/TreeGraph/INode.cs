using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeGraph
{
    public interface INode
    {

        int Depth { get; }
        int Height { get; }
        string NodeName { get; }
        string NodeValue { get; }
        string KeyIdentifier { get; }
        INode ParentNode { get; }
        List<INode> NodeChildren { get; }
        void AddNodeChild(INode NewNode);
        void ChangeParentNode(INode Parent);
        void RemoveNodeChild(INode RemoveNode);
        void RemoveNodeChild(string Name);
        List<INode> GetChildrenList();

    }
}
