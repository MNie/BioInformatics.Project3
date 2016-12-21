using BioInformatics.Project3.Core.Algorithms.Alignment;
using BioInformatics.Project3.Core.Model;
using Nancy;

namespace BioInformatics.Project3.Web.Modules.Algorithms.Alignment
{
    public class NucmerModule : NancyModule
    {
        private readonly INucmerAlignerProvider _provider;

        public NucmerModule(INucmerAlignerProvider provider)
        {
            _provider = provider;

            Post["/Align/Nucmer/Standard/{minimum}/"] = _ =>
            {
                var data = (SequenceModel[])NancyExtensionToPost.GetData<SequenceModel[]>(Request.Query);
                return Response.AsJson(_provider.AlignSequences(data));
            };

            Post["/Align/Nucmer/Simple/{minimum}/"] = _ =>
            {
                var data = (SequenceModel[])NancyExtensionToPost.GetData<SequenceModel[]>(Request.Query);
                return Response.AsJson(_provider.AlignSequencesSimple(data));
            };
        }
    }
}