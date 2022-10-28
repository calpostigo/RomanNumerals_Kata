using FluentAssertions;
using NUnit.Framework;

namespace RomanNumerals_Kata {
    public class RomanNumeralsShould {
        [SetUp]
        public void Setup() {
        }

        [Test]
        public void return_roman_numeral_I_for_number_1() {
            var number = 1;

            var result = RomanNumerals.RomanNumeralFrom(number);

            result.Should().Be("I");
        }

        [Test]
        public void return_roman_numeral_II_for_number_2() {
            var number = 2;

            var result = RomanNumerals.RomanNumeralFrom(number);

            result.Should().Be("II");
        }

        [Test]
        public void return_roman_numeral_III_for_number_3() {
            var number = 3;

            var result = RomanNumerals.RomanNumeralFrom(number);

            result.Should().Be("III");
        }
    }

    public class RomanNumerals {
        public static object RomanNumeralFrom(int number) {
            if (number == 1) return "I";
            if (number == 2) return "II";
            return "III";
        }
    }
}