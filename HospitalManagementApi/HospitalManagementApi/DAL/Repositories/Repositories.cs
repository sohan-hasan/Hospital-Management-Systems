using HospitalManagementApi.DAL.IRepository;
using HospitalManagementApi.Models;
using HospitalManagementApi.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementApi.DAL.Repositories
{
    public class DoctorsInfoRepository : IDoctorsInfoRepository
    {
        private readonly HospitalManagementSystemContext _context;
        public DoctorsInfoRepository(HospitalManagementSystemContext contex)
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

<<<<<<< HEAD
    public class WordInfoRepository : IWordInfoRepsoitory
=======
    public class WardInfoRepository : IWardInfoRepsoitory
>>>>>>> d553aee8a1ed7a4df11e28f99813e6f6e67aeb79
    {
        private readonly HospitalManagementSystemContext _context;
        public WardInfoRepository(HospitalManagementSystemContext contex)
        {
            _context = contex;
        }

        public async Task<IEnumerable<WardInfoViewModel>> GetAll()
        {
            IEnumerable<WardInfoViewModel> listOfWards = await _context.WardInfos.Select(e => new WardInfoViewModel
            {
<<<<<<< HEAD
                WordNo = e.WordNo,
                WordName = e.WordName,
                WordCost = e.WordCost,
=======
                WardNo = e.WardNo,
                WardName = e.WardName,
                WardCost = e.WardCost,
>>>>>>> d553aee8a1ed7a4df11e28f99813e6f6e67aeb79
                BookingStatus = e.BookingStatus,
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
                    BookingStatus = e.BookingStatus,
                    FloorNo = e.FloorNo,
                    ImageName = e.ImageName
                };
<<<<<<< HEAD
                return word;
            }
            return null;
        }
        public async Task<WordInfoViewModel> Insert(WordInfoViewModel e)
        {
            WordInfoViewModel returnObj = new WordInfoViewModel();
            if (e != null)
            {
                WordInfo obj = new WordInfo()
                {
                    WordNo = e.WordNo,
                    WordName = e.WordName,
                    WordCost = e.WordCost,
                    BookingStatus = e.BookingStatus,
                    FloorNo = e.FloorNo,
                    ImageName = e.ImageName
                };
                await _context.WordInfos.AddAsync(obj);
                await Save();
                returnObj = await GetById(obj.WordNo);

            }
            return returnObj;
        }
        public async Task<WordInfoViewModel> Update(WordInfoViewModel e)
=======
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
                    BookingStatus = e.BookingStatus,
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
                result.BookingStatus = e.BookingStatus;
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
    public class CabinInfoRepository : ICabinInfoRepository
    {
        private readonly HospitalManagementSystemContext _context;
        public CabinInfoRepository(HospitalManagementSystemContext contex)
        {
            _context = contex;
        }
        public async Task<IEnumerable<CabinInfoViewModel>> GetAll()
        {
            IEnumerable<CabinInfoViewModel> listOfCabin = await _context.CabinInfos.Select(e => new CabinInfoViewModel
            {
                CabinId = e.CabinId,
                CabinName = e.CabinName,
                CabinType = e.CabinType,
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
                    CabinType = e.CabinType,
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
                    CabinType = e.CabinType,
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
>>>>>>> d553aee8a1ed7a4df11e28f99813e6f6e67aeb79
        {
            var result = await _context.CabinInfos.FirstOrDefaultAsync(h => h.CabinId == e.CabinId);
            CabinInfoViewModel returnObj = new CabinInfoViewModel();
            if (result != null)
            {
                result.CabinId = e.CabinId;
                result.CabinName = e.CabinName;
                result.CabinType = e.CabinType;
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

    }
    public class BedInfoRepository : IBedInfoRepository
    {
        private readonly HospitalManagementSystemContext _context;
        public BedInfoRepository(HospitalManagementSystemContext contex)
        {
            _context = contex;
        }

        public async Task<IEnumerable<BedInfoViewModel>> GetAll()
        {
            IEnumerable<BedInfoViewModel> listOfBed = await _context.BedInfos.Select(e => new BedInfoViewModel
            {
                BedId = e.BedId,
                BedNo = e.BedNo,
                WardNo = e.WardNo

            }).ToListAsync();
            return listOfBed;
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
                    WardNo = e.WardNo
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
                    WardNo = e.WardNo
                };
                await _context.BedInfos.AddAsync(obj);
                await Save();
                returnObj = await GetById(obj.BedId);

            }
            return returnObj;
        }


        public async Task<BedInfoViewModel> Update(BedInfoViewModel e)
        {
            var result = await _context.BedInfos.FirstOrDefaultAsync(h => h.BedId == e.BedId);
            BedInfoViewModel returnObj = new BedInfoViewModel();
            if (result != null)
            {
                result.BedId = e.BedId;
                result.BedNo = e.BedNo;
                result.WardNo = e.WardNo;

            }
            await Save();
            returnObj = await GetById(result.BedId);
            return returnObj;
        }
        public async Task Save()
        {
            await _context.SaveChangesAsync();
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
<<<<<<< HEAD
    }
    //public class CabinInfoRepository : ICabinInfoRepository
    //{
    //    private readonly HospitalManagementSystemContext _context;
    //    public CabinInfoRepository(HospitalManagementSystemContext contex)
    //    {
    //        _context = contex;
    //    }
    //    public async Task<IEnumerable<CabinInfoViewModel>> GetAll()
    //    {
    //        IEnumerable<CabinInfoViewModel> listOfCabin = await _context.CabinInfos.Select(e => new CabinInfoViewModel
    //        {
    //            CabinId = e.CabinId,
    //            CabinName = e.CabinName,
    //            CabinType = e.CabinType,
    //            CabinSize = e.CabinSize,
    //            FloorNo = e.FloorNo,
    //            CostPerDay = e.CostPerDay,
    //            BookingStatus = e.BookingStatus,
    //            CabinDirection = e.CabinDirection,
    //            ImageName = e.ImageName
    //        }).ToListAsync();
    //        return listOfCabin;
    //    }

    //    public async Task<CabinInfoViewModel> GetById(int id)
    //    {
    //        CabinInfo e = await _context.CabinInfos.AsNoTracking().FirstOrDefaultAsync(e => e.CabinId == id);
    //        if (e != null)
    //        {
    //            CabinInfoViewModel cabin = new CabinInfoViewModel
    //            {
    //                CabinId = e.CabinId,
    //                CabinName = e.CabinName,
    //                CabinType = e.CabinType,
    //                CabinSize = e.CabinSize,
    //                FloorNo = e.FloorNo,
    //                CostPerDay = e.CostPerDay,
    //                BookingStatus = e.BookingStatus,
    //                CabinDirection = e.CabinDirection,
    //                ImageName = e.ImageName
    //            };
    //            return cabin;

    //        }
    //        return null;
    //    }

    //    public async Task<CabinInfoViewModel> Insert(CabinInfoViewModel e)
    //    {
    //        CabinInfoViewModel returnObj = new CabinInfoViewModel();
    //        if (e != null)
    //        {
    //            CabinInfo obj = new CabinInfo()
    //            {

    //                CabinId = e.CabinId,
    //                CabinName = e.CabinName,
    //                CabinType = e.CabinType,
    //                CabinSize = e.CabinSize,
    //                FloorNo = e.FloorNo,
    //                CostPerDay = e.CostPerDay,
    //                BookingStatus = e.BookingStatus,
    //                CabinDirection = e.CabinDirection,
    //                ImageName = e.ImageName,
    //            };
    //            await _context.CabinInfos.AddAsync(obj);
    //            await Save();
    //            returnObj = await GetById(obj.CabinId);

    //        }
    //        return returnObj;
    //    }
    //    public async Task<CabinInfoViewModel> Update(CabinInfoViewModel e)
    //    {
    //        var result = await _context.CabinInfos.FirstOrDefaultAsync(h => h.CabinId == e.CabinId);
    //        CabinInfoViewModel returnObj = new CabinInfoViewModel();
    //        if (result != null)
    //        {
    //            result.CabinId = e.CabinId;
    //            result.CabinName = e.CabinName;
    //            result.CabinType = e.CabinType;
    //            result.CabinSize = e.CabinSize;
    //            result.FloorNo = e.FloorNo;
    //            result.CostPerDay = e.CostPerDay;
    //            result.BookingStatus = e.BookingStatus;
    //            result.CabinDirection = e.CabinDirection;
    //            result.ImageName = e.ImageName;
    //        }
    //        await Save();
    //        returnObj = await GetById(result.CabinId);
    //        return returnObj;
    //    }

    //    public async Task Delete(int id)
    //    {
    //        var result = await _context.CabinInfos.FirstOrDefaultAsync(p => p.CabinId == id);
    //        if (result != null)
    //        {
    //            _context.CabinInfos.Remove(result);
    //            await _context.SaveChangesAsync();
    //        }
    //    }

    //    public async Task Save()
    //    {
    //        await _context.SaveChangesAsync();
    //    }

    //}
=======

    }
    public class TestInfoRepository : ITestInfoRepository
    {
        private readonly HospitalManagementSystemContext _context;
        public TestInfoRepository(HospitalManagementSystemContext contex)
        {
            _context = contex;
        }
        public async Task<IEnumerable<TestInfoViewModel>> GetAll()
        {
            IEnumerable<TestInfoViewModel> listOfTest = await _context.TestInfos.Select(e => new TestInfoViewModel
            {
                TestId = e.TestId,
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
    }
    public class AppointmentInfoRepository : IAppointmentInfoRepository
    {
        private readonly HospitalManagementSystemContext _context;
        public AppointmentInfoRepository(HospitalManagementSystemContext contex)
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
                SerialNo = e.SerialNo,
                AppointmentTime = e.AppointmentTime,
                ArrivalTime = e.ArrivalTime,
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
                    ArrivalTime = e.ArrivalTime,
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
                    ArrivalTime = e.ArrivalTime,
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
                result.ArrivalTime = e.ArrivalTime;
                result.NextAppointmentDate = e.NextAppointmentDate;
                result.Remark = e.Remark;

            }
            await Save();
            returnObj = await GetById(result.AppointmentId);
            return returnObj;
        }
        public async Task Save()
        {
            await _context.SaveChangesAsync();
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
    }
    public class OutDoorConsultancyRepository : IOutDoorConsultancyRepository
    {
        private readonly HospitalManagementSystemContext _context;
        public OutDoorConsultancyRepository(HospitalManagementSystemContext contex)
        {
            _context = contex;
        }
        public async Task<IEnumerable<OutDoorConsultancyViewModel>> GetAll()
        {
            IEnumerable<OutDoorConsultancyViewModel> listOfConsultancy = await _context.OutDoorConsultancies.Select(e => new OutDoorConsultancyViewModel
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

    }
    public class LabandTestEntryInfoRepository : ILabandTestEntry
        {
            private readonly HospitalManagementSystemContext _context;
            public LabandTestEntryInfoRepository(HospitalManagementSystemContext contex)
            {
                _context = contex;
            }       
            
            public async Task<IEnumerable<LabandTestEntryInfoViewModel>> GetAll()
            {
                IEnumerable<LabandTestEntryInfoViewModel> listOfLabTest = await _context.LabandTestEntryInfos.Select(e => new LabandTestEntryInfoViewModel
                {
                    InvoiceId = e.InvoiceId,
                    TestId = e.TestId,
                    ReceiveDate = e.ReceiveDate,
                    DeliveryDate = e.DeliveryDate,
                    Sample = e.Sample,
                    Remarks = e.Remarks,               
                }).ToListAsync();
                return listOfLabTest;
            }

            public async Task<LabandTestEntryInfoViewModel> GetById(int id)
            {
                LabandTestEntryInfo e = await _context.LabandTestEntryInfos.AsNoTracking().FirstOrDefaultAsync(e => e.LabandTestId == id);
                if (e != null)
                {
                    LabandTestEntryInfoViewModel word = new LabandTestEntryInfoViewModel
                    {
                        InvoiceId = e.InvoiceId,
                        TestId = e.TestId,
                        ReceiveDate = e.ReceiveDate,
                        DeliveryDate = e.DeliveryDate,
                        Sample = e.Sample,
                        Remarks = e.Remarks,
                    };
                    return word;
                }
                return null;
            }

            public async Task<LabandTestEntryInfoViewModel> Insert(LabandTestEntryInfoViewModel e)
            {
                LabandTestEntryInfoViewModel returnObj = new LabandTestEntryInfoViewModel();
                if (e != null)
                {
                    LabandTestEntryInfo obj = new LabandTestEntryInfo()
                    {
                        InvoiceId = e.InvoiceId,
                        TestId = e.TestId,
                        ReceiveDate = e.ReceiveDate,
                        DeliveryDate = e.DeliveryDate,
                        Sample = e.Sample,
                        Remarks = e.Remarks,
                    };
                    await _context.LabandTestEntryInfos.AddAsync(obj);
                    await Save();
                    returnObj = await GetById(obj.TestId);

                }
                return returnObj;
            }
            public async Task<LabandTestEntryInfoViewModel> Update(LabandTestEntryInfoViewModel e)
            {
                var result = await _context.LabandTestEntryInfos.FirstOrDefaultAsync(h => h.LabandTestId == e.LabandTestId);
                LabandTestEntryInfoViewModel returnObj = new LabandTestEntryInfoViewModel();
                if (result != null)
                {
                    result.InvoiceId = e.InvoiceId;
                    result.TestId = e.TestId;
                    result.ReceiveDate = e.ReceiveDate;
                    result.DeliveryDate = e.DeliveryDate;
                    result.Sample = e.Sample;
                    result.Remarks = e.Remarks;
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
                var result = await _context.LabandTestEntryInfos.FirstOrDefaultAsync(p => p.TestId == id);
                if (result != null)
                {
                    _context.LabandTestEntryInfos.Remove(result);
                    await _context.SaveChangesAsync();
                }
            }

        }
>>>>>>> d553aee8a1ed7a4df11e28f99813e6f6e67aeb79
}
