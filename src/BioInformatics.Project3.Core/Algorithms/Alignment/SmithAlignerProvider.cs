using System.Collections.Generic;
using System.Linq;
using Bio.Algorithms.Alignment;
using BioInformatics.Project3.Core.Model;
using BioInformatics.Project3.Core.Providers;

namespace BioInformatics.Project3.Core.Algorithms.Alignment
{
    public interface ISmithAlignerProvider
    {
        IList<IPairwiseSequenceAlignment> AlignSequences(SequenceModel[] sequenceData);
        IList<IPairwiseSequenceAlignment> AlignSequencesSimple(SequenceModel[] sequenceData);
    }

    public class SmithAlignerProvider : ISmithAlignerProvider
    {
        private readonly ISequenceProvider _provider;
        private readonly SmithWatermanAligner _aligner;

        public SmithAlignerProvider(ISequenceProvider provider, SmithWatermanAligner aligner)
        {
            _provider = provider;
            _aligner = aligner;
        }

        public IList<IPairwiseSequenceAlignment> AlignSequences(SequenceModel[] sequenceData)
        {
            var sequences = sequenceData.SelectMany(sequence => _provider.Provide(sequence?.FileName, sequence?.Content));
            return _aligner.Align(sequences);
        }

        public IList<IPairwiseSequenceAlignment> AlignSequencesSimple(SequenceModel[] sequenceData)
        {
            var sequences = sequenceData.SelectMany(sequence => _provider.Provide(sequence?.FileName, sequence?.Content));
            return _aligner.AlignSimple(sequences);
        }
    }
}
