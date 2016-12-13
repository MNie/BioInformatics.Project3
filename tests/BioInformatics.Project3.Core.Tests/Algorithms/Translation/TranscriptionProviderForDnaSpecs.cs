using Bio;
using Bio.Algorithms.MUMmer;
using Bio.Algorithms.StringSearch;
using BioInformatics.Project3.Core.Algorithms.StringSearch;
using BioInformatics.Project3.Core.Algorithms.Translation;
using BioInformatics.Project3.Core.Providers;
using Rhino.Mocks;
using Shouldly;
using Xunit;

namespace BioInformatics.Project3.Core.Tests.Algorithms.Translation
{
    public class TranscriptionProviderForDnaSpecs
    {
        private static Sequence _seq;
        private readonly ITranscriptionProvider _sut;
        public TranscriptionProviderForDnaSpecs()
        {
            _seq = new Sequence(Alphabets.DNA, "TACCGC");
            var sequenceProvider = MockRepository.GenerateStub<ISequenceProvider>();
            sequenceProvider.Stub(x => x.Provide(null, null)).IgnoreArguments().Return(new[] { _seq });
            _sut = new TranscriptionProvider(sequenceProvider);
        }

        [Fact]
        public void should_transcript_to_rna()
        {
            var result = _sut.TranscribeToRNA(null);
            result.ToString().ShouldBe("UACCGC");
        }

        ~TranscriptionProviderForDnaSpecs()
        {
            _seq = null;
        }
    }
}
