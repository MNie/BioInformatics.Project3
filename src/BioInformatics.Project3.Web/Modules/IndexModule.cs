using System.Linq;
using BioInformatics.Project3.Core.Model;
using BioInformatics.Project3.Core.Providers;
using Nancy;
using Nancy.ModelBinding;

namespace BioInformatics.Project3.Web.Modules
{
    public class IndexModule : NancyModule
    {
        private readonly ISequenceProvider _provider;
        public IndexModule(ISequenceProvider provider)
        {
            _provider = provider;
            Get["/"] = parameters => View["index"];

            Post["/Sequence/Parse"] = _ =>
            {
                var data = this.Bind<SequenceModel>();
                return Response.AsJson(_provider.Provide(data?.FileName, data?.Content).Select(x => x.ToString()));
            };
        }
    }
}