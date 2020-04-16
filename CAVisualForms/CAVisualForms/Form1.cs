using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CAVisualForms
{
    public partial class Form1 : Form
    {
        int[,] array = new int[64, 64];
        public Form1()
        {
            InitializeComponent();
            Graphics formGraphics = this.CreateGraphics();

            for (int i = 0; i < array.GetLength(0); ++i)
            {
                for (int j = 0; j < array.GetLength(1); ++j)
                {
                    array[i, j] = (i + j) % 2 == 0 ? 1 : 0;
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
            array[test, test] = 0;
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
                    if (array[i, j] == 0)
                        e.Graphics.FillRectangle(new SolidBrush(Color.Black), new Rectangle(box * i, box * j, box, box));
                    else if (array[i, j] == 1)
                        e.Graphics.FillRectangle(new SolidBrush(Color.White), new Rectangle(box * i, box * j, box, box));
                }
            }
        }
    }
}
