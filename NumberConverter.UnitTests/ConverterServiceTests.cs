using System;
using NumberConverter.Repository;
using NumberConverter.Services;
using NUnit.Framework;

namespace NumberConverter.Tests
{
    [TestFixture]
    public class ConverterServiceTests
    {
        private IConverterService _converterService;

        [SetUp]
        public void Setup()
        {
            _converterService = new ConverterService(new WordsRepository());
        }

        [Test]
        public void NumberToWords_ReturnsCorrect_Result_ForOneDigitNumber()
        {
            var words = _converterService.NumberToWords(5);

            Assert.AreEqual("FIVE", words);
        }

        [Test]
        public void Two_Digit_Number_Returns_Correct_Result()
        {
            var words = _converterService.NumberToWords(99);

            Assert.AreEqual("NINETY NINE", words);
        }

        [Test]
        public void Three_Digit_Number_Returns_Correct_Result()
        {
            var words = _converterService.NumberToWords(321);

            Assert.AreEqual("THREE HUNDRED AND TWENTY ONE", words);
        }

        [Test]
        public void Four_Digit_Number_Returns_Correct_Result()
        {
            var words = _converterService.NumberToWords(9876);

            Assert.AreEqual("NINE THOUSAND, EIGHT HUNDRED AND SEVENTY SIX", words);
        }

        [Test]
        public void Seven_Digit_Number_Returns_Correct_Result()
        {
            var words = _converterService.NumberToWords(5555555);

            Assert.AreEqual("FIVE MILLION, FIVE HUNDRED AND FIFTY FIVE THOUSAND, FIVE HUNDRED AND FIFTY FIVE", words);
        }

        [Test]
        public void Seven_Digit_Number_With_Zeroes_Returns_Correct_Result()
        {
            var words = _converterService.NumberToWords(1001001);

            Assert.AreEqual("ONE MILLION, ONE THOUSAND AND ONE", words);
        }

        [Test]
        public void Zero_Number_Returns_Correct_Result()
        {
            var words = _converterService.NumberToWords(0);

            Assert.AreEqual("ZERO", words);
        }

        [Test]
        public void Number_With_All_Numbers_Returns_Correct_Result()
        {
            var words = _converterService.NumberToWords(123456789);

            Assert.AreEqual("ONE HUNDRED AND TWENTY THREE MILLION, FOUR HUNDRED AND FIFTY SIX THOUSAND, SEVEN HUNDRED AND EIGHTY NINE", words);
        }
    }
}
