using HospitalManagementApi.DAL.IRepository;
using HospitalManagementApi.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BedInfoController : ControllerBase
    {
        private readonly IBedInfoRepository _iBedInfoRepository;
        public BedInfoController(IBedInfoRepository IBedInfoRepository)
        {
            _iBedInfoRepository = IBedInfoRepository;
        }
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                return Ok(await _iBedInfoRepository.GetAll());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retriving data from database");
            }
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<BedInfoViewModel>> GetById(int id)
        {
            try
            {
                var result = await _iBedInfoRepository.GetById(id);
                if (result == null)
                {
                    return NotFound();
                }
                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retriving data from database");
            }
        }
        [HttpPost]
        public async Task<ActionResult<BedInfoViewModel>> Insert(BedInfoViewModel obj)
        {
            try
            {
                if (obj == null)
                {
                    return BadRequest();
                }
                var bed = await _iBedInfoRepository.GetById(obj.BedId);
                if (bed != null)
                {
                    ModelState.AddModelError("", "Bed is already Add");
                    return BadRequest(ModelState);
                }
                var returnObj = await _iBedInfoRepository.Insert(obj);
                return CreatedAtAction(nameof(GetAll), new { id = returnObj.BedId }, returnObj);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retriving data from database");
            }
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult<BedInfoViewModel>> Update(int id, BedInfoViewModel obj)
        {
            try
            {
                if (id != obj.BedId)
                {
                    return BadRequest("Bed Id mismatch");
                }
                var bed = await _iBedInfoRepository.GetById(id);
                if (bed == null)
                {
                    return NotFound();
                }
                return await _iBedInfoRepository.Update(obj);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retriving data from database");
            }
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var bed = await _iBedInfoRepository.GetById(id);
                if (bed == null)
                {
                    return NotFound();
                }
                await _iBedInfoRepository.Delete(id);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retriving data from database");
            }
        }
    }
}
