using Autofac;
using Bio.Algorithms.Alignment;
using Bio.Algorithms.StringSearch;
using BioInformatics.Project3.Core.Algorithms.Alignment;
using BioInformatics.Project3.Core.Algorithms.Kmer;
using BioInformatics.Project3.Core.Algorithms.StringSearch;
using BioInformatics.Project3.Core.Algorithms.SuffixTree;
using BioInformatics.Project3.Core.Algorithms.Translation;
using BioInformatics.Project3.Core.Providers;
using Nancy.Bootstrappers.Autofac;

namespace BioInformatics.Project3.Web
{
    public class Bootstrapper : AutofacNancyBootstrapper
    {
        protected override void ConfigureApplicationContainer(ILifetimeScope existingContainer)
        {
            base.ConfigureApplicationContainer(existingContainer);
            existingContainer.Update(x =>
            {
                x.RegisterType<SequenceProvider>().As<ISequenceProvider>();
                x.RegisterType<StatisticsProvider>().As<IStatisticsProvider>();
                x.RegisterType<BoyerMoore>().AsSelf();
                x.RegisterType<BoyerMooreProvider>().As<IBoyerMooreProvider>();
                x.RegisterType<TranscriptionProvider>().As<ITranscriptionProvider>();
                x.RegisterType<ProteinProvider>().As<IProteinProvider>();
                x.RegisterType<PairwiseSequenceAlignmentProvider>().As<IPairwiseSequenceProvider>();
                x.RegisterType<NeedlemanWunschAlignerProvider>().As<INeedlemanWunschAlignerProvider>();
                x.RegisterType<NeedlemanWunschAligner>().AsSelf();
                x.RegisterType<DeltaProvider>().As<IDeltaProvider>();
                x.RegisterType<ClusterProvider>().As<IClusterProvider>();
                x.RegisterType<MultiWaySuffixTreeProvider>().As<IMultiWaySuffixTreeProvider>();
                x.RegisterType<IndexerProvider>().As<IIndexerProvider>();
            });
        }

        // The bootstrapper enables you to reconfigure the composition of the framework,
        // by overriding the various methods and properties.
        // For more information https://github.com/NancyFx/Nancy/wiki/Bootstrapper
    }
}