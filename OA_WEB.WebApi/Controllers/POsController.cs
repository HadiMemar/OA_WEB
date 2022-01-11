using Microsoft.AspNetCore.Mvc;
using OA_WEB.DataAccess.DTO;
using OA_WEB.DataAccess.Models.CompundTransactions;
using OA_WEB.Service.Interface;

namespace OA_WEB.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class POsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public POsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult GetPOs()
        {
            var results = _unitOfWork.POs.GetAll();
            return Ok(results);
        }

        [HttpGet("{id}")]
        public IActionResult GetPOById(int id)
        {
            var result = _unitOfWork.POs.GetPODetails(id);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddPO([FromBody] POSODTO poTrans)
        {
            var result = _unitOfWork.POs.AddPO(poTrans);
            _unitOfWork.Complete();
            return Ok(result);
        }

        [HttpPut("{id}")]
        public IActionResult EditPO(int id, [FromBody] PO poTrans)
        {
            if (poTrans.Id == 0)
            {
                poTrans.Id = id;
            }
            if (id != poTrans.Id)
            {
                return BadRequest();
            }
            _unitOfWork.POs.Update(poTrans);
            var result = _unitOfWork.POs.Update(poTrans);
            _unitOfWork.Complete();
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePO(int id)
        {
            var result = _unitOfWork.POs.Remove(id);
            _unitOfWork.Complete();
            return Ok(result);
        }

        [HttpGet("{id}/post")]
        public IActionResult PostPO(int id)
        {
            var result = _unitOfWork.POs.Post(id);
            _unitOfWork.Complete();
            return Ok(result);
        }
    }
}