using System;
using CellularCompiler.Models;

namespace CellularCompiler.Nodes.Values
{
    class StateValueNode : ValueNode
    {
        public StateSymbol State { get; set; }

        public StateValueNode(StateSymbol state)
        {
            State = state;
        }

        public override bool Equals(object obj)
        {
            bool result;

            result = obj switch
            {
                StateSymbol s => State == s,
                StateValueNode s => State == s.State,
                _ => false,
            };

            return result && base.Equals(obj);
        }
    }
}
