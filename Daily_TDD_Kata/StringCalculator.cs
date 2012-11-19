using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Daily_TDD_Kata
{
    public class StringCalculator
    {
        public static int Add(string numbers)
        {
            // If the input is an empty string, always yeild 0
            if(numbers == "")
                return 0;

            // Define standard delimiters
            List<string> accepted_delimiters = new List<string>() { ",", @"\n" };

            // Search the input string for delimiters noted 
            // Like this:   "//[delimiter]\n[numbers…]" for example "//;\n1;2" should return three where the default delimiter is ';' .
            Match dynamic_delimiter_worker = new Regex(@"^//[\D]\\n").Match(numbers);

            if(dynamic_delimiter_worker.Success){
                // Add matched group value, removing the // and \n
                string cleaned_delimiter = Regex.Replace(dynamic_delimiter_worker.Groups[0].Value, @"//|\\n", "", RegexOptions.IgnoreCase);
                accepted_delimiters.Add(cleaned_delimiter);

                // Remove the // from the original input
                numbers = numbers.Replace(dynamic_delimiter_worker.Groups[0].Value, "");
            }

            // Convert the number to an IEnumerable to more easily work against the collection
            IEnumerable<int> number_worker = numbers
                .Split(accepted_delimiters.ToArray(), StringSplitOptions.RemoveEmptyEntries)
                .Where(number => int.Parse(number) <= 1000)  // Ignore numbers greater than 1000
                .Select(number => int.Parse(number));

            if (number_worker.Any(n => n < 0))
            {
                throw new Exception("Negative numbers are not allowed");
            }

            return number_worker.Sum();
        }
    }
}
