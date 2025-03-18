using System.Reflection.Metadata;
using Blackbird.Applications.Sdk.Common.Files;
using FileConverter.Actions;
using SlackAPI;

public static class TestMethods
{

    public static async Task TestDocxToPdfConversion(DocumentTranslationRequest docxFile)
    {
        try
        {
            var result = await new Actions(null, null).ConvertDocxToPdf(docxFile);

            if (result != null)
            {
              Console.WriteLine($"PDF saved to: {result}");
            }
            else
            {
                Console.WriteLine("Conversion failed - no result returned");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error converting DOCX to PDF: {ex.Message}");
        }
    }

    public static async Task TestPdfToDocxConversion(DocumentTranslationRequest pdfFile)
    {
        try
        {
            var result = await new Actions(null, null).ConvertPdfToDocx(pdfFile);


            if (result != null)
            {
              Console.WriteLine($"DOCX saved to: {result}");
            }
            else
            {
                Console.WriteLine("Conversion failed - no result returned");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error converting PDF to DOCX: {ex.Message}");
        }
    }
    
}
