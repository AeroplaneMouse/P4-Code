using System;
using CellularCompiler.Models;

namespace CellularCompiler.Nodes.Values
{
    class StateValueNode : ValueNode
    {
        public State State { get; set; }

        public StateValueNode(State state)
        {
            State = state;
        }

        public override bool Equals(object obj)
        {
            if (obj is State state)
                return State == state;
            else if (obj is StateValueNode node)
                return State == node.State;
            else
                return false;
        }
    }
}
