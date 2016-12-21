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
    public class NucmerAlignerProviderSpecs
    {
        private static Sequence _seq1;
        private static Sequence _seq2;
        private readonly NucmerAlignerProvider _sut;
        public NucmerAlignerProviderSpecs()
        {
            _seq1 = new Sequence(Alphabets.DNA, "AAAACCGGCCAAAACCGGCCAAAACCGGCCAAAACCGGCCAAAACCGGCCAAAACCGGCCAAAACCGGCCAAAACCGGCCAAAACCGGCCAAAACCGGCCAAAACCGGCCAAAACCGGCCAAAACCGGCCAAAACCGGCCAAAACCGGCCAAAACCGGCCAAAACCGGCCAAAACCGGCCAAAACCGGCCAAAACCGGCCAAAACCGG");
            _seq2 = new Sequence(Alphabets.DNA, "AAAACCGGCCAAAACCGGCCAAAACCGGCCAAAACCGGCCAAAACCGGCCAAAACCGGCCAAAACCGGCCAAAACCGGCCAAAACCGGCCAAAACCGGCCAAAACCGGCCAAAACCGGCCAAAACCGGCCAAAACCGGCCAAAACCGGCCAAAACCGGCCAAAACCGGCCAAAACCGGCCAAAACCGGCCAAAACCGGCCAAAACCGGCC");
            var sequenceProvider = MockRepository.GenerateStub<ISequenceProvider>();
            sequenceProvider.Stub(x => x.Provide(null, null)).IgnoreArguments().Return(new[] { _seq1, _seq2 });
            _sut = new NucmerAlignerProvider(sequenceProvider, new NucmerPairwiseAligner());
        }

        [Fact]
        public void should_return_proper_sequences_for_align()
        {
            var result = _sut.AlignSequences(new[] { new SequenceModel() });
            result.First().ToString().Trim().StartsWith("AAAACCGGCCAAAACCGGCCAAAACCGGCCAAAACCGGCCAAAACCGGCCAAAACCGGCCAAAA");
        }

        [Fact]
        public void should_return_proper_sequences_for_simple_align()
        {
            var result = _sut.AlignSequencesSimple(new[] { new SequenceModel() });
            result.First().ToString().Trim().StartsWith("AAAACCGGCCAAAACCGGCCAAAACCGGCCAAAACCGGCCAAAACCGGCCAAAACCGGCCAAAA");
        }

        ~NucmerAlignerProviderSpecs()
        {
            _seq1 = null;
            _seq2 = null;
        }
    }
}
