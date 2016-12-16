using BioInformatics.Project3.Core.Algorithms.Alignment;
using BioInformatics.Project3.Core.Model;
using Nancy;
using Nancy.ModelBinding;

namespace BioInformatics.Project3.Web.Modules.Algorithms.Alignment
{
    public class NeedlemanModule : NancyModule
    {
        private readonly INeedlemanWunschAlignerProvider _provider;

        public NeedlemanModule(INeedlemanWunschAlignerProvider provider)
        {
            _provider = provider;

            Post["/Align/Needleman/Standard"] = _ =>
            {
                var data = this.Bind<SequenceModel>();
                return Response.AsJson(_provider.AlignSequences(data));
            };

            Post["/Align/Needleman/Simple"] = _ =>
            {
                var data = this.Bind<SequenceModel>();
                return Response.AsJson(_provider.AlignSequencesSimple(data));
            };
        }
    }
}