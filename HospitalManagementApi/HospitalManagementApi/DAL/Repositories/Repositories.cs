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
    {
        private readonly HospitalManagementSystemContext _context;
        public WordInfoRepository(HospitalManagementSystemContext contex)
        {
            _context = contex;
        }

        public async Task<IEnumerable<WordInfoViewModel>> GetAll()
        {
            IEnumerable<WordInfoViewModel> listOfWords = await _context.WordInfos.Select(e => new WordInfoViewModel
            {
                WordNo=e.WordNo,
                WordName=e.WordName,
                WordCost=e.WordCost,
                BookingStatus=e.BookingStatus,
                FloorNo=e.FloorNo,
                ImageName=e.ImageName
            }).ToListAsync();
            return listOfWords;
        }

        public async Task<WordInfoViewModel> GetById(int id)
        {
            WordInfo e = await _context.WordInfos.AsNoTracking().FirstOrDefaultAsync(e => e.WordNo == id);
            if (e != null)
            {
                WordInfoViewModel word = new WordInfoViewModel
                {
                    WordNo = e.WordNo,
                    WordName = e.WordName,
                    WordCost = e.WordCost,
                    BookingStatus = e.BookingStatus,
                    FloorNo = e.FloorNo,
                    ImageName = e.ImageName
                };
                return word;
=======
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
>>>>>>> 636893cce02ed540b9316fa1ea83496a3a5b5b16
            }
            return null;
        }

<<<<<<< HEAD
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
=======
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
>>>>>>> 636893cce02ed540b9316fa1ea83496a3a5b5b16
            }
            return returnObj;
        }

<<<<<<< HEAD
      
        public async Task<WordInfoViewModel> Update(WordInfoViewModel e)
        {
            var result = await _context.WordInfos.FirstOrDefaultAsync(h => h.WordNo == e.WordNo);
            WordInfoViewModel returnObj = new WordInfoViewModel();
            if (result != null)
            {
                result.WordNo = e.WordNo;
                result.WordName = e.WordName;
                result.WordCost = e.WordCost;
                result.BookingStatus = e.BookingStatus;
                result.FloorNo = e.FloorNo;
                result.ImageName = e.ImageName;
            }
            await Save();
            returnObj = await GetById(result.WordNo);
            return returnObj;
        }
        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            var result = await _context.WordInfos.FirstOrDefaultAsync(p => p.WordNo == id);
            if (result != null)
            {
                _context.WordInfos.Remove(result);
                await _context.SaveChangesAsync();
            }
        }
=======

        public async Task<CabinInfoViewModel> Update(CabinInfoViewModel e)
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
>>>>>>> 636893cce02ed540b9316fa1ea83496a3a5b5b16
    }
}
