using BioInformatics.Project3.Core.Model;
using BioInformatics.Project3.Core.Providers;
using Nancy;
using Nancy.ModelBinding;

namespace BioInformatics.Project3.Web.Modules
{
    public class StatisticsModule : NancyModule
    {
        private readonly IStatisticsProvider _provider;
        public StatisticsModule(IStatisticsProvider provider)
        {
            _provider = provider;

            Post["/Stats/Symbol"] = _ =>
            {
                var data = this.Bind<SequenceModel>();
                return Response.AsJson(_provider.SymbolCounts(data?.FileName, data?.Content));
            };

            Post["/Stats/Total"] = _ =>
            {
                var data = this.Bind<SequenceModel>();
                return Response.AsJson(_provider.TotalCount(data?.FileName, data?.Content));
            };
        }
    }
}