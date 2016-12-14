using System.Collections.Generic;
using System.Linq;
using Bio.Algorithms.SuffixTree;
using BioInformatics.Project3.Core.Model;
using BioInformatics.Project3.Core.Providers;

namespace BioInformatics.Project3.Core.Algorithms.SuffixTree
{
    public interface IMultiWaySuffixTreeProvider
    {
        IEnumerable<Match> GetMatches(SequenceModel sequenceData);
        IEnumerable<Match> GetUniqueMatches(SequenceModel sequenceData);
        long GetEdgesCount(SequenceModel sequenceData);
    }

    public class MultiWaySuffixTreeProvider : IMultiWaySuffixTreeProvider
    {
        private readonly ISequenceProvider _sequenceProvider;
        private MultiWaySuffixTree _suffixTree;
        public MultiWaySuffixTreeProvider(ISequenceProvider sequenceProvider)
        {
            _sequenceProvider = sequenceProvider;
        }

        public IEnumerable<Match> GetMatches(SequenceModel sequenceData)
        {
            var sequence = _sequenceProvider.Provide(sequenceData?.FileName, sequenceData?.Content)?.First();
            _suffixTree = new MultiWaySuffixTree(sequence);
            return _suffixTree.SearchMatches(sequence);
        }

        public IEnumerable<Match> GetUniqueMatches(SequenceModel sequenceData)
        {
            var sequence = _sequenceProvider.Provide(sequenceData?.FileName, sequenceData?.Content)?.First();
            _suffixTree = new MultiWaySuffixTree(sequence);
            return _suffixTree.SearchMatchesUniqueInReference(sequence);
        }

        public long GetEdgesCount(SequenceModel sequenceData)
        {
            var sequence = _sequenceProvider.Provide(sequenceData?.FileName, sequenceData?.Content)?.First();
            _suffixTree = new MultiWaySuffixTree(sequence);
            return _suffixTree.EdgesCount;
        }
    }
}
