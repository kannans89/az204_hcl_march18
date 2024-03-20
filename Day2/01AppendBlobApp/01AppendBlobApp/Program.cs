using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using System;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        //await CaseStudy1();
       await  CaseStudy2();
    }

    private static async Task CaseStudy2()
    {
        string connectionString = "DefaultEndpointsProtocol=https;AccountName=day2gpv2store;AccountKey=i0s776lQsoehQDzuRD0e6F1kSCUfSb6C7Tsbch0yXLoctjln9IeAs7NHKVKngiWkD+RWTalVDYlK+ASt4WOwPw==;EndpointSuffix=core.windows.net";
        string containerName = "mylogs";
        string blobName = "mydata.log";

        // Get a reference to a container
        BlobContainerClient container = new BlobContainerClient(connectionString, containerName);

        // Get a reference to an append blob
        AppendBlobClient appendBlob = container.GetAppendBlobClient(blobName);

        // Ensure the append blob exists
        if (!await appendBlob.ExistsAsync())
        {
            Console.WriteLine("The specified append blob does not exist.");
            return;
        }

        // Append more text to the blob
        string additionalTextToAppend = "Additional text to append.,hello again\n";
        await appendBlob.AppendBlockAsync(new MemoryStream(Encoding.UTF8.GetBytes(additionalTextToAppend)));

        Console.WriteLine("Additional text appended to the blob successfully.");
    }

    private static async Task CaseStudy1()
    {
        string connectionString = "DefaultEndpointsProtocol=https;AccountName=day2gpv2store;AccountKey=i0s776lQsoehQDzuRD0e6F1kSCUfSb6C7Tsbch0yXLoctjln9IeAs7NHKVKngiWkD+RWTalVDYlK+ASt4WOwPw==;EndpointSuffix=core.windows.net";
        string containerName = "mylogs";
        string blobName = "mydata.log";

        // Get a reference to a container
        BlobContainerClient container = new BlobContainerClient(connectionString, containerName);

        // Create the container if it does not exist.
        await container.CreateIfNotExistsAsync();

        // Get a reference to an append blob
        AppendBlobClient appendBlob = container.GetAppendBlobClient(blobName);

        // Create the append blob if it does not exist
        await appendBlob.CreateIfNotExistsAsync();

        // Append text to the blob
        string textToAppend = "Hello, World!\n";
        await appendBlob.AppendBlockAsync(new MemoryStream(Encoding.UTF8.GetBytes(textToAppend)));

        Console.WriteLine("Text appended to the blob successfully.");
    }
}