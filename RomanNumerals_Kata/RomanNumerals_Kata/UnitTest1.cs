using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace RomanNumerals_Kata {
    public class RomanNumeralsShould {
        [SetUp]
        public void Setup() {
        }

        [TestCase(1, "I")]
        [TestCase(2, "II")]
        [TestCase(3, "III")]
        [TestCase(4, "IV")]
        [TestCase(5, "V")]
        [TestCase(6, "VI")]
        [TestCase(9, "IX")]
        [TestCase(10, "X")]
        [TestCase(13, "XIII")]
        [TestCase(14, "XIV")]
        [TestCase(27, "XXVII")]
        [TestCase(40, "XL")]
        public void return_expected_roman_numeral_for_a_number(int number, string expected) {

            var result = RomanNumerals.RomanNumeralFrom(number);

            result.Should().Be(expected);
        }
    }

    public class RomanNumerals {
        public static object RomanNumeralFrom(int number) {
            var romanNumeral = string.Empty;
            var discount = 0;

            var romanNumeralsDictionary = RomanNumeralDictionary();
            
            for (var counter = number; counter > 0; counter -= discount) {
                var orderedRomanNumerals = romanNumeralsDictionary
                    .OrderByDescending(i => i.Key)
                    .First(x => x.Key <= counter);
                var roman = orderedRomanNumerals.Value;
                discount = orderedRomanNumerals.Key;
                romanNumeral += roman;
            }
            return romanNumeral;
        }

        private static Dictionary<int, string> RomanNumeralDictionary() {
            return new Dictionary<int, string>() {
                { 1, "I" },
                { 4, "IV" },
                { 5, "V" },
                { 9, "IX" },
                { 10, "X" }
            };
        }
    }
}