using System.Collections.Generic;
using Bio;
using Bio.Algorithms.Alignment.MultipleSequenceAlignment;
using BioInformatics.Project3.Core.Algorithms.Kmer;
using Shouldly;
using Xunit;

namespace BioInformatics.Project3.Core.Tests.Algorithms.Kmer
{
    public class IndexerProviderSpecs
    {
        private readonly IIndexerProvider _sut;
        public IndexerProviderSpecs()
        {
            _sut = new IndexerProvider();
        }

        [Fact]
        public void Should_return_proper_value_for_distance_score()
        {
            var result = _sut.DistanceScore(10, Alphabets.DNA, DistanceFunctionTypes.EuclideanDistance,
                new Dictionary<string, float>() {{"dede", 4.3f}}, new Dictionary<string, float>() {{"dede", 1.2f}});
            result.ShouldBeGreaterThan(3.1f);
            result.ShouldBeLessThan(3.101f);
        }
    }
}
