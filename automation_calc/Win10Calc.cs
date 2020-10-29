using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Definitions;

namespace math_calc_autoops.automation_calc
{
    class Win10Calc : ICalculator
    {
        private readonly AutomationElement _mainWindow;
        private static readonly string STANDARD_MODE = "Standard";
        private static readonly string SCIENTIFIC_MODE = "Scientific";
        public string CurrentMode = STANDARD_MODE;
      
        public Button Button0 => FindElement("num0Button").AsButton();
        public Button Button1 => FindElement("num1Button").AsButton();
        public Button Button2 => FindElement("num2Button").AsButton();
        public Button Button3 => FindElement("num3Button").AsButton();
        public Button Button4 => FindElement("num4Button").AsButton();
        public Button Button5 => FindElement("num5Button").AsButton();
        public Button Button6 => FindElement("num6Button").AsButton();
        public Button Button7 => FindElement("num7Button").AsButton();
        public Button Button8 => FindElement("num8Button").AsButton();
        public Button Button9 => FindElement("num9Button").AsButton();
        public Button ButtonAdd => FindElement("plusButton").AsButton();
        public Button ButtonMinus => FindElement("minusButton").AsButton();
        public Button ButtonMultiply => FindElement("multiplyButton").AsButton();
        public Button ButtonDivide => FindElement("divideButton").AsButton();
        public Button ButtonEquals => FindElement("equalButton").AsButton();
        public Button ButtonPower => FindElement("powerButton").AsButton();
        public Button ButtonClose => FindElement("Close").AsButton();
        public Button ButtonTogglePane => FindElement("TogglePaneButton").AsButton();
        public MenuItem MenuItems => FindElement("MenuItemsHost").AsMenuItem();
        public ListBox MenuList => FindElement("MenuItemsHost").AsListBox();
        public TextBox Header => FindElement("Header").AsTextBox();

        public string Result
        {
            get
            {
                var resultElement = FindElement("CalculatorResults");
                var value = resultElement.Properties.Name;
                return Regex.Replace(value, "[^0-9]", String.Empty);
            }
        }

        public Win10Calc(AutomationElement mainWindow)
        {
            _mainWindow = mainWindow;
        }


        public void clickNumbers(char number)
        {
            switch (number)
            {
                case '0': 
                    Button0.Click();
                    break;
                case '1':
                    Button1.Click();
                    break;
                case '2':
                    Button2.Click();
                    break;
                case '3':
                    Button3.Click();
                    break;
                case '4':
                    Button4.Click();
                    break;
                case '5':
                    Button5.Click();
                    break;
                case '6':
                    Button6.Click();
                    break;
                case '7':
                    Button7.Click();
                    break;
                case '8':
                    Button8.Click();
                    break;
                case '9':
                    Button9.Click();
                    break;
            }
        }


        public void clickMathOperations(OperationType operationType)
        {
            switch (operationType)
            {
                case OperationType.ADD:
                    ButtonAdd.Click();
                    break;
                case OperationType.MINUS:
                    ButtonMinus.Click();
                    break;
                case OperationType.MULTIPLY:
                    ButtonMultiply.Click();
                    break;
                case OperationType.DIVIDE:
                    ButtonDivide.Click();
                    break;
                case OperationType.POWER:
                    ButtonPower.Click();
                    break;
                case OperationType.EQUALS:
                    ButtonEquals.Click();
                    break;
            }
        }

        private AutomationElement FindElement(string text)
        {
            var element = _mainWindow.FindFirstDescendant(cf => cf.ByAutomationId(text));
            return element;
        }

        public void switchToScientific()
        {
            switchMode(SCIENTIFIC_MODE);
            CurrentMode = SCIENTIFIC_MODE;
        }

        public void switchToStandard()
        {
            switchMode(STANDARD_MODE);
            CurrentMode = STANDARD_MODE;
        }

        private void switchMode(String mode)
        {
            ButtonTogglePane.Click();
            if (MenuItems.IsEnabled)
            {
                var element = _mainWindow.FindFirstDescendant(d => d.ByAutomationId("NavView"))
                               .FindFirstDescendant(w => w.ByAutomationId("PaneRoot"))
                               .FindFirstDescendant(p => p.ByClassName("ScrollViewer"))
                               .FindFirstDescendant(i => i.ByControlType(ControlType.Group))
                               .FindFirstDescendant(t => t.ByAutomationId(mode))
                               .AsMenuItem();
                element.Click();
            }

        }

        public bool isStandardMode()
        {
            return CurrentMode.Equals(STANDARD_MODE);
        }
    }
}
