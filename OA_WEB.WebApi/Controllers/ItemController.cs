using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OA_WEB.DataAccess.Models;
using OA_WEB.Repository.UnitOfWork;
using OA_WEB.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace OA_WEB.WebApi.Controllers
{
    [Route("api/items")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public ItemController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public IActionResult GetItems()
        {
            var results = _unitOfWork.Items.GetAll();
            return Ok(results);

        }
        [HttpGet("{id}")]
        public IActionResult GetItemById(int id)
        {
            var result = _unitOfWork.Items.GetById(id);
            return Ok(result);

        }
        [HttpPost]
        public IActionResult AddItem([FromBody] Item item)
        {
            var result = _unitOfWork.Items.Add(item);
            _unitOfWork.Complete();
            return Ok(result);
        }
        [HttpPut("{id}")]
        public IActionResult EditItem(int id, [FromBody] Item item)
        {
            if (item.Id == 0)
            {
                item.Id = id;
            }
            if (id != item.Id)
            {
                return BadRequest();
            }
            _unitOfWork.Items.Update(item);
            var result = _unitOfWork.Items.Update(item);
            _unitOfWork.Complete();
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteItem(int id)
        {
            var result = _unitOfWork.Items.Remove(id);
            _unitOfWork.Complete();
            return Ok(result);
        }
    }
}
