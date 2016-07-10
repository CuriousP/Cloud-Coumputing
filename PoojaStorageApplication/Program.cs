namespace PoojaStorageApplication
{
    using Microsoft.WindowsAzure.Storage;
    using Microsoft.WindowsAzure.Storage.Blob;
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your name and address: ");
            string userData = Console.ReadLine();

            string storageConnectionString = "DefaultEndpointsProtocol=https;AccountName;Endpoint=https://storage.blob.core.windows.net/;TableEndpoint=https://storage.table.core.windows.net/;QueueEndpoint=https://storage.queue.core.windows.net/;FileEndpoint=https://storage.file.core.windows.net/";

            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(storageConnectionString);
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

            CloudBlobContainer container = blobClient.GetContainerReference("ucsccloudcomputing");
            container.CreateIfNotExists();

            CloudBlockBlob blockBlob = container.GetBlockBlobReference("userdata");

            blockBlob.UploadText(userData);

            Console.WriteLine("Upload to storage successful");
            Console.ReadLine();
        }
    }
}
