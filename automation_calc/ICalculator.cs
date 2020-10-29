using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using FlaUI.Core.AutomationElements;

namespace math_calc_autoops.automation_calc
{
    interface ICalculator
    {
        Button Button0 { get; }
        Button Button1 { get; }
        Button Button2 { get; }
        Button Button3 { get; }
        Button Button4 { get; }
        Button Button5 { get; }
        Button Button6 { get; }
        Button Button7 { get; }
        Button Button8 { get; }
        Button Button9 { get; }
        Button ButtonAdd { get; }
        Button ButtonMinus { get; }
        Button ButtonMultiply { get; }
        Button ButtonDivide { get; }
        Button ButtonEquals { get; }
        Button ButtonPower { get;  }
        Button ButtonTogglePane { get; }
        Button ButtonClose { get;  }
        MenuItem MenuItems { get; }
        ListBox MenuList { get; }
        TextBox Header { get; }
        void clickNumbers(char number);
        void clickMathOperations(OperationType operationType);
        void switchToScientific();
        void switchToStandard();
        Boolean isStandardMode();
        string Result { get; }
    }
}
