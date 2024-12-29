using Budgetr.Core.Abstractions;

using System;
using System.Collections.Generic;

namespace Budgetr.Core.Algorithms
{
    public class BNZCategorisationAlgorithm : ICategorisationAlgorithm
    {
        private readonly List<string> _categories;
        public BNZCategorisationAlgorithm(List<string> categories)
        {
            _categories = categories;
        }
        public List<Dictionary<string, string>> CategoriseData(List<Dictionary<string, string>> rawData)
        {
            if (rawData.Count != _categories.Count) throw new ArithmeticException("The data cannot be categorised as the number of categories does not match the number of data entries");

            for (int i = 0; i < _categories.Count; i++)
            {
                string category = _categories[i];
                if (string.IsNullOrEmpty(category) || string.IsNullOrWhiteSpace(category)) throw new ArgumentNullException("A category cannot be null or empty");

                rawData[i]["Category"] = category;
            }
            return rawData;
        }
    }
}
