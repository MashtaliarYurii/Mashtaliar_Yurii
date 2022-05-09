﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hometask_1
{
    [TestFixture]
    class Task_Extra_2
    {
        public string GetIPv4(uint number)
        {
            var ipv4 = new List<string>();
            var divider = (uint)(Math.Pow(2, 8));
            for (int i = 0; i < 4; i++)
            {
                ipv4.Insert(0, (number % divider).ToString());
                number /= divider;
            }
            return String.Join('.', ipv4);
        }
        [TestCase(2149583361, "128.32.10.1")]
        [TestCase((uint)32, "0.0.0.32")]
        [TestCase((uint)0, "0.0.0.0")]
        public void TestTransformation(uint number, string expected)
        {
            var result = GetIPv4(number);
            Assert.AreEqual(expected, result);
        }
    }
}