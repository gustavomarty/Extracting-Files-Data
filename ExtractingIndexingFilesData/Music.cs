using Nest;

namespace ExtractingIndexingFilesData
{
    public class Music
    {
        [Text(Index = true)]
        public string Id { get; set; }
        
        [Text]
        public string Title { get; set; }

        [Text(Analyzer = "word_delimiter", SearchAnalyzer = "synonym")]
        public string Lyrics { get; set; }

        [Text]
        public string ContentType { get; set; }

        [Number]
        public long ContentLength { get; set; }
    }
}
