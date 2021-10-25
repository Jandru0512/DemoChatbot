using Demo.Common;
using Demo.Service;
using IBM.Cloud.SDK.Core.Authentication.Iam;
using IBM.Watson.Assistant.v1;
using IBM.Watson.Assistant.v1.Model;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace Demo.ServicesDependencies
{
    public class ChatDependencies : IChatDependencies
    {
        private readonly IConfiguration _configuration;
        private const string _workspace = "Watson:Workspace";

        public ChatDependencies(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<string> Chat(ChatDto chat)
        {
            string workspace = _configuration[_workspace];
            MessageInput input = new()
            {
                Text = chat.Message
            };

            AssistantService assistan = CreateAssistant();
            dynamic result = assistan.Message(workspace, input: input, context: chat.Context ?? null, alternateIntents: true);
            return result.Response;
        }

        private AssistantService CreateAssistant()
        {
            string apiKey = _configuration["Watson:ApiKey"];
            string url = _configuration["Watson:Url"];
            string version = _configuration["Watson:Version"];
            IamAuthenticator authenticator = new(apiKey);
            AssistantService assistant = new(version, authenticator);
            assistant.SetServiceUrl(url);
            return assistant;
        }
    }
}
