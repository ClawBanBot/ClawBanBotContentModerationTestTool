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
        // Name of the file that contains text
        private static readonly string TextFile = "TextFile.txt";
        // The name of the file to contain the output from the evaluation.
        private static string TextOutputFile = "TextModerationOutput.txt";

        static void Main(string[] args)
        {
            // Create a text review client
            ContentModeratorClient clientText = Authenticate(Secrets.SubscriptionKey, Secrets.Endpoint);        
           
            // Moderate text from text in a file
            ModerateText(clientText, TextFile, TextOutputFile);
        }

        public static ContentModeratorClient Authenticate(string key, string endpoint)
        {
            ContentModeratorClient client = new ContentModeratorClient(new ApiKeyServiceClientCredentials(key));
            client.Endpoint = endpoint;

            return client;
        }

        /*
 * TEXT MODERATION
 * This example moderates text from file.
 */
        public static void ModerateText(ContentModeratorClient client, string inputFile, string outputFile)
        {
            Console.WriteLine("--------------------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("TEXT MODERATION");
            Console.WriteLine();
            // Load the input text.
            string text = File.ReadAllText(inputFile);

            // Remove carriage returns
            text = text.Replace(Environment.NewLine, " ");
            // Convert string to a byte[], then into a stream (for parameter in ScreenText()).
            byte[] textBytes = Encoding.UTF8.GetBytes(text);
            MemoryStream stream = new MemoryStream(textBytes);

            Console.WriteLine("Screening {0}...", inputFile);


            if (stream.Length > 0)
            {    
                // Write results to console
                using (client)
                {
                    // Screen the input text: check for profanity, classify the text into three categories,
                    // do autocorrect text, and check for personally identifying information (PII)
                    Console.WriteLine("Autocorrect typos, check for matching terms, PII, and classify.");

                    // Moderate the text
                    var screenResult = client.TextModeration.ScreenText("text/plain", stream, "eng", true, true, null, true);

                    var screenResultDeserialised = JsonConvert.SerializeObject(screenResult, Formatting.Indented);

                    var sexuallyExplicitPercentage = int.Parse(screenResult.Classification.Category1.ToString()) * 100;
                    var sexuallySuggestivePercentage = int.Parse(screenResult.Classification.Category2.ToString()) * 100;
                    var potentiallyOffensivePercentage = int.Parse(screenResult.Classification.Category3.ToString()) * 100;

                    Console.WriteLine($"Sexually Explicit/Adult Language probability: {sexuallyExplicitPercentage}%");
                    Console.WriteLine($"Sexually Suggestive Language probability: {sexuallySuggestivePercentage}%");
                    Console.WriteLine($"Potentially Offensive Language probability: {potentiallyOffensivePercentage}%");
                }              
            }

            else
            {
                Console.WriteLine("Please add some text to validate in TextFile.txt");
            }
        }
    }
}
