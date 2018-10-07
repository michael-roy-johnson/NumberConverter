using System;
using NumberConverter.Repository;
using NumberConverter.Services;
using NUnit.Framework;

namespace NumberConverter.Tests
{
    [TestFixture]
    public class WordsRepositoryTests
    {
        private IWordsRepository _wordsRepository;

        [SetUp]
        public void Setup()
        {
            _wordsRepository = new WordsRepository();
        }

        [Test]
        public void GetWordsDictionary_ReturnsWordsDictionary()
        {
            var wordsDictionary = _wordsRepository.GetWordsDictionary();

            Assert.IsNotNull(wordsDictionary);
            Assert.IsTrue(wordsDictionary.Count > 0);
        }
    }
}
