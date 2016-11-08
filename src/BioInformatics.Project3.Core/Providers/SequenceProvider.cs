using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Bio;
using Bio.IO;

namespace BioInformatics.Project3.Core.Providers
{
    public interface ISequenceProvider
    {
        IReadOnlyCollection<ISequence> Provide(string fileName, string content);
    }

    public class SequenceProvider : ISequenceProvider
    {
        public IReadOnlyCollection<ISequence> Provide(string fileName, string content)
        {
            IReadOnlyCollection<ISequence> sequences = new ISequence[0];
            var byteArray = Encoding.UTF8.GetBytes(content);
            MemoryStream stream = null;
            try
            {
                stream = new MemoryStream(byteArray);
                var type = SequenceParsers.FindParserByFileName(fileName).GetType();
                var parser = (ISequenceParser) Activator.CreateInstance(type);

                sequences = parser.Parse(stream).ToList();

            }
            catch (Exception)
            {

            }
            finally
            {
                stream?.Close();
            }
            return sequences;
        }
    }
}
