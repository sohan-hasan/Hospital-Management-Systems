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
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierRepository _iSupplierRepository;
        private readonly IWebHostEnvironment _iWebHostEnvironment;

        public SupplierController(ISupplierRepository iSupplierRepository, IWebHostEnvironment iWebHostEnvironment)
        {
            _iSupplierRepository = iSupplierRepository;
            _iWebHostEnvironment = iWebHostEnvironment;
        }
        [HttpGet("GetAll")]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                var cabinInfoList = await _iSupplierRepository.GetAll();
                return Ok(cabinInfoList);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message); ;
            }
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<SupplierViewModel>> GetById(int id)
        {
            try
            {
                var result = await _iSupplierRepository.GetById(id);
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
        public async Task<object> Insert([FromForm] SupplierViewModel obj)
        {

            try
            {
                string uniqueImageName = "";

                if (obj.Photo != null)
                {
                    string uploadFolder = Path.Combine(_iWebHostEnvironment.WebRootPath, "images/supplier_images");
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
                var cabin = await _iSupplierRepository.GetById(obj.SupplierId);
                if (cabin != null)
                {
                    ModelState.AddModelError("", "Supplier is already Added.");
                    return await Task.FromResult(new ResponseModel(ResponseCode.Error, "Data Object Missing", null));
                }
                var returnObj = await _iSupplierRepository.Insert(obj);
                return await Task.FromResult(new ResponseModel(ResponseCode.OK, "Data inserted successfully", returnObj));
            }
            catch (Exception)
            {
                return await Task.FromResult(new ResponseModel(ResponseCode.Error, "Error retrieving data from database", null));
            }
        }
        [HttpPut("Update")]
        public async Task<object> Update([FromForm] SupplierViewModel obj)
        {
            try
            {
                string uniqueImageName = "";
                if (obj.SupplierId > 0)
                {
                    if (obj.Photo != null)
                    {
                        string uploadFolder = Path.Combine(_iWebHostEnvironment.WebRootPath, "images/supplier_images");
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

                var cabin = await _iSupplierRepository.GetById(obj.SupplierId);
                if (cabin == null)
                {
                    return await Task.FromResult(new ResponseModel(ResponseCode.Error, "Error retrieving data from database", null));
                }
                var returnObj = await _iSupplierRepository.Update(obj);
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
                var supplier = await _iSupplierRepository.GetById(id);
                if (supplier == null)
                {
                    return NotFound();
                }
                await _iSupplierRepository.Delete(id);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retriving data from database");
            }
        }
    }
}
