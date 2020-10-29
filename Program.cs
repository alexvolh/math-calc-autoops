using FlaUI.Core.AutomationElements;
using FlaUI.UIA3;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace math_calc_autoops
{
    class Program
    {
        static void Main(string[] args)
        {
            List<BinaryOperation> binaryOperations = CsvHelper.LoadDatafromFile(@args[0]);
            binaryOperations.ForEach(bo => Console.WriteLine(bo.ToString()));

            AutomatitionCalc calc = new AutomatitionCalc();
            calc.executeMathActions(binaryOperations);

            Console.ReadKey();
        }
    }
}
