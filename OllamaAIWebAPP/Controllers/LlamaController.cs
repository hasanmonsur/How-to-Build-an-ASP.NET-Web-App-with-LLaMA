using Microsoft.AspNetCore.Mvc;
using OllamaAIWebAPP.Services;

namespace OllamaAIWebAPP.Controllers
{
    [Route("api/llama")]
    [ApiController]
    public class LlamaController : ControllerBase
    {
        private readonly LlamaService _llamaService;

        public LlamaController(LlamaService llamaService)
        {
            _llamaService = llamaService;
        }

        [HttpPost("ask")]
        public async Task<IActionResult> Ask([FromBody] string prompt)
        {
            var response = await _llamaService.GetResponseFromLlamaAsync(prompt);
            return Ok(response);
        }
    }
}
