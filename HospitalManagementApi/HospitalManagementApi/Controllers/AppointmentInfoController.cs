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
    public class AppointmentInfoController : ControllerBase
    {
        private readonly IAppointmentInfoRepository _iAppointmentInfoRepository;
        public AppointmentInfoController(IAppointmentInfoRepository IAppointmentInfoRepository)
        {
            _iAppointmentInfoRepository = IAppointmentInfoRepository;
        }
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                return Ok(await _iAppointmentInfoRepository.GetAll());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retriving data from database");
            }
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<AppointmentInfoViewModel>> GetById(int id)
        {
            try
            {
                var result = await _iAppointmentInfoRepository.GetById(id);
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
        public async Task<ActionResult<AppointmentInfoViewModel>> Insert(AppointmentInfoViewModel obj)
        {
            try
            {
                if (obj == null)
                {
                    return BadRequest();
                }
                var appointment = await _iAppointmentInfoRepository.GetById(obj.AppointmentId);
                if (appointment != null)
                {
                    ModelState.AddModelError("", "Appointment is already Add");
                    return BadRequest(ModelState);
                }
                var returnObj = await _iAppointmentInfoRepository.Insert(obj);
                return CreatedAtAction(nameof(GetAll), new { id = returnObj.AppointmentId }, returnObj);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retriving data from database");
            }
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult<AppointmentInfoViewModel>> Update(int id, AppointmentInfoViewModel obj)
        {
            try
            {
                if (id != obj.AppointmentId)
                {
                    return BadRequest("Appointment Id mismatch");
                }
                var appointment = await _iAppointmentInfoRepository.GetById(id);
                if (appointment == null)
                {
                    return NotFound();
                }
                return await _iAppointmentInfoRepository.Update(obj);
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
                var appointment = await _iAppointmentInfoRepository.GetById(id);
                if (appointment == null)
                {
                    return NotFound();
                }
                await _iAppointmentInfoRepository.Delete(id);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retriving data from database");
            }
        }
    }
}

