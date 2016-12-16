using System.Collections.Generic;
using System.Linq;
using Bio.Algorithms.Alignment;
using Bio.Algorithms.SuffixTree;

namespace BioInformatics.Project3.Core.Algorithms.Alignment
{
    public interface IClusterProvider
    {
        IList<MatchExtension> GetMatches(Match[] matches);
        bool IsReverseQueryDirection(Match[] matches);
    }

    public class ClusterProvider : IClusterProvider
    {
        private Cluster _aligner;

        public IList<MatchExtension> GetMatches(Match[] matches)
        {
            _aligner = new Cluster(matches.Select(x => new MatchExtension(x)).ToArray());
            return _aligner.Matches;
        }

        public bool IsReverseQueryDirection(Match[] matches)
        {
            _aligner = new Cluster(matches.Select(x => new MatchExtension(x)).ToArray());
            return _aligner.IsReverseQueryDirection;
        }
    }
}
