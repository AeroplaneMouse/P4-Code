using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CellularCompiler.Evaluators;
using CellularCompiler.Models;

namespace CAVisualFormsCore
{
    public partial class Visualization : Form
    {
        ICoronaEvaluator evaluator;

        public Visualization(ICoronaEvaluator evaluator)
        {
            InitializeComponent();
            Graphics formGraphics = this.CreateGraphics();

            this.evaluator = evaluator;

            //for (int i = 0; i < array.GetLength(0); ++i)
            //{
            //    for (int j = 0; j < array.GetLength(1); ++j)
            //    {
            //        array[i, j] = grid.GetCell(i, j);
            //    }
            //}

            main();
        }

        private async void main()
        {
            for (int i = 0; i < 2000; i++)
            {
                await Task.Delay(10);
                RequestAnimationFrame();
            }
        }

        public void RequestAnimationFrame()
        {
            evaluator.GenerateNextGeneration();
            evaluator.PushNextGeneration();
            Refresh();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Cell[,] array = evaluator.GetCurrentGeneration();

            int box = 5;
            int firstDimensionLength = array.GetLength(0);
            int secondDimensionLength = array.GetLength(1);
            e.Graphics.FillRectangle(new SolidBrush(Color.Black), new Rectangle(0, 0, box*firstDimensionLength, box*secondDimensionLength));

            for (int j = 0; j < firstDimensionLength; ++j)
            {
                for (int i = 0; i < secondDimensionLength; ++i)
                {
                    if (array[j, i].State.Label == "dead")
                        e.Graphics.FillRectangle(new SolidBrush(Color.Black), new Rectangle(box * j, box * i, box, box));
                    else if (array[j, i].State.Label == "alive")
                        e.Graphics.FillRectangle(new SolidBrush(Color.White), new Rectangle(box * j, box * i, box, box));
                }
            }
        }
    }
}
