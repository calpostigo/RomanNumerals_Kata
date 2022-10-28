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
    }

    public class RomanNumerals {
        public static object RomanNumeralFrom(int number) {
            return "I";
        }
    }
}