using System.Linq;
using BioInformatics.Project3.Core.Providers;
using Shouldly;
using Xunit;

namespace BioInformatics.Project3.Core.Tests.Providers
{
    public class SequenceProviderSpecs
    {
        private readonly ISequenceProvider _sut;

        public SequenceProviderSpecs()
        {
            _sut = new SequenceProvider();
        }

        [Fact]
        public void Should_return_proper_sequence()
        {
            const string expectedResult = "GGCAGATTCCCCCTAGACCCGCCCGCACCATGGTCAGGCATGCCCCTCCTCATCGCTGGGCACA";
            var result = _sut.Provide(".fasta", $"> Complement: Complement: HSBGPG Human gene for bone gla protein(BGP)\n{expectedResult}");
            result.First().ToString().ShouldBe(expectedResult);
        }

        [Fact]
        public void Should_return_zero_sequences_when_passing_a_incorrect_data()
        {
            var result = _sut.Provide(".fasta", "dede");
            result.ShouldBeEmpty();
        }
    }
}
