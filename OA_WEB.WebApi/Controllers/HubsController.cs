using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore;
using OA_WEB.DataAccess.Models;
using OA_WEB.Repository.UnitOfWork;
using OA_WEB.Service.Interface;

namespace OA_WEB.WebApi.Controllers
{
    [Route("api/hubs")]
    [ApiController]
    public class HubsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public HubsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult GetHubs()
        {
            var results = _unitOfWork.Hubs.GetAll();
            return Ok(results);

        }
        [HttpGet("{id}")]
        public IActionResult GetHubById(int id)
        {
            var result = _unitOfWork.Hubs.GetHubDetailsById(id);
            return Ok(result);

        }
        [HttpPost]
        public IActionResult AddHub([FromBody] Hub hub)
        {
            var result = _unitOfWork.Hubs.Add(hub);
            _unitOfWork.Complete();
            return Ok(result);
        }
        [HttpPut("{id}")]
        public IActionResult EditHub(int id, [FromBody] Hub hub)
        {
            if (hub.Id == 0)
            {
                hub.Id = id;
            }
            if (id != hub.Id)
            {
                return BadRequest();
            }
            _unitOfWork.Hubs.Update(hub);
            var result = _unitOfWork.Hubs.Update(hub);
            _unitOfWork.Complete();
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteHub(int id)
        {
            var result = _unitOfWork.Hubs.Remove(id);
            _unitOfWork.Complete();
            return Ok(result);
        }
    }
}
