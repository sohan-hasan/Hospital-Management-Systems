using HospitalManagementApi.DAL.IRepositories;
using HospitalManagementApi.Models;
using HospitalManagementApi.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
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
        [HttpGet("GetAll")]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                var appointment = await _iAppointmentInfoRepository.GetAll();
                return Ok(appointment);
              
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
        [HttpPost("Insert")]
        public async Task<object> Insert([FromBody] AppointmentInfoViewModel obj)
           {
            try
            {
                

                if (obj == null)
                {
                    return await Task.FromResult(new ResponseModel(ResponseCode.Error, "Data object Error", null));
                }
                var appointment = await _iAppointmentInfoRepository.GetById(obj.AppointmentId);
                if (appointment != null)
                {
                    return await Task.FromResult(new ResponseModel(ResponseCode.Error, "Data alrady Exist", null));
                }
                int serialNo = await _iAppointmentInfoRepository.GetSerialNo(obj.DoctorId, obj.AppointmentDate);
                obj.SerialNo = serialNo;
                var returnObj = await _iAppointmentInfoRepository.Insert(obj);
                return await Task.FromResult(new ResponseModel(ResponseCode.OK, "Appointment info Inserted", returnObj));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpPut("Update")]
        public async Task<object> Update([FromBody]AppointmentInfoViewModel obj)
        {
            try
            {
                
                var appointment = await _iAppointmentInfoRepository.GetById(obj.AppointmentId);
                if (appointment == null)
                {
                    return await Task.FromResult(new ResponseModel(ResponseCode.Error, "Data object Error", null));
                }
                if (obj.DoctorId!=appointment.DoctorId || Convert.ToDateTime(obj.AppointmentDate) != Convert.ToDateTime(appointment.AppointmentDate))
                {
                    int serialNo = await _iAppointmentInfoRepository.GetSerialNo(obj.DoctorId, obj.AppointmentDate);
                    obj.SerialNo = serialNo;
                }
               
                var returnObj = await _iAppointmentInfoRepository.Update(obj);
                return await Task.FromResult(new ResponseModel(ResponseCode.OK, "Appointment info Updated Successfully", returnObj));
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





