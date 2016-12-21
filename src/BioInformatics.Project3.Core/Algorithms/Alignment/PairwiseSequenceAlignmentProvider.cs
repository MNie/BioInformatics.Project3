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
        IDictionary<string, object> GetMetadata(SequenceModel[] sequenceData);
    }

    public class PairwiseSequenceAlignmentProvider : IPairwiseSequenceProvider
    {
        private readonly ISequenceProvider _provider;

        public PairwiseSequenceAlignmentProvider(ISequenceProvider provider)
        {
            _provider = provider;
        }

        public IDictionary<string, object> GetMetadata(SequenceModel[] sequenceData)
        {
            var sequences = sequenceData.SelectMany(sequence => _provider.Provide(sequence?.FileName, sequence?.Content)).ToList();
            var alignment = new PairwiseSequenceAlignment(sequences.First(), sequences.Last());
            return alignment.Metadata;
        }
    }
}
