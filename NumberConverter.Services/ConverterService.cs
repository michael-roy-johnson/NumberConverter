using System;
using System.Collections.Generic;
using NumberConverter.Repository;
using System.Linq;

namespace NumberConverter.Services
{
    public class ConverterService : IConverterService
    {
        private readonly IWordsRepository _wordRespository;
        private IDictionary<int, string> _wordsDictionary;
        private string _words = String.Empty;

        public ConverterService(IWordsRepository wordRespository)
        {
            _wordRespository = wordRespository;
        }

        public string NumberToWords(int number)
        {
            var indexes = new List<int> { 0 };

            _wordsDictionary = _wordRespository.GetWordsDictionary();

            if (number > 0)
            {
                indexes = GetIndexes(number);
            }

            return BuildWordsFromIndexes(indexes).ToUpper();
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
                if (rightIndex >= 100)
                {
                    return ", ";
                }

                return " and ";
            }

            if (leftIndex > 100 && centerIndex > 100)
            {
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
