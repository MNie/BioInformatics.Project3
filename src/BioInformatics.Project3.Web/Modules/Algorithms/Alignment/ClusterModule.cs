using Bio.Algorithms.SuffixTree;
using BioInformatics.Project3.Core.Algorithms.Alignment;
using Nancy;
using Nancy.ModelBinding;

namespace BioInformatics.Project3.Web.Modules.Algorithms.Alignment
{
    public class ClusterModule : NancyModule
    {
        private readonly IClusterProvider _provider;

        public ClusterModule(IClusterProvider provider)
        {
            _provider = provider;

            Post["/Align/Cluster/Match"] = _ =>
            {
                var data = this.Bind<Match[]>();
                return Response.AsJson(_provider.GetMatches(data));
            };

            Post["/Align/Cluster/IsReverse"] = _ =>
            {
                var data = this.Bind<Match[]>();
                return Response.AsJson(_provider.IsReverseQueryDirection(data));
            };
        }
    }
}