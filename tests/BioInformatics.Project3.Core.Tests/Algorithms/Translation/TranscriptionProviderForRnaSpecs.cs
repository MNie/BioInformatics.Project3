using Bio;
using Bio.Algorithms.MUMmer;
using BioInformatics.Project3.Core.Algorithms.Translation;
using BioInformatics.Project3.Core.Providers;
using Rhino.Mocks;
using Shouldly;
using Xunit;

namespace BioInformatics.Project3.Core.Tests.Algorithms.Translation
{
    public class TranscriptionProviderForRnaSpecs
    {
        private static Sequence _seq;
        private readonly ITranscriptionProvider _sut;
        
        public TranscriptionProviderForRnaSpecs()
        {
            _seq = new Sequence(Alphabets.RNA, "UACCGC");
            var sequenceProvider = MockRepository.GenerateStub<ISequenceProvider>();
            sequenceProvider.Stub(x => x.Provide(null, null)).IgnoreArguments().Return(new[] { _seq });
            _sut = new TranscriptionProvider(sequenceProvider);
        }

        [Fact]
        public void should_transcript_to_rna()
        {
            var result = _sut.TranscribeToDNA(null);
            result.ToString().ShouldBe("TACCGC");
        }

        ~TranscriptionProviderForRnaSpecs()
        {
            _seq = null;
        }
    }
}
