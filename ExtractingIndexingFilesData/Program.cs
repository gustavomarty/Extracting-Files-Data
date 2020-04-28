using System;

namespace ExtractingIndexingFilesData
{
    class Program
    {
        static void Main(string[] args)
        {

            Elasticsearch.CreateIndex();

            IndexItems();

        }

        /// <summary>
        /// Index simple examples items
        /// </summary>
        static void IndexItems()
        {
            var article = new Article();
            article.Body = "child";

            Elasticsearch.Index(article);

            article = new Article();
            article.Body = "baby";

            Elasticsearch.Index(article);

            article = new Article();
            article.Body = "car";

            Elasticsearch.Index(article);

            article = new Article();
            article.Body = "motorcar";

            Elasticsearch.Index(article);

            article = new Article();
            article.Body = "automobile";

            Elasticsearch.Index(article);
        }

    }
}
