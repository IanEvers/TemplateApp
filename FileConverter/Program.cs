// Test methods for file conversions
using Blackbird.Applications.Sdk.Common.Files;
using FileConverter.Actions;

async Task RunTests()
{
    try 
    {
        Console.WriteLine("Starting test of DOCX to PDF conversion");
        
        var inputDocx = new DocumentTranslationRequest
        {
            File = new FileReference()
        };

        var inputPdf = new DocumentTranslationRequest()
        {
            File = new FileReference()
        };

        await TestMethods.TestDocxToPdfConversion(inputDocx);

        await TestMethods.TestPdfToDocxConversion(inputPdf);

        Console.WriteLine("Tests finished.");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error during tests: {ex.Message}");
    }
}

await RunTests();
