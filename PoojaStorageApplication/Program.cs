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

            string storageConnectionString = "DefaultEndpointsProtocol=https;AccountName=poojaucscstorage;AccountKey=t6df4Fdbe9yQC1bVARa9fM66LxlU2LguJDj0ZUKmBTEAK9EasC0CTsuzZOAmly/wsX+VYrLSpV4rN7O2xwU0yg==;BlobEndpoint=https://poojaucscstorage.blob.core.windows.net/;TableEndpoint=https://poojaucscstorage.table.core.windows.net/;QueueEndpoint=https://poojaucscstorage.queue.core.windows.net/;FileEndpoint=https://poojaucscstorage.file.core.windows.net/";

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
