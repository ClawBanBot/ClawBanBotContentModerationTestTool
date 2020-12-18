using System;
using System.Collections.Generic;
using System.Text;

namespace ClawBanBotContentFilterTestTool
{
    public static class Secrets
    {
        // Your Content Moderator subscription key is found in your Azure portal resource on the 'Keys' page.
        private static readonly string SubscriptionKey = "CONTENT_MODERATOR_SUBSCRIPTION_KEY";
        // Base endpoint URL. Found on 'Overview' page in Azure resource. For example: https://westus.api.cognitive.microsoft.com
        private static readonly string Endpoint = "CONTENT_MODERATOR_ENDPOINT";
    }
}
