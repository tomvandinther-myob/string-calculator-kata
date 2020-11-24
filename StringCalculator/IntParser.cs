using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace StringCalculator
{
    public class IntParser
    {
        private string[] GetDelimiters(GroupCollection groups)
        {
            List<string> delimiters = new List<string>(new string[]{"\n"});
            delimiters.Add(groups[1].Value);

            return delimiters.ToArray();
        }

        private string GetCalcString(GroupCollection groups)
        {
            return groups["calcString"].Value;
        }

        private MatchCollection GetMatches(string inputString)
        {
            List<string> delimiters = new List<string>(new string[]{"\n"});
            var singleCharDelimiterRegex = new Regex(@"//(.)\n(?<calcString>(?:.|\n)+)");
            var multiCharDelimiterRegex = new Regex(@"//\[?(.+[^\]])\]?\n(?<calcString>(?:.|\n)+)");

            var matches = singleCharDelimiterRegex.Matches(inputString);
            if (matches.Any())
            {
                return matches;
            }
            else
            {
                matches = multiCharDelimiterRegex.Matches(inputString);
                return matches;
            }
        }
        
        private GroupCollection GetMatchGroups(MatchCollection matches)
        {
            return matches[0].Groups;            
        }
        
        public int[] ParseInts(string inputString)
        {
            var matches = GetMatches(inputString);

            string[] delimiters;
            string calcString;
            
            if (matches.Any())
            {
                var groups = GetMatchGroups(matches);
                delimiters = GetDelimiters(groups);
                calcString = GetCalcString(groups);
            }
            else
            {
                calcString = inputString;
                delimiters = new string[]{",", "\n"};
            }

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