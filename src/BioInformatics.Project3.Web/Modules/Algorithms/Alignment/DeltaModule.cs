using BioInformatics.Project3.Core.Algorithms.Alignment;
using BioInformatics.Project3.Core.Model;
using Nancy;
using Nancy.ModelBinding;

namespace BioInformatics.Project3.Web.Modules.Algorithms.Alignment
{
    public class DeltaModule : NancyModule
    {
        private readonly IDeltaProvider _provider;

        public DeltaModule(IDeltaProvider provider)
        {
            _provider = provider;

            Post["/Align/Delta/Delta"] = _ =>
            {
                var data = this.Bind<SequenceModel>();
                return Response.AsJson(_provider.GetDeltas(data));
            };

            Post["/Align/Delta/IsReverse"] = _ =>
            {
                var data = this.Bind<SequenceModel>();
                return Response.AsJson(_provider.IsReverseQueryDirection(data));
            };
        }
    }
}