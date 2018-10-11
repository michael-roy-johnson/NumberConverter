using Moq;
using NumberConverter.API.Controllers;
using NumberConverter.Services;
using NUnit.Framework;

namespace NumberConverter.Tests
{
    [TestFixture]
    public class ConverterControllerTests
    {
        private ConverterController _converterController;
        private Mock<IConverterService> _converterService;

        [SetUp]
        public void Setup()
        {
            _converterService = new Mock<IConverterService>();
            _converterController = new ConverterController(_converterService.Object);
        }

        [Test]
        public void GetWords_ReturnsWordsString()
        {
            const string WORDS = "FIVE HUNDRED DOLLARS";
            const decimal NUMBER = 500;

            _converterService
                .Setup(x => x.NumberToWords(NUMBER))
                .Returns(WORDS);

            var result = _converterController.Get(NUMBER);

            Assert.AreEqual(WORDS, result);
            _converterService.Verify(x => x.NumberToWords(It.IsAny<decimal>()), Times.Once);
        }
    }
}
