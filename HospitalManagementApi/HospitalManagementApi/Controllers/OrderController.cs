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
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _iOrderRepository;

        public OrderController(IOrderRepository iOrderRepository, IWebHostEnvironment iWebHostEnvironment)
        {
            this._iOrderRepository = iOrderRepository;
        }
        [HttpGet("GetAll")]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                var orderList = await _iOrderRepository.GetAll();
                return Ok(orderList);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message); ;
            }
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<OrderViewModel>> GetById(int id)
        {
            try
            {
                var result = await _iOrderRepository.GetById(id);
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
        public async Task<object> Insert([FromForm] OrderViewModel obj)
        {

            try
            {
                if (obj == null)
                {
                    return await Task.FromResult(new ResponseModel(ResponseCode.Error, "Data Object Missing", null));
                }
                var order = await _iOrderRepository.GetById(obj.OrderId);
                if (order != null)
                {
                    ModelState.AddModelError("", "Data is already Added.");
                    return await Task.FromResult(new ResponseModel(ResponseCode.Error, "Data Object Missing", null));
                }
                var returnObj = await _iOrderRepository.Insert(obj);
                return await Task.FromResult(new ResponseModel(ResponseCode.OK, "Data inserted successfully", returnObj));
            }
            catch (Exception)
            {
                return await Task.FromResult(new ResponseModel(ResponseCode.Error, "Error retrieving data from database", null));
            }
        }
        [HttpPut("Update")]
        public async Task<object> Update([FromForm] OrderViewModel obj)
        {
            try
            {

                var orders = await _iOrderRepository.GetById(obj.OrderId);
                if (orders == null)
                {
                    return await Task.FromResult(new ResponseModel(ResponseCode.Error, "Error retrieving data from database", null));
                }
                var returnObj = await _iOrderRepository.Update(obj);
                return await Task.FromResult(new ResponseModel(ResponseCode.OK, "Data updated successfully", null));
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
                var product = await _iOrderRepository.GetById(id);
                if (product == null)
                {
                    return NotFound();
                }
                await _iOrderRepository.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
