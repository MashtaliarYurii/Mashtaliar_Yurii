using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hometask_1
{
    [TestFixture]
    class Task_Extra
    {
        public int GetNextBiggerNumber(int number)
        {
            var number_copy = number;
            var current_digit_order = 0;
            while (number_copy / 10 != 0)
            {
                var current_digit = number_copy % 10;
                var previous_digit_order = current_digit_order + 1;
                while (number_copy / 10 != 0)
                {
                    number_copy /= 10;
                    var previous_digit = number_copy % 10;
                    if (previous_digit < current_digit)
                    {
                        for (int ord = current_digit_order; ord < previous_digit_order; ord++)
                            number += (int)(9 * Math.Pow(10, ord) * (current_digit - previous_digit));
                        return number;
                    }
                    previous_digit_order++;

                }
                current_digit_order++;
                number_copy = (int)(number / Math.Pow(10, current_digit_order));

            }

            return -1;
        }
        [TestCase(0, -1)]
        [TestCase(10, -1)]
        public void TestNegativeOne(int value, int expected)
        {
            var result = GetNextBiggerNumber(value);
            Assert.AreEqual(expected, result);
        }
        [TestCase(12, 21)]
        [TestCase(513, 531)]
        [TestCase(2017, 2071)]
        [TestCase(1111101, 1111110)]
        public void TestChangedNumber(int value, int expected)
        {
            var result = GetNextBiggerNumber(value);
            Assert.AreEqual(expected, result);
        }
    }
}