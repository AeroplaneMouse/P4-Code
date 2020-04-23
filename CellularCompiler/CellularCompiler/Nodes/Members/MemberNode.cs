using System.Collections.Generic;
using CellularCompiler.Nodes.Base;

namespace CellularCompiler.Nodes.Members
{
    class MemberNode
    {
        public string Label { get; set; }
        public List<MemberValueNode> Values { get; set; }

        public MemberNode(string label, List<MemberValueNode> values)
        {
            Label = label;
            Values = values;
        }
    }
}
