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
        [TestCase(13, "XIII")]
        [TestCase(14, "XIV")]
        [TestCase(27, "XXVII")]
        public void return_expected_roman_numeral_for_a_number(int number, string expected) {

            var result = RomanNumerals.RomanNumeralFrom(number);

            result.Should().Be(expected);
        }
    }

    public class RomanNumerals {
        public static object RomanNumeralFrom(int number) {
            var romanNumeral = string.Empty;

            if (number >= 10) {
                romanNumeral = "X";
                number -= 10;
            }
            
            if (number == 9) {
                romanNumeral += "IX";
                number -= 9;
            }
           
            if (number >= 5) {
                romanNumeral += "V";
                number -= 5;
            }

            if (number == 4) {
                romanNumeral += "IV";
                number -= 4;
            }


            for (int counter = 1; counter <= number; counter++) {
                romanNumeral += "I";
            }
            return romanNumeral;
        }
    }
}