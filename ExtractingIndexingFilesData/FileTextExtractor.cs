using org.apache.tika.config;
using org.apache.tika.detect;
using org.apache.tika.io;
using org.apache.tika.mime;
using System;
using System.Text.RegularExpressions;
using TikaOnDotNet;

namespace ExtractingIndexingFilesData
{
    public class FileTextExtractor
    {
        private static TextExtractor _cut;

        public static Music ExtractData(string filename)
        {
            _cut = new TextExtractor();

            var file = System.IO.File.ReadAllBytes(filename);
            var result = _cut.Extract(filename);

            var music = new Music()
            {
                Id = filename,
                ContentType = result.ContentType,
                Lyrics = Regex.Replace(result.Text, @"\r\n?|\n", " ")
            };

            if (result.Metadata.ContainsKey("title"))
                music.Title = result.Metadata["title"];
            else
                music.Title = filename;
            
            if (result.Metadata.ContainsKey("Content-Length"))
            {
                long longtest;
                if (long.TryParse(result.Metadata["Content-Length"], out longtest))
                {
                    music.ContentLength = longtest;
                }
            }

            return music;
        }

        public static string ExtractText(string filename)
        {
            _cut = new TextExtractor();

            System.IO.File.ReadAllBytes(filename);
            var result = _cut.Extract(filename);
            return result.Text;
        }

    }
}
