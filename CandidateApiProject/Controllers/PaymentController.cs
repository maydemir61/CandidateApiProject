using Business.Abstract;
using DataAccess.PayzeeRequestResponse.PaymentService;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CandidateApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : Controller
    {
        IPayzeeService _payzeeService;
        public PaymentController(IPayzeeService payzeeService)
        {
            this._payzeeService=payzeeService; 
        }
        [HttpPost("payment")]
        public IActionResult Payment(PaymentRequest request)
        {
            var result = _payzeeService.Payment(request);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
