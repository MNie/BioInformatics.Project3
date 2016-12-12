using System.Linq;
using Bio;
using Bio.Algorithms.MUMmer;
using Bio.Algorithms.StringSearch;
using BioInformatics.Project3.Core.Algorithms.StringSearch;
using BioInformatics.Project3.Core.Providers;
using Rhino.Mocks;
using Shouldly;
using Xunit;

namespace BioInformatics.Project3.Core.Tests.Algorithms.StringSearch
{
    public class BoyerMooreProviderSpecs
    {
        private static Sequence seq;
        private readonly IBoyerMooreProvider sut;
        public BoyerMooreProviderSpecs()
        {
            seq = new Sequence(DnaAlphabet.Instance.GetMummerAlphabet(), "GGCCC");
            var sequenceProvider = MockRepository.GenerateStub<ISequenceProvider>();
            sequenceProvider.Stub(x => x.Provide(null, null)).IgnoreArguments().Return(new[] { seq });
            sut = new BoyerMooreProvider(sequenceProvider, new BoyerMoore());
        }

        [Fact]
        public void Should_return_proper_count_of_matches()
        {
            var result = sut.GetMatches(null, new [] {"G", "CC", "GG", "cc"});
            result["G"].Count.ShouldBe(2);
            result["CC"].Count.ShouldBe(2);
            result["cc"].Count.ShouldBe(0);
            result["GG"].Count.ShouldBe(1);
        }

        [Fact]
        public void Should_return_proper_count_of_matches_when_we_ignore_case()
        {
            var result = sut.GetMatches(null, new[] { "G", "cc" }, true);
            result["G"].Count.ShouldBe(2);
            result["cc"].Count.ShouldBe(2);
        }

        [Fact]
        public void Should_return_proper_count_of_matches_when_we_start_from_custom_index()
        {
            var result = sut.GetMatches(null, new[] { "G", "CC" }, startIndex: 3);
            result["G"].Count.ShouldBe(0);
            result["CC"].Count.ShouldBe(1);
        }
    }
}
