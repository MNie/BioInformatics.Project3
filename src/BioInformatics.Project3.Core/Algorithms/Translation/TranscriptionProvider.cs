using System.Collections.Generic;
using System.Linq;
using Bio;
using Bio.Algorithms.StringSearch;
using Bio.Algorithms.Translation;
using BioInformatics.Project3.Core.Model;
using BioInformatics.Project3.Core.Providers;

namespace BioInformatics.Project3.Core.Algorithms.Translation
{
    public interface ITranscriptionProvider
    {
        ISequence TranscribeToRNA(SequenceModel sequenceData);
        ISequence TranscribeToDNA(SequenceModel sequenceData);
    }

    public class TranscriptionProvider : ITranscriptionProvider
    {
        private readonly ISequenceProvider _sequenceProvider;
        public TranscriptionProvider(ISequenceProvider sequenceProvider)
        {
            _sequenceProvider = sequenceProvider;
        }

        public ISequence TranscribeToRNA(SequenceModel sequenceData)
        {
            var sequence = _sequenceProvider.Provide(sequenceData?.FileName, sequenceData?.Content)?.First();
            return Transcription.Transcribe(sequence);
        }

        public ISequence TranscribeToDNA(SequenceModel sequenceData)
        {
            var sequence = _sequenceProvider.Provide(sequenceData?.FileName, sequenceData?.Content)?.First();
            return Transcription.ReverseTranscribe(sequence);
        }
    }
}
