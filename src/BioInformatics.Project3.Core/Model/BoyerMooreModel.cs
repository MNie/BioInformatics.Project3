namespace BioInformatics.Project3.Core.Model
{
    public class BoyerMooreModel
    {
        public SequenceModel Model { get; set; }
        public string[] Searches { get; set; }
        public bool IgnoreCase { get; set; }
        public int StartIndex { get; set; }
    }
}
