using System.Collections.Generic;
using System.Threading.Tasks;
using FirstVetApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FirstVetApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MeetingsController : ControllerBase
    {
        private readonly ILogger<MeetingsController> _logger;
        private readonly MeetingsService _meetingsService;

        public MeetingsController(ILogger<MeetingsController> logger, MeetingsService meetingsService)
        {
            _logger = logger;
            _meetingsService = meetingsService;
        }

        [HttpGet]
        public async Task<List<string>> Get([FromQuery] string state)
        {
            // TODO: Implement logging
            return await _meetingsService.Get(state);
        }
    }
}
