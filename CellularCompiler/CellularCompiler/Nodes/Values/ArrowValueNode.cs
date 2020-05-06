namespace CellularCompiler.Nodes.Values
{
    class ArrowValueNode : ValueNode
    {
        public int LeftValue { get; set; }
        public int RightValue { get; set; }

        public ArrowValueNode(int left, int right)
        {
            LeftValue = left;
            RightValue = right;
        }
    }
}
