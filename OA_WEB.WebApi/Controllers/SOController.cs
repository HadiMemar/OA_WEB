using Microsoft.AspNetCore.Mvc;
using OA_WEB.DataAccess.DTO;
using OA_WEB.DataAccess.Models.CompundTransactions;
using OA_WEB.Service.Interface;

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
        public IActionResult AddSO([FromBody] POSODTO soTrans)
        {
            var result = _unitOfWork.SOs.AddSO(soTrans);
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