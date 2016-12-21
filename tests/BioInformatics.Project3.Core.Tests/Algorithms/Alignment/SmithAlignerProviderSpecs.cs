using System.Linq;
using Bio;
using Bio.Algorithms.Alignment;
using BioInformatics.Project3.Core.Algorithms.Alignment;
using BioInformatics.Project3.Core.Model;
using BioInformatics.Project3.Core.Providers;
using Rhino.Mocks;
using Shouldly;
using Xunit;

namespace BioInformatics.Project3.Core.Tests.Algorithms.Alignment
{
    public class SmithAlignerProviderSpecs
    {
        private static Sequence _seq1;
        private static Sequence _seq2;
        private readonly SmithAlignerProvider _sut;
        public SmithAlignerProviderSpecs()
        {
            _seq1 = new Sequence(Alphabets.DNA, "AGCGTAG");
            _seq2 = new Sequence(Alphabets.DNA, "CTCGTC");
            //_seq1 = new Sequence(Alphabets.DNA, "GACTTAC");
            //_seq2 = new Sequence(Alphabets.DNA, "CGTGAATTCAT");
            //_seq1 = new Sequence(Alphabets.DNA, "AACGTTGAC");
            //_seq2 = new Sequence(Alphabets.DNA, "AAGGTATGAATC");
            var sequenceProvider = MockRepository.GenerateStub<ISequenceProvider>();
            sequenceProvider.Stub(x => x.Provide(null, null)).IgnoreArguments().Return(new[] { _seq1, _seq2 });
            _sut = new SmithAlignerProvider(sequenceProvider, new SmithWatermanAligner());
        }

        [Fact]
        public void should_return_proper_sequences_for_align()
        {
            var result = _sut.AlignSequences(new[] { new SequenceModel() });
            result.First().ToString().Trim().ShouldBe("CGT\r\nCGT\r\nCGT");
            //result.First().ToString().Trim().ShouldBe("GAMTT\r\nGACTT\r\nGAATT");
            //result.First().ToString().Trim().ShouldBe("AASGT\r\nAACGT\r\nAAGGT");
        }

        [Fact]
        public void should_return_proper_sequences_for_simple_align()
        {
            var result = _sut.AlignSequencesSimple(new[] { new SequenceModel() });
            result.First().ToString().Trim().ShouldBe("CGT\r\nCGT\r\nCGT");
        }

        ~SmithAlignerProviderSpecs()
        {
            _seq1 = null;
            _seq2 = null;
        }
    }
}
