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
    public class DesignationController : ControllerBase
    {
        private readonly IDesignationRepository _iDesignation;
        public DesignationController(IDesignationRepository iDesignation)
        {
            this._iDesignation = iDesignation;
        }
        [HttpGet("GetAll")]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                var testList = await _iDesignation.GetAll();
                return Ok(testList);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<DesignationViewModel>> GetById(int id)
        {
            try
            {
                var result = await _iDesignation.GetById(id);
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
        public async Task<object> Insert([FromBody] DesignationViewModel obj)
        {
            try
            {
                if (obj == null)
                {
                    return await Task.FromResult(new ResponseModel(ResponseCode.Error, "Data Missing", null));

                }
                var deg = await _iDesignation.GetById(obj.DesignationId);
                if (deg != null)
                {
                    return await Task.FromResult(new ResponseModel(ResponseCode.Error, "Data Already Exixt", deg));

                }
                var returnObj = await _iDesignation.Insert(obj);
                return await Task.FromResult(new ResponseModel(ResponseCode.OK, "Data Insert Successfully", returnObj));

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpPut("Update")]
        public async Task<object> Update([FromBody] DesignationViewModel obj)
        {
            try
            {
                var deg = await _iDesignation.GetById(obj.DesignationId);
                if (deg == null)
                {
                    return await Task.FromResult(new ResponseModel(ResponseCode.Error, "Data Object Missing", null));
                }
                var returnObj = await _iDesignation.Update(obj);
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
                var test = await _iDesignation.GetById(id);
                if (test == null)
                {
                    return NotFound();
                }
                await _iDesignation.Delete(id);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retriving data from database");
            }
        }
    }
}
