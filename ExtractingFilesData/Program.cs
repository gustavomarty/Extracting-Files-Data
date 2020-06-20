using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtractingFilesData
{
    class Program
    {
        static void Main(string[] args)
        {
            ExtractTextContent();

            ExtractImgContent();
        }
        static void ExtractTextContent()
        {
            string currentDir = @"Files\Text";
            var files = System.IO.Directory.GetFiles(currentDir);

            foreach (string file in files)
            {
                try
                {
                    var music = FileTextExtractor.ExtractData(file);
                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);
                    continue;
                }
            }
        }

        static void ExtractImgContent()
        {
            string currentDir = @"Files\Images";
            var files = System.IO.Directory.GetFiles(currentDir);

            foreach (string file in files)
            {
                try
                {
                    var music = OCR.ExtractContent(file);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
            }
        }
    }
}
