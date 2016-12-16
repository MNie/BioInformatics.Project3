using BioInformatics.Project3.Core.Algorithms.Alignment;
using BioInformatics.Project3.Core.Model;
using Nancy;
using Nancy.ModelBinding;

namespace BioInformatics.Project3.Web.Modules.Algorithms.Alignment
{
    public class PairwaiseModule : NancyModule
    {
        private readonly IPairwiseSequenceProvider _provider;

        public PairwaiseModule(IPairwiseSequenceProvider provider)
        {
            _provider = provider;

            Post["/Align/Pairwise/Metadata"] = _ =>
            {
                var data = this.Bind<SequenceModel>();
                return Response.AsJson(_provider.GetMetadata(data));
            };
        }
    }
}