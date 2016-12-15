using Bio;
using BioInformatics.Project3.Core.Algorithms.Alignment;
using BioInformatics.Project3.Core.Providers;
using Rhino.Mocks;
using Shouldly;
using Xunit;

namespace BioInformatics.Project3.Core.Tests.Algorithms.Alignment
{
    public class PairwiseSequenceAlignmentProviderSpecs
    {
        private static Sequence _seq1;
        private static Sequence _seq2;
        private readonly IPairwiseSequenceProvider _sut;
        public PairwiseSequenceAlignmentProviderSpecs()
        {
            _seq1 = new Sequence(Alphabets.DNA, "GGCCC");
            _seq2 = new Sequence(Alphabets.DNA, "AACCC");
            var sequenceProvider = MockRepository.GenerateStub<ISequenceProvider>();
            sequenceProvider.Stub(x => x.Provide(null, null)).IgnoreArguments().Return(new[] { _seq1, _seq2 });
            _sut = new PairwiseSequenceAlignmentProvider(sequenceProvider);
        }

        [Fact]
        public void should_return_empty_metadata_for_sequences()
        {
            var result = _sut.GetMetadata(null);
            result.ShouldBeEmpty();
        }
    }
}
