using System.Collections.Generic;
using Bio;
using Bio.Algorithms.Alignment.MultipleSequenceAlignment;

namespace BioInformatics.Project3.Core.Algorithms.Kmer
{
    public interface IIndexerProvider
    {
        float DistanceScore(int kmerLength, IAlphabet alphabet, DistanceFunctionTypes distanceFunctionType, Dictionary<string, float> countsDA, Dictionary<string, float> countsDB);
    }

    public class IndexerProvider : IIndexerProvider
    {
        private KmerDistanceScoreCalculator _indexer;
        public float DistanceScore(int kmerLength, IAlphabet alphabet, DistanceFunctionTypes distanceFunctionType, Dictionary<string, float> countsDA, Dictionary<string, float> countsDB)
        {
            _indexer = new KmerDistanceScoreCalculator(kmerLength, alphabet, distanceFunctionType);
            return _indexer.CalculateDistanceScore(countsDA, countsDB);
        }
    }
}
