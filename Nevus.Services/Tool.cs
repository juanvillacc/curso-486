using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nevus.Services
{
    public static class Tool
    {
        public static void Log(string Mensaje)
        {
            string cc = "DefaultEndpointsProtocol=https;AccountName=demo486;AccountKey=fR6//NGphI+RE7OCV0/FpzfK1BSjWzjopr1rHUprECt3IYZfG6t5uXydafLw/SQTFu1TkL46ZARp+AStG//ukA==;EndpointSuffix=core.windows.net";
            string storageAcc = "demo486";

            CloudBlobContainer container = new CloudBlobContainer(new Uri("https://"+ storageAcc+".blob.core.windows.net"));

        }

    }
}
