using System.IO;
using System.Threading.Tasks;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace SecondFunctionApp
{
    public class MyDocsBlobTrigger
    {
        private readonly ILogger<MyDocsBlobTrigger> _logger;

        public MyDocsBlobTrigger(ILogger<MyDocsBlobTrigger> logger)
        {
            _logger = logger;
        }

        [Function(nameof(MyDocsBlobTrigger))]
        public async Task Run([BlobTrigger("mydocs/{name}", Connection = "mystorageconnectionstring")] Stream stream, string name)
        {
            using var blobStreamReader = new StreamReader(stream);
            var content = await blobStreamReader.ReadToEndAsync();
            _logger.LogInformation($"C# Blob trigger function Processed blob\n Name: {name} \n Data: {content}");
        }
    }
}
