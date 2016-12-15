using System.Linq;
using Bio;
using Bio.Algorithms.Alignment;
using BioInformatics.Project3.Core.Algorithms.Alignment;
using BioInformatics.Project3.Core.Providers;
using Rhino.Mocks;
using Shouldly;
using Xunit;

namespace BioInformatics.Project3.Core.Tests.Algorithms.Alignment
{
    public class NeedlemanWunschAlignerProviderSpecs
    {
        private static Sequence _seq1;
        private static Sequence _seq2;
        private readonly NeedlemanWunschAlignerProvider _sut;
        public NeedlemanWunschAlignerProviderSpecs()
        {
            _seq1 = new Sequence(Alphabets.DNA, "GG");
            _seq2 = new Sequence(Alphabets.DNA, "AACC");
            var sequenceProvider = MockRepository.GenerateStub<ISequenceProvider>();
            sequenceProvider.Stub(x => x.Provide(null, null)).IgnoreArguments().Return(new[] { _seq1, _seq2 });
            _sut = new NeedlemanWunschAlignerProvider(sequenceProvider, new NeedlemanWunschAligner());
        }

        [Fact]
        public void should_return_proper_sequences_for_align()
        {
            var result = _sut.AlignSequences(null);
            result.First().ToString().Trim().ShouldBe("RRCC\r\nGG--\r\nAACC");
        }

        [Fact]
        public void should_return_proper_sequences_for_simple_align()
        {
            var result = _sut.AlignSequencesSimple(null);
            result.First().ToString().Trim().ShouldBe("RRCC\r\nGG--\r\nAACC");
        }

        ~NeedlemanWunschAlignerProviderSpecs()
        {
            _seq1 = null;
            _seq2 = null;
        }
    }
}
