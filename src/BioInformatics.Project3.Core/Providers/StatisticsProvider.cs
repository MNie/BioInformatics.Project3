using System;
using System.Collections.Generic;
using System.Linq;
using Bio;

namespace BioInformatics.Project3.Core.Providers
{
    public interface IStatisticsProvider
    {
        IEnumerable<long> TotalCount(string fileName, string content);
        IEnumerable<IEnumerable<Tuple<char, long>>> SymbolCounts(string fileName, string content);
    }

    public class StatisticsProvider : IStatisticsProvider
    {
        private readonly ISequenceProvider _sequenceProvider;

        public StatisticsProvider(ISequenceProvider sequenceProvider)
        {
            _sequenceProvider = sequenceProvider;
        }

        private IEnumerable<TItem> BaseStatistics<TItem>(string fileName, string content,
            Func<SequenceStatistics, TItem> selector)
        {
            var sequences = _sequenceProvider.Provide(fileName, content);
            return sequences.ToList().Select(x =>
            {
                var stats = new SequenceStatistics(x);
                return selector(stats);
            });
        }

        public IEnumerable<long> TotalCount(string fileName, string content)
        {
            return BaseStatistics(fileName, content, x => x.TotalCount);
        }

        public IEnumerable<IEnumerable<Tuple<char, long>>> SymbolCounts(string fileName, string content)
        {
            return BaseStatistics(fileName, content, x => x.SymbolCounts);
        }
    }
}
