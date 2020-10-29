using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace math_calc_autoops
{
    class BinaryOperation
    {
        private int firstNumber;
        private int secondNumber;
        private OperationType operationType;

        public int FirstName
        {
            get { return firstNumber; }
            set { firstNumber = value; }
        }

        public int SecondName
        {
            get { return secondNumber; }
            set { secondNumber = value; }
        }

        public OperationType getOperationType { get { return operationType; } }

        public BinaryOperation(int firstNumber, int secondNumber, OperationType operationType)
        {
            this.firstNumber = firstNumber;
            this.secondNumber = secondNumber;
            this.operationType = operationType;
        }

        public override string ToString()
        {
            return String.Format(" first value: {0}, second value: {1}, operation type: {2}", this.firstNumber, this.secondNumber, this.operationType.ToString());
        }
    }
}
