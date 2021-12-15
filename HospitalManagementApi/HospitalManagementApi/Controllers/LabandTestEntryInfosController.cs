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
    public class LabandTestEntryInfosController : ControllerBase
    {
        private readonly ILabandTestEntry _iLabandTestEntry;
        public LabandTestEntryInfosController(ILabandTestEntry iLabandTestEntry)
        {
            this._iLabandTestEntry = iLabandTestEntry;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                return Ok(await _iLabandTestEntry.GetAll());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retriving data from database");
            }
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<LabandTestEntryInfoViewModel>> GetById(int id)
        {
            try
            {
                var result = await _iLabandTestEntry.GetById(id);
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
        public async Task<ActionResult<LabandTestEntryInfoViewModel>> Insert(LabandTestEntryInfoViewModel obj)
        {
            try
            {
                if (obj == null)
                {
                    return BadRequest();
                }
                var lab = await _iLabandTestEntry.GetById(obj.TestId);
                if (lab != null)
                {
                    ModelState.AddModelError("", "Lab Test info is already Add");
                    return BadRequest(ModelState);
                }
                var returnObj = await _iLabandTestEntry.Insert(obj);
                return CreatedAtAction(nameof(GetAll), new { id = returnObj }, returnObj);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retriving data from database");
            }
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult<LabandTestEntryInfoViewModel>> Update(int id, LabandTestEntryInfoViewModel obj)
        {
            try
            {
                if (id != obj.TestId)
                {
                    return BadRequest("Test Id mismatch");
                }
                var consultancy = await _iLabandTestEntry.GetById(id);
                if (consultancy == null)
                {
                    return NotFound();
                }
                return await _iLabandTestEntry.Update(obj);
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
                var consultancy = await _iLabandTestEntry.GetById(id);
                if (consultancy == null)
                {
                    return NotFound();
                }
                await _iLabandTestEntry.Delete(id);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retriving data from database");
            }
        }
    }
}
