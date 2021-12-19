﻿using HospitalManagementApi.DAL.IRepository;
using HospitalManagementApi.Models;
using HospitalManagementApi.ViewModels;
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
    public class DoctorsInfoController : ControllerBase
    {
        private readonly IDoctorsInfoRepository _iDoctorsInfoRepository;
        private readonly IWebHostEnvironment _iWebHostEnvironment;

        public DoctorsInfoController(IDoctorsInfoRepository iDoctorsInfoRepository, IWebHostEnvironment iWebHostEnvironment)
        {
            _iDoctorsInfoRepository = iDoctorsInfoRepository;
            _iWebHostEnvironment = iWebHostEnvironment;

        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {

            try
            {
                return Ok(await _iDoctorsInfoRepository.GetAll());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retriving data from database");
            }
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<DoctorsInfoViewModel>> GetById(int id)
        {
            try
            {
                var result = await _iDoctorsInfoRepository.GetById(id);
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
        public async Task<object> Insert([FromForm]DoctorsInfoViewModel obj)
        {
            try
            {
                string uniqueImageName = "";

                if (obj.Photo != null)
                {
                    string uploadFolder = Path.Combine(_iWebHostEnvironment.WebRootPath, "images/doctor_images");
                    uniqueImageName = Guid.NewGuid().ToString() + "_" + obj.Photo.FileName;
                    string filePath = Path.Combine(uploadFolder, uniqueImageName);
                    FileStream fileStream = new FileStream(filePath, FileMode.Create);
                    obj.Photo.CopyTo(fileStream);
                    fileStream.Close();
                    obj.ImageName = uniqueImageName;
                }

                if (obj == null)
                {
                    return await Task.FromResult(new ResponseModel(ResponseCode.Error, "Data object Error", null));
                }
                var doctor = await _iDoctorsInfoRepository.GetById(obj.DoctorId);
                if (doctor != null)
                {
                   return await Task.FromResult(new ResponseModel(ResponseCode.Error, "Data alrady Exist", null));
                }
                var returnObj = await _iDoctorsInfoRepository.Insert(obj);
                return await Task.FromResult(new ResponseModel(ResponseCode.OK, "Docctor info Inserted", returnObj));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retriving data from database");
            }
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult<DoctorsInfoViewModel>> Update(int id, DoctorsInfoViewModel obj)
        {
            try
            {
                if (id != obj.DoctorId)
                {
                    return BadRequest("Doctor Id mismatch");
                }
                var doctor = await _iDoctorsInfoRepository.GetById(id);
                if (doctor == null)
                {
                    return NotFound();
                }
                return await _iDoctorsInfoRepository.Update(obj);
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
                var doctor = await _iDoctorsInfoRepository.GetById(id);
                if (doctor == null)
                {
                    return NotFound();
                }
                await _iDoctorsInfoRepository.Delete(id);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retriving data from database");
            }
        }
    }
}
