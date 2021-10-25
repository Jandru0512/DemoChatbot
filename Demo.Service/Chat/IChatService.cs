using Demo.Common;
using System.Threading.Tasks;

namespace Demo.Service
{
    public interface IChatService
    {
        Task<string> Chat(ChatDto chat);
    }
}