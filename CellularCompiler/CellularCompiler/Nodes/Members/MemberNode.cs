using System.Collections.Generic;
using CellularCompiler.Nodes.Values;

namespace CellularCompiler.Nodes.Members
{
    public class MemberNode
    {
        public string Label { get; set; }
        public List<ValueNode> Values { get; set; }

        public MemberNode(string label, List<ValueNode> values)
        {
            Label = label;
            Values = values;
        }
    }
}
