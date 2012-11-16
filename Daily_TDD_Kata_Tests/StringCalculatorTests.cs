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
            [TestMethod]
            public void ReturnZeroForEmptyString()
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
            public void ReturnOneforStringOne()
            {
                // arrange
                string input_string = "1";
                int expected = 1;

                // act
                int actual = StringCalculator.Add(input_string);

                // assert
                Assert.AreEqual(expected, actual);
            }

            [TestMethod]
            public void ReturnThreeForStringOneTwo()
            {
                // arrange
                string input_string = "1,2";
                int expected = 3;

                // act
                int actual = StringCalculator.Add(input_string);

                // assert
                Assert.AreEqual(expected, actual);
                
            }

            [TestMethod]
            public void ReturnSixForStringOneTwoThree()
            {
                // arrange
                string input_string = "1,2,3";
                int expected = 6;

                // act
                int actual = StringCalculator.Add(input_string);

                // assert
                Assert.AreEqual(expected, actual);
            }

            [TestMethod]
            public void ReturnSixUsingNewlineDelimiter()
            {
                // arrange
                string input_string = @"1\n2,3";
                int expected = 6;

                // act
                int actual = StringCalculator.Add(input_string);

                // assert
                Assert.AreEqual(expected, actual);
            }

            [TestMethod]
            public void ReturnSixUsingDelimitersDefinedInInputString()
            {
                // arrange
                string input_string = @"//;\n1;2";
                int expected = 3;

                // act
                int actual = StringCalculator.Add(input_string);

                // assert
                Assert.AreEqual(expected, actual);
            }
        }
    }
}
