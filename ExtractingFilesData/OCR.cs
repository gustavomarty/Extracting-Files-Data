using System;
using Tesseract;

namespace ExtractingFilesData
{
    public class OCR
    {
		public static string ExtractContent(string imgPath)
		{
			using (var engine = new TesseractEngine(@"tessdata", "eng", EngineMode.Default))
			{
				using (var img = Pix.LoadFromFile(imgPath))
				{
					using (var page = engine.Process(img))
					{
						var text = page.GetText();

						Console.WriteLine($"score -> {page.GetMeanConfidence()}");

						return text;
					}
				}
			}
		}
	}
}
