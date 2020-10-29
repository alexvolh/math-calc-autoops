using FlaUI.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace math_calc_autoops.automation_calc
{
    public abstract class AutoBase
    {
        protected AutomationBase automationBase { get; set; }
        protected Application application { get; set; }

        protected abstract Application StartApplication();
        protected abstract AutomationBase GetAutomation();
    }
}
