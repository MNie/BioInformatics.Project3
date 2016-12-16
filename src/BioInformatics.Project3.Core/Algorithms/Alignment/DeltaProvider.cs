using System.Collections.Generic;
using System.Linq;
using Bio.Algorithms.Alignment;
using BioInformatics.Project3.Core.Model;
using BioInformatics.Project3.Core.Providers;

namespace BioInformatics.Project3.Core.Algorithms.Alignment
{
    public interface IDeltaProvider
    {
        IList<long> GetDeltas(SequenceModel sequenceData);
        bool IsReverseQueryDirection(SequenceModel sequenceData);
    }

    public class DeltaProvider : IDeltaProvider
    {
        private readonly ISequenceProvider _provider;
        private DeltaAlignment _aligner;

        public DeltaProvider(ISequenceProvider provider)
        {
            _provider = provider;
        }

        public IList<long> GetDeltas(SequenceModel sequenceData)
        {
            var sequences = _provider.Provide(sequenceData?.FileName, sequenceData?.Content);
            _aligner = new DeltaAlignment(sequences.First(), sequences.Last());
            return _aligner.Deltas;
        }

        public bool IsReverseQueryDirection(SequenceModel sequenceData)
        {
            var sequences = _provider.Provide(sequenceData?.FileName, sequenceData?.Content);
            _aligner = new DeltaAlignment(sequences.First(), sequences.Last());
            return _aligner.IsReverseQueryDirection;
        }
    }
}
