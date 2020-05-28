namespace CI.Nodes.Values
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

        public override bool Equals(object obj)
        {
            bool result;
            if (obj is ArrowValueNode otherNode)
                result = LeftValue == otherNode.LeftValue && RightValue == otherNode.RightValue;
            else
                result = false;

            return result && base.Equals(obj);
        }
    }
}
