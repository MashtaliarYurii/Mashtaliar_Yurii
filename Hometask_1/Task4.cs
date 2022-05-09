using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Hometask_1
{
    [TestFixture]
    class Task_4
    {
        public int NumberOfPairs(int[] arr, int target = 5)
        {
            var result = 0;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                result += arr.Skip(i + 1).Where(number => arr[i] + number == target).ToArray().Length;
            }
            return result;
        }
        [TestCase(new int[] { 1, 3, 6, 2, 2, 0, 4, 5 }, 5, 4)]
        [TestCase(new int[] { 1, 1, 1 }, 4, 0)]
        [TestCase(new int[] { }, 1, 0)]
        public void TestNumberOfPairs(int[] array, int target, int expected)
        {
            var result = NumberOfPairs(array, target);
            Assert.AreEqual(expected, result);
        }
    }
}