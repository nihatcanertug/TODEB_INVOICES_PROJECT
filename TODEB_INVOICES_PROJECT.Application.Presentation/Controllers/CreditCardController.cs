using API.Configuration.Filters.Auth;
using Microsoft.AspNetCore.Mvc;
using Bussines.Abstract;
using Microsoft.AspNetCore.Authorization;
using Models.Document;
using Models.Entities;
using MongoDB.Bson;


namespace TODEB_INVOICES_PROJECT.Application.Presentation.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CreditCardController : ControllerBase
    {
        private readonly ICreditCardService _service;

        public CreditCardController(ICreditCardService service)
        {
            _service = service;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var data = _service.GetAll();
            return Ok(data);
        }

        [HttpGet("GetById")]
        public CreditCard GetById(string id)
        {

            return _service.Get(new ObjectId(id));
        }


        [HttpPost]
        // [LogFilter]
        [Permission(Permission.CreditCardPost)]
        public IActionResult Post(CreditCard request)
        {
            _service.Add(request);
            return Ok();
        }

        [HttpPut]
        public IActionResult Put(CreditCard request)
        {
            _service.Update(request);
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(ObjectId id)
        {
            _service.Delete(id);
            return Ok();
        }

        [HttpGet("TestExceptionFilter")]
        public IActionResult TestExceptionFilter()
        {
            _service.TestExceptionFilter();
            return Ok();
        }

    }
}
