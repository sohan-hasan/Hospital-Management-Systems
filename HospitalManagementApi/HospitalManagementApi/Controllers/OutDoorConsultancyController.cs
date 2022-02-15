using HospitalManagementApi.DAL.IRepositories;
using HospitalManagementApi.Models;
using HospitalManagementApi.Models.ViewModels;
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
    public class OutDoorConsultancyController : ControllerBase
    {
        private readonly IOutDoorConsultancyRepository _iOutDoorConsultancy;
        public OutDoorConsultancyController(IOutDoorConsultancyRepository iOutDoorConsultancy)
        {
            this._iOutDoorConsultancy = iOutDoorConsultancy;
        }
        [HttpGet("GetAll")]
        public async Task<object> GetAll()
        {
            try
            {
                var outdoorConsultancy = await _iOutDoorConsultancy.GetAll();
                return Ok(outdoorConsultancy);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<OutDoorConsultancyViewModel>> GetById(int id)
        {
            try
            {
                var result = await _iOutDoorConsultancy.GetById(id);
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
        public async Task<object> Insert([FromBody] OutDoorConsultancyViewModel obj)
        {
            try
            {
                if (obj == null)
                {
                    return await Task.FromResult(new ResponseModel(ResponseCode.Error, "Data object missing", null));
                }
                var consultancy = await _iOutDoorConsultancy.GetById(obj.OutDoorId);
                if (consultancy != null)
                {
                    return await Task.FromResult(new ResponseModel(ResponseCode.Error, "Data already exist", consultancy));
                }
                int serialNo = await _iOutDoorConsultancy.GetSerialNo(obj.DoctorId, obj.EntryDate);
                obj.SerialNo = serialNo;
                var returnObj = await _iOutDoorConsultancy.Insert(obj);
                return await Task.FromResult(new ResponseModel(ResponseCode.OK, "Data entry successful", returnObj));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retriving data from database");
            }
        }
        [HttpPut("Update")]
        public async Task<object> Update([FromBody] OutDoorConsultancyViewModel obj)
        {
            try
            {

                var consultancy = await _iOutDoorConsultancy.GetById(obj.OutDoorId);
                if (consultancy == null)
                {
                    return await Task.FromResult(new ResponseModel(ResponseCode.Error, "Data object misssing", null));
                }
                if (obj.DoctorId != consultancy.DoctorId || Convert.ToDateTime(obj.EntryDate) != Convert.ToDateTime(consultancy.EntryDate))
                {
                    int serialNo = await _iOutDoorConsultancy.GetSerialNo(obj.DoctorId, obj.EntryDate);
                    obj.SerialNo = serialNo;
                }
                var returnObj = await _iOutDoorConsultancy.Update(obj);
                return await Task.FromResult(new ResponseModel(ResponseCode.OK, "Data updated succesfully", returnObj));
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
                var consultancy = await _iOutDoorConsultancy.GetById(id);
                if (consultancy == null)
                {
                    return NotFound();
                }
                await _iOutDoorConsultancy.Delete(id);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retriving data from database");
            }
        }

    }
}
