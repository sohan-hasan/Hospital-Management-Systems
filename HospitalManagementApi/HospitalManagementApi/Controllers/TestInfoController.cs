using HospitalManagementApi.DAL.IRepository;
using HospitalManagementApi.ViewModels;
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
    public class TestInfoController : ControllerBase
    {
        private readonly ITestInfoRepository _itestInfoRepository;
        public TestInfoController(ITestInfoRepository itestInfoRepository)
        {
            this._itestInfoRepository = itestInfoRepository;
        }
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                return Ok(await _itestInfoRepository.GetAll());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retriving data from database");
            }
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<TestInfoViewModel>> GetById(int id)
        {
            try
            {
                var result = await _itestInfoRepository.GetById(id);
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
        [HttpPost]
        public async Task<ActionResult<TestInfoViewModel>> Insert(TestInfoViewModel obj)
        {
            try
            {
                if (obj == null)
                {
                    return BadRequest();
                }
                var test = await _itestInfoRepository.GetById(obj.TestId);
                if (test != null)
                {
                    ModelState.AddModelError("", "Test is already Add");
                    return BadRequest(ModelState);
                }
                var returnObj = await _itestInfoRepository.Insert(obj);
                return CreatedAtAction(nameof(GetAll), new { id = returnObj.TestId }, returnObj);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retriving data from database");
            }
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult<TestInfoViewModel>> Update(int id, TestInfoViewModel obj)
        {
            try
            {
                if (id != obj.TestId)
                {
                    return BadRequest("Test Id mismatch");
                }
                var test = await _itestInfoRepository.GetById(id);
                if (test == null)
                {
                    return NotFound();
                }
                return await _itestInfoRepository.Update(obj);
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
                var test = await _itestInfoRepository.GetById(id);
                if (test == null)
                {
                    return NotFound();
                }
                await _itestInfoRepository.Delete(id);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retriving data from database");
            }
        }
    }
}
