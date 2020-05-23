using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.XPath;

namespace CI.Nodes.Values
{
    class IdentifierValueNode : ValueNode
    {
        public string Label { get; set; }

        public IdentifierValueNode(string label)
        {
            Label = label;
        }

        public override bool Equals(object obj)
        {
            bool result;

            if (obj is IdentifierValueNode node)
                result = Label == node.Label;
            else
                result = false;

            return result && base.Equals(obj);
        }
    }
}
