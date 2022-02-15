using HospitalManagementApi.DAL.IRepositories;
using HospitalManagementApi.Models;
using HospitalManagementApi.Models.ContextModels;
using HospitalManagementApi.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementApi.DAL.Repositories
{
    public class DoctorsInfoRepository : IDoctorsInfoRepository
    {
        private readonly HospitalManagementContext _context;
        public DoctorsInfoRepository(HospitalManagementContext contex)
        {
            _context = contex;
        }

        public async Task<IEnumerable<DoctorsInfoViewModel>> GetAll()
        {
            IEnumerable<DoctorsInfoViewModel> listOfDoctors = await _context.DoctorsInfos.Select(e => new DoctorsInfoViewModel
            {
                DoctorId = e.DoctorId,
                DoctorName = e.DoctorName,
                Specialist = e.Specialist,
                Phone = e.Phone,
                Address = e.Address,
                Qualification = e.Qualification,
                DutyStartTime = e.DutyStartTime,
                DutyEndTime = e.DutyEndTime,
                JoinDate = e.JoinDate,
                ResignDate = e.ResignDate,
                DoctorType = e.DoctorType,
                CommissionStatus = e.CommissionStatus,
                ImageName = e.ImageName
            }).ToListAsync();
            return listOfDoctors;
        }

        public async Task<DoctorsInfoViewModel> GetById(int id)
        {
            DoctorsInfo e = await _context.DoctorsInfos.AsNoTracking().FirstOrDefaultAsync(e => e.DoctorId == id);
            if (e != null)
            {
                DoctorsInfoViewModel doctor = new DoctorsInfoViewModel
                {
                    DoctorId = e.DoctorId,
                    DoctorName = e.DoctorName,
                    Specialist = e.Specialist,
                    Phone = e.Phone,
                    Address = e.Address,
                    Qualification = e.Qualification,
                    DutyStartTime = e.DutyStartTime,
                    DutyEndTime = e.DutyEndTime,
                    JoinDate = e.JoinDate,
                    ResignDate = e.ResignDate,
                    DoctorType = e.DoctorType,
                    CommissionStatus = e.CommissionStatus,
                    ImageName = e.ImageName
                };
                return doctor;
            }
            return null;
        }

        public async Task<DoctorsInfoViewModel> Insert(DoctorsInfoViewModel e)
        {
            DoctorsInfoViewModel returnObj = new DoctorsInfoViewModel();
            if (e != null)
            {
                DoctorsInfo obj = new DoctorsInfo()
                {
                    DoctorName = e.DoctorName,
                    Specialist = e.Specialist,
                    Phone = e.Phone,
                    Address = e.Address,
                    Qualification = e.Qualification,
                    DutyStartTime = e.DutyStartTime,
                    DutyEndTime = e.DutyEndTime,
                    JoinDate = e.JoinDate,
                    ResignDate = e.ResignDate,
                    DoctorType = e.DoctorType,
                    CommissionStatus = e.CommissionStatus,
                    ImageName = e.ImageName
                };
                await _context.DoctorsInfos.AddAsync(obj);
                await Save();
                returnObj = await GetById(obj.DoctorId);
            }
            return returnObj;
        }
        public async Task<DoctorsInfoViewModel> Update(DoctorsInfoViewModel e)
        {
            var result = await _context.DoctorsInfos.FirstOrDefaultAsync(h => h.DoctorId == e.DoctorId);
            DoctorsInfoViewModel returnObj = new DoctorsInfoViewModel();
            if (result != null)
            {
                result.DoctorId = e.DoctorId;
                result.DoctorName = e.DoctorName;
                result.Specialist = e.Specialist;
                result.Phone = e.Phone;
                result.Address = e.Address;
                result.Qualification = e.Qualification;
                result.DutyStartTime = e.DutyStartTime;
                result.DutyEndTime = e.DutyEndTime;
                result.JoinDate = e.JoinDate;
                result.ResignDate = e.ResignDate;
                result.DoctorType = e.DoctorType;
                result.CommissionStatus = e.CommissionStatus;
                result.ImageName = e.ImageName;
            }
            await Save();
            returnObj = await GetById(result.DoctorId);
            return returnObj;
        }
        public async Task Delete(int id)
        {
            var result = await _context.DoctorsInfos.FirstOrDefaultAsync(p => p.DoctorId == id);
            if (result != null)
            {
                _context.DoctorsInfos.Remove(result);
                await _context.SaveChangesAsync();
            }
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }


    }
    public class TestInfoRepository : ITestInfoRepository
    {
        private readonly HospitalManagementContext _context;
        public TestInfoRepository(HospitalManagementContext contex)
        {
            _context = contex;
        }
        public async Task<IEnumerable<TestInfoViewModel>> GetAll()
        {
            IEnumerable<TestInfoViewModel> listOfTest = await _context.TestInfos.Select(e => new TestInfoViewModel
            {
                TestId = e.TestId,
                CategoryId = e.CategoryId,
                CategoryName = e.TestCategory.CategoryName,
                TestName = e.TestName,
                TestCost = e.TestCost,
                Remarks = e.Remarks,
                PercentangeToDoctor = e.PercentangeToDoctor,
                Unit = e.Unit,
                CashToDoctor = e.CashToDoctor

            }).ToListAsync();
            return listOfTest;
        }

        public async Task<TestInfoViewModel> GetById(int id)
        {
            TestInfo e = await _context.TestInfos.AsNoTracking().FirstOrDefaultAsync(e => e.TestId == id);
            if (e != null)
            {
                TestInfoViewModel test = new TestInfoViewModel
                {
                    TestId = e.TestId,
                    CategoryId = e.CategoryId,
                    TestName = e.TestName,
                    TestCost = e.TestCost,
                    Remarks = e.Remarks,
                    PercentangeToDoctor = e.PercentangeToDoctor,
                    Unit = e.Unit,
                    CashToDoctor = e.CashToDoctor
                };
                return test;
            }
            return null;
        }

        public async Task<TestInfoViewModel> Insert(TestInfoViewModel e)
        {
            TestInfoViewModel returnObj = new TestInfoViewModel();
            if (e != null)
            {
                TestInfo obj = new TestInfo()
                {
                    TestId = e.TestId,
                    CategoryId = e.CategoryId,
                    TestName = e.TestName,
                    TestCost = e.TestCost,
                    Remarks = e.Remarks,
                    PercentangeToDoctor = e.PercentangeToDoctor,
                    Unit = e.Unit,
                    CashToDoctor = e.CashToDoctor
                };
                await _context.TestInfos.AddAsync(obj);
                await Save();
                returnObj = await GetById(obj.TestId);

            }
            return returnObj;
        }

        public async Task<TestInfoViewModel> Update(TestInfoViewModel e)
        {
            var result = await _context.TestInfos.FirstOrDefaultAsync(h => h.TestId == e.TestId);
            TestInfoViewModel returnObj = new TestInfoViewModel();
            if (result != null)
            {
                result.TestId = e.TestId;
                result.CategoryId = e.CategoryId;
                result.TestName = e.TestName;
                result.TestCost = e.TestCost;
                result.Remarks = e.Remarks;
                result.PercentangeToDoctor = e.PercentangeToDoctor;
                result.Unit = e.Unit;
                result.CashToDoctor = e.CashToDoctor;
            }
            await Save();
            returnObj = await GetById(result.TestId);
            return returnObj;
        }
        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            var result = await _context.TestInfos.FirstOrDefaultAsync(p => p.TestId == id);
            if (result != null)
            {
                _context.TestInfos.Remove(result);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<IEnumerable<TestInfoViewModel>> GetAllTestByCatagoryId(int categoryId)
        {
            IEnumerable<TestInfoViewModel> bedList = await _context.TestInfos.Where(a => a.CategoryId == categoryId).Select(e => new TestInfoViewModel
            {
                TestId = e.TestId,
                CategoryId = e.CategoryId,
                TestName = e.TestName,
                TestCost = e.TestCost,
                Remarks = e.Remarks,
                PercentangeToDoctor = e.PercentangeToDoctor,
                Unit = e.Unit,
                CashToDoctor = e.CashToDoctor
            }).ToListAsync();
            return bedList;
        }
    }
    public class TestCategoryRepository : ITestCategoryRepository
    {
        private readonly HospitalManagementContext _context;
        public TestCategoryRepository(HospitalManagementContext contex)
        {
            _context = contex;
        }
        public async Task<IEnumerable<TestCategoryViewModel>> GetAll()
        {
            IEnumerable<TestCategoryViewModel> listOfTestCategory = await _context.TestCategories.Select(e => new TestCategoryViewModel
            {
                CategoryId = e.CategoryId,
                CategoryName = e.CategoryName,

            }).ToListAsync();
            return listOfTestCategory;
        }

        public async Task<TestCategoryViewModel> GetById(int id)
        {
            TestCategory e = await _context.TestCategories.AsNoTracking().FirstOrDefaultAsync(e => e.CategoryId == id);
            if (e != null)
            {
                TestCategoryViewModel testCategory = new TestCategoryViewModel
                {
                    CategoryId = e.CategoryId,
                    CategoryName = e.CategoryName,
                };
                return testCategory;
            }
            return null;
        }

        public async Task<TestCategoryViewModel> Insert(TestCategoryViewModel e)
        {
            TestCategoryViewModel returnObj = new TestCategoryViewModel();
            if (e != null)
            {
                TestCategory obj = new TestCategory()
                {
                    CategoryId = e.CategoryId,
                    CategoryName = e.CategoryName,
                };
                await _context.TestCategories.AddAsync(obj);
                await Save();
                returnObj = await GetById(obj.CategoryId);

            }
            return returnObj;
        }

        public async Task<TestCategoryViewModel> Update(TestCategoryViewModel e)
        {
            var result = await _context.TestCategories.FirstOrDefaultAsync(h => h.CategoryId == e.CategoryId);
            TestCategoryViewModel returnObj = new TestCategoryViewModel();
            if (result != null)
            {
                result.CategoryId = e.CategoryId;
                result.CategoryName = e.CategoryName;
            }
            await Save();
            returnObj = await GetById(result.CategoryId);
            return returnObj;
        }
        public async Task Delete(int id)
        {
            var result = await _context.TestCategories.FirstOrDefaultAsync(p => p.CategoryId == id);
            if (result != null)
            {
                _context.TestCategories.Remove(result);
                await _context.SaveChangesAsync();
            }
        }
        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
    public class PatientAdmissionInfoRepository : IPatientAdmissionInfoRepository
    {
        private readonly HospitalManagementContext _context;
        public PatientAdmissionInfoRepository(HospitalManagementContext contex)
        {
            _context = contex;
        }
        public async Task<IEnumerable<PatientAdmissionInfoViewModel>> GetAll()
        {
            IEnumerable<PatientAdmissionInfoViewModel> listOfPatientAdmission = await _context.PatientAdmissionInfos.Select(p => new PatientAdmissionInfoViewModel
            {
                PatientAdmissionId = p.PatientAdmissionId,
                AdmissionDate = p.AdmissionDate,
                PatientId = p.PatientId,
                PatientName = p.PatientInfo.PatientName,
                Gender = p.PatientInfo.Gender,
                FatherName = p.PatientInfo.FatherName,
                Address = p.PatientInfo.Address,
                Phone = p.PatientInfo.Phone,
                Occupation = p.PatientInfo.Occupation,
                Nationality = p.PatientInfo.Nationality,
                NidCardNo = p.PatientInfo.NidCardNo,
                BloodGroup = p.PatientInfo.BloodGroup,
                Age = p.PatientInfo.Age,
                ImageName = p.PatientInfo.ImageName,
                DoctorId = p.DoctorId,
                DoctorName = p.DoctorsInfo.DoctorName,
                CabinTypeId = p.CabinTypeId,
                CabinTypeName = p.CabinTypeName,
                CabinId = p.CabinId,
                CabinName = p.CabinName,
                WardNo = p.WardNo,
                WardName = p.WardName,
                BedId = p.BedId,
                BedNo = p.BedNo,
                AdvanceAmount = p.AdvanceAmount,
                CostPerDay = p.CostPerDay,
            }).ToListAsync();
            return listOfPatientAdmission;
        }

        public async Task<PatientAdmissionInfoViewModel> GetById(int id)
        {
            PatientAdmissionInfo p = await _context.PatientAdmissionInfos.AsNoTracking().FirstOrDefaultAsync(p => p.PatientAdmissionId == id);
            if (p != null)
            {
                PatientAdmissionInfoViewModel test = new PatientAdmissionInfoViewModel
                {
                    PatientAdmissionId = p.PatientAdmissionId,
                    AdmissionDate = p.AdmissionDate,
                    PatientId = p.PatientId,
                    DoctorId = p.DoctorId,
                    CabinTypeId = p.CabinTypeId,
                    CabinTypeName = p.CabinTypeName,
                    CabinId = p.CabinId,
                    CabinName = p.CabinName,
                    WardNo = p.WardNo,
                    WardName = p.WardName,
                    BedId = p.BedId,
                    BedNo = p.BedNo,
                    AdvanceAmount = p.AdvanceAmount,
                    CostPerDay = p.CostPerDay,
                };
                return test;
            }
            return null;
        }

        public async Task<PatientAdmissionInfoViewModel> Insert(PatientAdmissionInfoViewModel p)
        {
            PatientAdmissionInfoViewModel returnObj = new PatientAdmissionInfoViewModel();
            if (p != null)
            {
                PatientAdmissionInfo obj = new PatientAdmissionInfo()
                {

                    PatientAdmissionId = p.PatientAdmissionId,
                    AdmissionDate = p.AdmissionDate,
                    PatientId = p.PatientId,
                    DoctorId = p.DoctorId,
                    CabinTypeId = p.CabinTypeId,
                    CabinTypeName = p.CabinTypeName,
                    CabinId = p.CabinId,
                    CabinName = p.CabinName,
                    WardNo = p.WardNo,
                    WardName = p.WardName,
                    BedId = p.BedId,
                    BedNo = p.BedNo,
                    AdvanceAmount = p.AdvanceAmount,
                    CostPerDay = p.CostPerDay,
                };
                await _context.PatientAdmissionInfos.AddAsync(obj);
                await Save();
                returnObj = await GetById(obj.PatientAdmissionId);

            }
            return returnObj;
        }

        public async Task<PatientAdmissionInfoViewModel> Update(PatientAdmissionInfoViewModel p)
        {
            var result = await _context.PatientAdmissionInfos.FirstOrDefaultAsync(h => h.PatientAdmissionId == p.PatientAdmissionId);
            PatientAdmissionInfoViewModel returnObj = new PatientAdmissionInfoViewModel();
            if (result != null)
            {
                result.PatientAdmissionId = p.PatientAdmissionId;
                result.AdmissionDate = p.AdmissionDate;
                result.PatientId = p.PatientId;
                result.DoctorId = p.DoctorId;
                result.CabinTypeId = p.CabinTypeId;
                result.CabinTypeName = p.CabinTypeName;
                result.CabinId = p.CabinId;
                result.CabinName = p.CabinName;
                result.WardNo = p.WardNo;
                result.WardName = p.WardName;
                result.BedId = p.BedId;
                result.BedNo = p.BedNo;
                result.AdvanceAmount = p.AdvanceAmount;
                result.CostPerDay = p.CostPerDay;
            }
            await Save();
            returnObj = await GetById(result.PatientAdmissionId);
            return returnObj;
        }
        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            var result = await _context.PatientAdmissionInfos.FirstOrDefaultAsync(p => p.PatientAdmissionId == id);
            if (result != null)
            {
                _context.PatientAdmissionInfos.Remove(result);
                await _context.SaveChangesAsync();
            }
        }
    }
    public class PatientInfoRepository : IPatientInfoRepository
    {
        private readonly HospitalManagementContext _context;
        public PatientInfoRepository(HospitalManagementContext contex)
        {
            _context = contex;
        }
        public async Task<IEnumerable<PatientInfoViewModel>> GetAll()
        {
            IEnumerable<PatientInfoViewModel> patientobj = await _context.PatientInfos.Select(e => new PatientInfoViewModel
            {
                PatientId = e.PatientId,
                PatientName = e.PatientName,
                Gender = e.Gender,
                FatherName = e.FatherName,
                Address = e.Address,
                Phone = e.Phone,
                Occupation = e.Occupation,
                Nationality = e.Nationality,
                NidCardNo = e.NidCardNo,
                BloodGroup = e.BloodGroup,
                Age = e.Age,
                IsAdmit = e.IsAdmit,
                ImageName = e.ImageName,
            }).ToListAsync();
            return patientobj;
        }

        public async Task<PatientInfoViewModel> GetById(int id)
        {
            PatientInfo e = await _context.PatientInfos.AsNoTracking().FirstOrDefaultAsync(e => e.PatientId == id);
            if (e != null)
            {
                PatientInfoViewModel patient = new PatientInfoViewModel
                {
                    PatientId = e.PatientId,
                    PatientName = e.PatientName,
                    Gender = e.Gender,
                    FatherName = e.FatherName,
                    Address = e.Address,
                    Phone = e.Phone,
                    Occupation = e.Occupation,
                    Nationality = e.Nationality,
                    NidCardNo = e.NidCardNo,
                    BloodGroup = e.BloodGroup,
                    Age = e.Age,
                    IsAdmit = e.IsAdmit,
                    ImageName = e.ImageName
                };
                return patient;
            }
            return null;
        }

        public async Task<PatientInfoViewModel> Insert(PatientInfoViewModel e)
        {
            PatientInfoViewModel returnObj = new PatientInfoViewModel();
            if (e != null)
            {
                PatientInfo obj = new PatientInfo()
                {
                    PatientId = e.PatientId,
                    PatientName = e.PatientName,
                    Gender = e.Gender,
                    FatherName = e.FatherName,
                    Address = e.Address,
                    Phone = e.Phone,
                    Occupation = e.Occupation,
                    Nationality = e.Nationality,
                    NidCardNo = e.NidCardNo,
                    BloodGroup = e.BloodGroup,
                    Age = e.Age,
                    IsAdmit = e.IsAdmit,
                    ImageName = e.ImageName
                };
                await _context.PatientInfos.AddAsync(obj);
                await Save();
                returnObj = await GetById(obj.PatientId);

            }
            return returnObj;
        }
        public async Task<PatientInfoViewModel> Update(PatientInfoViewModel e)
        {
            var result = await _context.PatientInfos.FirstOrDefaultAsync(h => h.PatientId == e.PatientId);
            PatientInfoViewModel returnObj = new PatientInfoViewModel();
            if (result != null)
            {
                result.PatientId = e.PatientId;
                result.PatientName = e.PatientName;
                result.Gender = e.Gender;
                result.FatherName = e.FatherName;
                result.Address = e.Address;
                result.Phone = e.Phone;
                result.Occupation = e.Occupation;
                result.Nationality = e.Nationality;
                result.NidCardNo = e.NidCardNo;
                result.BloodGroup = e.BloodGroup;
                result.Age = e.Age;
                result.IsAdmit = e.IsAdmit;
                result.ImageName = e.ImageName;
            }
            await Save();
            returnObj = await GetById(result.PatientId);
            return returnObj;
        }
        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            var result = await _context.PatientInfos.FirstOrDefaultAsync(p => p.PatientId == id);
            if (result != null)
            {
                _context.PatientInfos.Remove(result);
                await _context.SaveChangesAsync();
            }
        }
    }
    public class AppointmentInfoRepository : IAppointmentInfoRepository
    {
        private readonly HospitalManagementContext _context;
        public AppointmentInfoRepository(HospitalManagementContext contex)
        {
            _context = contex;
        }

        public async Task<IEnumerable<AppointmentInfoViewModel>> GetAll()
        {
            IEnumerable<AppointmentInfoViewModel> listOfAppoint = await _context.AppoinmentInfos.Select(e => new AppointmentInfoViewModel
            {
                AppointmentId = e.AppointmentId,
                AppointmentDate = e.AppointmentDate,
                DoctorId = e.DoctorId,
                DoctorName = e.DoctorsInfo.DoctorName,
                SerialNo = e.SerialNo,
                AppointmentTime = e.AppointmentTime,
                PatientName = e.PatientName,
                PhoneNo = e.PhoneNo,
                NextAppointmentDate = e.NextAppointmentDate,
                Remark = e.Remark
            }).ToListAsync();
            return listOfAppoint;
        }

        public async Task<AppointmentInfoViewModel> GetById(int id)
        {
            AppointmentInfo e = await _context.AppoinmentInfos.AsNoTracking().FirstOrDefaultAsync(e => e.AppointmentId == id);
            if (e != null)
            {
                AppointmentInfoViewModel appoint = new AppointmentInfoViewModel
                {
                    AppointmentId = e.AppointmentId,
                    AppointmentDate = e.AppointmentDate,
                    DoctorId = e.DoctorId,
                    SerialNo = e.SerialNo,
                    AppointmentTime = e.AppointmentTime,
                    PatientName = e.PatientName,
                    PhoneNo = e.PhoneNo,
                    NextAppointmentDate = e.NextAppointmentDate,
                    Remark = e.Remark
                };
                return appoint;

            }
            return null;
        }

        public async Task<AppointmentInfoViewModel> Insert(AppointmentInfoViewModel e)
        {
            AppointmentInfoViewModel returnObj = new AppointmentInfoViewModel();
            if (e != null)
            {
                AppointmentInfo obj = new AppointmentInfo()
                {

                    AppointmentId = e.AppointmentId,
                    AppointmentDate = e.AppointmentDate,
                    DoctorId = e.DoctorId,
                    SerialNo = e.SerialNo,
                    AppointmentTime = e.AppointmentTime,
                    PatientName = e.PatientName,
                    PhoneNo = e.PhoneNo,
                    NextAppointmentDate = e.NextAppointmentDate,
                    Remark = e.Remark
                };
                await _context.AppoinmentInfos.AddAsync(obj);
                await Save();
                returnObj = await GetById(obj.AppointmentId);

            }
            return returnObj;
        }
        public async Task<AppointmentInfoViewModel> Update(AppointmentInfoViewModel e)
        {
            var result = await _context.AppoinmentInfos.FirstOrDefaultAsync(h => h.AppointmentId == e.AppointmentId);
            AppointmentInfoViewModel returnObj = new AppointmentInfoViewModel();
            if (result != null)
            {
                result.AppointmentId = e.AppointmentId;
                result.AppointmentDate = e.AppointmentDate;
                result.DoctorId = e.DoctorId;
                result.SerialNo = e.SerialNo;
                result.AppointmentTime = e.AppointmentTime;
                result.PatientName = e.PatientName;
                result.PhoneNo = e.PhoneNo;
                result.NextAppointmentDate = e.NextAppointmentDate;
                result.Remark = e.Remark;

            }
            await Save();
            returnObj = await GetById(result.AppointmentId);
            return returnObj;
        }

        public async Task Delete(int id)
        {
            var result = await _context.AppoinmentInfos.FirstOrDefaultAsync(p => p.AppointmentId == id);
            if (result != null)
            {
                _context.AppoinmentInfos.Remove(result);
                await _context.SaveChangesAsync();
            }
        }
        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<int> GetSerialNo(int id, string appionmentDate)
        {
            int sirialNo = 1;

            IEnumerable<AppointmentInfoViewModel> listOfAppoint = await _context.AppoinmentInfos.Where(a => a.DoctorId == id).Select(e => new AppointmentInfoViewModel
            {
                AppointmentId = e.AppointmentId,
                AppointmentDate = e.AppointmentDate,
                DoctorId = e.DoctorId,
                SerialNo = e.SerialNo,
                AppointmentTime = e.AppointmentTime,
                PatientName = e.PatientName,
                PhoneNo = e.PhoneNo,
                NextAppointmentDate = e.NextAppointmentDate,
                Remark = e.Remark
            }).ToListAsync();
            foreach (var item in listOfAppoint)
            {

                if (Convert.ToDateTime(item.AppointmentDate) == Convert.ToDateTime(appionmentDate))
                {
                    sirialNo += 1;
                }
            }
            return sirialNo;
        }
    }
    public class OutDoorConsultancyRepository : IOutDoorConsultancyRepository
    {
        private readonly HospitalManagementContext _context;
        public OutDoorConsultancyRepository(HospitalManagementContext contex)
        {
            _context = contex;
        }
        public async Task<IEnumerable<OutDoorConsultancyViewModel>> GetAll()
        {
            IEnumerable<OutDoorConsultancyViewModel> listOfConsultancy = await _context.OutDoorConsultancies.Select(e => new OutDoorConsultancyViewModel
            {
                OutDoorId = e.OutDoorId,
                DoctorId = e.DoctorId,
                DoctorName = e.DoctorsInfo.DoctorName,
                SerialNo = e.SerialNo,
                EntryDate = e.EntryDate,
                PatientName = e.PatientName,
                Gender = e.Gender,
                Age = e.Age,
                Prescription = e.Prescription,
                Address = e.Address,
                Phone = e.Phone,
                Testifications = e.Testifications,
            }).ToListAsync();
            return listOfConsultancy;
        }
        public async Task<OutDoorConsultancyViewModel> GetById(int id)
        {
            OutDoorConsultancy e = await _context.OutDoorConsultancies.AsNoTracking().FirstOrDefaultAsync(e => e.OutDoorId == id);
            if (e != null)
            {
                OutDoorConsultancyViewModel word = new OutDoorConsultancyViewModel
                {
                    OutDoorId = e.OutDoorId,
                    DoctorId = e.DoctorId,
                    SerialNo = e.SerialNo,
                    EntryDate = e.EntryDate,
                    PatientName = e.PatientName,
                    Gender = e.Gender,
                    Age = e.Age,
                    Prescription = e.Prescription,
                    Address = e.Address,
                    Phone = e.Phone,
                    Testifications = e.Testifications,
                };
                return word;
            }
            return null;
        }
        public async Task<OutDoorConsultancyViewModel> Insert(OutDoorConsultancyViewModel e)
        {
            OutDoorConsultancyViewModel returnObj = new OutDoorConsultancyViewModel();
            if (e != null)
            {
                OutDoorConsultancy obj = new OutDoorConsultancy()
                {
                    OutDoorId = e.OutDoorId,
                    DoctorId = e.DoctorId,
                    SerialNo = e.SerialNo,
                    EntryDate = e.EntryDate,
                    PatientName = e.PatientName,
                    Gender = e.Gender,
                    Age = e.Age,
                    Prescription = e.Prescription,
                    Address = e.Address,
                    Phone = e.Phone,
                    Testifications = e.Testifications,
                };
                await _context.OutDoorConsultancies.AddAsync(obj);
                await Save();
                returnObj = await GetById(obj.OutDoorId);

            }
            return returnObj;
        }
        public async Task<OutDoorConsultancyViewModel> Update(OutDoorConsultancyViewModel e)
        {
            var result = await _context.OutDoorConsultancies.FirstOrDefaultAsync(h => h.OutDoorId == e.OutDoorId);
            OutDoorConsultancyViewModel returnObj = new OutDoorConsultancyViewModel();
            if (result != null)
            {
                result.OutDoorId = e.OutDoorId;
                result.DoctorId = e.DoctorId;
                result.SerialNo = e.SerialNo;
                result.EntryDate = e.EntryDate;
                result.PatientName = e.PatientName;
                result.Gender = e.Gender;
                result.Age = e.Age;
                result.Prescription = e.Prescription;
                result.Address = e.Address;
                result.Phone = e.Phone;
                result.Testifications = e.Testifications;
            }
            await Save();
            returnObj = await GetById(result.OutDoorId);
            return returnObj;
        }
        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            var result = await _context.OutDoorConsultancies.FirstOrDefaultAsync(p => p.OutDoorId == id);
            if (result != null)
            {
                _context.OutDoorConsultancies.Remove(result);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<int> GetSerialNo(int id, string entryDate)
        {
            int serialNo = 1;

            IEnumerable<OutDoorConsultancyViewModel> listOfAppoint = await _context.OutDoorConsultancies.Where(a => a.DoctorId == id).Select(e => new OutDoorConsultancyViewModel
            {
                OutDoorId = e.OutDoorId,
                DoctorId = e.DoctorId,
                SerialNo = e.SerialNo,
                EntryDate = e.EntryDate,
                PatientName = e.PatientName,
                Gender = e.Gender,
                Age = e.Age,
                Prescription = e.Prescription,
                Address = e.Address,
                Phone = e.Phone,
                Testifications = e.Testifications,
            }).ToListAsync();
            foreach (var item in listOfAppoint)
            {

                if (Convert.ToDateTime(item.EntryDate) == Convert.ToDateTime(entryDate))
                {
                    serialNo += 1;
                }
            }
            return serialNo;
        }

    }
    public class CabinInfoRepository : ICabinInfoRepository
    {
        private readonly HospitalManagementContext _context;
        public CabinInfoRepository(HospitalManagementContext contex)
        {
            _context = contex;
        }
        public async Task<IEnumerable<CabinInfoViewModel>> GetAll()
        {
            IEnumerable<CabinInfoViewModel> listOfCabin = await _context.CabinInfos.Select(e => new CabinInfoViewModel
            {
                CabinId = e.CabinId,
                CabinName = e.CabinName,
                CabinTypeId = e.CabinTypeId,
                CabinTypeName = e.CabinTypeInfo.CabinTypeName,
                CabinSize = e.CabinSize,
                FloorNo = e.FloorNo,
                CostPerDay = e.CostPerDay,
                BookingStatus = e.BookingStatus,
                CabinDirection = e.CabinDirection,
                ImageName = e.ImageName
            }).ToListAsync();
            return listOfCabin;
        }

        public async Task<CabinInfoViewModel> GetById(int id)
        {
            CabinInfo e = await _context.CabinInfos.AsNoTracking().FirstOrDefaultAsync(e => e.CabinId == id);
            if (e != null)
            {
                CabinInfoViewModel cabin = new CabinInfoViewModel
                {
                    CabinId = e.CabinId,
                    CabinName = e.CabinName,
                    CabinTypeId = e.CabinTypeId,
                    CabinSize = e.CabinSize,
                    FloorNo = e.FloorNo,
                    CostPerDay = e.CostPerDay,
                    BookingStatus = e.BookingStatus,
                    CabinDirection = e.CabinDirection,
                    ImageName = e.ImageName
                };
                return cabin;

            }
            return null;
        }

        public async Task<CabinInfoViewModel> Insert(CabinInfoViewModel e)
        {
            CabinInfoViewModel returnObj = new CabinInfoViewModel();
            if (e != null)
            {
                CabinInfo obj = new CabinInfo()
                {

                    CabinId = e.CabinId,
                    CabinName = e.CabinName,
                    CabinTypeId = e.CabinTypeId,
                    CabinSize = e.CabinSize,
                    FloorNo = e.FloorNo,
                    CostPerDay = e.CostPerDay,
                    BookingStatus = e.BookingStatus,
                    CabinDirection = e.CabinDirection,
                    ImageName = e.ImageName,
                };
                await _context.CabinInfos.AddAsync(obj);
                await Save();
                returnObj = await GetById(obj.CabinId);

            }
            return returnObj;
        }
        public async Task<CabinInfoViewModel> Update(CabinInfoViewModel e)
        {
            var result = await _context.CabinInfos.FirstOrDefaultAsync(h => h.CabinId == e.CabinId);
            CabinInfoViewModel returnObj = new CabinInfoViewModel();
            if (result != null)
            {
                result.CabinId = e.CabinId;
                result.CabinName = e.CabinName;
                result.CabinTypeId = e.CabinTypeId;
                result.CabinSize = e.CabinSize;
                result.FloorNo = e.FloorNo;
                result.CostPerDay = e.CostPerDay;
                result.BookingStatus = e.BookingStatus;
                result.CabinDirection = e.CabinDirection;
                result.ImageName = e.ImageName;
            }
            await Save();
            returnObj = await GetById(result.CabinId);
            return returnObj;
        }

        public async Task Delete(int id)
        {
            var result = await _context.CabinInfos.FirstOrDefaultAsync(p => p.CabinId == id);
            if (result != null)
            {
                _context.CabinInfos.Remove(result);
                await _context.SaveChangesAsync();
            }
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<CabinInfoViewModel>> GetByTypeId(int cabinTypeId)
        {

            IEnumerable<CabinInfoViewModel> listOfCabin = await _context.CabinInfos.Where(a => a.CabinTypeId == cabinTypeId && a.BookingStatus == 1).Select(e => new CabinInfoViewModel
            {
                CabinId = e.CabinId,
                CabinName = e.CabinName,
                CabinTypeId = e.CabinTypeId,
                CabinSize = e.CabinSize,
                FloorNo = e.FloorNo,
                CostPerDay = e.CostPerDay,
                BookingStatus = e.BookingStatus,
                CabinDirection = e.CabinDirection,
                ImageName = e.ImageName
            }).ToListAsync();
            return listOfCabin;
        }
    }
    public class CabinTypeInfoRepository : ICabinTypeRepository
    {

        private readonly HospitalManagementContext _context;
        public CabinTypeInfoRepository(HospitalManagementContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<CabinTypeInfoViewModel>> GetAll()
        {
            IEnumerable<CabinTypeInfoViewModel> listOfCabinType = await _context.CabinTypeInfos.Select(e => new CabinTypeInfoViewModel
            {
                CabinTypeId = e.CabinTypeId,
                CabinTypeName = e.CabinTypeName,


            }).ToListAsync();
            return listOfCabinType;
        }

        public async Task<CabinTypeInfoViewModel> GetById(int id)
        {
            CabinTypeInfo e = await _context.CabinTypeInfos.AsNoTracking().FirstOrDefaultAsync(e => e.CabinTypeId == id);
            if (e != null)
            {
                CabinTypeInfoViewModel cabinType = new CabinTypeInfoViewModel
                {
                    CabinTypeId = e.CabinTypeId,
                    CabinTypeName = e.CabinTypeName
                };
                return cabinType;

            }
            return null;
        }

        public async Task<CabinTypeInfoViewModel> Insert(CabinTypeInfoViewModel e)
        {
            CabinTypeInfoViewModel returnObj = new CabinTypeInfoViewModel();
            if (e != null)
            {
                CabinTypeInfo obj = new CabinTypeInfo()
                {

                    CabinTypeId = e.CabinTypeId,
                    CabinTypeName = e.CabinTypeName
                };
                await _context.CabinTypeInfos.AddAsync(obj);
                await Save();
                returnObj = await GetById(obj.CabinTypeId);

            }
            return returnObj;
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<CabinTypeInfoViewModel> Update(CabinTypeInfoViewModel e)
        {
            var result = await _context.CabinTypeInfos.FirstOrDefaultAsync(h => h.CabinTypeId == e.CabinTypeId);
            CabinTypeInfoViewModel returnObj = new CabinTypeInfoViewModel();
            if (result != null)
            {
                result.CabinTypeId = e.CabinTypeId;
                result.CabinTypeName = e.CabinTypeName;
            }
            await Save();
            returnObj = await GetById(result.CabinTypeId);
            return returnObj;
        }
        public async Task Delete(int id)
        {
            var result = await _context.CabinTypeInfos.FirstOrDefaultAsync(p => p.CabinTypeId == id);
            if (result != null)
            {
                _context.CabinTypeInfos.Remove(result);
                await _context.SaveChangesAsync();
            }
        }
    }
    public class WardInfoRepository : IWardInfoRepsoitory
    {
        private readonly HospitalManagementContext _context;
        public WardInfoRepository(HospitalManagementContext contex)
        {
            _context = contex;
        }

        public async Task<IEnumerable<WardInfoViewModel>> GetAll()
        {
            IEnumerable<WardInfoViewModel> listOfWards = await _context.WardInfos.Select(e => new WardInfoViewModel
            {
                WardNo = e.WardNo,
                WardName = e.WardName,
                WardCost = e.WardCost,
                FloorNo = e.FloorNo,
                ImageName = e.ImageName
            }).ToListAsync();
            return listOfWards;
        }

        public async Task<WardInfoViewModel> GetById(int id)
        {
            WardInfo e = await _context.WardInfos.AsNoTracking().FirstOrDefaultAsync(e => e.WardNo == id);
            if (e != null)
            {
                WardInfoViewModel Ward = new WardInfoViewModel
                {
                    WardNo = e.WardNo,
                    WardName = e.WardName,
                    WardCost = e.WardCost,
                    FloorNo = e.FloorNo,
                    ImageName = e.ImageName
                };
                return Ward;
            }
            return null;
        }
        public async Task<WardInfoViewModel> Insert(WardInfoViewModel e)
        {
            WardInfoViewModel returnObj = new WardInfoViewModel();
            if (e != null)
            {
                WardInfo obj = new WardInfo()
                {
                    WardNo = e.WardNo,
                    WardName = e.WardName,
                    WardCost = e.WardCost,
                    FloorNo = e.FloorNo,
                    ImageName = e.ImageName
                };
                await _context.WardInfos.AddAsync(obj);
                await Save();
                returnObj = await GetById(obj.WardNo);

            }
            return returnObj;
        }
        public async Task<WardInfoViewModel> Update(WardInfoViewModel e)
        {
            var result = await _context.WardInfos.FirstOrDefaultAsync(h => h.WardNo == e.WardNo);
            WardInfoViewModel returnObj = new WardInfoViewModel();
            if (result != null)
            {
                result.WardNo = e.WardNo;
                result.WardName = e.WardName;
                result.WardCost = e.WardCost;
                result.FloorNo = e.FloorNo;
                result.ImageName = e.ImageName;
            }
            await Save();
            returnObj = await GetById(result.WardNo);
            return returnObj;
        }
        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            var result = await _context.WardInfos.FirstOrDefaultAsync(p => p.WardNo == id);
            if (result != null)
            {
                _context.WardInfos.Remove(result);
                await _context.SaveChangesAsync();
            }
        }
    }
    public class BedInfoRepository : IBedInfoRepsoitory
    {

        private readonly HospitalManagementContext _context;
        public BedInfoRepository(HospitalManagementContext contex)
        {
            _context = contex;
        }
        public async Task<IEnumerable<BedInfoViewModel>> GetAll()
        {
            IEnumerable<BedInfoViewModel> listOfBeds = await _context.BedInfos.Select(e => new BedInfoViewModel
            {
                BedId = e.BedId,
                BedNo = e.BedNo,
                WardNo = e.WardNo,
                WardName = e.WardInfo.WardName,
                BookingStatus = e.BookingStatus
            }).ToListAsync();
            return listOfBeds;
        }

        public async Task<BedInfoViewModel> GetById(int id)
        {
            BedInfo e = await _context.BedInfos.AsNoTracking().FirstOrDefaultAsync(e => e.BedId == id);
            if (e != null)
            {
                BedInfoViewModel bed = new BedInfoViewModel
                {
                    BedId = e.BedId,
                    BedNo = e.BedNo,
                    WardNo = e.WardNo,
                    BookingStatus = e.BookingStatus
                };
                return bed;
            }
            return null;
        }

        public async Task<BedInfoViewModel> Insert(BedInfoViewModel e)
        {
            BedInfoViewModel returnObj = new BedInfoViewModel();
            if (e != null)
            {
                BedInfo obj = new BedInfo()
                {
                    BedId = e.BedId,
                    BedNo = e.BedNo,
                    WardNo = e.WardNo,
                    BookingStatus = e.BookingStatus
                };
                await _context.BedInfos.AddAsync(obj);
                await Save();
                returnObj = await GetById(obj.BedId);

            }
            return returnObj;
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<BedInfoViewModel> Update(BedInfoViewModel e)
        {
            var result = await _context.BedInfos.FirstOrDefaultAsync(h => h.BedId == e.BedId);
            BedInfoViewModel returnObj = new BedInfoViewModel();
            if (result != null)
            {
                result.BedId = e.BedId;
                result.WardNo = e.WardNo;
                result.BedNo = e.BedNo;
                result.BookingStatus = e.BookingStatus;

            }
            await Save();
            returnObj = await GetById(result.BedId);
            return returnObj;
        }
        public async Task Delete(int id)
        {
            var result = await _context.BedInfos.FirstOrDefaultAsync(p => p.BedId == id);
            if (result != null)
            {
                _context.BedInfos.Remove(result);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<BedInfoViewModel>> GetByWardNo(int bedId)
        {
            IEnumerable<BedInfoViewModel> bedList = await _context.BedInfos.Where(a => a.WardNo == bedId && a.BookingStatus == 1).Select(e => new BedInfoViewModel
            {
                BedId = e.BedId,
                BedNo = e.BedNo,
                WardNo = e.WardNo,
                BookingStatus = e.BookingStatus,
            }).ToListAsync();
            return bedList;
        }
    }
    public class PatientMedicineInfoRepository : IPatientMedicineInfoRepository
    {
        private readonly HospitalManagementContext _context;
        public PatientMedicineInfoRepository(HospitalManagementContext contex)
        {
            _context = contex;
        }
        public async Task<IEnumerable<PatientMedicineInfoViewModel>> GetAll()
        {
            IEnumerable<PatientMedicineInfoViewModel> listOfMedicines = await _context.PatientMedicineInfos.Select(e => new PatientMedicineInfoViewModel
            {
                PatientMedicineInfoId = e.PatientMedicineInfoId,
                ProductId = e.ProductId,
                ProductName = e.Product.ProductName,
                PatientAdmissionId = e.PatientAdmissionId,
                PatientName = e.PatientAdmissionInfo.PatientInfo.PatientName,
                MedicineDate = e.MedicineDate,
                InstructionsForMedicine = e.InstructionsForMedicine,
                Quantity = e.Quantity,
                UnitPrice = e.UnitPrice,
                Total = e.Total

            }).ToListAsync();
            return listOfMedicines;
        }

        public async Task<PatientMedicineInfoViewModel> GetById(int id)
        {
            PatientMedicineInfo e = await _context.PatientMedicineInfos.AsNoTracking().FirstOrDefaultAsync(e => e.PatientMedicineInfoId == id);
            if (e != null)
            {
                PatientMedicineInfoViewModel medicine = new PatientMedicineInfoViewModel
                {
                    PatientMedicineInfoId = e.PatientMedicineInfoId,
                    ProductId = e.ProductId,
                    PatientAdmissionId = e.PatientAdmissionId,
                    MedicineDate = e.MedicineDate,
                    InstructionsForMedicine = e.InstructionsForMedicine,
                    Quantity = e.Quantity,
                    UnitPrice = e.UnitPrice,
                    Total = e.Total
                };
                return medicine;
            }
            return null;
        }

        public async Task<PatientMedicineInfoViewModel> Insert(PatientMedicineInfoViewModel e)
        {
            PatientMedicineInfoViewModel returnObj = new PatientMedicineInfoViewModel();
            if (e != null)
            {
                PatientMedicineInfo obj = new PatientMedicineInfo()
                {
                    PatientMedicineInfoId = e.PatientMedicineInfoId,
                    ProductId = e.ProductId,
                    PatientAdmissionId = e.PatientAdmissionId,
                    MedicineDate = e.MedicineDate,
                    InstructionsForMedicine = e.InstructionsForMedicine,
                    Quantity = e.Quantity,
                    UnitPrice = e.UnitPrice,
                    Total = e.Total
                };
                await _context.PatientMedicineInfos.AddAsync(obj);
                await Save();
                returnObj = await GetById(obj.PatientMedicineInfoId);

            }
            return returnObj;
        }

        public async Task<PatientMedicineInfoViewModel> Update(PatientMedicineInfoViewModel e)
        {
            var result = await _context.PatientMedicineInfos.FirstOrDefaultAsync(h => h.PatientMedicineInfoId == e.PatientMedicineInfoId);
            PatientMedicineInfoViewModel returnObj = new PatientMedicineInfoViewModel();
            if (result != null)
            {
                result.PatientMedicineInfoId = e.PatientMedicineInfoId;
                result.ProductId = e.ProductId;
                result.PatientAdmissionId = e.PatientAdmissionId;
                result.MedicineDate = e.MedicineDate;
                result.InstructionsForMedicine = e.InstructionsForMedicine;
                result.Quantity = e.Quantity;
                result.UnitPrice = e.UnitPrice;
                result.Total = e.Total;
            }
            await Save();
            returnObj = await GetById(result.PatientMedicineInfoId);
            return returnObj;
        }
        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            var result = await _context.PatientMedicineInfos.FirstOrDefaultAsync(p => p.PatientMedicineInfoId == id);
            if (result != null)
            {
                _context.PatientMedicineInfos.Remove(result);
                await _context.SaveChangesAsync();
            }
        }
    }
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly HospitalManagementContext _context;
        public DepartmentRepository(HospitalManagementContext contex)
        {
            _context = contex;
        }

        public async Task<IEnumerable<DepartmentViewModel>> GetAll()
        {
            IEnumerable<DepartmentViewModel> listOfLabTest = await _context.Departments.Select(e => new DepartmentViewModel
            {
                DepartmentId = e.DepartmentId,

                DepartmentName = e.DepartmentName,

            }).ToListAsync();
            return listOfLabTest;
        }

        public async Task<DepartmentViewModel> GetById(int id)
        {
            Department e = await _context.Departments.AsNoTracking().FirstOrDefaultAsync(e => e.DepartmentId == id);
            if (e != null)
            {
                DepartmentViewModel word = new DepartmentViewModel
                {
                    DepartmentId = e.DepartmentId,

                    DepartmentName = e.DepartmentName,

                };
                return word;
            }
            return null;
        }

        public async Task<DepartmentViewModel> Insert(DepartmentViewModel e)
        {
            DepartmentViewModel returnObj = new DepartmentViewModel();
            if (e != null)
            {
                Department obj = new Department()
                {
                    DepartmentId = e.DepartmentId,

                    DepartmentName = e.DepartmentName,

                };
                await _context.Departments.AddAsync(obj);
                await Save();
                returnObj = await GetById(obj.DepartmentId);

            }
            return returnObj;
        }
        public async Task<DepartmentViewModel> Update(DepartmentViewModel e)
        {
            var result = await _context.Departments.FirstOrDefaultAsync(h => h.DepartmentId == e.DepartmentId);
            DepartmentViewModel returnObj = new DepartmentViewModel();
            if (result != null)
            {
                result.DepartmentId = e.DepartmentId;

                result.DepartmentName = e.DepartmentName;

            }
            await Save();
            returnObj = await GetById(result.DepartmentId);
            return returnObj;
        }
        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            var result = await _context.Departments.FirstOrDefaultAsync(p => p.DepartmentId == id);
            if (result != null)
            {
                _context.Departments.Remove(result);
                await _context.SaveChangesAsync();
            }
        }

    }
    public class DesignationRepository : IDesignationRepository
    {
        private readonly HospitalManagementContext _context;
        public DesignationRepository(HospitalManagementContext contex)
        {
            _context = contex;
        }

        public async Task<IEnumerable<DesignationViewModel>> GetAll()
        {
            IEnumerable<DesignationViewModel> listOfLabTest = await _context.Designations.Select(e => new DesignationViewModel
            {
                DesignationId = e.DesignationId,

                DesignationName = e.DesignationName,

            }).ToListAsync();
            return listOfLabTest;
        }

        public async Task<DesignationViewModel> GetById(int id)
        {
            Designation e = await _context.Designations.AsNoTracking().FirstOrDefaultAsync(e => e.DesignationId == id);
            if (e != null)
            {
                DesignationViewModel word = new DesignationViewModel
                {
                    DesignationId = e.DesignationId,

                    DesignationName = e.DesignationName,

                };
                return word;
            }
            return null;
        }

        public async Task<DesignationViewModel> Insert(DesignationViewModel e)
        {
            DesignationViewModel returnObj = new DesignationViewModel();
            if (e != null)
            {
                Designation obj = new Designation()
                {
                    DesignationId = e.DesignationId,

                    DesignationName = e.DesignationName,

                };
                await _context.Designations.AddAsync(obj);
                await Save();
                returnObj = await GetById(obj.DesignationId);

            }
            return returnObj;
        }
        public async Task<DesignationViewModel> Update(DesignationViewModel e)
        {
            var result = await _context.Designations.FirstOrDefaultAsync(h => h.DesignationId == e.DesignationId);
            DesignationViewModel returnObj = new DesignationViewModel();
            if (result != null)
            {
                result.DesignationId = e.DesignationId;

                result.DesignationName = e.DesignationName;

            }
            await Save();
            returnObj = await GetById(result.DesignationId);
            return returnObj;
        }
        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            var result = await _context.Designations.FirstOrDefaultAsync(p => p.DesignationId == id);
            if (result != null)
            {
                _context.Designations.Remove(result);
                await _context.SaveChangesAsync();
            }
        }

    }
    public class EducationRepository : IEducationRepository
    {
        private readonly HospitalManagementContext _context;
        public EducationRepository(HospitalManagementContext contex)
        {
            _context = contex;
        }

        public async Task<IEnumerable<EducationViewModel>> GetAll()
        {
            IEnumerable<EducationViewModel> listOfLabTest = await _context.Educations.Select(e => new EducationViewModel
            {
                EducationID = e.EducationID,
                Degree = e.Degree,
                Institution = e.Institution,
                PasingYear = e.PasingYear,
                Result = e.Result,

                EmployeeId = e.EmployeeId
            }).ToListAsync();
            return listOfLabTest;
        }

        public async Task<EducationViewModel> GetById(int id)
        {
            Education e = await _context.Educations.AsNoTracking().FirstOrDefaultAsync(e => e.EducationID == id);
            if (e != null)
            {
                EducationViewModel word = new EducationViewModel
                {
                    EducationID = e.EducationID,
                    Degree = e.Degree,
                    Institution = e.Institution,
                    PasingYear = e.PasingYear,
                    Result = e.Result,

                    EmployeeId = e.EmployeeId
                };
                return word;
            }
            return null;
        }

        public async Task<EducationViewModel> Insert(EducationViewModel e)
        {
            EducationViewModel returnObj = new EducationViewModel();
            if (e != null)
            {
                Education obj = new Education()
                {
                    EducationID = e.EducationID,
                    Degree = e.Degree,
                    Institution = e.Institution,
                    PasingYear = e.PasingYear,
                    Result = e.Result,

                    EmployeeId = e.EmployeeId
                };
                await _context.Educations.AddAsync(obj);
                await Save();
                returnObj = await GetById(obj.EducationID);

            }
            return returnObj;
        }
        public async Task<EducationViewModel> Update(EducationViewModel e)
        {
            var result = await _context.Educations.FirstOrDefaultAsync(h => h.EducationID == e.EducationID);
            EducationViewModel returnObj = new EducationViewModel();
            if (result != null)
            {
                result.EducationID = e.EducationID;
                result.Degree = e.Degree;
                result.Institution = e.Institution;
                result.PasingYear = e.PasingYear;
                result.Result = e.Result;

                result.EmployeeId = e.EmployeeId;
            }
            await Save();
            returnObj = await GetById(result.EducationID);
            return returnObj;
        }
        public async Task<IEnumerable<EducationViewModel>> GetEduByEmpId(int empId)
        {
            IEnumerable<EducationViewModel> expInfo = await _context.Educations.Where(a => a.EmployeeId == empId).Select(e => new EducationViewModel
            {
                EducationID = e.EducationID,
                Degree = e.Degree,
                PasingYear = e.PasingYear,
                Result = e.Result,
                Institution = e.Institution,
                EmployeeId = e.EmployeeId

            }).ToListAsync();
            return expInfo;
        }
        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            var result = await _context.Educations.FirstOrDefaultAsync(p => p.EducationID == id);
            if (result != null)
            {
                _context.Educations.Remove(result);
                await _context.SaveChangesAsync();
            }
        }
    }
    public class ExperienceRepository : IExperienceRepository
    {
        private readonly HospitalManagementContext _context;
        public ExperienceRepository(HospitalManagementContext contex)
        {
            _context = contex;
        }

        public async Task<IEnumerable<ExperienceViewModel>> GetAll()
        {
            IEnumerable<ExperienceViewModel> listOfLabTest = await _context.Experiences.Select(e => new ExperienceViewModel
            {
                ExperienceID = e.ExperienceID,
                YearsOfExperience = e.YearsOfExperience,

                CompanyName = e.CompanyName,
                StartDate = e.StartDate,
                FinishDate = e.FinishDate,

                Designation = e.Designation,

                EmployeeId = e.EmployeeId
            }).ToListAsync();
            return listOfLabTest;
        }

        public async Task<ExperienceViewModel> GetById(int id)
        {
            Experience e = await _context.Experiences.AsNoTracking().FirstOrDefaultAsync(e => e.ExperienceID == id);
            if (e != null)
            {
                ExperienceViewModel word = new ExperienceViewModel
                {
                    ExperienceID = e.ExperienceID,
                    YearsOfExperience = e.YearsOfExperience,

                    CompanyName = e.CompanyName,
                    StartDate = e.StartDate,
                    FinishDate = e.FinishDate,

                    Designation = e.Designation,

                    EmployeeId = e.EmployeeId
                };
                return word;
            }
            return null;
        }

        public async Task<ExperienceViewModel> Insert(ExperienceViewModel e)
        {
            ExperienceViewModel returnObj = new ExperienceViewModel();
            if (e != null)
            {
                Experience obj = new Experience()
                {
                    ExperienceID = e.ExperienceID,
                    YearsOfExperience = e.YearsOfExperience,

                    CompanyName = e.CompanyName,
                    StartDate = e.StartDate,
                    FinishDate = e.FinishDate,

                    Designation = e.Designation,

                    EmployeeId = e.EmployeeId
                };
                await _context.Experiences.AddAsync(obj);
                await Save();
                returnObj = await GetById(obj.ExperienceID);

            }
            return returnObj;
        }
        public async Task<ExperienceViewModel> Update(ExperienceViewModel e)
        {
            var result = await _context.Experiences.FirstOrDefaultAsync(h => h.ExperienceID == e.ExperienceID);
            ExperienceViewModel returnObj = new ExperienceViewModel();
            if (result != null)
            {
                result.ExperienceID = e.ExperienceID;
                result.YearsOfExperience = e.YearsOfExperience;

                result.CompanyName = e.CompanyName;
                result.StartDate = e.StartDate;
                result.FinishDate = e.FinishDate;

                result.Designation = e.Designation;

                result.EmployeeId = e.EmployeeId;
            }
            await Save();
            returnObj = await GetById(result.ExperienceID);
            return returnObj;
        }
        public async Task<IEnumerable<ExperienceViewModel>> GetExpByEmpId(int empId)
        {
            IEnumerable<ExperienceViewModel> expInfo = await _context.Experiences.Where(a => a.EmployeeId == empId).Select(e => new ExperienceViewModel
            {
                ExperienceID = e.ExperienceID,
                YearsOfExperience = e.YearsOfExperience,

                CompanyName = e.CompanyName,
                StartDate = e.StartDate,
                FinishDate = e.FinishDate,

                Designation = e.Designation,
                Responsibilities = e.Responsibilities,

                EmployeeId = e.EmployeeId

            }).ToListAsync();
            return expInfo;
        }
        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            var result = await _context.Experiences.FirstOrDefaultAsync(p => p.ExperienceID == id);
            if (result != null)
            {
                _context.Experiences.Remove(result);
                await _context.SaveChangesAsync();
            }
        }
    }
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly HospitalManagementContext _context;
        public EmployeeRepository(HospitalManagementContext contex)
        {
            _context = contex;
        }

        public async Task<IEnumerable<EmployeeViewModel>> GetAll()
        {
            IEnumerable<EmployeeViewModel> listOfWards = await _context.Employees.Select(e => new EmployeeViewModel
            {
                EmployeeId = e.EmployeeId,
                EmployeeName = e.EmployeeName,
                FatherName = e.FatherName,
                MotherName = e.MotherName,
                Sex = e.Sex,
                Department = e.Department.DepartmentName,
                Designation = e.Designation.DesignationName,
                DateOfBirth = e.DateOfBirth,
                Age = e.Age,
                Maritaltatus = e.Maritaltatus,
                SpouseName = e.SpouseName,
                PesentAddress = e.PesentAddress,
                PermanentAddress = e.PermanentAddress,
                Phone = e.Phone,
                BloodGroup = e.BloodGroup,
                Religion = e.Religion,
                JoinDate = e.JoinDate,

                ShiftTime = e.ShiftTime,

                BasicSalary = e.BasicSalary,
                HouseRent = e.HouseRent,
                Medical = e.Medical,


                AccountNo = e.AccountNo,
                TerminationDate = e.TerminationDate,
                Active = e.Active,
                ImageName = e.ImageName,

                NID = e.NID,
                Passport = e.Passport,
                BirthID = e.BirthID,
                DepartmentId = e.DepartmentId,
                DesignationId = e.DesignationId

            }).ToListAsync();
            return listOfWards;
        }
        //================================
        public async Task<DesignationViewModel> GetDesignationById(int id)
        {
            Designation e = await _context.Designations.AsNoTracking().FirstOrDefaultAsync(e => e.DesignationId == id);
            if (e != null)
            {
                DesignationViewModel word = new DesignationViewModel
                {
                    DesignationId = e.DesignationId,

                    DesignationName = e.DesignationName,

                };
                return word;
            }
            return null;
        }

        //=================================
        public async Task<DepartmentViewModel> GetDepartmentById(int id)
        {
            Department e = await _context.Departments.AsNoTracking().FirstOrDefaultAsync(e => e.DepartmentId == id);
            if (e != null)
            {
                DepartmentViewModel word = new DepartmentViewModel
                {
                    DepartmentId = e.DepartmentId,

                    DepartmentName = e.DepartmentName,

                };
                return word;
            }
            return null;
        }

        public async Task<EmployeeViewModel> GetById(int id)
        {
            Employee e = await _context.Employees.AsNoTracking().FirstOrDefaultAsync(e => e.EmployeeId == id);
            if (e != null)
            {
                EmployeeViewModel Ward = new EmployeeViewModel
                {
                    EmployeeId = e.EmployeeId,
                    EmployeeName = e.EmployeeName,
                    FatherName = e.FatherName,
                    MotherName = e.MotherName,
                    Sex = e.Sex,

                    DateOfBirth = e.DateOfBirth,
                    Age = e.Age,
                    Maritaltatus = e.Maritaltatus,
                    SpouseName = e.SpouseName,
                    PesentAddress = e.PesentAddress,
                    PermanentAddress = e.PermanentAddress,
                    Phone = e.Phone,
                    BloodGroup = e.BloodGroup,
                    Religion = e.Religion,
                    JoinDate = e.JoinDate,

                    ShiftTime = e.ShiftTime,

                    BasicSalary = e.BasicSalary,
                    HouseRent = e.HouseRent,
                    Medical = e.Medical,



                    AccountNo = e.AccountNo,
                    TerminationDate = e.TerminationDate,
                    Active = e.Active,
                    ImageName = e.ImageName,

                    NID = e.NID,
                    Passport = e.Passport,
                    BirthID = e.BirthID,
                    DepartmentId = e.DepartmentId,
                    DesignationId = e.DesignationId
                };
                return Ward;
            }
            return null;
        }
        public async Task<EmployeeViewModel> Insert(EmployeeViewModel e)
        {
            EmployeeViewModel returnObj = new EmployeeViewModel();
            if (e != null)
            {
                Employee obj = new Employee()
                {
                    EmployeeId = e.EmployeeId,
                    EmployeeName = e.EmployeeName,
                    FatherName = e.FatherName,
                    MotherName = e.MotherName,
                    Sex = e.Sex,

                    DateOfBirth = e.DateOfBirth,
                    Age = e.Age,
                    Maritaltatus = e.Maritaltatus,
                    SpouseName = e.SpouseName,
                    PesentAddress = e.PesentAddress,
                    PermanentAddress = e.PermanentAddress,
                    Phone = e.Phone,
                    BloodGroup = e.BloodGroup,
                    Religion = e.Religion,
                    JoinDate = e.JoinDate,

                    ShiftTime = e.ShiftTime,

                    BasicSalary = e.BasicSalary,
                    HouseRent = e.HouseRent,
                    Medical = e.Medical,



                    AccountNo = e.AccountNo,
                    TerminationDate = e.TerminationDate,
                    Active = e.Active,
                    ImageName = e.ImageName,

                    NID = e.NID,
                    Passport = e.Passport,
                    BirthID = e.BirthID,
                    DepartmentId = e.DepartmentId,
                    DesignationId = e.DesignationId
                };
                await _context.Employees.AddAsync(obj);
                await Save();
                returnObj = await GetById(obj.EmployeeId);

            }
            return returnObj;
        }
        public async Task<EmployeeViewModel> Update(EmployeeViewModel e)
        {
            var result = await _context.Employees.FirstOrDefaultAsync(h => h.EmployeeId == e.EmployeeId);
            EmployeeViewModel returnObj = new EmployeeViewModel();
            if (result != null)
            {

                result.EmployeeId = e.EmployeeId;
                result.EmployeeName = e.EmployeeName;
                result.FatherName = e.FatherName;
                result.MotherName = e.MotherName;
                result.Sex = e.Sex;

                result.DateOfBirth = e.DateOfBirth;
                result.Age = e.Age;
                result.Maritaltatus = e.Maritaltatus;
                result.SpouseName = e.SpouseName;
                result.PesentAddress = e.PesentAddress;
                result.PermanentAddress = e.PermanentAddress;
                result.Phone = e.Phone;
                result.BloodGroup = e.BloodGroup;
                result.Religion = e.Religion;
                result.JoinDate = e.JoinDate;

                result.ShiftTime = e.ShiftTime;

                result.BasicSalary = e.BasicSalary;
                result.HouseRent = e.HouseRent;
                result.Medical = e.Medical;



                result.AccountNo = e.AccountNo;
                result.TerminationDate = e.TerminationDate;
                result.Active = e.Active;
                result.ImageName = e.ImageName;

                result.NID = e.NID;
                result.Passport = e.Passport;
                result.BirthID = e.BirthID;
                result.DepartmentId = e.DepartmentId;
                result.DesignationId = e.DesignationId;
            }
            await Save();
            returnObj = await GetById(result.EmployeeId);
            return returnObj;
        }
        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            var result = await _context.Employees.FirstOrDefaultAsync(p => p.EmployeeId == id);
            if (result != null)
            {
                _context.Employees.Remove(result);
                await _context.SaveChangesAsync();
            }
        }
    }
    public class PatientTestingInfoRepository : IPatientTestingInfoRepository
    {
        private readonly HospitalManagementContext _context;
        public PatientTestingInfoRepository(HospitalManagementContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<PatientTestingInfoViewModel>> GetAll()
        {
            IEnumerable<PatientTestingInfoViewModel> listOfPatientTestingInfo = await _context.PatientTestingInfos.Select(e => new PatientTestingInfoViewModel
            {
                TestNo = e.TestNo,
                TestId = e.TestId,
                TestName = e.TestInfo.TestName,
                TestDate = e.TestDate,
                PatientAdmissionId = e.PatientAdmissionId,
                Remarks = e.Remarks,
                UnitPrice = e.UnitPrice,
            }).ToListAsync();
            return listOfPatientTestingInfo;
        }


        public async Task<PatientTestingInfoViewModel> GetById(int id)
        {
            PatientTestingInfo e = await _context.PatientTestingInfos.AsNoTracking().FirstOrDefaultAsync(e => e.TestNo == id);
            if (e != null)
            {
                PatientTestingInfoViewModel pTest = new PatientTestingInfoViewModel
                {
                    TestNo = e.TestNo,
                    TestId = e.TestId,
                    TestDate = e.TestDate,
                    PatientAdmissionId = e.PatientAdmissionId,
                    Remarks = e.Remarks,
                    UnitPrice = e.UnitPrice,
                };
                return pTest;
            }
            return null;
        }

        public async Task<PatientTestingInfoViewModel> Insert(PatientTestingInfoViewModel e)
        {
            PatientTestingInfoViewModel returnObj = new PatientTestingInfoViewModel();
            if (e != null)
            {
                PatientTestingInfo obj = new PatientTestingInfo()
                {
                    TestNo = e.TestNo,
                    TestId = e.TestId,
                    TestDate = e.TestDate,
                    PatientAdmissionId = e.PatientAdmissionId,
                    Remarks = e.Remarks,
                    UnitPrice = e.UnitPrice,
                };
                await _context.PatientTestingInfos.AddAsync(obj);
                await Save();
                returnObj = await GetById(obj.TestNo);
            }
            return returnObj;
        }
        public async Task<PatientTestingInfoViewModel> Update(PatientTestingInfoViewModel e)
        {
            var result = await _context.PatientTestingInfos.FirstOrDefaultAsync(p => p.TestNo == e.TestNo);
            PatientTestingInfoViewModel returnObj = new PatientTestingInfoViewModel();
            if (result != null)
            {
                result.TestId = e.TestId;
                result.TestDate = e.TestDate;
                result.PatientAdmissionId = e.PatientAdmissionId;
                result.Remarks = e.Remarks;
                result.UnitPrice = e.UnitPrice;
            }
            await Save();
            returnObj = await GetById(result.TestNo);
            return returnObj;
        }
        public async Task Delete(int id)
        {
            var result = await _context.PatientTestingInfos.FirstOrDefaultAsync(p => p.TestNo == id);
            if (result != null)
            {
                _context.PatientTestingInfos.Remove(result);
                await _context.SaveChangesAsync();
            }
        }
        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

    }
    public class SupplierRepository : ISupplierRepository
    {
        private readonly HospitalManagementContext _context;
        public SupplierRepository(HospitalManagementContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<SupplierViewModel>> GetAll()
        {
            IEnumerable<SupplierViewModel> listOfSupplier = await _context.Suppliers.Select(e => new SupplierViewModel
            {
                SupplierId = e.SupplierId,
                CompanyName = e.CompanyName,
                ContactName = e.ContactName,
                Address = e.Address,
                Phone = e.Phone,
                Email = e.Email,
                ImageName = e.ImageName,
            }).ToListAsync();
            return listOfSupplier;
        }

        public async Task<SupplierViewModel> GetById(int id)
        {
            Supplier e = await _context.Suppliers.AsNoTracking().FirstOrDefaultAsync(e => e.SupplierId == id);
            if (e != null)
            {
                SupplierViewModel supplier = new SupplierViewModel
                {
                    SupplierId = e.SupplierId,
                    CompanyName = e.CompanyName,
                    ContactName = e.ContactName,
                    Address = e.Address,
                    Phone = e.Phone,
                    Email = e.Email,
                    ImageName = e.ImageName,
                };
                return supplier;
            }
            return null;
        }

        public async Task<SupplierViewModel> Insert(SupplierViewModel e)
        {
            SupplierViewModel returnObj = new SupplierViewModel();
            if (e != null)
            {
                Supplier obj = new Supplier()
                {
                    SupplierId = e.SupplierId,
                    CompanyName = e.CompanyName,
                    ContactName = e.ContactName,
                    Address = e.Address,
                    Phone = e.Phone,
                    Email = e.Email,
                    ImageName = e.ImageName,
                };
                await _context.Suppliers.AddAsync(obj);
                await Save();
                returnObj = await GetById(obj.SupplierId);
            }
            return returnObj;
        }
        public async Task<SupplierViewModel> Update(SupplierViewModel e)
        {
            var result = await _context.Suppliers.FirstOrDefaultAsync(p => p.SupplierId == e.SupplierId);
            SupplierViewModel returnObj = new SupplierViewModel();
            if (result != null)
            {
                result.SupplierId = e.SupplierId;
                result.CompanyName = e.CompanyName;
                result.ContactName = e.ContactName;
                result.Address = e.Address;
                result.Phone = e.Phone;
                result.Email = e.Email;
                result.ImageName = e.ImageName;
            }
            await Save();
            returnObj = await GetById(result.SupplierId);
            return returnObj;
        }
        public async Task Delete(int id)
        {
            var result = await _context.Suppliers.FirstOrDefaultAsync(p => p.SupplierId == id);
            if (result != null)
            {
                _context.Suppliers.Remove(result);
                await _context.SaveChangesAsync();
            }
        }
        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

    }
    public class CategoryRepository : ICategoryRepository
    {
        private readonly HospitalManagementContext _context;
        public CategoryRepository(HospitalManagementContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<CategoryViewModel>> GetAll()
        {
            IEnumerable<CategoryViewModel> category = await _context.Categories.Select(e => new CategoryViewModel
            {
                CategoryId = e.CategoryId,
                CategoryName = e.CategoryName,
            }).ToListAsync();
            return category;
        }

        public async Task<CategoryViewModel> GetById(int id)
        {
            Category e = await _context.Categories.AsNoTracking().FirstOrDefaultAsync(e => e.CategoryId == id);
            if (e != null)
            {
                CategoryViewModel category = new CategoryViewModel
                {
                    CategoryId = e.CategoryId,
                    CategoryName = e.CategoryName,
                };
                return category;
            }
            return null;
        }

        public async Task<CategoryViewModel> Insert(CategoryViewModel e)
        {
            CategoryViewModel returnObj = new CategoryViewModel();
            if (e != null)
            {
                Category obj = new Category()
                {
                    CategoryId = e.CategoryId,
                    CategoryName = e.CategoryName,
                };
                await _context.Categories.AddAsync(obj);
                await Save();
                returnObj = await GetById(obj.CategoryId);
            }
            return returnObj;
        }
        public async Task<CategoryViewModel> Update(CategoryViewModel e)
        {
            var result = await _context.Categories.FirstOrDefaultAsync(p => p.CategoryId == e.CategoryId);
            CategoryViewModel returnObj = new CategoryViewModel();
            if (result != null)
            {
                result.CategoryId = e.CategoryId;
                result.CategoryName = e.CategoryName;
            }
            await Save();
            returnObj = await GetById(result.CategoryId);
            return returnObj;
        }
        public async Task Delete(int id)
        {
            var result = await _context.Categories.FirstOrDefaultAsync(p => p.CategoryId == id);
            if (result != null)
            {
                _context.Categories.Remove(result);
                await _context.SaveChangesAsync();
            }
        }
        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

    }
    public class ProductRepository : IProductRepository
    {
        private readonly HospitalManagementContext _context;
        public ProductRepository(HospitalManagementContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<ProductViewModel>> GetAll()
        {
            IEnumerable<ProductViewModel> listOfProduct = await _context.Products.Select(e => new ProductViewModel
            {
                ProductId = e.ProductId,
                ProductName = e.ProductName,
                PurchaseDate = e.PurchaseDate,
                CategoryId = e.CategoryId,
                CategoryName = e.Category.CategoryName,
                SupplierId = e.SupplierId,
                SupplierName = e.Supplier.CompanyName,
                Quantity = e.Quantity,
                UnitPrice = e.UnitPrice,
                SalesUnitPrice = e.SalesUnitPrice,
                ImageName = e.ImageName,
            }).ToListAsync();
            return listOfProduct;
        }

        public async Task<ProductViewModel> GetById(int id)
        {
            Product e = await _context.Products.AsNoTracking().FirstOrDefaultAsync(e => e.ProductId == id);
            if (e != null)
            {
                ProductViewModel product = new ProductViewModel
                {
                    ProductId = e.ProductId,
                    ProductName = e.ProductName,
                    PurchaseDate = e.PurchaseDate,
                    CategoryId = e.CategoryId,
                    SupplierId = e.SupplierId,
                    Quantity = e.Quantity,
                    UnitPrice = e.UnitPrice,
                    SalesUnitPrice = e.SalesUnitPrice,
                    ImageName = e.ImageName,
                };
                return product;
            }
            return null;
        }

        public async Task<ProductViewModel> Insert(ProductViewModel e)
        {
            ProductViewModel returnObj = new ProductViewModel();
            if (e != null)
            {
                Product obj = new Product()
                {
                    ProductId = e.ProductId,
                    ProductName = e.ProductName,
                    CategoryId = e.CategoryId,
                    SupplierId = e.SupplierId,
                    PurchaseDate = e.PurchaseDate,
                    Quantity = e.Quantity,
                    UnitPrice = e.UnitPrice,
                    SalesUnitPrice = e.SalesUnitPrice,
                    ImageName = e.ImageName,
                };
                await _context.Products.AddAsync(obj);
                await Save();
                returnObj = await GetById(obj.ProductId);
            }
            return returnObj;
        }
        public async Task<ProductViewModel> Update(ProductViewModel e)
        {
            var result = await _context.Products.FirstOrDefaultAsync(p => p.ProductId == e.ProductId);
            ProductViewModel returnObj = new ProductViewModel();
            if (result != null)
            {
                result.ProductId = e.ProductId;
                result.CategoryId = e.CategoryId;
                result.SupplierId = e.SupplierId;
                result.ProductName = e.ProductName;
                result.PurchaseDate = e.PurchaseDate;
                result.Quantity = e.Quantity;
                result.UnitPrice = e.UnitPrice;
                result.SalesUnitPrice = e.SalesUnitPrice;
                result.ImageName = e.ImageName;
            }
            await Save();
            returnObj = await GetById(result.ProductId);
            return returnObj;
        }
        public async Task Delete(int id)
        {
            var result = await _context.Products.FirstOrDefaultAsync(p => p.ProductId == id);
            if (result != null)
            {
                _context.Products.Remove(result);
                await _context.SaveChangesAsync();
            }
        }
        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ProductViewModel>> GetProductByCategoryId(int categoryId)
        {
            if (categoryId > 0)
            {
                IEnumerable<ProductViewModel> productList = await _context.Products.Where(a => a.CategoryId == categoryId).Select(e => new ProductViewModel
                {
                    ProductId = e.ProductId,
                    ProductName = e.ProductName,
                    PurchaseDate = e.PurchaseDate,
                    Quantity = e.Quantity,
                    UnitPrice = e.UnitPrice,
                    SalesUnitPrice = e.SalesUnitPrice,
                    ImageName = e.ImageName,
                }).ToListAsync();
                return productList;
            }
            return null;
        }

        public async Task<IEnumerable<SupplierViewModel>> GetAllSupplierById(int supplier)
        {
            IEnumerable<SupplierViewModel> supplIst = await _context.Suppliers.Where(a => a.SupplierId == supplier).Select(e => new SupplierViewModel
            {
                SupplierId = e.SupplierId,
                CompanyName = e.CompanyName,
                ContactName = e.ContactName,
                Address = e.Address,
                Phone = e.Phone,
                Email = e.Email,
                ImageName = e.ImageName,
            }).ToListAsync();
            return supplIst;
        }

    }
    public class OrderRepository : IOrderRepository
    {
        private readonly HospitalManagementContext _context;
        public OrderRepository(HospitalManagementContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<OrderViewModel>> GetAll()
        {
            IEnumerable<OrderViewModel> order = await _context.Orders.Select(e => new OrderViewModel
            {
                OrderId = e.OrderId,
                CategoryId = e.Product.CategoryId,
                ProductId = e.ProductId,
                PatientAdmissionId = e.PatientAdmissionId,
                PatientName = e.PatientAdmissionInfo.PatientInfo.PatientName,
                Date_Of_Order = e.Date_Of_Order,
                OrderDeatils = e.OrderDeatils,
                Quantity = e.Quantity,
                SalesUnitPrice = e.SalesUnitPrice,
                ProductName = e.Product.ProductName
            }).ToListAsync();
            return order;
        }

        public async Task<OrderViewModel> GetById(int id)
        {
            Order e = await _context.Orders.AsNoTracking().FirstOrDefaultAsync(e => e.OrderId == id);
            if (e != null)
            {
                OrderViewModel order = new OrderViewModel
                {
                    OrderId = e.OrderId,
                    ProductId = e.ProductId,
                    PatientAdmissionId = e.PatientAdmissionId,
                    Date_Of_Order = e.Date_Of_Order,
                    OrderDeatils = e.OrderDeatils,
                    Quantity = e.Quantity,
                    SalesUnitPrice = e.SalesUnitPrice,
                };
                return order;
            }
            return null;
        }

        public async Task<OrderViewModel> Insert(OrderViewModel e)
        {
            OrderViewModel returnObj = new OrderViewModel();
            if (e != null)
            {
                Order obj = new Order()
                {
                    OrderId = e.OrderId,
                    PatientAdmissionId = e.PatientAdmissionId,
                    Date_Of_Order = e.Date_Of_Order,
                    OrderDeatils = e.OrderDeatils,
                    Quantity = e.Quantity,
                    ProductId = e.ProductId,
                    SalesUnitPrice = e.SalesUnitPrice,
                };
                await _context.Orders.AddAsync(obj);
                await Save();
                returnObj = await GetById(obj.OrderId);
            }
            return returnObj;
        }
        public async Task<OrderViewModel> Update(OrderViewModel e)
        {
            var result = await _context.Orders.FirstOrDefaultAsync(p => p.OrderId == e.OrderId);
            OrderViewModel returnObj = new OrderViewModel();
            if (result != null)
            {
                result.OrderId = e.OrderId;
                result.PatientAdmissionId = e.PatientAdmissionId;
                result.Date_Of_Order = e.Date_Of_Order;
                result.OrderDeatils = e.OrderDeatils;
                result.Quantity = e.Quantity;
                result.SalesUnitPrice = e.SalesUnitPrice;
                result.ProductId = e.ProductId;
            }
            await Save();
            returnObj = await GetById(result.OrderId);
            return returnObj;
        }
        public async Task Delete(int id)
        {
            var result = await _context.Orders.FirstOrDefaultAsync(p => p.OrderId == id);
            if (result != null)
            {
                _context.Orders.Remove(result);
                await _context.SaveChangesAsync();
            }
        }
        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

    }
    public class Product_In_The_OrderRepository : IProduct_In_The_OrderRepository
    {
        private readonly HospitalManagementContext _context;
        public Product_In_The_OrderRepository(HospitalManagementContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Product_In_The_OrderViewModel>> GetAll()
        {
            IEnumerable<Product_In_The_OrderViewModel> order = await _context.Product_In_The_Orders.Select(e => new Product_In_The_OrderViewModel
            {
                OrderItemId = e.OrderItemId,
                ProductId = e.ProductId,
                OrderId = e.OrderId,
                Quantity = e.Quantity,
            }).ToListAsync();
            return order;
        }

        public async Task<Product_In_The_OrderViewModel> GetById(int id)
        {
            Product_In_The_Order e = await _context.Product_In_The_Orders.AsNoTracking().FirstOrDefaultAsync(e => e.OrderItemId == id);
            if (e != null)
            {
                Product_In_The_OrderViewModel order = new Product_In_The_OrderViewModel
                {
                    OrderItemId = e.OrderItemId,
                    ProductId = e.ProductId,
                    OrderId = e.OrderId,
                    Quantity = e.Quantity,
                };
                return order;
            }
            return null;
        }

        public async Task<Product_In_The_OrderViewModel> Insert(Product_In_The_OrderViewModel e)
        {
            Product_In_The_OrderViewModel returnObj = new Product_In_The_OrderViewModel();
            if (e != null)
            {
                Product_In_The_Order obj = new Product_In_The_Order()
                {
                    OrderItemId = e.OrderItemId,
                    ProductId = e.ProductId,
                    OrderId = e.OrderId,
                    Quantity = e.Quantity,
                };
                await _context.Product_In_The_Orders.AddAsync(obj);
                await Save();
                returnObj = await GetById(obj.OrderItemId);
            }
            return returnObj;
        }
        public async Task<Product_In_The_OrderViewModel> Update(Product_In_The_OrderViewModel e)
        {
            var result = await _context.Product_In_The_Orders.FirstOrDefaultAsync(p => p.OrderItemId == e.OrderItemId);
            Product_In_The_OrderViewModel returnObj = new Product_In_The_OrderViewModel();
            if (result != null)
            {
                result.OrderItemId = e.OrderItemId;
                result.ProductId = e.ProductId;
                result.OrderId = e.OrderId;
                result.Quantity = e.Quantity;
            }
            await Save();
            returnObj = await GetById(result.OrderItemId);
            return returnObj;
        }
        public async Task Delete(int id)
        {
            var result = await _context.Product_In_The_Orders.FirstOrDefaultAsync(p => p.OrderItemId == id);
            if (result != null)
            {
                _context.Product_In_The_Orders.Remove(result);
                await _context.SaveChangesAsync();
            }
        }
        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

    }
}

