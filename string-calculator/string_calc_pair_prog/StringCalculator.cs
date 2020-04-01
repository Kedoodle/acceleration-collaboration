using System;
using System.Collections.Generic;
using System.Linq;

namespace string_calc_test
{
    public static class StringCalculator
    {
        private static readonly string[] DefaultDelimiters = {",", "\n"};

        public static int Add(string stringToCalc)
        {
            string[] delimiters;
            if (HasCustomDelimiter(stringToCalc))
            {
                delimiters = GetCustomDelimiter(stringToCalc);
                stringToCalc = RemoveCustomDelimiterDeclaration(stringToCalc);
            }
            else
            {
                delimiters = DefaultDelimiters;
            }

            if (IsEmptyString(stringToCalc))
            {
                return 0;
            }

            var stringOperands = GetStringOperands(stringToCalc, delimiters);
            var intOperands = GetOperands(stringOperands);
            ThrowExceptionIfNegativeOperands(intOperands);
            intOperands = RemoveOperandsGreaterThanOrEqualTo1000(intOperands);
            return intOperands.Sum();
        }
        
        private static bool HasCustomDelimiter(string stringToCalc)
        {
            return stringToCalc.StartsWith("//");
        }
        
        private static string[] GetCustomDelimiter(string stringToCalc)
        {
            const int firstOpenBracketIndex = 2;
            var lastCloseBracketIndex = GetLastCloseBracketIndex(stringToCalc);
            var delimitersSubstring = stringToCalc.Substring(firstOpenBracketIndex + 1,
                lastCloseBracketIndex - firstOpenBracketIndex - 1);
            var delimiters = delimitersSubstring.Split("][");
            return delimiters;
        }

        private static string RemoveCustomDelimiterDeclaration(string stringToCalc)
        {
            var lastCloseBracketIndex = GetLastCloseBracketIndex(stringToCalc);
            return stringToCalc.Substring(lastCloseBracketIndex + 2);
        }
        
        private static int GetLastCloseBracketIndex(string stringToCalc)
        {
            return stringToCalc.LastIndexOf(']');
        }
        
        private static bool IsEmptyString(string stringToCalc)
        {
            return stringToCalc == "";
            
        }
        
        private static IEnumerable<string> GetStringOperands(string stringToCalc, string[] delimiters)
        {
            return stringToCalc.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
        }
        
        private static IEnumerable<int> GetOperands(IEnumerable<string> stringOperands)
        {
            return stringOperands.Select(int.Parse).ToList();
        }
        
        private static void ThrowExceptionIfNegativeOperands(IEnumerable<int> intOperands)
        {
            if (!intOperands.Any(operand => operand < 0)) return;
            
            var negativeOperands = intOperands.Where(operand => operand < 0);
            throw new ArgumentException($"Negatives not allowed: {string.Join(", ", negativeOperands)}");
        }
        
        private static IEnumerable<int> RemoveOperandsGreaterThanOrEqualTo1000(IEnumerable<int> intOperands)
        {
            return intOperands.Where(operand => operand < 1000);
        }

    }
}
