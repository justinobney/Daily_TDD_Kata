using System;
using System.Text;
using Daily_TDD_Kata;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Daily_TDD_Kata_Tests
{
    [TestClass]
    public class StringCalculatorTests
    {
        protected StringCalculator Target;

        [TestInitialize]
        public void Init()
        {
            Target = new StringCalculator();
        }

        [TestClass]
        public class TheAddMethod : StringCalculatorTests
        {
            // The method can take 0, 1 or 2 numbers, and will return their sum 
            // (for an empty string it will return 0) for example "" or "1" or "1,2"

            [TestMethod]
            public void ReturnZeroForEmptyString()
            {
                // arrange
                string input_string = "";
                int expected = 0;

                // act
                int actual = Target.Add(input_string);

                // assert
                Assert.AreEqual(expected, actual);
            }

            [TestMethod]
            public void ReturnOneForStringOne()
            {
                // arrange
                string input_string = "1";
                int expected = 1;

                // act
                int actual = Target.Add(input_string);

                // assert
                Assert.AreEqual(expected, actual);
            }

            [TestMethod]
            public void ReturnsThreeForStringOneTwo()
            {
                // arrange
                string input_string = "1,2";
                int expected = 3;

                // act
                int actual = Target.Add(input_string);

                // assert
                Assert.AreEqual(expected, actual);
            }

            [TestMethod]
            public void ReturnsSixForStringOneTwoThree()
            {
                // arrange
                string input_string = "1,2,3";
                int expected = 6;

                // act
                int actual = Target.Add(input_string);

                // assert
                Assert.AreEqual(expected, actual);
            }

            [TestMethod]
            public void ReturnsSixAloowingNewLineDelimiter()
            {
                // arrange
                string input_string = @"1\n2,3";
                int expected = 6;

                // act
                int actual = Target.Add(input_string);

                // assert
                Assert.AreEqual(expected, actual);
            }
            
        }
    }
}
