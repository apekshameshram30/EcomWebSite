using Application.CQRS.Command;
using Application.CQRS.Query;
using Application.DTOs;
using Domain.Entity;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;

using System.Reflection.Metadata.Ecma335;
using WebApplication1.Controllers;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValueController : ApiController
    {
        [HttpPost("Registration")]
        public async Task<IActionResult> AddRegister([FromForm] AddRegistration add)
        {
            return Ok(await Mediator.Send(add));
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] AddLogin addLogin)
        {
            return Ok(await Mediator.Send(addLogin));   
        }

        [HttpPost("ForgetPassword")]
        public async Task<IActionResult> ResetPassword(ForgotPassword forgotPass)
        {
            return Ok(await Mediator.Send(forgotPass));
        }

        [HttpPost("OtpVerification")]
        public async Task<IActionResult> OTPVerify([FromBody] VerificationOfOtp verifyOtp)
        {
            return Ok(await Mediator.Send(verifyOtp));
        }

        [HttpPost("UserChangePassword")]
        public async Task<IActionResult> UserChangePassword(ChangePassword changePassword)
        {
            return Ok(await Mediator.Send(changePassword));
        }

        [HttpPost("AddProduct")]
        public async Task<IActionResult> AddProduct([FromBody] AddProduct addProduct)
        {
            return Ok(await Mediator.Send(addProduct));
        }

        [HttpPost("Add-Country")]
        public async Task<IActionResult> AddCountry([FromBody] CountryDTO addCountry)
        {
            return Ok(await Mediator.Send (new AddCountry { countryDto = addCountry}));
        }

        [HttpPost("AddStates")]
        public async Task<IActionResult> AddStates([FromBody] AddStates addState)
        {
            return Ok(await Mediator.Send(addState));
        }

        [HttpGet("GetCountry")]
        public async Task<IEnumerable<Country>> GetCountry()
        {
            return await Mediator.Send(new GetAllCountry());
        }

        [HttpGet("GetAllStates")]
        public async Task<IEnumerable<State>> GetState()
        {
            return await Mediator.Send(new GetAllState());
        }

        [HttpGet("GetStateByCountryId")]
         public async Task<IEnumerable<State>> GetSByCId(int id)
         {
             var details= await Mediator.Send(new GetStateByCountryId {CountryId=id });
             return details;
         }
        

        [HttpGet("GetAllProducts")]
        public async Task<IEnumerable<ProductDTO>> GetProduct()
        {
            return await Mediator.Send(new GetAllProduct());
        }

        [HttpPut ("Update-Product")]
        public async Task<IActionResult> Update(int id, [FromBody] ProductDTO updateProduct)
        {
            return Ok(await Mediator.Send (new UpdateProduct {ProductId=id, ProductDto= updateProduct }));
        }

        [HttpGet("GetRegistrationById")]
        public async Task<IEnumerable<Registration>> GetResteredData(int id)
        {
            var data= await Mediator.Send(new GetRegistrationById { Id=id});
            return data;
        }
    }
}
