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
    public class ExprienceController : ControllerBase
    {
        private readonly IExperienceRepository _iExperienceRepository;
        public ExprienceController(IExperienceRepository iExperienceRepository)
        {
            _iExperienceRepository = iExperienceRepository;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                var cabinInfoList = await _iExperienceRepository.GetAll();
                return Ok(cabinInfoList);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message); ;
            }
        }
        [HttpGet("GetById")]
        public async Task<ActionResult<ExperienceViewModel>> GetById(int id)
        {
            try
            {
                var result = await _iExperienceRepository.GetById(id);
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

        [HttpGet("GetExpByEmpId/{id:int}")]
        public async Task<ActionResult<IEnumerable<ExperienceViewModel>>> GetExpByEmpId(int id)
        {
            try
            {
                var result = await _iExperienceRepository.GetExpByEmpId(id);
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
        public async Task<object> Insert([FromBody] ExperienceViewModel obj)
        {
            try
            {
                if (obj == null)
                {
                    return await Task.FromResult(new ResponseModel(ResponseCode.Error, "Data object missing", null));
                }
                var consultancy = await _iExperienceRepository.GetById(obj.ExperienceID);
                if (consultancy != null)
                {
                    return await Task.FromResult(new ResponseModel(ResponseCode.Error, "Data already exist", consultancy));
                }

                var returnObj = await _iExperienceRepository.Insert(obj);
                return await Task.FromResult(new ResponseModel(ResponseCode.OK, "Data entry successful", returnObj));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message + "\nError retriving data from database");
            }
        }
        [HttpPut("Update")]
        public async Task<object> Update([FromBody] ExperienceViewModel obj)
        {
            try
            {

                var consultancy = await _iExperienceRepository.GetById(obj.ExperienceID);
                if (consultancy == null)
                {
                    return await Task.FromResult(new ResponseModel(ResponseCode.Error, "Data object misssing", null));
                }

                var returnObj = await _iExperienceRepository.Update(obj);
                return await Task.FromResult(new ResponseModel(ResponseCode.OK, "Data updated succesfully", returnObj));
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
                var consultancy = await _iExperienceRepository.GetById(id);
                if (consultancy == null)
                {
                    return NotFound();
                }
                await _iExperienceRepository.Delete(id);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retriving data from database");
            }
        }
    }
}
