using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Northwind.Models.Models;
using Northwind.UnitOfWork;

namespace Northwind.WepApi.Controlllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public CustomerController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Route("id:int")]
        public IActionResult GetById(int id)
        {
            return Ok(_unitOfWork.Customer.GetById(id));
        }


        [HttpGet]
        [Route("GetPaginatedCustomer/{page:int}/rows:int")]
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
        [Route("id:int")]
        public IActionResult Delete([FromBody] Customer model)
        {
            if (model.Id > 0)
                return Ok(_unitOfWork.Customer.Delete(model));

            return BadRequest();
        }
    }
}
