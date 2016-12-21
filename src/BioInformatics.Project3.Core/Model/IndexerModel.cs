using System;
using System.Collections.Generic;
using System.Linq;
using Bio;
using Bio.Algorithms.Alignment.MultipleSequenceAlignment;
using Newtonsoft.Json;

namespace BioInformatics.Project3.Core.Model
{
    public class IndexerModel
    {
        public int Length { get; set; }

        public IAlphabet Alphabet
        {
            get { return Alphabets.All.Single(x => x.Name.Equals(AlphabetSerialized, StringComparison.InvariantCultureIgnoreCase)); }
        }

        public DistanceFunctionTypes DistanceFunction { get; set; }

        public Dictionary<string, float> CountsA => JsonConvert.DeserializeObject<Dictionary<string, float>>(CountsASerialized);

        public Dictionary<string, float> CountsB => JsonConvert.DeserializeObject<Dictionary<string, float>>(CountsBSerialized);
        public string CountsASerialized { get; set; }
        public string CountsBSerialized { get; set; }
        public string AlphabetSerialized { get; set; }
    }
}
