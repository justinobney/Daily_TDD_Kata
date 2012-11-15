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
                string empty_string = "";
                int expected = 0;

                // act
                int actual = StringCalculator.Add(empty_string);

                // assert
                Assert.AreEqual(expected, actual);
                
            }

            [TestMethod]
            public void ReturnOneForStringOne()
            {
                // arrange
                string numbers = "1";
                int expected = 1;

                // act
                int actual = StringCalculator.Add(numbers);

                // assert
                Assert.AreEqual(expected, actual);
                
            }

            [TestMethod]
            public void ReturnThreeForStringOneTwo()
            {
                // arrange
                string numbers = "1,2";
                int expected = 3;

                // act
                int actual = StringCalculator.Add(numbers);

                // assert
                Assert.AreEqual(expected, actual);

            }

            [TestMethod]
            public void ReturnSixForStringOneTwoTree()
            {
                // arrange
                string numbers = "1,2,3";
                int expected = 6;

                // act
                int actual = StringCalculator.Add(numbers);

                // assert
                Assert.AreEqual(expected, actual);

            }

            [TestMethod]
            public void ReturnSixForStringWithMultipleDelimeters()
            {
                // arrange
                string numbers = @"1\n2,3";
                int expected = 6;

                // act
                int actual = StringCalculator.Add(numbers);

                // assert
                Assert.AreEqual(expected, actual);

            }

            [TestMethod]
            public void ReturnSixForStringSupportingDifferentDelimeters()
            {
                // arrange
                string numbers = @"//;1\n2,3";
                int expected = 6;

                // act
                int actual = StringCalculator.Add(numbers);

                // assert
                Assert.AreEqual(expected, actual);

            }
        }
    }
}
