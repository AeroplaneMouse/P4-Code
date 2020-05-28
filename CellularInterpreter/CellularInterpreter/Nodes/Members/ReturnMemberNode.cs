using CI.Nodes.Values;

namespace CI.Nodes.Members
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
