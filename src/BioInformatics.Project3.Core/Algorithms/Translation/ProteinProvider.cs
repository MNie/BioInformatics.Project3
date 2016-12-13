using System.Linq;
using Bio;
using Bio.Algorithms.Translation;
using BioInformatics.Project3.Core.Model;
using BioInformatics.Project3.Core.Providers;

namespace BioInformatics.Project3.Core.Algorithms.Translation
{
    public interface IProteinProvider
    {
        ISequence Translate(SequenceModel sequenceData);
    }

    public class ProteinProvider : IProteinProvider
    {
        private readonly ISequenceProvider _provider;

        public ProteinProvider(ISequenceProvider provider)
        {
            _provider = provider;
        }

        public ISequence Translate(SequenceModel sequenceData)
        {
            var sequence = _provider.Provide(sequenceData?.FileName, sequenceData?.Content)?.First();
            return ProteinTranslation.Translate(sequence);
        }
    }
}
