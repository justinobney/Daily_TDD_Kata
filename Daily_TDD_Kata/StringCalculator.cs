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

            // Define standard delimiters
            List<string> delimiters = new List<string>() { ",", @"\n" };

            // Check input for dynamically defined delimiters
            /* REGEX: ^//[\D]*\\n
             *   ^      = Starts with
             *   //     = Simple character matching "//"
             *   [/D]*  = Matches a non-digit character. Equivalent to [^0-9].
             *   \\n    = Matches the "\n" Newline string
            */
            Match string_defined_delimiters = new Regex(@"^//[\D]*\\n").Match(numbers);

            if (string_defined_delimiters.Success) { 
                // Add matched group value, removing the // and \n
                delimiters.Add(string_defined_delimiters
                                .Groups[0].Value
                                .Replace(@"//", "").Replace(@"\n", "")
                            );

                // Remove the // from the original input
                numbers = numbers.Replace(string_defined_delimiters.Groups[0].Value, "");
            }

            // check for delimiters
            if (delimiters.Any(numbers.Contains))
            {
                // convert split array to ienumerable to more easily do work on the numbers
                IEnumerable<string> numbers_worker = (IEnumerable<string>)numbers.Split(delimiters.ToArray(), StringSplitOptions.RemoveEmptyEntries);
                result = numbers_worker.Select(n => int.Parse(n)).Sum();
            }
            else {
                result = int.Parse(numbers);
            }

            return result;
        }
    }
}
