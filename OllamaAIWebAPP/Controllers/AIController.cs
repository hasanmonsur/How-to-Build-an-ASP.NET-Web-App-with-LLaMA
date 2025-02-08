using Microsoft.AspNetCore.Mvc;
using OllamaAIWebAPP.Services;

namespace OllamaAIWebAPP.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AIController : ControllerBase
    {
        private readonly OllamaService _ollmaServie;

        public AIController(OllamaService ollmaServie)
        {
            _ollmaServie = ollmaServie;
        }

        [HttpPost("chat")]
        public async Task<IActionResult> Chat([FromBody] string userInput)
        {
            var response = await _ollmaServie.GenerateResponseAsync(userInput);
            return Ok(response);
        }
    }
}
