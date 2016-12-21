using BioInformatics.Project3.Core.Algorithms.Alignment;
using BioInformatics.Project3.Core.Model;
using Nancy;

namespace BioInformatics.Project3.Web.Modules.Algorithms.Alignment
{
    public class SmithModule : NancyModule
    {
        private readonly ISmithAlignerProvider _provider;

        public SmithModule(ISmithAlignerProvider provider)
        {
            _provider = provider;

            Post["/Align/Smith/Standard"] = _ =>
            {
                var data = (SequenceModel[])NancyExtensionToPost.GetData<SequenceModel[]>(Request.Query);
                return Response.AsJson(_provider.AlignSequences(data));
            };

            Post["/Align/Smith/Simple"] = _ =>
            {
                var data = (SequenceModel[])NancyExtensionToPost.GetData<SequenceModel[]>(Request.Query);
                return Response.AsJson(_provider.AlignSequencesSimple(data));
            };
        }
    }
}