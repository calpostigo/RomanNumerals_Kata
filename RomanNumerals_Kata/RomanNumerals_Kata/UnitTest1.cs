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
        public void return_expected_roman_numeral_for_a_number(int number, string expected) {

            var result = RomanNumerals.RomanNumeralFrom(number);

            result.Should().Be(expected);
        }
    }

    public class RomanNumerals {
        public static object RomanNumeralFrom(int number) {
            var romanNumeral = string.Empty;
            int discount = 0;
            for (int i = number; i > 0; i = i - discount) {
                if (number >= 10) {
                    romanNumeral += "X";
                    discount = 10;
                    number -= discount;
                }

                if (number == 9) {
                    romanNumeral += "IX";
                    discount = 9;
                    number -= discount;
                }

                if (number >= 5 && number < 9) {
                    romanNumeral += "V";
                    discount = 5;
                    number -= discount;
                }

                if (number == 4) {
                    romanNumeral += "IV";
                    discount = 4;
                    number -= discount;
                }
                if (number < 4 && number > 0) {
                    romanNumeral += "I";
                    discount = 1;
                    number -= discount;
                }
            }
            return romanNumeral;
        }

    }
}