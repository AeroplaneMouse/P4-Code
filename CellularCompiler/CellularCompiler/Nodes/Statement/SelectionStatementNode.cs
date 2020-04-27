using System;
using System.Collections.Generic;
using System.Text;
using CellularCompiler.Nodes.Base;
using CellularCompiler.Nodes.Members;

namespace CellularCompiler.Nodes.Statement
{
    class SelectionStatementNode : StatementNode
    {
        public bool MatchOnState { get; set;}
        public List<MemberIDNode> MemberIDs { get; set; }
        

        public List<CaseStatementNode> CaseStatements { get; set; }
        public SelectionStatementNode()
            : this(null, null) { }

        public SelectionStatementNode(List<MemberIDNode> memberIDs, List<CaseStatementNode> caseStatements)
        {
            MemberIDs = memberIDs;
            CaseStatements = caseStatements;
        }
    }
}
