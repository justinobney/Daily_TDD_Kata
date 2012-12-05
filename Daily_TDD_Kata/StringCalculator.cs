using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Daily_TDD_Kata
{
    public class StringCalculator
    {
        public int Add(string numbers)
        {
            var result = 0;

            //Return 0 when an empty string is sent in
            if (string.IsNullOrEmpty(numbers))
                return result;

            string[] standardDelimiters = {",", @"\n"};

            if (standardDelimiters.Any(numbers.Contains))
            {
                IEnumerable<string> splitNums = numbers.Split(standardDelimiters, StringSplitOptions.None);
                result = splitNums.Select(int.Parse).Sum();
            }
            else
                result = int.Parse(numbers);

            return result;
        }
    }
}
