using BlazorTextboxAsyncHttp.Shared;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace BlazorTextboxAsyncHttp.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Step1Controller : ControllerBase
    {
        private readonly ILogger _logger;

        public Step1Controller(ILogger<Step1Controller> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public async Task<Step1Response> Post([FromBody] Step1Request request)
        {
            await Task.Delay(TimeSpan.FromSeconds(1));

            var tokens = request.Text.Split(" ");
            var text = string.Join(" ", tokens.Select(token => $"<a href='#'>{token}</a>"));

            return new Step1Response { Text = text };
        }
    }
}