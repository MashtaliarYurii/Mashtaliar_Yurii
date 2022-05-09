using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Hometask_1
{
    [TestFixture]
    class Task_3
    {
        public int digital_root(int number)
        {
            if (number < 0)
                number *= -1;
            if (number < 10)
                return number;
            var reduced_number = 0;
            while (number != 0)
            {
                reduced_number += number % 10;
                number /= 10;
            }
            return digital_root(reduced_number);
        }
        [TestCase(942, 6)]
        [TestCase(132189, 6)]
        [TestCase(0, 0)]
        [TestCase(-1919, 2)]
        public void TestDigitalRoot(int value, int expected)
        {
            var result = digital_root(value);
            Assert.AreEqual(expected, result);
        }
    }
}