
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
    public class CabinTypeInfoController : ControllerBase
    {
        private readonly ICabinTypeRepository _iCabinTypeRepository;
        private readonly IWebHostEnvironment _iWebHostEnvironment;
        public CabinTypeInfoController(ICabinTypeRepository iCabinTypeRepository, IWebHostEnvironment iWebHostEnvironment)
        {
            _iCabinTypeRepository = iCabinTypeRepository;
            _iWebHostEnvironment = iWebHostEnvironment;
        }
        [HttpGet("GetAll")]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                var cabinInfoList = await _iCabinTypeRepository.GetAll();
                return Ok(cabinInfoList);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message); ;
            }
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<CabinTypeInfoViewModel>> GetById(int id)
        {
            try
            {
                var result = await _iCabinTypeRepository.GetById(id);
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
        public async Task<object> Insert([FromBody] CabinTypeInfoViewModel obj)
        {
            try
            {
                if (obj == null)
                {
                    return await Task.FromResult(new ResponseModel(ResponseCode.Error, "Data object missing", null));
                }
                var consultancy = await _iCabinTypeRepository.GetById(obj.CabinTypeId);
                if (consultancy != null)
                {
                    return await Task.FromResult(new ResponseModel(ResponseCode.Error, "Data already exist", consultancy));
                }
               
                var returnObj = await _iCabinTypeRepository.Insert(obj);
                return await Task.FromResult(new ResponseModel(ResponseCode.OK, "Data entry successful", returnObj));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retriving data from database");
            }
        }
        [HttpPut("Update")]
        public async Task<object> Update([FromBody] CabinTypeInfoViewModel obj)
        {
            try
            {

                var consultancy = await _iCabinTypeRepository.GetById(obj.CabinTypeId);
                if (consultancy == null)
                {
                    return await Task.FromResult(new ResponseModel(ResponseCode.Error, "Data object misssing", null));
                }
               
                var returnObj = await _iCabinTypeRepository.Update(obj);
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
                var consultancy = await _iCabinTypeRepository.GetById(id);
                if (consultancy == null)
                {
                    return NotFound();
                }
                await _iCabinTypeRepository.Delete(id);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retriving data from database");
            }
        }
    }
}
