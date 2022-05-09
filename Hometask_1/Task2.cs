using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace Hometask_1
{
    [TestFixture]
    public class Task_2
    {
        private class LetterEqualityComparer : IEqualityComparer<char>
        {
            public bool Equals(char x, char y) => Char.ToLower(x).Equals(Char.ToLower(y));

            public int GetHashCode([DisallowNull] char obj) => Char.ToLower(obj).GetHashCode();
        }
        public char first_non_repeating_letter(string str)
        {
            if (str.Equals(string.Empty)) return default;
            var characters = new List<char>(str);
            var lower_str = str.ToLower();
            var repetitive_characters =
                new List<char>(lower_str).GroupBy(c => c).Where(c => c.Count() > 1).Select(c => c.Key);
            var unique = characters.Except(repetitive_characters, new LetterEqualityComparer());
            return unique.FirstOrDefault();
        }
        [TestCase("sTreSS", 'T')]
        [TestCase("stress", 't')]
        [TestCase("", '\0')]
        [TestCase("QWERTYqwerty", '\0')]
        public void TestFirstNonRepeatingLetter(string str, char expected)
        {
            var result = first_non_repeating_letter(str);
            Assert.AreEqual(expected, result);
        }
    }
}