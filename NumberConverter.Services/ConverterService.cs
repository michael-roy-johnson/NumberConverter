using System;
using System.Collections.Generic;
using NumberConverter.Repository;
using System.Linq;

namespace NumberConverter.Services
{
    public class ConverterService : IConverterService
    {
        private IWordsRepository _wordRespository;
        private IDictionary<int, string> _wordsDictionary;
        private string _words = String.Empty;
        private const decimal MAX_VALUE = 999999999.99m;
        private const decimal MIN_VALUE = 0;

        public ConverterService(IWordsRepository wordRespository)
        {
            _wordRespository = wordRespository;
        }

        public string NumberToWords(decimal number)
        {
            if (number > MAX_VALUE || number < MIN_VALUE)
            {
                throw new ArgumentException($"Number cannot be greater than {MAX_VALUE.ToString()} or less than {MIN_VALUE.ToString()}.");
            }

            var indexes = new List<int> { 0 };

            _wordsDictionary = _wordRespository.GetWordsDictionary();

            return BuildWordsFromNumber(number).ToUpper();
        }

        private string BuildWordsFromNumber(decimal number)
        {
            var dollars = GetDollars(number);
            var cents = GetCents(number);
            var dollarsWords = String.Empty;
            var centsWords = String.Empty;
            var words = String.Empty;

            if (dollars <= 0 && cents <= 0)
            {
                return _wordsDictionary[0];
            }

            if (dollars > 0)
            {
                var dollarsIndexes = GetIndexes(dollars);
                dollarsWords = BuildWordsFromIndexes(dollarsIndexes);

                dollarsWords += dollars == 1 ?
                    " dollar" :
                    " dollars";
                centsWords = cents > 0 ?
                    " and " :
                    String.Empty;
            }

            if (cents > 0)
            {
                var centsIndexes = GetIndexes(cents);
                centsWords += BuildWordsFromIndexes(centsIndexes);

                centsWords += cents == 1 ?
                    " cent" :
                    " cents";
            }

            return dollarsWords + centsWords;
        }

        private int GetDollars(decimal number)
        {
            return (int)number;
        }

        private int GetCents(decimal number)
        {
            var dollars = GetDollars(number);
            var roundedNumber = Math.Round(number, 2);
            var cents = (roundedNumber - dollars) * 100;

            return (int)cents;
        }

        private string BuildWordsFromIndexes(List<int> indexes, int currentPosition = 0)
        {
            if ((indexes?.Count) == 0) return String.Empty;

            string currentWord = _wordsDictionary[indexes[currentPosition]];

            if (currentPosition + 1 >= indexes.Count) {
                return currentWord;
            }

            var nextPosition = currentPosition + 1;
            var delimiter = GenerateDelimiter(indexes[currentPosition], indexes[nextPosition], indexes.ElementAtOrDefault(nextPosition+1));

            return currentWord + delimiter + BuildWordsFromIndexes(indexes, nextPosition);
        }

        private string GenerateDelimiter(int leftIndex, int centerIndex, int? rightIndex = null) {
            if (leftIndex >= 100 && centerIndex < 100)
            {
                if (rightIndex < leftIndex && rightIndex >= 100)
                {
                    return ", ";
                }

                return " and ";
            }

            if (leftIndex > 100 && centerIndex > 100)
            {
                if (rightIndex < 100)
                {
                    return " and ";
                }

                return ", ";
            }

            return " ";
        }

        private List<int> GetIndexes(int number)
        {
            if (number >= 1000000)
            {
                return GetIndexesForNumberByIndex(number, 1000000);
            }

            if (number >= 1000)
            {
                return GetIndexesForNumberByIndex(number, 1000);
            }

            if (number >= 100)
            {
                return GetIndexesForNumberByIndex(number, 100);
            }

            if (number >= 20)
            {
                var currentIndex = number / 10 * 10;
                var nextIndexes = GetIndexes(number - currentIndex);
                var indexes = new List<int> { currentIndex };

                indexes.AddRange(nextIndexes);

                return indexes;
            }

            if (number >= 1)
            {
                return new List<int> { number };
            }

            return new List<int>();
        }

        private List<int> GetIndexesForNumberByIndex(int number, int index) {
            var previousIndexes = GetIndexes(number / index);
            var nextIndexes = GetIndexes(number % index);
            var indexes = previousIndexes;

            indexes.Add(index);
            indexes.AddRange(nextIndexes);

            return indexes;
        }

        private string GetWordWithDelimiter(string word, string previousWord, string delimiter = " ")
        {
            return String.IsNullOrEmpty(previousWord) ?
                word :
                $"{delimiter}{word}";
        }
    }
}