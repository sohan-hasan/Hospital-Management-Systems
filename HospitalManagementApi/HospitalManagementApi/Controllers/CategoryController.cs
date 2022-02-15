using HospitalManagementApi.DAL.IRepositories;
using HospitalManagementApi.Models;
using HospitalManagementApi.Models.ViewModels;
using Microsoft.AspNetCore.Hosting;
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
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _iCategoryRepository;
        private readonly IWebHostEnvironment _iWebHostEnvironment;

        public CategoryController(ICategoryRepository iCategoryRepository, IWebHostEnvironment iWebHostEnvironment)
        {
            _iCategoryRepository = iCategoryRepository;
            _iWebHostEnvironment = iWebHostEnvironment;
        }
        [HttpGet("GetAll")]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                var catagoryList = await _iCategoryRepository.GetAll();
                return Ok(catagoryList);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message); ;
            }
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<CategoryViewModel>> GetById(int id)
        {
            try
            {
                var result = await _iCategoryRepository.GetById(id);
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
        public async Task<object> Insert([FromBody] CategoryViewModel obj)
        {

            try
            {
                if (obj == null)
                {
                    return await Task.FromResult(new ResponseModel(ResponseCode.Error, "Data Object Missing", null));
                }
                var category = await _iCategoryRepository.GetById(obj.CategoryId);
                if (category != null)
                {
                    ModelState.AddModelError("", "Product is already Added.");
                    return await Task.FromResult(new ResponseModel(ResponseCode.Error, "Data Object Missing", null));
                }
                var returnObj = await _iCategoryRepository.Insert(obj);
                return await Task.FromResult(new ResponseModel(ResponseCode.OK, "Data inserted successfully", returnObj));
            }
            catch (Exception)
            {
                return await Task.FromResult(new ResponseModel(ResponseCode.Error, "Error retrieving data from database", null));
            }
        }
        [HttpPut("Update")]
        public async Task<object> Update([FromBody] CategoryViewModel obj)
        {
            try
            {

                var products = await _iCategoryRepository.GetById(obj.CategoryId);
                if (products == null)
                {
                    return await Task.FromResult(new ResponseModel(ResponseCode.Error, "Error retrieving data from database", null));
                }
                var returnObj = await _iCategoryRepository.Update(obj);
                return await Task.FromResult(new ResponseModel(ResponseCode.OK, "Data updated successfully", null));
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
                var product = await _iCategoryRepository.GetById(id);
                if (product == null)
                {
                    return NotFound();
                }
                await _iCategoryRepository.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
