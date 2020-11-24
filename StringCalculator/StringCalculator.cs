using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace StringCalculator
{
    public class StringCalculator
    {
        IntParser _intParser = new IntParser();

        public int Add(string calcString)
        {
            return _intParser.ParseInts(calcString).Sum();

            throw new NotImplementedException("Not implemented.");
        }
    }
}
