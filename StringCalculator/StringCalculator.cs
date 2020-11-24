using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculator
{
    public class StringCalculator
    {

        private int[] ParseInts(string calcString)
        {
            char customDelimiter = ',';
            if (calcString[0] == '/' && calcString[1] == '/')
            {
                customDelimiter = calcString[2];
                calcString = calcString[4..^0];
            }
            
            char[] delimiters = {customDelimiter, '\n'};
            List<int> numbers = new List<int>();
            List<int> negatives = new List<int>();
            
            foreach (var stringInt in calcString.Split(delimiters))
            {
                var n = int.Parse(stringInt);
                if (n < 0) negatives.Add(n);
                else if (n >= 1000);
                else numbers.Add(n);
            }
            if (negatives.Any()) throw new Exception("Negatives not allowed:");
            return numbers.ToArray();
        }
        
		public int Add(string calcString)
        {
            return ParseInts(calcString).Sum();

            throw new NotImplementedException("Not implemented.");
        }
    }
}
