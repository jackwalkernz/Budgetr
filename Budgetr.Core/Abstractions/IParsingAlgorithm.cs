using System.Collections.Generic;

namespace Budgetr.Core.Abstractions
{
    public interface IParsingAlgorithm
    {
        List<Dictionary<string, string>> ParseData();
    }
}
