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
            
            foreach (var stringInt in calcString.Split(delimiters))
            {
                var n = int.Parse(stringInt);
                numbers.Add(n);
            }

            return numbers.ToArray();
        }
        
		public int Add(string calcString)
        {
            return ParseInts(calcString).Sum();

            throw new NotImplementedException("Not implemented.");
        }
    }
}
