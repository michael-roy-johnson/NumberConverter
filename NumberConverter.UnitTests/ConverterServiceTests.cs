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

            Assert.AreEqual("FIVE DOLLARS", words);
        }

        [Test]
        public void NumberToWords_ReturnsCorrect_Result_ForTwoDigitNumber()
        {
            var words = _converterService.NumberToWords(99);

            Assert.AreEqual("NINETY NINE DOLLARS", words);
        }

        [Test]
        public void NumberToWords_ReturnsCorrect_Result_ForThreeDigitNumber()
        {
            var words = _converterService.NumberToWords(321);

            Assert.AreEqual("THREE HUNDRED AND TWENTY ONE DOLLARS", words);
        }

        [Test]
        public void NumberToWords_ReturnsCorrect_Result_ForFourDigitNumber()
        {
            var words = _converterService.NumberToWords(9876);

            Assert.AreEqual("NINE THOUSAND, EIGHT HUNDRED AND SEVENTY SIX DOLLARS", words);
        }

        [Test]
        public void NumberToWords_ReturnsCorrect_Result_ForSevenDigitNumber()
        {
            var words = _converterService.NumberToWords(5555555);

            Assert.AreEqual("FIVE MILLION, FIVE HUNDRED AND FIFTY FIVE THOUSAND, FIVE HUNDRED AND FIFTY FIVE DOLLARS", words);
        }

        [Test]
        public void NumberToWords_ReturnsCorrectDelimiters_ForNumberWithZeroes()
        {
            var words = _converterService.NumberToWords(909000);

            Assert.AreEqual("NINE HUNDRED AND NINE THOUSAND DOLLARS", words);
        }

        [Test]
        public void NumberToWords_ReturnsCorrectResult_ForNumberWithAllDigits()
        {
            var words = _converterService.NumberToWords(123456789);

            Assert.AreEqual("ONE HUNDRED AND TWENTY THREE MILLION, FOUR HUNDRED AND FIFTY SIX THOUSAND, SEVEN HUNDRED AND EIGHTY NINE DOLLARS", words);
        }

        [Test]
        public void NumberToWords_ReturnsCentsOnly_ForZeroDollars()
        {
            var words = _converterService.NumberToWords(0.79m);

            Assert.AreEqual("SEVENTY NINE CENTS", words);
        }

        [Test]
        public void NumberToWords_ReturnsRoundedCents_ForMoreThanTwoDecmimalPoints()
        {
            var words = _converterService.NumberToWords(0.12345678m);

            Assert.AreEqual("TWELVE CENTS", words);
        }

        [Test]
        public void NumberToWords_ReturnsCorrectResult_ForSingleDecimalPoint()
        {
            var words = _converterService.NumberToWords(0.5m);

            Assert.AreEqual("FIFTY CENTS", words);
        }

        [Test]
        public void NumberToWords_ReturnsCorrectResult_ForNumberWithDollarsAndCents()
        {
            var words = _converterService.NumberToWords(1234567.89m);

            Assert.AreEqual("ONE MILLION, TWO HUNDRED AND THIRTY FOUR THOUSAND, FIVE HUNDRED AND SIXTY SEVEN DOLLARS AND EIGHTY NINE CENTS", words);
        }

        [Test]
        public void NumberToWords_ReturnsSingularText_ForOneDollar()
        {
            var words = _converterService.NumberToWords(1);

            Assert.AreEqual("ONE DOLLAR", words);
        }

        [Test]
        public void NumberToWords_ReturnsSingularText_ForOneCent()
        {
            var words = _converterService.NumberToWords(0.01m);

            Assert.AreEqual("ONE CENT", words);
        }

        [Test]
        public void NumberToWords_ReturnsCorrectResult_ForZero()
        {
            var words = _converterService.NumberToWords(0);

            Assert.AreEqual("ZERO", words);
        }

        [Test]
        public void NumberToWords_ThrowsArgumentException_ForNumberGreaterThanRange()
        {
            Assert.Throws<ArgumentException>(() => _converterService.NumberToWords(9999999999));
        }

        [Test]
        public void NumberToWords_ThrowsArgumentException_ForNumberLessThanRange()
        {
            Assert.Throws<ArgumentException>(() => _converterService.NumberToWords(-0.01m));
        }
    }
}
