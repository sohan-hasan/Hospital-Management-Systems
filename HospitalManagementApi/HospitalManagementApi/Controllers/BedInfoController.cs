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
    public class BedInfoController : ControllerBase
    {
        private readonly IBedInfoRepsoitory _iBedInfoRepository;
        private readonly IWebHostEnvironment _iWebHostEnvironment;
        public BedInfoController(IBedInfoRepsoitory iBedInfoRepository, IWebHostEnvironment iWebHostEnvironment)
        {
            _iBedInfoRepository = iBedInfoRepository;
            _iWebHostEnvironment = iWebHostEnvironment;
        }
        [HttpGet("GetAll")]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                var bedInfoList = await _iBedInfoRepository.GetAll();
                return Ok(bedInfoList);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message); ;
            }
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<BedInfoViewModel>> GetById(int id)
        {
            try
            {
                var result = await _iBedInfoRepository.GetById(id);
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
        public async Task<object> Insert([FromBody] BedInfoViewModel obj)
        {
            try
            {
                if (obj == null)
                {
                    return await Task.FromResult(new ResponseModel(ResponseCode.Error, "Data object missing", null));
                }
                var bed = await _iBedInfoRepository.GetById(obj.BedId);
                if (bed != null)
                {
                    return await Task.FromResult(new ResponseModel(ResponseCode.Error, "Data already exist", bed));
                }
                obj.BookingStatus = 1;
                var returnObj = await _iBedInfoRepository.Insert(obj);
                return await Task.FromResult(new ResponseModel(ResponseCode.OK, "Data entry successful", returnObj));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retriving data from database");
            }
        }
        [HttpPut("Update")]
        public async Task<object> Update([FromBody] BedInfoViewModel obj)
        {
            try
            {

                var bed = await _iBedInfoRepository.GetById(obj.BedId);
                if (bed == null)
                {
                    return await Task.FromResult(new ResponseModel(ResponseCode.Error, "Data object misssing", null));
                }
                obj.BookingStatus = 1;
                var returnObj = await _iBedInfoRepository.Update(obj);
                return await Task.FromResult(new ResponseModel(ResponseCode.OK, "Data updated succesfully", returnObj));
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
                var consultancy = await _iBedInfoRepository.GetById(id);
                if (consultancy == null)
                {
                    return NotFound();
                }
                await _iBedInfoRepository.Delete(id);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retriving data from database");
            }
        }
        [HttpGet("GetByWardNo")]
        public async Task<ActionResult> GetByTypeId(int id)
        {
            try
            {
                var bedlist = await _iBedInfoRepository.GetByWardNo(id);
                return Ok(bedlist);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message); ;
            }
        }
    }
}
