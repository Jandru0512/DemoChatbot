using Demo.Common;
using System.Threading.Tasks;

namespace Demo.Service
{
    public class ChatService : IChatService
    {
        private readonly IChatDependencies _dependencies;
        public ChatService(IChatDependencies dependencies)
        {
            _dependencies = dependencies;
        }

        public async Task<string> Chat(ChatDto chat)
        {
            return await _dependencies.Chat(chat);
        }
    }
}
