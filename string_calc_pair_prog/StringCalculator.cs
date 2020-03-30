using System;
using System.Linq;

namespace string_calc_test
{
    public static class StringCalculator
    {
        public static int Add(string stringToCalc)
        {
            var delimiters = new[] {',', '\n'};
            if (stringToCalc.StartsWith("//"))
            {
                var delimiterDeclarationEndIndex = stringToCalc.IndexOf('\n');
                stringToCalc = stringToCalc.Substring(delimiterDeclarationEndIndex + 1);
                delimiters = new[] {stringToCalc[2]};
            }
            if (stringToCalc.Count(c => c == ',') == 0) return stringToCalc == "" ? 0 : int.Parse(stringToCalc);
            
            var stringOperands = stringToCalc.Split(delimiters);
            return stringOperands.Sum(int.Parse);
        }
    }
}