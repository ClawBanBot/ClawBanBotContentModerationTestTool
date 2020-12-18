using Microsoft.Azure.CognitiveServices.ContentModerator;
using Microsoft.Azure.CognitiveServices.ContentModerator.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;

namespace ClawBanBotContentFilterTestTool
{
    class Program
    {
        // Your Content Moderator subscription key is found in your Azure portal resource on the 'Keys' page.
        private static readonly string SubscriptionKey = "CONTENT_MODERATOR_SUBSCRIPTION_KEY";
        // Base endpoint URL. Found on 'Overview' page in Azure resource. For example: https://westus.api.cognitive.microsoft.com
        private static readonly string Endpoint = "CONTENT_MODERATOR_ENDPOINT";


        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
