using System;
using System.Linq;

namespace string_calc_test
{
    public static class StringCalculator
    {
        public static int Add(string stringToCalc)
        {
            var delimiters = new[] {',', '\n'};
            if (HasCustomDelimiter(stringToCalc))
            {
                delimiters = GetCustomDelimiter(stringToCalc);
                stringToCalc = stringToCalc.Substring(4);
            }

            if (IsEmptyString(stringToCalc))
            {
                return 0;
            }

            var stringOperands = GetStringOperands(stringToCalc, delimiters);
            return stringOperands.Sum(int.Parse);
        }

        private static char[] GetCustomDelimiter(string stringToCalc)
        {
            var delimiters = new[] {stringToCalc[2]};
            return delimiters;
        }

        private static bool HasCustomDelimiter(string stringToCalc)
        {
            return stringToCalc.StartsWith("//");
        }
        

        private static bool IsEmptyString(string stringToCalc)
        {
            return stringToCalc == "";
            
        }

        private static string[] GetStringOperands(string stringToCalc, char[] delimiters)
        {
            return stringToCalc.Split(delimiters);
        }
    }
}

//get delimiters
// get operands
// .replace("\n """)
