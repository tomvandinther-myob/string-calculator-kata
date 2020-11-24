using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace StringCalculator
{
    public class IntParser
    {
        private (string delimiterSubstring, string calcSubstring) GetSubstrings(string inputString)
        {
            string delimiterSubstring;
            string calcSubstring;
            
            if (inputString.StartsWith("//"))
            {
                var delimiterBreakPosition = inputString.IndexOf('\n');
                delimiterSubstring = inputString.Substring(2, delimiterBreakPosition - 2);
                calcSubstring = inputString.Substring(delimiterBreakPosition + 1);
            }
            else
            {
                delimiterSubstring = ",";
                calcSubstring = inputString;
            }

            return (delimiterSubstring, calcSubstring);
        }
        
        private string[] GetDelimiters(string delimiterSubstring)
        {
            List<string> delimiters = new List<string>(new string[]{"\n"});

            var delimiterRegex = new Regex(@"(?<=\[)?[^\s\[\]]+(?=\[)?");
            var matches = delimiterRegex.Matches(delimiterSubstring);

            foreach (Match match in matches)
            {
                delimiters.Add(match.Value);
            }

            // var singleCharDelimiterRegex = new Regex(@"//(.)\n(?<calcString>(?:.|\n)+)");
            // var multiCharDelimiterRegex = new Regex(@"//\[?(.+[^\]])\]?\n(?<calcString>(?:.|\n)+)");
            // var manyMultiCharDelimiterRegex = new Regex(@"//\[?(.+[^\]])\]?\n(?<calcString>(?:.|\n)+)");

            return delimiters.ToArray();
        }

        public int[] ParseInts(string inputString)
        {
            var substrings = GetSubstrings(inputString);
            var delimiters = GetDelimiters(substrings.delimiterSubstring);
            var calcString = substrings.calcSubstring;

            List<int> numbers = new List<int>();
            List<int> negatives = new List<int>();
            
            foreach (var stringInt in calcString.Split(delimiters, StringSplitOptions.None))
            {
                var n = int.Parse(stringInt);
                if (n < 0) negatives.Add(n);
                else if (n >= 1000);
                else numbers.Add(n);
            }
            
            if (negatives.Any()) throw new Exception("Negatives not allowed:");
            return numbers.ToArray();
        }
    }
}