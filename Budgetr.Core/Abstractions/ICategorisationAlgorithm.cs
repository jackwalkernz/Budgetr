using System.Collections.Generic;

namespace Budgetr.Core.Abstractions
{
    public interface ICategorisationAlgorithm
    {
        List<Dictionary<string, string>> CategoriseData(List<Dictionary<string, string>> rawData);
    }
}
