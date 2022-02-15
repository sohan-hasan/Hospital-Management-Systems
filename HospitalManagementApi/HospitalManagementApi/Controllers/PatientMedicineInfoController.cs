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
    public class PatientMedicineInfoController : Controller
    {
        private readonly IPatientMedicineInfoRepository _iPatientMedicineInfoRepository;
        public PatientMedicineInfoController(IPatientMedicineInfoRepository iPatientMedicineInfoRepository)
        {
            _iPatientMedicineInfoRepository = iPatientMedicineInfoRepository;
        }
        [HttpGet("GetAll")]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                var patientMedicine = await _iPatientMedicineInfoRepository.GetAll();
                return Ok(patientMedicine);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<PatientMedicineInfoViewModel>> GetById(int id)
        {
            try
            {
                var result = await _iPatientMedicineInfoRepository.GetById(id);
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
        public async Task<object> Insert([FromBody] ICollection<PatientMedicineInfoViewModel> collection)
        {
            try
            {
                if (collection == null)
                {
                    return await Task.FromResult(new ResponseModel(ResponseCode.Error, "Data object Missing", null));
                }
                foreach (var obj in collection)
                {
                    var patientMedicine = await _iPatientMedicineInfoRepository.GetById(obj.PatientMedicineInfoId);
                    if (patientMedicine != null)
                    {
                        ModelState.AddModelError("", "Medicine is already prescribed.");
                        return await Task.FromResult(new ResponseModel(ResponseCode.Error, "Data object Missing", null));
                    }
                    var returnObj = await _iPatientMedicineInfoRepository.Insert(obj);

                }
                return await Task.FromResult(new ResponseModel(ResponseCode.OK, "Data inserted successfully", null));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


        [HttpPut("Update")]
        public async Task<object> Update([FromForm] PatientMedicineInfoViewModel obj)
        {
            try
            {
                var patientMedicine = await _iPatientMedicineInfoRepository.GetById(obj.PatientMedicineInfoId);
                if (patientMedicine == null)
                {
                    return await Task.FromResult(new ResponseModel(ResponseCode.Error, "Error retrieving data from database", null));
                }
                var returnObj = await _iPatientMedicineInfoRepository.Update(obj);
                return await Task.FromResult(new ResponseModel(ResponseCode.OK, "Patient Medicine Info Updated Successfully", null));
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
                var patientMedicine = await _iPatientMedicineInfoRepository.GetById(id);
                if (patientMedicine == null)
                {
                    return NotFound();
                }
                await _iPatientMedicineInfoRepository.Delete(id);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retriving data from database");
            }
        }
    }


}
