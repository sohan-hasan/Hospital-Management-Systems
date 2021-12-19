using HospitalManagementApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementApi.DAL.IRepository
{
    public interface IDoctorsInfoRepository
    {
        Task<IEnumerable<DoctorsInfoViewModel>> GetAll();
        Task<DoctorsInfoViewModel> GetById(int id);
        Task<DoctorsInfoViewModel> Insert(DoctorsInfoViewModel e);
        Task<DoctorsInfoViewModel> Update(DoctorsInfoViewModel e);
        Task Delete(int id);
        Task Save();
    }

<<<<<<< HEAD
    public interface IWordInfoRepsoitory
=======
    public interface IWardInfoRepsoitory
>>>>>>> d553aee8a1ed7a4df11e28f99813e6f6e67aeb79
    {
        Task<IEnumerable<WardInfoViewModel>> GetAll();
        Task<WardInfoViewModel> GetById(int id);
        Task<WardInfoViewModel> Insert(WardInfoViewModel e);
        Task<WardInfoViewModel> Update(WardInfoViewModel e);
        Task Delete(int id);
        Task Save();
    }

    public interface ICabinInfoRepository
    {
        Task<IEnumerable<CabinInfoViewModel>> GetAll();
        Task<CabinInfoViewModel> GetById(int id);
        Task<CabinInfoViewModel> Insert(CabinInfoViewModel e);
        Task<CabinInfoViewModel> Update(CabinInfoViewModel e);
        Task Delete(int id);
        Task Save();
    }
<<<<<<< HEAD
=======
    public interface IBedInfoRepository
    {
        Task<IEnumerable<BedInfoViewModel>> GetAll();
        Task<BedInfoViewModel> GetById(int id);
        Task<BedInfoViewModel> Insert(BedInfoViewModel e);
        Task<BedInfoViewModel> Update(BedInfoViewModel e);
        Task Delete(int id);
        Task Save();
    }
    public interface ITestInfoRepository
    {
        Task<IEnumerable<TestInfoViewModel>> GetAll();
        Task<TestInfoViewModel> GetById(int id);
        Task<TestInfoViewModel> Insert(TestInfoViewModel e);
        Task<TestInfoViewModel> Update(TestInfoViewModel e);
        Task Delete(int id);
        Task Save();
    }
    public interface IAppointmentInfoRepository
    {
        Task<IEnumerable<AppointmentInfoViewModel>> GetAll();
        Task<AppointmentInfoViewModel> GetById(int id);
        Task<AppointmentInfoViewModel> Insert(AppointmentInfoViewModel e);
        Task<AppointmentInfoViewModel> Update(AppointmentInfoViewModel e);
        Task Delete(int id);
        Task Save();
    }
    public interface IOutDoorConsultancyRepository
    {
        Task<IEnumerable<OutDoorConsultancyViewModel>> GetAll();
        Task<OutDoorConsultancyViewModel> GetById(int id);
        Task<OutDoorConsultancyViewModel> Insert(OutDoorConsultancyViewModel e);
        Task<OutDoorConsultancyViewModel> Update(OutDoorConsultancyViewModel e);
        Task Delete(int id);
        Task Save();
    }
    public interface ILabandTestEntry
    {
        Task<IEnumerable<LabandTestEntryInfoViewModel>> GetAll();
        Task<LabandTestEntryInfoViewModel> GetById(int id);
        Task<LabandTestEntryInfoViewModel> Insert(LabandTestEntryInfoViewModel e);
        Task<LabandTestEntryInfoViewModel> Update(LabandTestEntryInfoViewModel e);
        Task Delete(int id);
        Task Save();
    }
>>>>>>> d553aee8a1ed7a4df11e28f99813e6f6e67aeb79
}
