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
    public class PatientInfoController : ControllerBase
    {
        private readonly IWebHostEnvironment _iwebHostEnvironment;
        private readonly IPatientInfoRepository _ipatientRepository;
        public PatientInfoController(IPatientInfoRepository ipatientRepository, IWebHostEnvironment iwebHostEnvironment)
        {
            this._ipatientRepository = ipatientRepository;
            this._iwebHostEnvironment = iwebHostEnvironment;
        }
        [HttpGet("GetAll")]
        public async Task<ActionResult> GetAll()
        {

            try
            {
               var patientList = await _ipatientRepository.GetAll();
               return Ok(patientList);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<PatientInfoViewModel>> GetById(int id)
        {
            try
            {
                var result = await _ipatientRepository.GetById(id);
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
        public async Task<object> Insert([FromForm] PatientInfoViewModel obj)
        {
            try
            {
                string uniqueImageName = "";

                if (obj.Photo != null)
                {
                    string uploadFolder = Path.Combine(_iwebHostEnvironment.WebRootPath, "images/patient_images");
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
                var patient = await _ipatientRepository.GetById(obj.PatientId);
                if (patient != null)
                {
                    return await Task.FromResult(new ResponseModel(ResponseCode.Error, "Data Already Exist", null));
                }
                obj.IsAdmit = 0;
                var returnObj = await _ipatientRepository.Insert(obj);
                return await Task.FromResult(new ResponseModel(ResponseCode.OK, "Data Entry Successfull", returnObj));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retriving data from database");
            }
        }
        
        [HttpPut("Update")]
        public async Task<object> Update([FromForm] PatientInfoViewModel obj)
        {
            try
            {
                string uniqueImageName = "";
                if (obj.PatientId > 0)
                {
                    if (obj.Photo != null)
                    {
                        string uploadFolder = Path.Combine(_iwebHostEnvironment.WebRootPath, "images/patient_images");
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
                var patient = await _ipatientRepository.GetById(obj.PatientId);
                if (patient == null)
                {
                    return await Task.FromResult(new ResponseModel(ResponseCode.Error, "Data object Missing", null));
                }
                obj.IsAdmit = patient.IsAdmit;
                var returnObj = await _ipatientRepository.Update(obj);
                return await Task.FromResult(new ResponseModel(ResponseCode.OK, "Data Update Successfully", null));
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
                var test = await _ipatientRepository.GetById(id);
                if (test == null)
                {
                    return NotFound();
                }
                await _ipatientRepository.Delete(id);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retriving data from database");
            }

        }
    }
}
