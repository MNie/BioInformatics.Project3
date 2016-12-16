using System.Linq;
using Bio;
using Bio.Algorithms.Alignment;
using Bio.Algorithms.SuffixTree;
using Bio.Util;
using BioInformatics.Project3.Core.Algorithms.Alignment;
using BioInformatics.Project3.Core.Providers;
using Rhino.Mocks;
using Shouldly;
using Xunit;

namespace BioInformatics.Project3.Core.Tests.Algorithms.Alignment
{
    public class ClusterProviderSpecs
    {
        private static Match _match1;
        private static Match _match2;
        private readonly ClusterProvider _sut;
        public ClusterProviderSpecs()
        {
            _match1 = new Match() {Length = 10, QuerySequenceOffset = 1, ReferenceSequenceOffset = 5};
            _match2 = new Match() {Length = 20, QuerySequenceOffset = 2, ReferenceSequenceOffset = 1};
            _sut = new ClusterProvider();
        }

        [Fact]
        public void should_return_not_empty_result_for_matches()
        {
            var result = _sut.GetMatches(new [] {_match1, _match2});
            result.ShouldNotBeEmpty();
        }

        [Fact]
        public void should_return_false_for_is_good_properties()
        {
            var result = _sut.GetMatches(new[] { _match1, _match2 });
            result.ForEach(x => x.IsGood.ShouldBeFalse());
        }

        [Fact]
        public void should_return_zero_for_all_scores()
        {
            var result = _sut.GetMatches(new[] { _match1, _match2 });
            result.ForEach(x => x.Score.ShouldBe(0));
        }

        [Fact]
        public void should_return_false_for_is_reverse()
        {
            var result = _sut.IsReverseQueryDirection(new[] {_match1, _match2});
            result.ShouldBeFalse();
        }
    }
}
