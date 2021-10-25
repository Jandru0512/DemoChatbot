using Demo.Common;
using System.Threading.Tasks;

namespace Demo.Service
{
    public interface IChatDependencies
    {
        Task<string> Chat(ChatDto chat);
    }
}