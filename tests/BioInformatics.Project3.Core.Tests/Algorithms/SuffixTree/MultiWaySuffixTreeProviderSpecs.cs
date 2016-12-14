using System.Linq;
using Bio;
using Bio.Algorithms.StringSearch;
using BioInformatics.Project3.Core.Algorithms.StringSearch;
using BioInformatics.Project3.Core.Algorithms.SuffixTree;
using BioInformatics.Project3.Core.Providers;
using Rhino.Mocks;
using Shouldly;
using Xunit;

namespace BioInformatics.Project3.Core.Tests.Algorithms.SuffixTree
{
    public class MultiWaySuffixTreeProviderSpecs
    {
        private static Sequence _seq;
        private readonly MultiWaySuffixTreeProvider _sut;
        public MultiWaySuffixTreeProviderSpecs()
        {
            _seq = new Sequence(Alphabets.DNA, "GGCCCA");
            var sequenceProvider = MockRepository.GenerateStub<ISequenceProvider>();
            sequenceProvider.Stub(x => x.Provide(null, null)).IgnoreArguments().Return(new[] { _seq });
            _sut = new MultiWaySuffixTreeProvider(sequenceProvider);
        }

        [Fact]
        public void Should_return_proper_matches()
        {
            var result = _sut.GetMatches(null);
            result.ShouldBeEmpty();
        }

        [Fact]
        public void Should_return_proper_unique_matches()
        {
            var result = _sut.GetUniqueMatches(null);
            result.ShouldBeEmpty();
        }

        [Fact]
        public void Should_return_proper_edges_count()
        {
            var result = _sut.GetEdgesCount(null);
            result.ShouldBe(11);
        }

        ~MultiWaySuffixTreeProviderSpecs()
        {
            _seq = null;
        }
    }
}
