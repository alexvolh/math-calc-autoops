using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace math_calc_autoops
{
    class CsvHelper
    {
        public static readonly char SEPARATOR = ','; 
        public static List<BinaryOperation> LoadDatafromFile(string path)
        {
            StreamReader streamReader = new StreamReader(File.OpenRead(path));
            List<BinaryOperation> binaryOperations = new List<BinaryOperation>();
            
                while (!streamReader.EndOfStream)
                {
                    string line = streamReader.ReadLine();
                    if (!String.IsNullOrWhiteSpace(line))
                    {
                        string[] values = line.Split(SEPARATOR);

                        if (values.Length == 3)
                        {
                            binaryOperations.Add(
                                new BinaryOperation(
                                    convertToInt(values[0]),
                                    convertToInt(values[1]),
                                    OperationTypeExtensions.ParseStrToOperationType(values[2], true))
                                );
                        }
                    }
                }

            return binaryOperations;
        }

        private static int convertToInt(string value)
        {
            int convertingValue = 0;

            try
            {
                convertingValue = Convert.ToInt32(value);
            } 
            catch(FormatException exc)
            {
                Console.WriteLine("Error coverting to int value : " + exc.ToString());
            }

            return convertingValue;
        }
        
    }
}
