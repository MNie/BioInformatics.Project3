using System.Collections.Generic;
using System.Linq;
using Bio.Algorithms.Alignment;
using BioInformatics.Project3.Core.Model;
using BioInformatics.Project3.Core.Providers;

namespace BioInformatics.Project3.Core.Algorithms.Alignment
{
    public interface INucmerAlignerProvider
    {
        IList<ISequenceAlignment> AlignSequences(SequenceModel[] sequenceData, int minimumScore = 200);
        IList<ISequenceAlignment> AlignSequencesSimple(SequenceModel[] sequenceData, int minimumScore = 200);
    }

    public class NucmerAlignerProvider : INucmerAlignerProvider
    {
        private readonly ISequenceProvider _provider;
        private readonly NucmerPairwiseAligner _aligner;

        public NucmerAlignerProvider(ISequenceProvider provider, NucmerPairwiseAligner aligner)
        {
            _provider = provider;
            _aligner = aligner;
        }

        public IList<ISequenceAlignment> AlignSequences(SequenceModel[] sequenceData, int minimumScore = 200)
        {
            _aligner.MinimumScore = minimumScore;
            var sequences = sequenceData.SelectMany(sequence => _provider.Provide(sequence?.FileName, sequence?.Content));
            return _aligner.Align(sequences);
        }

        public IList<ISequenceAlignment> AlignSequencesSimple(SequenceModel[] sequenceData, int minimumScore = 200)
        {
            _aligner.MinimumScore = minimumScore;
            var sequences = sequenceData.SelectMany(sequence => _provider.Provide(sequence?.FileName, sequence?.Content));
            return _aligner.AlignSimple(sequences);
        }
    }
}

