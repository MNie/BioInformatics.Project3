﻿using BioInformatics.Project3.Core.Algorithms.StringSearch;
using BioInformatics.Project3.Core.Model;
using Nancy;
using Nancy.ModelBinding;

namespace BioInformatics.Project3.Web.Modules.Algrithms
{
    public class StringSearchModule : NancyModule
    {
        private readonly IBoyerMooreProvider _provider;
        public StringSearchModule(IBoyerMooreProvider provider)
        {
            _provider = provider;

            Post["/StringSearch/Match"] = _ =>
            {
                var data = this.Bind<BoyerMooreModel>();
                return Response.AsJson(_provider.GetMatches(data.Model, data.Searches, data.IgnoreCase, data.StartIndex));
            };
        }
    }
}