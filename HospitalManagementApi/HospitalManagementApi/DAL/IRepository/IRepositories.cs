﻿using HospitalManagementApi.ViewModels;
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
    {
        Task<IEnumerable<WordInfoViewModel>> GetAll();
        Task<WordInfoViewModel> GetById(int id);
        Task<WordInfoViewModel> Insert(WordInfoViewModel e);
        Task<WordInfoViewModel> Update(WordInfoViewModel e);
        Task Delete(int id);
        Task Save();
    }
=======
    public interface ICabinInfoRepository
    {
        Task<IEnumerable<CabinInfoViewModel>> GetAll();
        Task<CabinInfoViewModel> GetById(int id);
        Task<CabinInfoViewModel> Insert(CabinInfoViewModel e);
        Task<CabinInfoViewModel> Update(CabinInfoViewModel e);
        Task Delete(int id);
        Task Save();
    }

>>>>>>> 636893cce02ed540b9316fa1ea83496a3a5b5b16
}
