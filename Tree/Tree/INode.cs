using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
    public interface INode
    {

        float Depth { get; set; }
        string Value { get; set; }
        string Identifier { get; }
        bool IsReady { get; set; }
        INode ParentNode { get; set; }
        List<INode> NodeChildren { get; }

    }

}
