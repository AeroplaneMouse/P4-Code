namespace CellularCompiler.Nodes.Math
{
    class NumberNode : ExpressionNode
    {
        public double Value { get; set; }

        public NumberNode()
            : this(0) { }

        public NumberNode(double value)
        {
            Value = value;
        }
    }
}



