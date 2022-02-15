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
    public class WardInfoController : ControllerBase
    {
        private IWebHostEnvironment _iWebHostEnvironment;
        private readonly IWardInfoRepsoitory _iWardInfoRepository;


        public WardInfoController(IWardInfoRepsoitory iWardInfoRepository, IWebHostEnvironment iWebHostEnvironment)
        {
            _iWardInfoRepository = iWardInfoRepository;
            _iWebHostEnvironment = iWebHostEnvironment;
        }



        [HttpGet("GetAll")]
        public async Task<ActionResult> GetAll()
        {
            try
            {
               var wardInfo = await _iWardInfoRepository.GetAll();
                return Ok(wardInfo);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }




        [HttpGet("{id:int}")]
        public async Task<ActionResult<WardInfoViewModel>> GetById(int id)
        {
            try
            {
                var result = await _iWardInfoRepository.GetById(id);
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
        public async Task<object> Insert([FromForm] WardInfoViewModel obj)
        {
            try
            {
                string uniqueImageName = "";

                if (obj.Photo != null)
                {

                    string uploadFolder = Path.Combine(_iWebHostEnvironment.WebRootPath, "images/ward_images");
                    uniqueImageName = Guid.NewGuid().ToString() + "_" + obj.Photo.FileName;
                    string filePath = Path.Combine(uploadFolder, uniqueImageName);
                    FileStream fileStream = new FileStream(filePath, FileMode.Create);
                    obj.Photo.CopyTo(fileStream);
                    fileStream.Close();
                    obj.ImageName = uniqueImageName;
                }


                if (obj == null)
                {
                    return await Task.FromResult(new ResponseModel(ResponseCode.Error, "Data Invalid", null));

                }
                var word = await _iWardInfoRepository.GetById(obj.WardNo);
                if (word != null)
                {
                    return await Task.FromResult(new ResponseModel(ResponseCode.Error, "Ward is mising", null));
                }
                var returnObj = await _iWardInfoRepository.Insert(obj);
                return await Task.FromResult(new ResponseModel(ResponseCode.OK, "Save Successfully", obj));
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
        [HttpPut("Update")]
        public async Task<object> Update([FromForm] WardInfoViewModel obj)
        {
            try
            {
                string uniqueImageName = "";
                if (obj.WardNo > 0)
                {
                    if (obj.Photo != null)
                    {
                        string uploadFolder = Path.Combine(_iWebHostEnvironment.WebRootPath, "images/ward_images");
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


                var word = await _iWardInfoRepository.GetById(obj.WardNo);
                if (word == null)
                {
                    return await Task.FromResult(new ResponseModel(ResponseCode.Error, "Ward is Missing", null));
                }
                var returnObj = await _iWardInfoRepository.Update(obj);
                return await Task.FromResult(new ResponseModel(ResponseCode.OK, "Updated Successfully", returnObj));

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
                var word = await _iWardInfoRepository.GetById(id);
                if (word == null)
                {
                    return NotFound();
                }
                await _iWardInfoRepository.Delete(id);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retriving data from database");
            }
        }

    }
}
