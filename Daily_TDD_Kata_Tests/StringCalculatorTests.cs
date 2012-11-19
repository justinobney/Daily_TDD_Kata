using System;
using System.Text;
using Daily_TDD_Kata;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Daily_TDD_Kata_Tests
{
    [TestClass]
    public class StringCalculatorTests
    {
        [TestClass]
        public class TheAddMethod
        {
            // The method can take 0, 1 or 2 numbers, and will return their sum (for an empty string it will return 0) for example "" or "1" or "1,2"
            [TestMethod]
            public void return_zero_for_empty_string()
            {
                // arrange
                string input_string = "";
                int expected = 0;

                // act
                int actual = StringCalculator.Add(input_string);

                // assert
                Assert.AreEqual(expected, actual);
            }

            [TestMethod]
            public void return_one_for_string_one()
            {
                // arrange
                int expected = 1;
                string input_string = "1";

                // act
                int actual = StringCalculator.Add(input_string);

                // assert
                Assert.AreEqual(expected, actual);
                
            }

            [TestMethod]
            public void return_three_for_comma_seperated_numbers_one_two()
            {
                // arrange
                int expected = 3;
                string input_string = "1,2";

                // act
                int actual = StringCalculator.Add(input_string);

                // assert
                Assert.AreEqual(expected, actual);
                
            }

            // Allow the Add method to handle an unknown amount of numbers
            [TestMethod]
            public void return_ten_for_comma_seperated_numbers_one_two_three_four()
            {
                // arrange
                int expected = 10;
                string input_string = "1,2,3,4";

                // act
                int actual = StringCalculator.Add(input_string);

                // assert
                Assert.AreEqual(expected, actual);
                
            }

            // Allow the Add method to handle new lines between numbers (instead of commas).
            // The following input is ok:  "1\n2,3"  (will equal 6)
            [TestMethod]
            public void allow_add_to_handle_new_line_as_delimiter()
            {
                // arrange
                int expected = 6;
                string input_string = @"1\n2,3";

                // act
                int actual = StringCalculator.Add(input_string);

                // assert
                Assert.AreEqual(expected, actual);
            }

            // Support different delimiters

            // To change a delimiter, the beginning of the string will contain a separate line that looks 
            // like this:   "//[delimiter]\n[numbers…]" for example "//;\n1;2" should return three where the default delimiter is ';' .

            [TestMethod]
            public void allow_delimiter_to_be_defined_in_input_string_using_slash_delimiter_new_line_format()
            {
                // arrange
                int expected = 3;
                string input_string = @"//;\n1;2";

                // act
                int actual = StringCalculator.Add(input_string);

                // assert
                Assert.AreEqual(expected, actual);
                
            }

            // Calling Add with a negative number will throw an exception “negatives not allowed” - and the negative that was passed.
            // If there are multiple negatives, show all of them in the exception message

            [TestMethod]
            [ExpectedException(typeof (Exception), "Negative numbers are not allowed")]
            public void throws_exception_for_negative_numbers()
            {
                // arrange
                int expected = 2;
                string input_string = "4,-2";

                // act
                int actual = StringCalculator.Add(input_string);

                // assert
                Assert.AreEqual(expected, actual);
                
            }

            // Numbers bigger than 1000 should be ignored, so adding 2 + 1001  = 2
            [TestMethod]
            public void ignore_numbers_greater_than_one_thousand()
            {
                // arrange
                int expected = 2;
                string input_string = "2,1001";

                // act
                int actual = StringCalculator.Add(input_string);

                // assert
                Assert.AreEqual(expected, actual);
                
            }
        }
    }
}
