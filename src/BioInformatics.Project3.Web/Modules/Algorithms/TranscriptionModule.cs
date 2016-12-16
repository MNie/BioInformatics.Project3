using BioInformatics.Project3.Core.Algorithms.Translation;
using BioInformatics.Project3.Core.Model;
using Nancy;
using Nancy.ModelBinding;

namespace BioInformatics.Project3.Web.Modules.Algorithms
{
    public class TranscriptionModule : NancyModule
    {
        private readonly ITranscriptionProvider _provider;

        public TranscriptionModule(ITranscriptionProvider provider)
        {
            _provider = provider;

            Post["/Transcription/ToDNA"] = _ =>
            {
                var data = this.Bind<SequenceModel>();
                return Response.AsJson(_provider.TranscribeToDNA(data));
            };

            Post["/Transcription/ToRNA"] = _ =>
            {
                var data = this.Bind<SequenceModel>();
                return Response.AsJson(_provider.TranscribeToRNA(data));
            };
        }
    }
}