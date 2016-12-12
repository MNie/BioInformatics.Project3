using System.Collections.Generic;
using System.Linq;
using Bio.Algorithms.StringSearch;
using BioInformatics.Project3.Core.Model;
using BioInformatics.Project3.Core.Providers;

namespace BioInformatics.Project3.Core.Algorithms.StringSearch
{
    public interface IBoyerMooreProvider
    {
        IDictionary<string, IList<int>> GetMatches(SequenceModel sequenceData, string[] searches, bool ignoreCase = false, int startIndex = 0);
    }

    public class BoyerMooreProvider : IBoyerMooreProvider
    {
        private readonly ISequenceProvider _sequenceProvider;
        private readonly BoyerMoore _boyerMoore;
        public BoyerMooreProvider(ISequenceProvider sequenceProvider, BoyerMoore boyerMoore)
        {
            _sequenceProvider = sequenceProvider;
            _boyerMoore = boyerMoore;
        }

        public IDictionary<string, IList<int>> GetMatches(SequenceModel sequenceData, string[] searches, bool ignoreCase = false, int startIndex = 0)
        {
            var sequence = _sequenceProvider.Provide(sequenceData?.FileName, sequenceData?.Content)?.First();
            _boyerMoore.IgnoreCase = ignoreCase;
            _boyerMoore.StartIndex = startIndex;
            return _boyerMoore.FindMatch(sequence, searches);
        }
    }
}
