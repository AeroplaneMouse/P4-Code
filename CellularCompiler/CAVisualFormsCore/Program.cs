using System;
using CellularCompiler;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using CellularCompiler.Evaluators;

namespace CAVisualFormsCore
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            CellularCompiler.CellularCompiler interpreter = new CellularCompiler.CellularCompiler();

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Visualization(interpreter.InterpretCorona()));
        }
    }
}
