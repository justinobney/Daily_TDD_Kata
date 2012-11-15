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

            // An empty string always yields 0.
            if (numbers == "") return 0;

            // Standard Delimiters
            List<string> delimiters = new List<string>(){ ",", @"\n" };

            // Finds delimiters that batch the //[delimiter] pattern and adds them
            Match dynamic_delimiters = new Regex(@"^//[\D]?").Match(numbers);
            if (dynamic_delimiters.Success)
            {
                numbers = numbers.Replace(dynamic_delimiters.Groups[0].Value, "");
                delimiters.Add(dynamic_delimiters.Groups[0].Value.Replace(@"//", ""));
            }

            // Checks for the existance of any delimiters else assumes it is a parsable number
            if (delimiters.Any(numbers.Contains))
            {
                IEnumerable<string> number_arr = (IEnumerable<string>)numbers.Split(delimiters.ToArray(), StringSplitOptions.None);
                result = number_arr.Select(s => int.Parse(s)).Sum();
            }
            else
            {
                result = int.Parse(numbers);
            }

            return result;
        }
    }
}
