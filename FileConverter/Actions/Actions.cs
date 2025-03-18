using System.Net.Mime;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Files;
using Blackbird.Applications.Sdk.Common.Invocation;
using Blackbird.Applications.Sdk.Common.Exceptions;
using RestSharp;
using FileConverter.Constants;
using FileConverter.Invocables;
using FileConverter.Models.Dto;
using FileConverter.Models.Request;
using FileConverter.Models.Response;
using FileConverter.RestSharp;
using ConvertApiDotNet;
using ConvertApiDotNet.Exceptions;

using Blackbird.Applications.SDK.Extensions.FileManagement.Interfaces;
namespace FileConverter.Actions;

public class DocumentTranslationRequest
{
    public FileReference File { get; set; }
}


/// <summary>
/// Contains list of actions
/// </summary>
[ActionList]
public class Actions : AppInvocable
{
    private const string ConvertApiToken = "token_4EmFztcP";

    private readonly IFileManagementClient _fileManagementClient;


    #region Constructors


    public Actions(InvocationContext invocationContext, IFileManagementClient fileManagementClient) : base(
        invocationContext)
    {
        _fileManagementClient = fileManagementClient;
    }

    #endregion

    #region Actions

    /// <summary>
    /// Convert a DOCX file to PDF format
    /// </summary>
    [Action("Convert DOCX to PDF", Description = "Convert a DOCX file to PDF format")]
    public async Task<FileResponse> ConvertDocxToPdf(
        [ActionParameter] DocumentTranslationRequest input
    )
    {
        if (input.File == null || string.IsNullOrEmpty(input.File.Url))
        {
            throw new PluginMisconfigurationException("No file provided. Please provide a valid file and try again.");
        }
        try
        {
            var convertApi = new ConvertApi(ConvertApiToken);

            var destinationFileName = Path.Combine(".", $"result-{Guid.NewGuid()}.pdf");

            var convertTask = await convertApi.ConvertAsync(
                "docx", 
                "pdf",
                new ConvertApiFileParam(input.File.Url)
            );

            Console.WriteLine("Converted file: " + convertTask.Files.First().FileName);

            var file = new FileReference(
                new HttpRequestMessage(HttpMethod.Get, convertTask.Files.First().Url), 
                convertTask.Files.First().FileName,
                MediaTypeNames.Application.Octet
            );

            Console.WriteLine("file uploaded: " + file.Name); 

            return new(file);
        }
        catch (ConvertApiException e)
        {
            Console.WriteLine("Status Code: " + e.StatusCode);
            Console.WriteLine("Response: " + e.Response);
            throw new PluginMisconfigurationException(e.Response);

        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
            throw new PluginMisconfigurationException(ex.Message);
        }
    }

    /// <summary>
    /// Convert a PDF file to DOCX format
    /// </summary>
    [Action("Convert PDF to DOCX", Description = "Convert a PDF file to DOCX format")]
    public async Task<FileResponse> ConvertPdfToDocx(
        [ActionParameter] DocumentTranslationRequest input
    )
    {
        if (input.File == null || string.IsNullOrEmpty(input.File.Url))
        {
            throw new PluginMisconfigurationException("No file provided. Please provide a valid file and try again.");
        }
        try
        {
            var convertApi = new ConvertApi(ConvertApiToken);

            var destinationFileName = Path.Combine(".", $"{input.File.Name}.docx");

            var convertTask = await convertApi.ConvertAsync(
                "pdf", 
                "docx",
                new ConvertApiFileParam(input.File.Url)
            );

            Console.WriteLine("Converted file: " + convertTask.Files.First().FileName);

            var file = new FileReference(
                new HttpRequestMessage(HttpMethod.Get, convertTask.Files.First().Url), 
                convertTask.Files.First().FileName,
                MediaTypeNames.Application.Octet
            );

            Console.WriteLine("file uploaded: " + file.Name); 

            return new(file);
        }
        catch (ConvertApiException e)
        {
            Console.WriteLine("Conversion failed. Status Code: " + e.StatusCode);
            Console.WriteLine("Response: " + e.Response);
            throw new($"Could not download your file; ", e);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
            throw new PluginMisconfigurationException(ex.Message);
        }
    }

    #endregion
}