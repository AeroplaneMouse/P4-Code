using System;
using System.Collections.Generic;
using System.Text;

namespace CellularCompiler.Nodes.Base
{
    class MainNode
    {
        public GridNode GridNode { get; set; }
        public List<StateNode> StateNodes { get; set; }
        public InitialNode InitialNode { get; set; }
        public RulesNode RulesNode { get; set; }

        public MainNode(GridNode grid, List<StateNode> states, InitialNode initial, RulesNode rules)
        {
            GridNode = grid;
            StateNodes = states;
            InitialNode = initial;
            RulesNode = rules;
        }
    }
}
