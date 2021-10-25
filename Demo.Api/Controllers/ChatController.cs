using Demo.Common;
using Demo.Service;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Demo.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly IChatService _chatService;

        public ChatController(IChatService chatService)
        {
            _chatService = chatService;
        }

        [HttpPost("chat")]
        public async Task<IActionResult> Chat([FromBody] ChatDto chat)
        {
            SessionDto session = SessionManager.Reaad(chat.User);
            chat.Context = session?.Context;
            string anwer = await _chatService.Chat(chat);

            if (anwer != string.Empty)
            {
                // Almacenar contexto
            }

            return Created(string.Empty, anwer);
        }
    }
}
