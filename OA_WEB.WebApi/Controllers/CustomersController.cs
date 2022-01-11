using Microsoft.AspNetCore.Mvc;
using OA_WEB.DataAccess.Models;
using OA_WEB.Service.Interface;

namespace OA_WEB.WebApi.Controllers
{
    [Route("api/customers")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public CustomersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult GetCustomers()
        {
            var results = _unitOfWork.Customers.GetAll();
            return Ok(results);
        }

        [HttpGet("{id}")]
        public IActionResult GetCustomerById(int id)
        {
            var results = _unitOfWork.Customers.GetById(id);
            return Ok(results);
        }

        [HttpPost]
        public IActionResult AddCustomers([FromBody] Customer customer)
        {
            var result = _unitOfWork.Customers.Add(customer);
            _unitOfWork.Complete();
            return Ok(result);
        }

        [HttpPut("{id}")]
        public IActionResult EditCustomer(int id, [FromBody] Customer customer)
        {
            if (customer.Id == 0)
            {
                customer.Id = id;
            }
            if (id != customer.Id)
            {
                return BadRequest();
            }
            _unitOfWork.Customers.Update(customer);
            var result = _unitOfWork.Customers.Update(customer);
            _unitOfWork.Complete();
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(int id)
        {
            var result = _unitOfWork.Customers.Remove(id);
            _unitOfWork.Complete();
            return Ok(result);
        }
    }
}