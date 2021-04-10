using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FindeksesController : ControllerBase
    {
        private IFindeksService _findeksService;

        public FindeksesController(IFindeksService findeksService)
        {
            _findeksService = findeksService;
        }

        [HttpGet("calculate")]
        public ActionResult CalculateFindeksRating()
        {
            var result = _findeksService.CalculateFindeksRating();

            if (result.Success) return Ok(result);

            return BadRequest(result);
        }
    }
}
