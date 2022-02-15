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
    public class EducationController : ControllerBase
    {
        private readonly IEducationRepository _iEducationRepository;
        public EducationController(IEducationRepository iEducationRepository)
        {
            _iEducationRepository = iEducationRepository;
        }

        [HttpGet("GetEduByEmpId/{id:int}")]
        public async Task<ActionResult<IEnumerable<EducationViewModel>>> GetEduByEmpId(int id)
        {
            try
            {
                var result = await _iEducationRepository.GetEduByEmpId(id);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }

            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retriving data from database");
            }
        }

        [HttpPost("Insert")]
        public async Task<object> Insert([FromBody] EducationViewModel obj)
        {
            try
            {
                if (obj == null)
                {
                    return await Task.FromResult(new ResponseModel(ResponseCode.Error, "Data object missing", null));
                }
                var consultancy = await _iEducationRepository.GetById(obj.EducationID);
                if (consultancy != null)
                {
                    return await Task.FromResult(new ResponseModel(ResponseCode.Error, "Data already exist", consultancy));
                }

                var returnObj = await _iEducationRepository.Insert(obj);
                return await Task.FromResult(new ResponseModel(ResponseCode.OK, "Data entry successful", returnObj));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message + "\nError retriving data from database");
            }
        }


        [HttpPut("Update")]
        public async Task<object> Update(EducationViewModel obj)
        {
            try
            {

                var consultancy = await _iEducationRepository.GetById(obj.EducationID);
                if (consultancy == null)
                {
                    return await Task.FromResult(new ResponseModel(ResponseCode.Error, "Data object misssing", null));
                }

                var returnObj = await _iEducationRepository.Update(obj);
                return await Task.FromResult(new ResponseModel(ResponseCode.OK, "Data updated succesfully", returnObj));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<EducationViewModel>> GetById(int id)
        {
            try
            {
                var result = await _iEducationRepository.GetById(id);
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


        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var consultancy = await _iEducationRepository.GetById(id);
                if (consultancy == null)
                {
                    return NotFound();
                }
                await _iEducationRepository.Delete(id);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retriving data from database");
            }
        }
    }
}

