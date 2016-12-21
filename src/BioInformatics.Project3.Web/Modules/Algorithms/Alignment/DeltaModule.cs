using BioInformatics.Project3.Core.Algorithms.Alignment;
using BioInformatics.Project3.Core.Model;
using Nancy;
using Nancy.Extensions;
using Nancy.IO;
using Nancy.ModelBinding;
using Newtonsoft.Json;

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
                var data = (SequenceModel[])NancyExtensionToPost.GetData<SequenceModel[]>(Request.Query);
                return Response.AsJson(_provider.GetDeltas(data));
            };

            Post["/Align/Delta/IsReverse"] = _ =>
            {
                var data = (SequenceModel[])NancyExtensionToPost.GetData<SequenceModel[]>(Request.Query);
                return Response.AsJson(_provider.IsReverseQueryDirection(data));
            };
        }
    }

    public static class NancyExtensionToPost
    {
        public static TItem GetData<TItem>(dynamic body)
        {
            return JsonConvert.DeserializeObject<TItem>(body["data"]);
        }
    }
}