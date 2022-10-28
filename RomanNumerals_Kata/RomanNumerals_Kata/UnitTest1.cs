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
        [TestCase(6, "VI")]
        [TestCase(9, "IX")]
        [TestCase(10, "X")]
        public void return_expected_roman_numeral_for_a_number(int number, string expected) {

            var result = RomanNumerals.RomanNumeralFrom(number);

            result.Should().Be(expected);
        }
    }

    public class RomanNumerals {
        public static object RomanNumeralFrom(int number) {
            var romanNumeral = string.Empty;
            if (number == 4) return "IV";
            if (number == 9) return "IX";

            if (number >= 5) {
                romanNumeral = "V";
                number -= 5;
            }
            for (int counter = 1; counter <= number; counter++) {
                romanNumeral += "I";
            }
            return romanNumeral;
        }
    }
}