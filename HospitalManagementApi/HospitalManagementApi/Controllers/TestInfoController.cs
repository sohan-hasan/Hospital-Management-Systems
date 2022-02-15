using HospitalManagementApi.DAL.IRepositories;
using HospitalManagementApi.DAL.Repositories;
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
    public class TestInfoController : ControllerBase
    {
        private readonly ITestInfoRepository _itestInfoRepository;
        public TestInfoController(ITestInfoRepository itestInfoRepository)
        {
            this._itestInfoRepository = itestInfoRepository;
        }
        [HttpGet("GetAll")]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                var testList = await _itestInfoRepository.GetAll();
                return Ok(testList);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpGet("GetById")]
        public async Task<ActionResult> GetById(int id)
        {
            try
            {
                var test = await _itestInfoRepository.GetById(id);
                return Ok(test);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message); ;
            }
        }
        [HttpPost("Insert")]
        public async Task<object> Insert([FromBody] TestInfoViewModel obj)
        {
            try
            {
                if (obj == null)
                {
                    return await Task.FromResult(new ResponseModel(ResponseCode.Error, "Data Missing", null));

                }
                var test = await _itestInfoRepository.GetById(obj.TestId);
                if (test != null)
                {
                    return await Task.FromResult(new ResponseModel(ResponseCode.Error, "Data Already Exixt", null));

                }
                var returnObj = await _itestInfoRepository.Insert(obj);
                return await Task.FromResult(new ResponseModel(ResponseCode.OK, "Data Insert Successfully", null));

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpPut("Update")]
        public async Task<object> Update([FromBody] TestInfoViewModel obj)
        {
            try
            {
                var test = await _itestInfoRepository.GetById(obj.TestId);
                if (test == null)
                {
                    return await Task.FromResult(new ResponseModel(ResponseCode.Error, "Data Object Missing", null));
                }
                var returnObj = await _itestInfoRepository.Update(obj);
                return await Task.FromResult(new ResponseModel(ResponseCode.OK, "Data updated successfully", returnObj));
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
                var test = await _itestInfoRepository.GetById(id);
                if (test == null)
                {
                    return NotFound();
                }
                await _itestInfoRepository.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpGet("GetAllTestByCatagoryId")]
        public async Task<ActionResult> GetAllTestByCatagoryId(int id)
        {
            try
            {
                var testList = await _itestInfoRepository.GetAllTestByCatagoryId(id);
                return Ok(testList);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message); ;
            }
        }
    }
}
