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
}
