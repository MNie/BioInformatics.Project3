﻿using BioInformatics.Project3.Core.Algorithms.Alignment;
using BioInformatics.Project3.Core.Model;
using Nancy;

namespace BioInformatics.Project3.Web.Modules.Algorithms.Alignment
{
    public class NeedlemanModule : NancyModule
    {
        private readonly INeedlemanWunschAlignerProvider _provider;

        public NeedlemanModule(INeedlemanWunschAlignerProvider provider)
        {
            _provider = provider;

            Post["/Align/Needleman/Standard"] = _ =>
            {
                var data = (SequenceModel[])NancyExtensionToPost.GetData<SequenceModel[]>(Request.Query);
                return Response.AsJson(_provider.AlignSequences(data));
            };

            Post["/Align/Needleman/Simple"] = _ =>
            {
                var data = (SequenceModel[])NancyExtensionToPost.GetData<SequenceModel[]>(Request.Query);
                return Response.AsJson(_provider.AlignSequencesSimple(data));
            };
        }
    }
}