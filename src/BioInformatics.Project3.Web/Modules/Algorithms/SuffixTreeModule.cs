using BioInformatics.Project3.Core.Algorithms.SuffixTree;
using BioInformatics.Project3.Core.Model;
using Nancy;
using Nancy.ModelBinding;

namespace BioInformatics.Project3.Web.Modules.Algorithms
{
    public class SuffixTreeModule : NancyModule
    {
        private readonly IMultiWaySuffixTreeProvider _provider;
        public SuffixTreeModule(IMultiWaySuffixTreeProvider provider)
        {
            _provider = provider;

            Post["/SuffixTree/Edge/Count"] = _ =>
            {
                var data = this.Bind<SequenceModel>();
                return Response.AsJson(_provider.GetEdgesCount(data));
            };

            Post["/SuffixTree/Matches/Standard"] = _ =>
            {
                var data = this.Bind<SequenceModel>();
                return Response.AsJson(_provider.GetMatches(data));
            };

            Post["/SuffixTree/Matches/Unique"] = _ =>
            {
                var data = this.Bind<SequenceModel>();
                return Response.AsJson(_provider.GetUniqueMatches(data));
            };
        }
    }
}