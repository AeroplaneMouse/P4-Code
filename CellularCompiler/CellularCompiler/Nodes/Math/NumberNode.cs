namespace CellularCompiler.Nodes.Math
{
    class NumberNode : ExpressionNode
    {
        public int Value { get; set; }

        public NumberNode()
            : this(0) { }

        public NumberNode(int value)
        {
            Value = value;
        }
    }
}



