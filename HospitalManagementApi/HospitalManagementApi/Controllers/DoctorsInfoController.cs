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
    public class DoctorsInfoController : ControllerBase
    {
        private readonly IDoctorsInfoRepository _iDoctorsInfoRepository;
        public DoctorsInfoController(IDoctorsInfoRepository iDoctorsInfoRepository)
        {
            _iDoctorsInfoRepository = iDoctorsInfoRepository;
        }
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                return Ok(await _iDoctorsInfoRepository.GetAll());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retriving data from database");
            }
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<DoctorsInfoViewModel>> GetById(int id)
        {
            try
            {
                var result = await _iDoctorsInfoRepository.GetById(id);
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
        public async Task<ActionResult<DoctorsInfoViewModel>> Insert(DoctorsInfoViewModel obj)
        {
            try
            {
                if (obj == null)
                {
                    return BadRequest();
                }
                var doctor = await _iDoctorsInfoRepository.GetById(obj.DoctorId);
                if (doctor != null)
                {
                    ModelState.AddModelError("", "Doctor is already Add");
                    return BadRequest(ModelState);
                }
                var returnObj = await _iDoctorsInfoRepository.Insert(obj);
                return CreatedAtAction(nameof(GetAll), new { id = returnObj.DoctorId }, returnObj);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retriving data from database");
            }
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult<DoctorsInfoViewModel>> Update(int id, DoctorsInfoViewModel obj)
        {
            try
            {
                if (id != obj.DoctorId)
                {
                    return BadRequest("Doctor Id mismatch");
                }
                var doctor = await _iDoctorsInfoRepository.GetById(id);
                if (doctor == null)
                {
                    return NotFound();
                }
                return await _iDoctorsInfoRepository.Update(obj);
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
                var doctor = await _iDoctorsInfoRepository.GetById(id);
                if (doctor == null)
                {
                    return NotFound();
                }
                await _iDoctorsInfoRepository.Delete(id);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retriving data from database");
            }
        }
    }
}
