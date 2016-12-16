using BioInformatics.Project3.Core.Algorithms.Translation;
using BioInformatics.Project3.Core.Model;
using Nancy;
using Nancy.ModelBinding;

namespace BioInformatics.Project3.Web.Modules.Algorithms
{
    public class ProteinModule : NancyModule
    {
        private readonly IProteinProvider _provider;
        public ProteinModule(IProteinProvider provider)
        {
            _provider = provider;

            Post["/Protein/Translate"] = _ =>
            {
                var data = this.Bind<SequenceModel>();
                return Response.AsJson(_provider.Translate(data));
            };
        }
    }
}