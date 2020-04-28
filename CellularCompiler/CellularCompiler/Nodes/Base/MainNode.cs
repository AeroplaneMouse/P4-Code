using System;
using System.Collections.Generic;
using System.Text;

namespace CellularCompiler.Nodes.Base
{
    class MainNode
    {
        public GridNode GridNode { get; set; }
        public List<StatesNode> StatesNodes { get; set; }
        public InitialNode InitialNode { get; set; }
        public RulesNode RulesNode { get; set; }

        public MainNode(GridNode grid, List<StatesNode> states, InitialNode initial, RulesNode rules)
        {
            GridNode = grid;
            StatesNodes = states;
            InitialNode = initial;
            RulesNode = rules;
        }
    }
}
