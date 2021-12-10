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
    public class CabinInfoController : ControllerBase
    {
        private readonly ICabinInfoRepository _iCabinInfoRepository;
        public CabinInfoController(ICabinInfoRepository iCabinInfoRepository)
        {
            _iCabinInfoRepository = iCabinInfoRepository;
        }
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                return Ok(await _iCabinInfoRepository.GetAll());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retriving data from database");
            }
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<CabinInfoViewModel>> GetById(int id)
        {
            try
            {
                var result = await _iCabinInfoRepository.GetById(id);
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
        public async Task<ActionResult<CabinInfoViewModel>> Insert(CabinInfoViewModel obj)
        {
            try
            {
                if (obj == null)
                {
                    return BadRequest();
                }
                var cabin = await _iCabinInfoRepository.GetById(obj.CabinId);
                if (cabin != null)
                {
                    ModelState.AddModelError("", "Cabin is already Add");
                    return BadRequest(ModelState);
                }
                var returnObj = await _iCabinInfoRepository.Insert(obj);
                return CreatedAtAction(nameof(GetAll), new { id = returnObj.CabinId }, returnObj);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retriving data from database");
            }
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult<CabinInfoViewModel>> Update(int id, CabinInfoViewModel obj)
        {
            try
            {
                if (id != obj.CabinId)
                {
                    return BadRequest("Cabin Id mismatch");
                }
                var cabin = await _iCabinInfoRepository.GetById(id);
                if (cabin == null)
                {
                    return NotFound();
                }
                return await _iCabinInfoRepository.Update(obj);
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
                var cabin = await _iCabinInfoRepository.GetById(id);
                if (cabin == null)
                {
                    return NotFound();
                }
                await _iCabinInfoRepository.Delete(id);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retriving data from database");
            }
        }
    }
}
