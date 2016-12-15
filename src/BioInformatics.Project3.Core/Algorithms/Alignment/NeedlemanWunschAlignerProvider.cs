using System.Collections.Generic;
using Bio.Algorithms.Alignment;
using BioInformatics.Project3.Core.Model;
using BioInformatics.Project3.Core.Providers;

namespace BioInformatics.Project3.Core.Algorithms.Alignment
{
    public interface INeedlemanWunschAlignerProvider
    {
        IList<IPairwiseSequenceAlignment> AlignSequences(SequenceModel sequenceData);
        IList<IPairwiseSequenceAlignment> AlignSequencesSimple(SequenceModel sequenceData);
    }

    public class NeedlemanWunschAlignerProvider : INeedlemanWunschAlignerProvider
    {
        private readonly ISequenceProvider _provider;
        private readonly NeedlemanWunschAligner _aligner;

        public NeedlemanWunschAlignerProvider(ISequenceProvider provider, NeedlemanWunschAligner aligner)
        {
            _provider = provider;
            _aligner = aligner;
        }

        public IList<IPairwiseSequenceAlignment> AlignSequences(SequenceModel sequenceData)
        {
            var sequences = _provider.Provide(sequenceData?.FileName, sequenceData?.Content);
            return _aligner.Align(sequences);
        }

        public IList<IPairwiseSequenceAlignment> AlignSequencesSimple(SequenceModel sequenceData)
        {
            var sequences = _provider.Provide(sequenceData?.FileName, sequenceData?.Content);
            return _aligner.AlignSimple(sequences);
        }
    }
}
