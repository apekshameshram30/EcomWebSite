using Application.CQRS.Command;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Controllers;

namespace Web.Controllers
{
    public class PaymentController : ApiController
    {

        
        [HttpPost ("Payment-Method")]
        public async Task<IActionResult> MakePayment([FromForm] AddPayment addPayment)
        {
            return Ok(await Mediator.Send(addPayment));
        }
    }
}
