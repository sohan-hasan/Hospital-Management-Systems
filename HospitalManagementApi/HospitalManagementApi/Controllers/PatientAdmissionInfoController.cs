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
    public class PatientAdmissionInfoController : ControllerBase
    {
        private readonly IPatientAdmissionInfoRepository _iPatientAdmissionInfoRepository;
        private readonly IPatientInfoRepository _ipatientRepository;
        private readonly IWebHostEnvironment _iwebHostEnvironment;
        private readonly ICabinInfoRepository _icabinInfoRepository;
        private readonly ICabinTypeRepository _iCabinTypeRepository;
        private readonly IWardInfoRepsoitory _iWardInfoRepsoitory;
        private readonly IBedInfoRepsoitory _iBedInfoRepository;
        private readonly IDoctorsInfoRepository _iDoctorInfoRepository;
        public PatientAdmissionInfoController(IPatientInfoRepository ipatientRepository, IWebHostEnvironment iwebHostEnvironment,
            IPatientAdmissionInfoRepository iPatientAdmissionInfoRepository, ICabinInfoRepository icabinInfoRepository,
            ICabinTypeRepository iCabinTypeRepository, IWardInfoRepsoitory iWardInfoRepsoitory, IBedInfoRepsoitory iBedInfoRepository,
            IDoctorsInfoRepository iDoctorInfoRepository)
        {
            this._iPatientAdmissionInfoRepository = iPatientAdmissionInfoRepository;
            this._ipatientRepository = ipatientRepository;
            this._iwebHostEnvironment = iwebHostEnvironment;
            this._icabinInfoRepository = icabinInfoRepository;
            this._iCabinTypeRepository = iCabinTypeRepository;
            this._iWardInfoRepsoitory = iWardInfoRepsoitory;
            this._iBedInfoRepository = iBedInfoRepository;
            this._iDoctorInfoRepository = iDoctorInfoRepository;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                var PatientAdmissionList = await _iPatientAdmissionInfoRepository.GetAll();
                return Ok(PatientAdmissionList);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<PatientAdmissionInfoViewModel>> GetById(int id)
        {
            try
            {
                var result = await _iPatientAdmissionInfoRepository.GetById(id);
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
        public async Task<object> Insert([FromForm] PatientAdmissionInfoViewModel obj)
        {
            try
            {
                string uniqueImageName = "";
                if (obj == null)
                {
                    return await Task.FromResult(new ResponseModel(ResponseCode.Error, "Data Missing", null));

                }
                var admission = await _iPatientAdmissionInfoRepository.GetById(obj.PatientAdmissionId);
                if (admission != null)
                {
                    return await Task.FromResult(new ResponseModel(ResponseCode.Error, "Data Already Exixt", null));
                }

                DoctorsInfoViewModel doctor = await _iDoctorInfoRepository.GetById(obj.DoctorId);
                if (doctor == null)
                {
                    return await Task.FromResult(new ResponseModel(ResponseCode.Error, "Doctor is missing", null));
                }
                var petaint = await _ipatientRepository.GetById(obj.PatientId);
                if (petaint != null)
                {
                    return await Task.FromResult(new ResponseModel(ResponseCode.Error, "Data Already Exixt", null));
                }
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
                PatientInfoViewModel patient = new PatientInfoViewModel
                {
                    PatientId = obj.PatientId,
                    PatientName = obj.PatientName,
                    Gender = obj.Gender,
                    FatherName = obj.FatherName,
                    Address = obj.Address,
                    Phone = obj.Phone,
                    Occupation = obj.Occupation,
                    Nationality = obj.Nationality,
                    NidCardNo = obj.NidCardNo,
                    BloodGroup = obj.BloodGroup,
                    Age = obj.Age,
                    IsAdmit = 1,
                    ImageName = obj.ImageName
                };
                var returnPetaint = await _ipatientRepository.Insert(patient);
                if (returnPetaint != null)
                {
                    if (obj.CabinTypeId > 0 && obj.CabinId > 0)
                    {
                        CabinInfoViewModel cabin = await _icabinInfoRepository.GetById(obj.CabinId);
                        CabinTypeInfoViewModel cabinType = await _iCabinTypeRepository.GetById(obj.CabinTypeId);
                        if (cabinType == null)
                        {
                            return await Task.FromResult(new ResponseModel(ResponseCode.Error, "Cabin type not found", null));
                        }
                        if (cabin == null)
                        {
                            return await Task.FromResult(new ResponseModel(ResponseCode.Error, "Cabin not found", null));
                        }
                        obj.PatientId = returnPetaint.PatientId;
                        obj.CabinId = cabin.CabinId;
                        obj.CabinName = cabin.CabinName;
                        obj.CabinTypeId = cabinType.CabinTypeId;
                        obj.CabinTypeName = cabinType.CabinTypeName;
                        var returnObj = await _iPatientAdmissionInfoRepository.Insert(obj);
                        if (returnObj != null)
                        {
                            cabin.BookingStatus = 0;
                            await _icabinInfoRepository.Update(cabin);
                            return await Task.FromResult(new ResponseModel(ResponseCode.OK, "Data Insert Successfully", null));
                        }
                    }
                    else if (obj.WardNo > 0 && obj.BedId > 0)
                    {
                        WardInfoViewModel ward = await _iWardInfoRepsoitory.GetById(obj.WardNo);
                        BedInfoViewModel bed = await _iBedInfoRepository.GetById(obj.BedId);
                        if (ward == null)
                        {
                            return await Task.FromResult(new ResponseModel(ResponseCode.Error, "Ward not found", null));
                        }
                        if (bed == null)
                        {
                            return await Task.FromResult(new ResponseModel(ResponseCode.Error, "Bed not found", null));
                        }
                        obj.PatientId = returnPetaint.PatientId;
                        obj.WardNo = ward.WardNo;
                        obj.WardName = ward.WardName;
                        obj.BedId = bed.BedId;
                        obj.BedNo = bed.BedNo;
                       
                    
                        var returnObj = await _iPatientAdmissionInfoRepository.Insert(obj);
                        if (returnObj != null)
                        {
                            bed.BookingStatus = 0;
                            await _iBedInfoRepository.Update(bed);
                            return await Task.FromResult(new ResponseModel(ResponseCode.OK, "Data Insert Successfully", null));
                        }
                    }
                }
                return await Task.FromResult(new ResponseModel(ResponseCode.Error, "Something is worng", null));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpPost("AdmitExitingPatient")]
        public async Task<object> AdmitExitingPatient([FromBody] PatientAdmissionInfoViewModel obj)
        {
            try
            {
                if (obj == null)
                {
                    return await Task.FromResult(new ResponseModel(ResponseCode.Error, "Data Missing", null));

                }
                var admission = await _iPatientAdmissionInfoRepository.GetById(obj.PatientAdmissionId); 
                if (admission != null)
                {
                    return await Task.FromResult(new ResponseModel(ResponseCode.Error, "Data Already Exixt", null));
                }
                DoctorsInfoViewModel doctor = await _iDoctorInfoRepository.GetById(obj.DoctorId);
                if (doctor == null)
                {
                    return await Task.FromResult(new ResponseModel(ResponseCode.Error, "Doctor is missing", null));
                }
                PatientInfoViewModel petaint = await _ipatientRepository.GetById(obj.PatientId);
                if (petaint == null)
                {
                    return await Task.FromResult(new ResponseModel(ResponseCode.Error, "Patient is missing", null));
                }
                if (petaint.IsAdmit == 1)
                {
                    return await Task.FromResult(new ResponseModel(ResponseCode.Error, "Patient is already admit.Please discharge for new admission", null));
                }
                petaint.IsAdmit = 1;
                var returnPetaint = await _ipatientRepository.Update(petaint);
                if (returnPetaint != null)
                {
                    if (obj.CabinTypeId > 0 && obj.CabinId > 0)
                    {
                        CabinInfoViewModel cabin = await _icabinInfoRepository.GetById(obj.CabinId);
                        CabinTypeInfoViewModel cabinType = await _iCabinTypeRepository.GetById(obj.CabinTypeId);
                        if (cabinType == null)
                        {
                            return await Task.FromResult(new ResponseModel(ResponseCode.Error, "Cabin type not found", null));
                        }
                        if (cabin == null)
                        {
                            return await Task.FromResult(new ResponseModel(ResponseCode.Error, "Cabin not found", null));
                        }
                        obj.PatientId = returnPetaint.PatientId;
                        obj.CabinId = cabin.CabinId;
                        obj.CabinName = cabin.CabinName;
                        obj.CabinTypeId = cabinType.CabinTypeId;
                        obj.CabinTypeName = cabinType.CabinTypeName;
                        var returnObj = await _iPatientAdmissionInfoRepository.Insert(obj);
                        if (returnObj != null)
                        {
                            cabin.BookingStatus = 0;
                            await _icabinInfoRepository.Update(cabin);
                            return await Task.FromResult(new ResponseModel(ResponseCode.OK, "Data Insert Successfully", null));
                        }
                    }
                    else if (obj.WardNo > 0 && obj.BedId > 0)
                    {
                        WardInfoViewModel ward = await _iWardInfoRepsoitory.GetById(obj.WardNo);
                        BedInfoViewModel bed = await _iBedInfoRepository.GetById(obj.BedId);
                        if (ward == null)
                        {
                            return await Task.FromResult(new ResponseModel(ResponseCode.Error, "Ward not found", null));
                        }
                        if (bed == null)
                        {
                            return await Task.FromResult(new ResponseModel(ResponseCode.Error, "Bed not found", null));
                        }
                        obj.PatientId = returnPetaint.PatientId;
                        obj.WardNo = ward.WardNo;
                        obj.WardName = ward.WardName;
                        obj.BedId = bed.BedId;
                        obj.BedNo = bed.BedNo;
                       
                        var returnObj = await _iPatientAdmissionInfoRepository.Insert(obj);
                        if (returnObj != null)
                        {
                            bed.BookingStatus = 0;
                            await _iBedInfoRepository.Update(bed);
                            return await Task.FromResult(new ResponseModel(ResponseCode.OK, "Data Insert Successfully", null));
                        }
                    }
                }
                return await Task.FromResult(new ResponseModel(ResponseCode.Error, "Something is worng", null));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpPut("Update")]
        public async Task<object> Update([FromForm] PatientAdmissionInfoViewModel obj)
        {
            try
            {
                string uniqueImageName = "";
                if (obj == null)
                {
                    return await Task.FromResult(new ResponseModel(ResponseCode.Error, "Data Missing", null));

                }
                var admition = await _iPatientAdmissionInfoRepository.GetById(obj.PatientAdmissionId);
                if (admition == null)
                {
                    return await Task.FromResult(new ResponseModel(ResponseCode.Error, "Enter valid admition", null));
                }
                var petaint = await _ipatientRepository.GetById(obj.PatientId);
                if (petaint == null)
                {
                    return await Task.FromResult(new ResponseModel(ResponseCode.Error, "Petaint not found", null));
                }
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
                PatientInfoViewModel patient = new PatientInfoViewModel
                {
                    PatientId = obj.PatientId,
                    PatientName = obj.PatientName,
                    Gender = obj.Gender,
                    FatherName = obj.FatherName,
                    Address = obj.Address,
                    Phone = obj.Phone,
                    Occupation = obj.Occupation,
                    Nationality = obj.Nationality,
                    NidCardNo = obj.NidCardNo,
                    BloodGroup = obj.BloodGroup,
                    Age = obj.Age,
                    ImageName = obj.ImageName
                };
                var returnPetaint = await _ipatientRepository.Update(patient);
                if (returnPetaint != null)
                {
                    if (obj.CabinId != obj.UpdateCabinId || obj.BedId != obj.UpdateBedId)
                    {
                        if (obj.CabinTypeId > 0 && obj.CabinId > 0 && obj.BedId == 0 && obj.WardNo == 0)
                        {
                            CabinTypeInfoViewModel cabinType = await _iCabinTypeRepository.GetById(obj.CabinTypeId);
                            CabinInfoViewModel cabin = await _icabinInfoRepository.GetById(obj.CabinId);
                            CabinInfoViewModel oldCabin = await _icabinInfoRepository.GetById(obj.UpdateCabinId);
                            if (cabinType == null)
                            {
                                return await Task.FromResult(new ResponseModel(ResponseCode.Error, "Cabin type not found", null));
                            }
                            if (cabin == null)
                            {
                                return await Task.FromResult(new ResponseModel(ResponseCode.Error, "Cabin not found", null));
                            }
                            obj.PatientId = returnPetaint.PatientId;
                            obj.CabinId = cabin.CabinId;
                            obj.CabinName = cabin.CabinName;
                            obj.CabinTypeId = cabinType.CabinTypeId;
                            obj.CabinTypeName = cabinType.CabinTypeName;
                            obj.PatientAdmissionId = 0;
                            var returnObj = await _iPatientAdmissionInfoRepository.Insert(obj);
                            if (returnObj != null)
                            {
                                cabin.BookingStatus = 0;
                                await _icabinInfoRepository.Update(cabin);
                                oldCabin.BookingStatus = 1;
                                await _icabinInfoRepository.Update(oldCabin);
                                return await Task.FromResult(new ResponseModel(ResponseCode.OK, "Data Insert Successfully", null));
                            }
                        }
                        else if (obj.UpdateCabinId > 0 && obj.WardNo > 0 && obj.BedId > 0)
                        {
                            WardInfoViewModel ward = await _iWardInfoRepsoitory.GetById(obj.WardNo);
                            BedInfoViewModel bed = await _iBedInfoRepository.GetById(obj.BedId);
                            CabinInfoViewModel oldCabin = await _icabinInfoRepository.GetById(obj.UpdateCabinId);
                            if (ward == null)
                            {
                                return await Task.FromResult(new ResponseModel(ResponseCode.Error, "Ward not found", null));
                            }
                            if (bed == null)
                            {
                                return await Task.FromResult(new ResponseModel(ResponseCode.Error, "Bed not found", null));
                            }
                            if (oldCabin == null)
                            {
                                return await Task.FromResult(new ResponseModel(ResponseCode.Error, "Bed not found", null));
                            }
                            obj.PatientId = returnPetaint.PatientId;
                            obj.WardNo = ward.WardNo;
                            obj.WardName = ward.WardName;
                            obj.BedId = bed.BedId;
                            obj.BedNo = bed.BedNo;
                            obj.CabinId = 0;
                            obj.CabinName = "";
                            obj.CabinTypeId = 0;
                            obj.CabinTypeName = "";
                            obj.PatientAdmissionId = 0;
                            var returnObj = await _iPatientAdmissionInfoRepository.Insert(obj);
                            if (returnObj != null)
                            {
                                bed.BookingStatus = 0;
                                await _iBedInfoRepository.Update(bed);
                                oldCabin.BookingStatus = 1;
                                await _icabinInfoRepository.Update(oldCabin);
                                return await Task.FromResult(new ResponseModel(ResponseCode.OK, "Data Insert Successfully", null));
                            }
                        }
                        else if (obj.WardNo > 0 && obj.BedId > 0 && obj.CabinId == 0 && obj.CabinTypeId == 0)
                        {
                            WardInfoViewModel ward = await _iWardInfoRepsoitory.GetById(obj.WardNo);
                            BedInfoViewModel bed = await _iBedInfoRepository.GetById(obj.BedId);
                            BedInfoViewModel oldBed = await _iBedInfoRepository.GetById(obj.BedId);
                            if (ward == null)
                            {
                                return await Task.FromResult(new ResponseModel(ResponseCode.Error, "Ward not found", null));
                            }
                            if (bed == null)
                            {
                                return await Task.FromResult(new ResponseModel(ResponseCode.Error, "Bed not found", null));
                            }
                            obj.PatientId = returnPetaint.PatientId;
                            obj.WardNo = ward.WardNo;
                            obj.WardName = ward.WardName;
                            obj.BedId = bed.BedId;
                            obj.BedNo = bed.BedNo;
                            obj.PatientAdmissionId = 0;
                            var patientAdmission = _iPatientAdmissionInfoRepository.GetById(obj.PatientAdmissionId);
                            if (bed == null)
                            {
                                return await Task.FromResult(new ResponseModel(ResponseCode.Error, "Patient  admition is missing", null));
                            }
                            var returnObj = await _iPatientAdmissionInfoRepository.Insert(obj);
                            if (returnObj != null)
                            {
                                bed.BookingStatus = 0;
                                await _iBedInfoRepository.Update(bed);
                                oldBed.BookingStatus = 1;
                                await _iBedInfoRepository.Update(oldBed);
                                return await Task.FromResult(new ResponseModel(ResponseCode.OK, "Data Insert Successfully", null));
                            }
                        }
                        else if (obj.UpdateBedId > 0 && obj.CabinTypeId > 0 && obj.CabinId > 0)
                        {
                            CabinTypeInfoViewModel cabinType = await _iCabinTypeRepository.GetById(obj.CabinTypeId);
                            CabinInfoViewModel cabin = await _icabinInfoRepository.GetById(obj.CabinId);
                            BedInfoViewModel oldBed = await _iBedInfoRepository.GetById(obj.BedId);
                            if (cabinType == null)
                            {
                                return await Task.FromResult(new ResponseModel(ResponseCode.Error, "Cabin type not found", null));
                            }
                            if (cabin == null)
                            {
                                return await Task.FromResult(new ResponseModel(ResponseCode.Error, "Cabin not found", null));
                            }
                            if (oldBed == null)
                            {
                                return await Task.FromResult(new ResponseModel(ResponseCode.Error, "Bed not found", null));
                            }
                            obj.PatientId = returnPetaint.PatientId;
                            obj.CabinId = cabin.CabinId;
                            obj.CabinName = cabin.CabinName;
                            obj.CabinTypeId = cabinType.CabinTypeId;
                            obj.CabinTypeName = cabinType.CabinTypeName;
                            obj.WardNo = 0;
                            obj.WardName = "";
                            obj.BedId = 0;
                            obj.BedNo = "";
                            obj.PatientAdmissionId = 0;
                            var returnObj = await _iPatientAdmissionInfoRepository.Insert(obj);
                            if (returnObj != null)
                            {
                                cabin.BookingStatus = 0;
                                await _icabinInfoRepository.Update(cabin);
                                oldBed.BookingStatus = 1;
                                await _iBedInfoRepository.Update(oldBed);
                                return await Task.FromResult(new ResponseModel(ResponseCode.OK, "Data Insert Successfully", null));
                            }
                        }

                    }
                    else if (obj.CabinId == obj.UpdateCabinId || obj.BedId == obj.UpdateBedId)
                    {
                        PatientAdmissionInfoViewModel admission = await _iPatientAdmissionInfoRepository.GetById(obj.PatientAdmissionId);
                        var returnObj = await _iPatientAdmissionInfoRepository.Update(admission);
                        return await Task.FromResult(new ResponseModel(ResponseCode.OK, "Data Insert Successfully", null));

                    }
                }
                return await Task.FromResult(new ResponseModel(ResponseCode.Error, "Something is worng", null));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var test = await _iPatientAdmissionInfoRepository.GetById(id);
                if (test == null)
                {
                    return NotFound();
                }
                var petaint = await _ipatientRepository.GetById(test.PatientId);
                if (petaint.ImageName != null)
                {
                    string uploadFolder = Path.Combine(_iwebHostEnvironment.WebRootPath, "images/patient_images");
                    DeleteExistingImage(Path.Combine(uploadFolder, petaint.ImageName));
                }
                await _ipatientRepository.Delete(test.PatientId);
                await _iPatientAdmissionInfoRepository.Delete(id);
                return Ok();
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
    }
}
