using Bio;
using BioInformatics.Project3.Core.Algorithms.Alignment;
using BioInformatics.Project3.Core.Providers;
using Rhino.Mocks;
using Shouldly;
using Xunit;

namespace BioInformatics.Project3.Core.Tests.Algorithms.Alignment
{
    public class DeltaProviderSpecs
    {
        private static Sequence _seq1;
        private static Sequence _seq2;
        private readonly DeltaProvider _sut;
        public DeltaProviderSpecs()
        {
            _seq1 = new Sequence(Alphabets.DNA, "GG");
            _seq2 = new Sequence(Alphabets.DNA, "AACC");
            var sequenceProvider = MockRepository.GenerateStub<ISequenceProvider>();
            sequenceProvider.Stub(x => x.Provide(null, null)).IgnoreArguments().Return(new[] { _seq1, _seq2 });
            _sut = new DeltaProvider(sequenceProvider);
        }

        [Fact]
        public void should_return_empty_result_for_deltas()
        {
            var result = _sut.GetDeltas(null);
            result.ShouldBeEmpty();
        }

        [Fact]
        public void should_return_false_for_is_reverse()
        {
            var result = _sut.IsReverseQueryDirection(null);
            result.ShouldBeFalse();
        }

        ~DeltaProviderSpecs()
        {
            _seq1 = null;
            _seq2 = null;
        }
    }
}
