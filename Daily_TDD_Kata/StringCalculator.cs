using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Daily_TDD_Kata
{
    public class StringCalculator
    {
        public static int Add(string numbers)
        {
            int result = 0;

            // An EMPTY string should always yield 0
            if (numbers == "") return 0;

            // Define standard delimiters:   [,] [\n]
            List<string> delimiters = new List<string>() { ",", @"\n" };

            // Regex for finding dynamic delimiters
            /* REGEX: ^//[\D]*\\n
             *   ^      = Starts with
             *   //     = Simple character matching "//"
             *   [/D]*  = Matches a non-digit character. Equivalent to [^0-9].
             *   \\n    = Matches the "\n" Newline string
            */
            Match string_defined_delimiters = new Regex(@"^//(\[?)[\D]*(\]?)\\n").Match(numbers);

            // Check input for dynamically defined delimiters
            if (string_defined_delimiters.Success) { 
               
                // Add matched group value, removing the // and \n
                string cleaned_delimiter = Regex.Replace(string_defined_delimiters.Groups[0].Value, @"//|\[|\]|\\n", "", RegexOptions.IgnoreCase);
                delimiters.Add(cleaned_delimiter);

                // Remove the // from the original input
                numbers = numbers.Replace(string_defined_delimiters.Groups[0].Value, "");
            }

            // Convert split array to ienumerable to more easily do work on the numbers
            IEnumerable<string> numbers_worker = (IEnumerable<string>)numbers.Split(delimiters.ToArray(), StringSplitOptions.RemoveEmptyEntries);

            // Negative values are not allowed in the input and should be displayed in the error message
            IEnumerable<string> negative_values = numbers_worker.Where(n => int.Parse(n) < 0);
            if (negative_values.Count() > 0)
            { 
               throw new Exception("negatives not allowed: " + string.Join(",", negative_values));
            }
            
            // Ignore numbers greater than 1000
            // Calculate the Sum
            result = numbers_worker.Where(s => int.Parse(s) <= 1000).Select(n => int.Parse(n)).Sum();

            return result;
        }
    }
}
