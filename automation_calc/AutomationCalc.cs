using FlaUI.Core;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Input;
using FlaUI.Core.WindowsAPI;
using OperatingSystem = FlaUI.Core.Tools.OperatingSystem;
using FlaUI.UIA3;
using math_calc_autoops.automation_calc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace math_calc_autoops
{
    class AutomatitionCalc : AutoBase
    {
        /*
         * Main method responsible for calc UI iteration using csv data
         */
        public void executeMathActions(List<BinaryOperation> binaryOperations)
        {
            var window = StartApplication().GetMainWindow(GetAutomation());
            var calc = (ICalculator)new Win10Calc(window);
           
            System.Threading.Thread.Sleep(1000);
            Keyboard.TypeSimultaneously(VirtualKeyShort.ALT, VirtualKeyShort.KEY_1);
            Wait.UntilInputIsProcessed();
            application.WaitWhileBusy();
            System.Threading.Thread.Sleep(1000);
            binaryOperations.ForEach(bo => executeBinaryOperation(bo, calc));
            Console.WriteLine("\nFinish");
        }

        public void executeBinaryOperation(BinaryOperation binaryOperation, ICalculator calc)
        {
            if(binaryOperation.getOperationType.Equals(OperationType.POWER))
            {
                Console.WriteLine("\n\nSwitching to Scientific mode");
                calc.switchToScientific();
                System.Threading.Thread.Sleep(2000);
            } else if(!binaryOperation.getOperationType.Equals(OperationType.POWER) && !calc.isStandardMode())
            {
                calc.switchToStandard();
                System.Threading.Thread.Sleep(2000);
            }

            Console.Write(String.Format("\n ====> {0} {1} {2}", 
                binaryOperation.FirstName, binaryOperation.getOperationType.GetMathSymbol(), binaryOperation.SecondName));

            foreach (char first in binaryOperation.FirstName.ToString())
            {
                calc.clickNumbers(first);
            }

            System.Threading.Thread.Sleep(1000);

            calc.clickMathOperations(binaryOperation.getOperationType);

            foreach (char second in binaryOperation.SecondName.ToString())
            {
                calc.clickNumbers(second);
            }

            calc.clickMathOperations(OperationType.EQUALS);

            System.Threading.Thread.Sleep(2000);

            Console.Write(" = " + calc.Result);
        }

        

        protected override Application StartApplication()
        {
            if(OperatingSystem.IsWindows10() || OperatingSystem.IsWindows8_1())
            {
                this.application = Application.LaunchStoreApp("Microsoft.WindowsCalculator_8wekyb3d8bbwe!App");

                return this.application;
            }

            this.application = Application.Launch("win32calc.exe"); 
           
            return this.application;
        }

        protected override AutomationBase GetAutomation()
        {
            this.automationBase = new UIA3Automation();

            return this.automationBase;
        }
    }
}
