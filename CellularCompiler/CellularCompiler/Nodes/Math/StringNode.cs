namespace CellularCompiler.Nodes.Math
{
    class StringNode : ExpressionNode
    {
        public string Value { get; set; }

        public StringNode(string value)
        {
            Value = value;
        }
    }
}



