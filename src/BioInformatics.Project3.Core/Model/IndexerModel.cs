using System.Collections.Generic;
using Bio;
using Bio.Algorithms.Alignment.MultipleSequenceAlignment;

namespace BioInformatics.Project3.Core.Model
{
    public class IndexerModel
    {
        public int Length { get; set; }
        public IAlphabet Alphabet { get; set; }
        public DistanceFunctionTypes DistanceFunction { get; set; }
        public Dictionary<string, float> CountsA { get; set; }
        public Dictionary<string, float> CountsB { get;set;}
    }
}
