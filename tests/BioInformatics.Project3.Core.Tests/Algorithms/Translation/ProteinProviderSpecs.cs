using Bio;
using Bio.Algorithms.StringSearch;
using BioInformatics.Project3.Core.Algorithms.StringSearch;
using BioInformatics.Project3.Core.Algorithms.Translation;
using BioInformatics.Project3.Core.Providers;
using Rhino.Mocks;
using Shouldly;
using Xunit;

namespace BioInformatics.Project3.Core.Tests.Algorithms.Translation
{
    public class ProteinProviderSpecs
    {
        private static Sequence _seq;
        private readonly IProteinProvider _sut;
        public ProteinProviderSpecs()
        {
            _seq = new Sequence(Alphabets.RNA, "GGCCC");
            var sequenceProvider = MockRepository.GenerateStub<ISequenceProvider>();
            sequenceProvider.Stub(x => x.Provide(null, null)).IgnoreArguments().Return(new[] { _seq });
            _sut = new ProteinProvider(sequenceProvider);
        }

        [Fact]
        public void Should_return_proper_protein_sequence()
        {
            var result = _sut.Translate(null);
            result.ToString().ShouldBe("G");
        }

        ~ProteinProviderSpecs()
        {
            _seq = null;
        }
    }
}
