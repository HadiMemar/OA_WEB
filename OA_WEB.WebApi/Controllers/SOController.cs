using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OA_WEB.DataAccess.Models;
using OA_WEB.DataAccess.Models.CompundTransactions;
using OA_WEB.Repository.UnitOfWork;
using OA_WEB.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace OA_WEB.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SOController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public SOController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public IActionResult GetSOs()
        {
            var results = _unitOfWork.SOs.GetAll();
            return Ok(results);

        }
        [HttpGet("{id}")]
        public IActionResult GetSOById(int id)
        {
            var result = _unitOfWork.SOs.GetById(id);
            return Ok(result);

        }
        [HttpPost]
        public IActionResult AddSO([FromBody] SO soTrans)
        {
            List<ItemEntry> itemEntries = new List<ItemEntry>();
            itemEntries.Add(new ItemEntry { ItemId = 1, Price = 10, Qty = 10 });

            soTrans.CreateLeafTransactions(itemEntries);
            var result = _unitOfWork.SOs.Add(soTrans);
            _unitOfWork.Complete();
            return Ok(result);
        }
        [HttpPut("{id}")]
        public IActionResult EditSO(int id, [FromBody] SO soTrans)
        {
            if (soTrans.Id == 0)
            {
                soTrans.Id = id;
            }
            if (id != soTrans.Id)
            {
                return BadRequest();
            }
            _unitOfWork.SOs.Update(soTrans);
            var result = _unitOfWork.SOs.Update(soTrans);
            _unitOfWork.Complete();
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteSO(int id)
        {
            var result = _unitOfWork.SOs.Remove(id);
            _unitOfWork.Complete();
            return Ok(result);
        }
        [HttpGet("{id}/post")]
        public IActionResult PostSO(int id)
        {
            var result = _unitOfWork.SOs.Post(id);
            _unitOfWork.Complete();
            return Ok(result);
        }
    }
}
