using System;
using System.Collections.Generic;

namespace NumberConverter.Repository
{
    public interface IWordsRepository
    {
        IDictionary<int, string> GetWordsDictionary();
    }
}
