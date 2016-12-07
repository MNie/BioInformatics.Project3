using Nancy;

namespace BioInformatics.Project3.Web.Modules
{
    public class IndexModule : NancyModule
    {
        public IndexModule()
        {
            Get["/"] = parameters =>
            {
                return View["index"];
            };

            Post["/Sequence/Parse"] = _ =>
            {
                return View["index"];
            };
        }
    }
}