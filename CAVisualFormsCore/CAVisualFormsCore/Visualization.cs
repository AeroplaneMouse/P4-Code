using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CellularCompiler.Models;

namespace CAVisualFormsCore
{
    public partial class Visualization : Form
    {
        Cell[,] array = null;
        State black = new State("black");
        State white = new State("white");
        public Visualization(Grid grid)
        {
            InitializeComponent();
            Graphics formGraphics = this.CreateGraphics();

            for (int i = 0; i < array.GetLength(0); ++i)
            {
                for (int j = 0; j < array.GetLength(1); ++j)
                {
                    array[i, j] = grid.GetCell(i, j);
                }
            }
            
            main();
        }

        private async void main()
        {
            await Task.Delay(1000);
            RequestAnimationFrame(0);
            await Task.Delay(1000);
            RequestAnimationFrame(10);
            await Task.Delay(1000);
            RequestAnimationFrame(20);
            await Task.Delay(1000);
            RequestAnimationFrame(30);
        }

        public void RequestAnimationFrame(int test)
        {
            array[test, test] = new Cell(black);
            Task.Delay(5000);
            Refresh();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            int box = 10;
            int firstDimensionLength = array.GetLength(0);
            int secondDimensionLength = array.GetLength(1);
            e.Graphics.FillRectangle(new SolidBrush(Color.Black), new Rectangle(0, 0, box*firstDimensionLength, box*secondDimensionLength));
            for (int i = 0; i < firstDimensionLength; ++i)
            {
                for (int j = 0; j < secondDimensionLength; ++j)
                {
                    if (array[i, j].State == black)
                        e.Graphics.FillRectangle(new SolidBrush(Color.Black), new Rectangle(box * i, box * j, box, box));
                    else if (array[i, j].State == white)
                        e.Graphics.FillRectangle(new SolidBrush(Color.White), new Rectangle(box * i, box * j, box, box));
                }
            }
        }
    }
}
