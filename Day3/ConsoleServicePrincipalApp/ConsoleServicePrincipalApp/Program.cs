
using Azure.Identity;
using Azure.Storage.Blobs;

string tenantId = "f0093ae3-bfa4-46e1-9b91-668278209d56";
string clientId = "6ce719ab-08f6-4e21-af1b-8a485045e420";
string clientSecret = "Oje8Q~8wev5Kk2QEdKO0o3~UynOZEbMWqK3~ccDr";


string blobURI = "https://day3storeks2024.blob.core.windows.net/images/sub.jpg";
string filePath = "C:\\temp\\new.jpg";
ClientSecretCredential clientCredential = new ClientSecretCredential(tenantId, clientId, clientSecret);

BlobClient blobClient = new BlobClient(new Uri(blobURI), clientCredential);

await blobClient.DownloadToAsync(filePath);

Console.WriteLine("The blob is downloaded");

