﻿using System;
using System.Linq;

namespace StringCalculator
{
    public class StringCalculator
    {

        private int[] ParseInts(string calcString)
        {
            return calcString.Split(",").Select(int.Parse).ToArray();
        }
        
		public int Add(string calcString)
        {
            return ParseInts(calcString).Sum();

            throw new NotImplementedException("Not implemented.");
        }
    }
}
