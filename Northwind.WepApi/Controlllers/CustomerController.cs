using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Northwind.Models.Models;
using Northwind.UnitOfWork;

namespace Northwind.WepApi.Controlllers
{
    [ApiController]
    [Route("api/customer")]
    public class CustomerController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<CustomerController> _logger;
        public CustomerController(IUnitOfWork unitOfWork, ILogger<CustomerController> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetById(int id)
        {
            return Ok(_unitOfWork.Customer.GetById(id));
        }


        [HttpGet]
        [Route("GetPaginatedCustomer/{page:int}/{rows:int}")]
        public IActionResult GetPaginated(int page, int rows)
        {
            return Ok(_unitOfWork.Customer.CustomerPagedList(page, rows));
        }

        [HttpPost]
        public IActionResult Post([FromBody] Customer model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(_unitOfWork.Customer.Insert(model));
        }

        [HttpPut]
        public IActionResult Put([FromBody] Customer model)
        {
            if (!ModelState.IsValid && _unitOfWork.Customer.Update(model))
            {
                return Ok(new { Message = "The Customer is update"});
            }
            return BadRequest();
        }

        [HttpDelete]
        public IActionResult Delete([FromBody] Customer model)
        {
            if (model.Id > 0)
                return Ok(_unitOfWork.Customer.Delete(model));

            return BadRequest();
        }
    }
}
