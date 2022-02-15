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
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentRepository _iDepartment;
        public DepartmentController(IDepartmentRepository iDepartment)
        {
            this._iDepartment = iDepartment;
        }
        [HttpGet("GetAll")]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                var testList = await _iDepartment.GetAll();
                return Ok(testList);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<DepartmentViewModel>> GetById(int id)
        {
            try
            {
                var result = await _iDepartment.GetById(id);
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
        public async Task<object> Insert([FromBody] DepartmentViewModel obj)
        {
            try
            {
                if (obj == null)
                {
                    return await Task.FromResult(new ResponseModel(ResponseCode.Error, "Data Missing", null));

                }
                var dep = await _iDepartment.GetById(obj.DepartmentId);
                if (dep != null)
                {
                    return await Task.FromResult(new ResponseModel(ResponseCode.Error, "Data Already Exixt", dep));

                }
                var returnObj = await _iDepartment.Insert(obj);
                return await Task.FromResult(new ResponseModel(ResponseCode.OK, "Data Insert Successfully", returnObj));

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpPut("Update")]
        public async Task<object> Update([FromBody] DepartmentViewModel obj)
        {
            try
            {
                var test = await _iDepartment.GetById(obj.DepartmentId);
                if (test == null)
                {
                    return await Task.FromResult(new ResponseModel(ResponseCode.Error, "Data Object Missing", null));
                }
                var returnObj = await _iDepartment.Update(obj);
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
                var test = await _iDepartment.GetById(id);
                if (test == null)
                {
                    return NotFound();
                }
                await _iDepartment.Delete(id);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retriving data from database");
            }
        }
    }
}
