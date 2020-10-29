using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace math_calc_autoops
{
    enum OperationType { ADD, MINUS, MULTIPLY, DIVIDE, POWER, EQUALS };

    static class OperationTypeExtensions
    {
        public static char GetMathSymbol(this OperationType operationType)
        {
            switch (operationType)
            {
                case OperationType.ADD: return '+';
                case OperationType.MINUS: return '-';
                case OperationType.MULTIPLY: return '*';
                case OperationType.DIVIDE: return '/';
                case OperationType.POWER: return '^';    
                case OperationType.EQUALS: return '=';    
                default: throw new ArgumentOutOfRangeException("OperationType");
            }
        }

        public static OperationType ParseStrToOperationType(this string value, bool ignoreCase = true)
        {
            return (OperationType)Enum.Parse(typeof(OperationType), value, ignoreCase);
        }
    }
}
