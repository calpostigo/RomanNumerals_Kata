using FluentAssertions;
using NUnit.Framework;

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
        public void return_expected_roman_numeral_for_a_number(int number, string expected) {

            var result = RomanNumerals.RomanNumeralFrom(number);

            result.Should().Be(expected);
        }
    }

    public class RomanNumerals {
        public static object RomanNumeralFrom(int number) {
            var romanNumeral = string.Empty;
            if (number == 4) return "IV";
            for (int counter = 1; counter <= number; counter++) {
                romanNumeral += "I";
            }
            return romanNumeral;
        }
    }
}