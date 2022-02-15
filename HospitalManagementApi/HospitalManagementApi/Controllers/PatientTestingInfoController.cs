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
    public class PatientTestingInfoController : ControllerBase
    {
        private readonly IPatientTestingInfoRepository _iPatientTestingInfoRepository;
        public PatientTestingInfoController(IPatientTestingInfoRepository iPatientTestingInfoRepository)
        {
            _iPatientTestingInfoRepository = iPatientTestingInfoRepository;
        }
        [HttpGet("GetAll")]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                var patientTest = await _iPatientTestingInfoRepository.GetAll();
                return Ok(patientTest);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<PatientTestingInfoViewModel>> GetById(int id)
        {
            try
            {
                var result = await _iPatientTestingInfoRepository.GetById(id);
                if (result == null)
                {
                    return NotFound();
                }
                return result;
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpPost("Insert")]
        public async Task<object> Insert([FromBody]ICollection<PatientTestingInfoViewModel> patientTestList)
        {
            try
            {
                if (patientTestList.Count==0)
                {
                        return await Task.FromResult(new ResponseModel(ResponseCode.Error, "Data Object Missing", null));
                }
                int count = 0;
                foreach (var obj in patientTestList)
                {
                    var pTest = await _iPatientTestingInfoRepository.GetById(obj.TestNo);
                    if (pTest != null)
                    {
                        ModelState.AddModelError("", "Test is already completed.");
                        return await Task.FromResult(new ResponseModel(ResponseCode.Error, "Data Object Missing", null));
                    }
                    await _iPatientTestingInfoRepository.Insert(obj);
                    count++;
                }
                return await Task.FromResult(new ResponseModel(ResponseCode.OK, count+" data inserted successfully", null));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(new ResponseModel(ResponseCode.Error, ex.Message, null));
            }
        }
        [HttpPut("Update")]
        public async Task<object> Update([FromForm] PatientTestingInfoViewModel obj)
        {
            try
            {
                var pTest = await _iPatientTestingInfoRepository.GetById(obj.TestNo);
                if (pTest == null)
                {
                    return await Task.FromResult(new ResponseModel(ResponseCode.Error, "Error retrieving data from database", null));
                }
                var returnObj = await _iPatientTestingInfoRepository.Update(obj);
                return await Task.FromResult(new ResponseModel(ResponseCode.OK, "Data updated successfully", null));

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var pTest = await _iPatientTestingInfoRepository.GetById(id);
                if (pTest == null)
                {
                    return NotFound();
                }
                await _iPatientTestingInfoRepository.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
