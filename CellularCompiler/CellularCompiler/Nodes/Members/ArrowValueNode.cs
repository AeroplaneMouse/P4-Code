namespace CellularCompiler.Nodes.Members
{
    class ArrowValueNode : MemberValueNode
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
