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
    public class ProductController : ControllerBase
    {
        private readonly IWebHostEnvironment _iWebHostEnvironment;
        private readonly IProductRepository _iProductRepository ;

        public ProductController(IProductRepository iProductRepository, IWebHostEnvironment iWebHostEnvironment)
        {
            _iProductRepository = iProductRepository;
            _iWebHostEnvironment = iWebHostEnvironment;
        }
        [HttpGet("GetAll")]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                var productList = await _iProductRepository.GetAll();
                return Ok(productList);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message); ;
            }
        }
        [HttpGet("GetById")]
        public async Task<ActionResult<ProductViewModel>> GetById(int id)
        {
            try
            {
                var result = await _iProductRepository.GetById(id);
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
        public async Task<object> Insert([FromForm] ProductViewModel obj)
        {

            try
            {
                string uniqueImageName = "";

                if (obj.Photo != null)
                {
                    string uploadFolder = Path.Combine(_iWebHostEnvironment.WebRootPath, "images/product_images");
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
                var cabin = await _iProductRepository.GetById(obj.ProductId);
                if (cabin != null)
                {
                    ModelState.AddModelError("", "Product is already Added.");
                    return await Task.FromResult(new ResponseModel(ResponseCode.Error, "Data Object Missing", null));
                }
                var returnObj = await _iProductRepository.Insert(obj);
                return await Task.FromResult(new ResponseModel(ResponseCode.OK, "Data inserted successfully", returnObj));
            }
            catch (Exception)
            {
                return await Task.FromResult(new ResponseModel(ResponseCode.Error, "Error retrieving data from database", null));
            }
        }
        [HttpPut("Update")]
        public async Task<object> Update([FromForm] ProductViewModel obj)
        {
            try
            {
                string uniqueImageName = "";
                if (obj.ProductId > 0)
                {
                    if (obj.Photo != null)
                    {
                        string uploadFolder = Path.Combine(_iWebHostEnvironment.WebRootPath, "images/product_images");
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

                var product = await _iProductRepository.GetById(obj.ProductId);
                if (product == null)
                {
                    return await Task.FromResult(new ResponseModel(ResponseCode.Error, "Error retrieving data from database", null));
                }
                var returnObj = await _iProductRepository.Update(obj);
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
                var product = await _iProductRepository.GetById(id);
                if (product == null)
                {
                    return NotFound();
                }
                await _iProductRepository.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpGet("GetProductByCategoryId")]
        public async Task<ActionResult> GetProductByCategoryId(int id)
        {
            try
            {
                var result = await _iProductRepository.GetProductByCategoryId(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpGet("GetAllSupplierByCatagoryId")]
        public async Task<ActionResult> GetAllSupplierById(int id)
        {
            try
            {
                var suppList = await _iProductRepository.GetAllSupplierById(id);
                return Ok(suppList);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message); ;
            }
        }
    }
}
