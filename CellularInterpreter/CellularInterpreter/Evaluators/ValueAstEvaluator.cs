using CI.Models;
using CI.Nodes.Values;
using System.Collections.Generic;

namespace CI.Evaluators
{
    class ValueAstEvaluator
    {
        private ICoronaEvaluator sender;

        public ValueAstEvaluator(ICoronaEvaluator sender)
        {
            this.sender = sender;
        }

        public Cell Visit(GridValueNode node)
        {
            MathExpressionAstEvaluator exprVisitor = new MathExpressionAstEvaluator();

            int x = exprVisitor.Visit(node.FirstD);
            int y = exprVisitor.Visit(node.SecondD);

            // Wrap around if out of bounds
            while (x >= sender.X_Max)
                x -= sender.X_Max;

            while (x < 0)
                x += sender.X_Max;

            while (y >= sender.Y_Max)
                y -= sender.Y_Max;

            while (y < 0)
                y += sender.Y_Max;

            return sender.GetCell(x, y);
        }

        public int Visit(IntValueNode node)
        {
            return node.Value;
        }

        public string Visit(StringValueNode node)
        {
            return node.Value;
        }

        public List<int> Visit(ArrowValueNode node)
        {
            // Create list of values
            List<int> values = new List<int>();
            for (int i = node.LeftValue; i <= node.RightValue; i++)
                values.Add(i);

            return values;
        }
    }
}
