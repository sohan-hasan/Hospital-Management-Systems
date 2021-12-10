﻿using HospitalManagementApi.DAL.IRepository;
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
    public class WordInfoController : ControllerBase
    {
        private readonly IWardInfoRepsoitory _iWordsInfoRepository;
        public WordInfoController(IWardInfoRepsoitory iWordsInfoRepository)
        {
            _iWordsInfoRepository = iWordsInfoRepository;
        }
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                return Ok(await _iWordsInfoRepository.GetAll());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retriving data from database");
            }
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<WardInfoViewModel>> GetById(int id)
        {
            try
            {
                var result = await _iWordsInfoRepository.GetById(id);
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
        public async Task<ActionResult<WardInfoViewModel>> Insert(WardInfoViewModel obj)
        {
            try
            {
                if (obj == null)
                {
                    return BadRequest();
                }
                var word = await _iWordsInfoRepository.GetById(obj.WardNo);
                if (word != null)
                {
                    ModelState.AddModelError("", "Word is already Add");
                    return BadRequest(ModelState);
                }
                var returnObj = await _iWordsInfoRepository.Insert(obj);
                return CreatedAtAction(nameof(GetAll), new { id = returnObj.WardNo }, returnObj);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retriving data from database");
            }
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult<WardInfoViewModel>> Update(int id, WardInfoViewModel obj)
        {
            try
            {
                if (id != obj.WardNo)
                {
                    return BadRequest("Word Id mismatch");
                }
                var word = await _iWordsInfoRepository.GetById(id);
                if (word == null)
                {
                    return NotFound();
                }
                return await _iWordsInfoRepository.Update(obj);
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
                var word = await _iWordsInfoRepository.GetById(id);
                if (word == null)
                {
                    return NotFound();
                }
                await _iWordsInfoRepository.Delete(id);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retriving data from database");
            }
        }
    }
}
