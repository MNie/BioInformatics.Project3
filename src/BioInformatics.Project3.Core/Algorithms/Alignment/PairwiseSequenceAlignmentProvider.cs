using System.Collections.Generic;
using System.Linq;
using Bio;
using Bio.Algorithms.Alignment;
using Bio.Algorithms.Translation;
using BioInformatics.Project3.Core.Model;
using BioInformatics.Project3.Core.Providers;

namespace BioInformatics.Project3.Core.Algorithms.Alignment
{
    public interface IPairwiseSequenceProvider
    {
        IDictionary<string, object> GetMetadata(SequenceModel sequenceData);
    }

    public class PairwiseSequenceAlignmentProvider : IPairwiseSequenceProvider
    {
        private readonly ISequenceProvider _provider;

        public PairwiseSequenceAlignmentProvider(ISequenceProvider provider)
        {
            _provider = provider;
        }

        public IDictionary<string, object> GetMetadata(SequenceModel sequenceData)
        {
            var sequence = _provider.Provide(sequenceData?.FileName, sequenceData?.Content);
            var alignment = new PairwiseSequenceAlignment(sequence.First(), sequence.Last());
            return alignment.Metadata;
        }
    }
}
