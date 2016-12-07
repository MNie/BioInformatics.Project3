using System.Linq;
using Bio;
using Bio.Algorithms.MUMmer;
using BioInformatics.Project3.Core.Providers;
using Rhino.Mocks;
using Shouldly;
using Xunit;

namespace BioInformatics.Project3.Core.Tests.Providers
{
    public class StatisticsProviderSpecs
    {
        private static Sequence seq;
        private readonly IStatisticsProvider sut;
        public StatisticsProviderSpecs()
        {
            seq = new Sequence(DnaAlphabet.Instance.GetMummerAlphabet(), "GGCCC");
            var sequenceProvider = MockRepository.GenerateStub<ISequenceProvider>();
            sequenceProvider.Stub(x => x.Provide(null, null)).IgnoreArguments().Return(new [] { seq });
            sut = new StatisticsProvider(sequenceProvider);
        }

        [Fact]
        public void Should_return_proper_total_cound()
        {
            var result = sut.TotalCount("", "");
            result.First().ShouldBe(5);
        }

        [Fact]
        public void Should_return_proper_symbol_counts()
        {
            var result = sut.SymbolCounts("", "");
            result?.First().First().Item1.ShouldBe('C');
            result?.First().Last().Item1.ShouldBe('G');

            result?.First().First().Item2.ShouldBe(3);
            result?.First().Last().Item2.ShouldBe(2);
        }
    }
}
