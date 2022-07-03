using BlazorTextboxAsyncHttp.Shared;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace BlazorTextboxAsyncHttp.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Step2Controller : ControllerBase
    {
        private readonly ILogger _logger;

        public Step2Controller(ILogger<Step2Controller> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public async Task<Step2Response> Post([FromBody] Step2Request request)
        {
            await Task.Delay(TimeSpan.FromSeconds(5));

            var dict = new Dictionary<char, int>();
            foreach(var c in request.Text)
            {
                if (dict.ContainsKey(c))
                {
                    dict[c]++;
                } else
                {
                    dict.Add(c, 1);
                }
            }

            return new Step2Response { CharCount = dict };
        }
    }
}