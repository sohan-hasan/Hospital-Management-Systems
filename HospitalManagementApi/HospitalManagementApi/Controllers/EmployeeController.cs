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
    public class EmployeeController : ControllerBase
    {
        private IWebHostEnvironment _iWebHostEnvironment;
        private readonly IEmployeeRepository _iEmployeeRepository;
        private readonly IEducationRepository _iEducationRepository;
        private readonly IExperienceRepository _iExperienceRepository;

        public EmployeeController(IEmployeeRepository iEmployeeRepository, IEducationRepository iEducationRepository, IExperienceRepository iExperienceRepository, IWebHostEnvironment iWebHostEnvironment)
        {
            _iEmployeeRepository = iEmployeeRepository;
            _iEducationRepository = iEducationRepository;
            _iExperienceRepository = iExperienceRepository;
            _iWebHostEnvironment = iWebHostEnvironment;
        }

        [HttpGet("GetById/{id:int}")]
        public async Task<ActionResult<EmployeeViewModel>> GetById(int id)
        {
            try
            {
                var result = await _iEmployeeRepository.GetById(id);

                var Department = await _iEmployeeRepository.GetDepartmentById(result.DepartmentId);
                var Designation = await _iEmployeeRepository.GetDesignationById(result.DesignationId);

                result.Designation = Designation.DesignationName;
                result.Department = Department.DepartmentName;



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

        [HttpGet("GetAll")]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                var wardInfo = await _iEmployeeRepository.GetAll();
                return Ok(wardInfo);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


        //[HttpGet("{id:int}")]
        //public async Task<ActionResult<EmployeeViewModel>> GetById(int id)
        //{
        //    try
        //    {
        //        var result = await _iEmployeeRepository.GetById(id);
        //        if (result == null)
        //        {
        //            return NotFound();
        //        }
        //        return result;
        //    }
        //    catch (Exception)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError, "Error retriving data from database");
        //    }
        //}


        [HttpPost("Insert")]
        public async Task<object> Insert([FromForm] EmployeeViewModel obj)
        {
            try
            {
                string uniqueImageName = "";
                if (obj == null)
                {
                    return await Task.FromResult(new ResponseModel(ResponseCode.Error, "Data Missing", null));
                }
                //var experience = await _iExperienceRepository.GetById(obj.EmployeeId);
                //if (experience != null)
                //{
                //    return await Task.FromResult(new ResponseModel(ResponseCode.Error, "Data Already Exixt", null));
                //}

                //EducationViewModel edu = await _iEducationRepository.GetById(obj.EducationId);
                //if (edu == null)
                //{
                //    return await Task.FromResult(new ResponseModel(ResponseCode.Error, "Doctor is missing", null));
                //}
                var employee = await _iEmployeeRepository.GetById(obj.EmployeeId);
                if (employee != null)
                {
                    return await Task.FromResult(new ResponseModel(ResponseCode.Error, "Data Already Exixt", null));
                }
                if (obj.Photo != null)
                {

                    string uploadFolder = Path.Combine(_iWebHostEnvironment.WebRootPath, "images/employee_images");
                    uniqueImageName = Guid.NewGuid().ToString() + "_" + obj.Photo.FileName;
                    string filePath = Path.Combine(uploadFolder, uniqueImageName);
                    FileStream fileStream = new FileStream(filePath, FileMode.Create);
                    obj.Photo.CopyTo(fileStream);
                    fileStream.Close();
                    obj.ImageName = uniqueImageName;
                }

                var returnObj = await _iEmployeeRepository.Insert(obj);
                if (returnObj != null )
                {
                    if (obj.EducationViewModels!=null)
                    {
                        if (obj.EducationViewModels.Count > 0)
                        {
                            foreach (var item in obj.EducationViewModels)
                            {
                                item.EmployeeId = returnObj.EmployeeId;
                                await _iEducationRepository.Insert(item);
                            }
                        }
                    }
                    if (obj.ExperienceViewModels!=null)
                    {
                       
                        if (obj.ExperienceViewModels.Count > 0)
                        {
                            foreach (var item in obj.ExperienceViewModels)
                            {
                                item.EmployeeId = returnObj.EmployeeId;
                                await _iExperienceRepository.Insert(item);
                            }
                        }
                    }

                return await Task.FromResult(new ResponseModel(ResponseCode.OK, "Save Successfully", obj));
                }
                return await Task.FromResult(new ResponseModel(ResponseCode.Error, "Data Can not be Saved", obj));

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retriving data from database");
            }

        }
        [HttpPut("Update")]
        public async Task<object> Update([FromForm] EmployeeViewModel obj)
        {
            try
            {
                string uniqueImageName = "";
                if (obj.EmployeeId > 0)
                {
                    if (obj.Photo!= null)
                    {
                        string uploadFolder = Path.Combine(_iWebHostEnvironment.WebRootPath, "images/employee_images");
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


                var word = await _iEmployeeRepository.GetById(obj.EmployeeId);
                if (word == null)
                {
                    return await Task.FromResult(new ResponseModel(ResponseCode.Error, "Ward is Missing", null));
                }
                var returnObj = await _iEmployeeRepository.Update(obj);
                return await Task.FromResult(new ResponseModel(ResponseCode.OK, "Updated Successfully", returnObj));

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
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
                var word = await _iEmployeeRepository.GetById(id);
                if (word == null)
                {
                    return NotFound();
                }
                await _iEmployeeRepository.Delete(id);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retriving data from database");
            }
        }
    }
}
