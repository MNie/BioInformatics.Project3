using BioInformatics.Project3.Core.Algorithms.Kmer;
using BioInformatics.Project3.Core.Model;
using Nancy;
using Nancy.ModelBinding;

namespace BioInformatics.Project3.Web.Modules.Algorithms
{
    public class IndexerModule : NancyModule
    {
        private readonly IIndexerProvider _provider;
        public IndexerModule(IIndexerProvider provider)
        {
            _provider = provider;

            Post["/Indexer/DistanceScore"] = _ =>
            {
                var data = this.Bind<IndexerModel>();
                return Response.AsJson(_provider.DistanceScore(data.Length, data.Alphabet, data.DistanceFunction, data.CountsA, data.CountsB));
            };
        }
    }
}