using CellularCompiler.Nodes.Values;

namespace CellularCompiler.Nodes.Members
{
    class ReturnMemberNode
    {
        public IdentifierValueNode ID { get; set; }
        public ValueNode Value { get; set; }

        public ReturnMemberNode(IdentifierValueNode id, ValueNode value)
        {
            ID = id;
            Value = value;
        }
    }
}
