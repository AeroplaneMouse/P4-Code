using System;
using System.IO;
using System.Drawing;
using System.Collections.Generic;
using System.Diagnostics;
using CI.Models;

namespace CI.ImageGeneration
{
    public class ImageGenerator
    {
        private string outputDirectory = @"output/";
        Dictionary<int, Color> colorDict = new Dictionary<int, Color>();

        private int width;
        private int height;
        private int frameCount = 0;

        public ImageGenerator(int arraySize_x, int arraySize_y)
        {
            width = arraySize_x;
            height = arraySize_y;
            if(Directory.Exists(outputDirectory) != true)
            {
                Directory.CreateDirectory(outputDirectory);
            }
        }

        private Color GetColorForInt(int integer)
        {
            try
            {
                return colorDict[integer];
            }
            catch (KeyNotFoundException)
            {

                Color newColor = Color.FromArgb(Convert.ToInt32(Math.PI * integer * 42 % 255 + 1), Convert.ToInt32(Math.PI * integer * 55 % 255 + 2), Convert.ToInt32(Math.PI * integer * 11 % 255 + 3));
                colorDict.Add(integer, newColor);

                return newColor;
            }
        }

        public void GenerateFrame(Grid grid)
        {
            frameCount += 1;
            Bitmap image = new Bitmap(this.width, this.height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            for (int x = 0; x < this.width; x++)
            {
                for (int y = 0; y < this.height; y++)
                {
                    Color color = GetColorForInt(grid.GetCell(x, y).State.ID);
                    image.SetPixel(x, y, color);
                }
            }
            image.Save(outputDirectory + frameCount.ToString() + ".bmp");
        }
    }
}
