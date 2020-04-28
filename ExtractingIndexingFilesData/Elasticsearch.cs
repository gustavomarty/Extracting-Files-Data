using Nest;
using System;

namespace ExtractingIndexingFilesData
{
    /// <summary>
    /// Class to manage elasticsearch
    /// </summary>
    public class Elasticsearch
    {
        #region Properties
        /// <summary>
        /// Default name of index
        /// </summary>
        private static string _indexName = "article";
        #endregion

        #region GetClient
        /// <summary>
        /// Get client to connect in elasticsearch
        /// </summary>
        /// <returns></returns>
        private static ElasticClient GetClient()
        {
            var uri = new Uri("http://localhost:9200");
            var settings = new ConnectionSettings(uri);
            var client = new ElasticClient();
            return client;
        }
        #endregion

        #region Index
        /// <summary>
        /// Index a document
        /// </summary>
        /// <param name="article"></param>
        public static void Index(Article article)
        {
            var client = GetClient();

            client.Index(new IndexRequest<Article>(article, _indexName));
        }
        #endregion

        #region CreateIndex
        /// <summary>
        /// Create indice with analyzer WordNet
        /// </summary>
        public static void CreateIndex()
        {
            var client = GetClient();

            var createIndexResponse = client.CreateIndex($"{_indexName}", c => c
                .Settings(s => s
                    .Analysis(a => a
                        .Analyzers(aa => aa
                            .Custom("synonym", sy => sy
                                .Tokenizer("whitespace")
                                .Filters("synonym")
                            )
                        )
                        .TokenFilters(tf => tf  
                            .Synonym("synonym", s => s
                                .Format(SynonymFormat.WordNet)
                                .SynonymsPath("analysis/wn_s.pl")
                                )
                        )
                    )
                )
                .Mappings(m => m
                    .Map<Article>(mm => mm
                        .AutoMap()
                    )
                )
            );
        }
        #endregion
    }
}
