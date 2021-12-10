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
    public class OutDoorConsultancyController : ControllerBase
    {
        private readonly IOutDoorConsultancyRepository _iOutDoorConsultancy;
        public OutDoorConsultancyController(IOutDoorConsultancyRepository iOutDoorConsultancy)
        {
            this._iOutDoorConsultancy = iOutDoorConsultancy;
        }
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                return Ok(await _iOutDoorConsultancy.GetAll());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retriving data from database");
            }
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<OutDoorConsultancyViewModel>> GetById(int id)
        {
            try
            {
                var result = await _iOutDoorConsultancy.GetById(id);
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
        public async Task<ActionResult<OutDoorConsultancyViewModel>> Insert(OutDoorConsultancyViewModel obj)
        {
            try
            {
                if (obj == null)
                {
                    return BadRequest();
                }
                var doctor = await _iOutDoorConsultancy.GetById(obj.OutDoorId);
                if (doctor != null)
                {
                    ModelState.AddModelError("", "Doctor is already Add");
                    return BadRequest(ModelState);
                }
                var returnObj = await _iOutDoorConsultancy.Insert(obj);
                return CreatedAtAction(nameof(GetAll), new { id = returnObj }, returnObj);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retriving data from database");
            }
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult<OutDoorConsultancyViewModel>> Update(int id, OutDoorConsultancyViewModel obj)
        {
            try
            {
                if (id != obj.OutDoorId)
                {
                    return BadRequest("Doctor Id mismatch");
                }
                var consultancy = await _iOutDoorConsultancy.GetById(id);
                if (consultancy == null)
                {
                    return NotFound();
                }
                return await _iOutDoorConsultancy.Update(obj);
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
                var consultancy = await _iOutDoorConsultancy.GetById(id);
                if (consultancy == null)
                {
                    return NotFound();
                }
                await _iOutDoorConsultancy.Delete(id);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retriving data from database");
            }
        }
    }
}
