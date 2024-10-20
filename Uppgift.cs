using System.IO;
using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http; // Important for using HttpRequestData
using Microsoft.Extensions.Logging;

namespace uppgift.Function
{
    public class Uppgift
    {
        private readonly ILogger<Uppgift> _logger;

        public Uppgift(ILogger<Uppgift> logger)
        {
            _logger = logger;
        }

        [Function("Uppgift")]
        public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequestData req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            // Create a response object
            var response = req.CreateResponse(HttpStatusCode.OK);

            // Since this is an async method, you can await here if you have any async calls in the future
            // For example, if you read a file asynchronously, it could look like this:
            // string fileContent = await File.ReadAllTextAsync("path/to/file.txt");

            response.WriteString("Welcome to Azure Functions!");

            return response; // Return the response
        }
    }
}
