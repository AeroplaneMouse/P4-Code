using System.Collections.Generic;
using CellularCompiler.Nodes.Base;

namespace CellularCompiler.Nodes.Values
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
