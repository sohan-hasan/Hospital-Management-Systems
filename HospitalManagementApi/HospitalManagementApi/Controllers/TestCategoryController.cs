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
    public class TestCategoryController : ControllerBase
    {
        private readonly ITestCategoryRepository _iTestCategoryRepository;

        public TestCategoryController(ITestCategoryRepository iTestCategoryRepository)
        {
            _iTestCategoryRepository = iTestCategoryRepository;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult> GetAll()
        {

            try
            {
                var testCategoryList = await _iTestCategoryRepository.GetAll();
                return Ok(testCategoryList);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<TestCategoryViewModel>> GetById(int id)
        {
            try
            {
                var result = await _iTestCategoryRepository.GetById(id);
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
        public async Task<object> Insert([FromBody] TestCategoryViewModel obj)
        {
            try
            {
                if (obj == null)
                {
                    return await Task.FromResult(new ResponseModel(ResponseCode.Error, "Data object Error", null));
                }
                var category = await _iTestCategoryRepository.GetById(obj.CategoryId);
                if (category != null)
                {
                    return await Task.FromResult(new ResponseModel(ResponseCode.Error, "Data alrady Exist", null));
                }
                var returnObj = await _iTestCategoryRepository.Insert(obj);
                return await Task.FromResult(new ResponseModel(ResponseCode.OK, "Docctor info Inserted", returnObj));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpPut("Update")]
        public async Task<object> Update([FromBody] TestCategoryViewModel obj)
        {
            try
            {
                var doctor = await _iTestCategoryRepository.GetById(obj.CategoryId);
                if (doctor == null)
                {
                    return await Task.FromResult(new ResponseModel(ResponseCode.Error, "Data object Error", null));
                }
                var returnObj = await _iTestCategoryRepository.Update(obj);
                return await Task.FromResult(new ResponseModel(ResponseCode.OK, "Docctor info Updated Successfully", returnObj));

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
                var testCategory = await _iTestCategoryRepository.GetById(id);
                if (testCategory == null)
                {
                    return NotFound();
                }
                await _iTestCategoryRepository.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
