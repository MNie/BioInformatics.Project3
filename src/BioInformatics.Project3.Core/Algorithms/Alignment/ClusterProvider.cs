using System.Collections.Generic;
using System.Linq;
using Bio.Algorithms.Alignment;
using Bio.Algorithms.SuffixTree;

namespace BioInformatics.Project3.Core.Algorithms.Alignment
{
    public interface IClusterProvider
    {
        IList<MatchExtension> GetMatches(Match[] matches, bool isReverse = false);
        bool IsReverseQueryDirection(Match[] matches, bool isReverse = false);
    }

    public class ClusterProvider : IClusterProvider
    {
        private Cluster _aligner;

        public IList<MatchExtension> GetMatches(Match[] matches, bool isReverse = false)
        {
            _aligner = new Cluster(matches.Select(x => new MatchExtension(x)).ToArray(), isReverse);
            return _aligner.Matches;
        }

        public bool IsReverseQueryDirection(Match[] matches, bool isReverse = false)
        {
            _aligner = new Cluster(matches.Select(x => new MatchExtension(x)).ToArray(), isReverse);
            return _aligner.IsReverseQueryDirection;
        }
    }
}
