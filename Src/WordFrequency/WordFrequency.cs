namespace WordFrequency
{
    public class WordFrequency : IWordFrequency
    {
        public string Word { get; private set; }
        public int Frequency { get; private set; }

        public WordFrequency(string word, int frequency)
        {
            Word = word;
            Frequency = frequency;
        }
    }
}
