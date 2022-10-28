using FluentAssertions;
using NUnit.Framework;
using System;
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
        [TestCase(68, "LXVIII")]
        [TestCase(1547, "MDXLVII")]
        [TestCase(3207, "MMMCCVII")]
        [TestCase(3999, "MMMCMXCIX")]
        public void return_expected_roman_numeral_for_a_number(int number, string expected) {

            var result = RomanNumerals.RomanNumeralFrom(number);

            result.Should().Be(expected);
        }
        [Test]
        public void numeric_is_lower_than_one() {
            Func<object> convertZeroToRoman = () => RomanNumerals.RomanNumeralFrom(0);
            convertZeroToRoman.Should().Throw<IndexOutOfRangeException>();
        }

        [Test]
        public void numeric_is_higher_than_three_thousand_nine_hundred_ninety_nine() {
            Func<object> convertZeroToRoman = () => RomanNumerals.RomanNumeralFrom(4000);
            convertZeroToRoman.Should().Throw<IndexOutOfRangeException>();
        }
    }

    public class RomanNumerals {
        public static object RomanNumeralFrom(int number) {
            var romanNumeral = string.Empty;
            var discount = 0;

            CheckIfIsAValidNumber(number);

            var romanNumeralsDictionary = RomanNumeralDictionary();
            
            for (var counter = number; counter > 0; counter -= discount) {
                var orderedRomanNumerals = MinorNearestToNumber(romanNumeralsDictionary, counter);
                var roman = orderedRomanNumerals.Value;
                discount = orderedRomanNumerals.Key;
                romanNumeral += roman;
            }
            return romanNumeral;
        }

        private static KeyValuePair<int, string> MinorNearestToNumber(Dictionary<int, string> romanNumeralsDictionary, int counter) {
            return romanNumeralsDictionary
                .OrderByDescending(i => i.Key)
                .First(x => x.Key <= counter);
        }

        private static void CheckIfIsAValidNumber(int number) {
            if (number < 1 || number > 3999) throw new IndexOutOfRangeException();
        }

        private static Dictionary<int, string> RomanNumeralDictionary() {
            return new Dictionary<int, string>() {
                { 1, "I" },
                { 4, "IV" },
                { 5, "V" },
                { 9, "IX" },
                { 10, "X" },
                { 40, "XL" },
                { 50, "L" },
                { 90, "XC" },
                { 100, "C" },
                { 400, "CD" },
                { 500, "D" },
                { 900, "CM" },
                { 1000, "M" }
            };
        }
    }
}