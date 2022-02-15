using HospitalManagementApi.DAL.IRepositories;
using HospitalManagementApi.Models;
using HospitalManagementApi.Models.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CabinInfoController : ControllerBase
    {
        private readonly ICabinInfoRepository _iCabinInfoRepository;
        private readonly IWebHostEnvironment _iWebHostEnvironment;

        public CabinInfoController(ICabinInfoRepository iCabinInfoRepository, IWebHostEnvironment iWebHostEnvironment)
        {
            _iCabinInfoRepository = iCabinInfoRepository;
            _iWebHostEnvironment = iWebHostEnvironment;
        }
        [HttpGet("GetAll")]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                var cabinInfoList = await _iCabinInfoRepository.GetAll();
                return Ok(cabinInfoList);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message); ;
            }
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<CabinInfoViewModel>> GetById(int id)
        {
            try
            {
                var result = await _iCabinInfoRepository.GetById(id);
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
        public async Task<object> Insert([FromForm] CabinInfoViewModel obj)
        {

            try
            {
                string uniqueImageName = "";

                if (obj.Photo != null)
                {
                    string uploadFolder = Path.Combine(_iWebHostEnvironment.WebRootPath, "images/cabin_images");
                    uniqueImageName = Guid.NewGuid().ToString() + "_" + obj.Photo.FileName;
                    string filePath = Path.Combine(uploadFolder, uniqueImageName);
                    FileStream fileStream = new FileStream(filePath, FileMode.Create);
                    obj.Photo.CopyTo(fileStream);
                    fileStream.Close();
                    obj.ImageName = uniqueImageName;
                }
                if (obj == null)
                {
                    return await Task.FromResult(new ResponseModel(ResponseCode.Error, "Data Object Missing", null));
                }
                var cabin = await _iCabinInfoRepository.GetById(obj.CabinId);
                if (cabin != null)
                {
                    ModelState.AddModelError("", "Cabin is already Added.");
                    return await Task.FromResult(new ResponseModel(ResponseCode.Error, "Data Object Missing", null));
                }
                obj.BookingStatus = 1;
                var returnObj = await _iCabinInfoRepository.Insert(obj);
                return await Task.FromResult(new ResponseModel(ResponseCode.OK, "Data inserted successfully", returnObj));
            }
            catch (Exception)
            {
                return await Task.FromResult(new ResponseModel(ResponseCode.Error, "Error retrieving data from database", null));
            }
        }
        [HttpPut("Update")]
        public async Task<object> Update([FromForm] CabinInfoViewModel obj)
        {
            try
            {
                string uniqueImageName = "";
                if (obj.CabinId > 0)
                {
                    if (obj.Photo != null)
                    {
                        string uploadFolder = Path.Combine(_iWebHostEnvironment.WebRootPath, "images/cabin_images");
                        if (obj.ImageName != null)
                        {
                            DeleteExistingImage(Path.Combine(uploadFolder, obj.ImageName));
                        }
                        uniqueImageName = Guid.NewGuid().ToString() + "_" + obj.Photo.FileName;
                        string filePath = Path.Combine(uploadFolder, uniqueImageName);
                        FileStream fileStream = new FileStream(filePath, FileMode.Create);
                        obj.Photo.CopyTo(fileStream);
                        fileStream.Close();
                        obj.ImageName = uniqueImageName;
                    }

                }

                var cabin = await _iCabinInfoRepository.GetById(obj.CabinId);
                if (cabin == null)
                {
                    return await Task.FromResult(new ResponseModel(ResponseCode.Error, "Error retrieving data from database", null));
                }
                obj.BookingStatus = 1;
                var returnObj = await _iCabinInfoRepository.Update(obj);
                return await Task.FromResult(new ResponseModel(ResponseCode.OK, "Data updated successfully", null));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retriving data from database");
            }
        }

        private void DeleteExistingImage(string imagePath)
        {
            FileInfo fileObj = new FileInfo(imagePath);
            if (fileObj.Exists)
            {
                fileObj.Delete();
            }

        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var cabin = await _iCabinInfoRepository.GetById(id);
                if (cabin == null)
                {
                    return NotFound();
                }
                await _iCabinInfoRepository.Delete(id);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retriving data from database");
            }
        }
        [HttpGet("GetByTypeId")]
        public async Task<ActionResult> GetByTypeId(int id)
        {
            try
            {
                var cabinInfoList = await _iCabinInfoRepository.GetByTypeId(id);
                return Ok(cabinInfoList);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message); ;
            }
        }
    }
}
