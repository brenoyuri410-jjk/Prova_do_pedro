using Microsoft.AspNetCore.Mvc;
using Senac_prova_do_pedraaaaao.Models;
using Senac_prova_do_pedraaaaao.Services;

namespace Senac_prova_do_pedraaaaao.Controllers
{
    [ApiController]
    [Route("hangouts")]
    public class HangoutsController : ControllerBase
    {
        private readonly HangoutService _hangoutService;

        public HangoutsController(HangoutService hangoutService)
        {
            _hangoutService = hangoutService;
        }

        [HttpGet]
        public ActionResult<List<Hangout>> Get()
        {
            return Ok(_hangoutService.GetAll());
        }

        [HttpPost]
        public ActionResult<Hangout> Post(Hangout hangout)
        {
            if (!_hangoutService.TryAdd(
                    hangout,
                    out var createdHangout,
                    out var errorMessage,
                    out var isConflict))
            {
                return isConflict
                    ? Conflict(new { message = errorMessage })
                    : BadRequest(new { message = errorMessage });
            }

            return Created("/hangouts", createdHangout);
        }
    }
}
