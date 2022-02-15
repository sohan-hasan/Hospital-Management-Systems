using HospitalManagementApi.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementApi.DAL.IRepositories
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
    public interface IPatientMedicineInfoRepository
    {
        Task<IEnumerable<PatientMedicineInfoViewModel>> GetAll();
        Task<PatientMedicineInfoViewModel> GetById(int id);
        Task<PatientMedicineInfoViewModel> Insert(PatientMedicineInfoViewModel id);
        Task<PatientMedicineInfoViewModel> Update(PatientMedicineInfoViewModel id);
        Task Delete(int id);
        Task Save();
    }
    public interface ITestInfoRepository
    {
        Task<IEnumerable<TestInfoViewModel>> GetAll();
        Task<TestInfoViewModel> GetById(int id);
        Task<IEnumerable<TestInfoViewModel>> GetAllTestByCatagoryId(int categoryId);
        Task<TestInfoViewModel> Insert(TestInfoViewModel e);
        Task<TestInfoViewModel> Update(TestInfoViewModel e);
        Task Delete(int id);
        Task Save();
    }
    public interface ITestCategoryRepository
    {
        Task<IEnumerable<TestCategoryViewModel>> GetAll();
        Task<TestCategoryViewModel> GetById(int id);
        Task<TestCategoryViewModel> Insert(TestCategoryViewModel e);
        Task<TestCategoryViewModel> Update(TestCategoryViewModel e);
        Task Delete(int id);
        Task Save();
    }
    public interface IPatientAdmissionInfoRepository
    {
        Task<IEnumerable<PatientAdmissionInfoViewModel>> GetAll();
        Task<PatientAdmissionInfoViewModel> GetById(int id);
        Task<PatientAdmissionInfoViewModel> Insert(PatientAdmissionInfoViewModel e);
        Task<PatientAdmissionInfoViewModel> Update(PatientAdmissionInfoViewModel e);
        Task Delete(int id);
        Task Save();
    }
    public interface IPatientInfoRepository
    {
        Task<IEnumerable<PatientInfoViewModel>> GetAll();
        Task<PatientInfoViewModel> GetById(int id);
        Task<PatientInfoViewModel> Insert(PatientInfoViewModel e);
        Task<PatientInfoViewModel> Update(PatientInfoViewModel e);
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

        Task<int> GetSerialNo(int id, string appointmentDate);

    }
    public interface IOutDoorConsultancyRepository
    {
        Task<IEnumerable<OutDoorConsultancyViewModel>> GetAll();
        Task<OutDoorConsultancyViewModel> GetById(int id);
        Task<OutDoorConsultancyViewModel> Insert(OutDoorConsultancyViewModel e);
        Task<OutDoorConsultancyViewModel> Update(OutDoorConsultancyViewModel e);
        Task Delete(int id);
        Task Save();
        Task<int> GetSerialNo(int id, string appointmentDate);
    }
    public interface ICabinInfoRepository
    {
        Task<IEnumerable<CabinInfoViewModel>> GetAll();
        Task<IEnumerable<CabinInfoViewModel>> GetByTypeId(int cabinTypeId);
        Task<CabinInfoViewModel> GetById(int id);
        Task<CabinInfoViewModel> Insert(CabinInfoViewModel e);
        Task<CabinInfoViewModel> Update(CabinInfoViewModel e);
        Task Delete(int id);
        Task Save();
    }
    public interface IWardInfoRepsoitory
    {
        Task<IEnumerable<WardInfoViewModel>> GetAll();
        Task<WardInfoViewModel> GetById(int id);
        Task<WardInfoViewModel> Insert(WardInfoViewModel e);
        Task<WardInfoViewModel> Update(WardInfoViewModel e);
        Task Delete(int id);
        Task Save();
    }
    public interface IBedInfoRepsoitory
    {
        Task<IEnumerable<BedInfoViewModel>> GetAll();
        Task<BedInfoViewModel> GetById(int id);
        Task<IEnumerable<BedInfoViewModel>> GetByWardNo(int cabinTypeId);
        Task<BedInfoViewModel> Insert(BedInfoViewModel e);
        Task<BedInfoViewModel> Update(BedInfoViewModel e);
        Task Delete(int id);
        Task Save();
    }
    public interface ICabinTypeRepository
    {
        Task<IEnumerable<CabinTypeInfoViewModel>> GetAll();
        Task<CabinTypeInfoViewModel> GetById(int id);
        Task<CabinTypeInfoViewModel> Insert(CabinTypeInfoViewModel e);
        Task<CabinTypeInfoViewModel> Update(CabinTypeInfoViewModel e);
        Task Delete(int id);
        Task Save();
    }
    public interface IPatientTestingInfoRepository
    {
        Task<IEnumerable<PatientTestingInfoViewModel>> GetAll();
        Task<PatientTestingInfoViewModel> GetById(int id);
        Task<PatientTestingInfoViewModel> Insert(PatientTestingInfoViewModel id);
        Task<PatientTestingInfoViewModel> Update(PatientTestingInfoViewModel id);
        Task Delete(int id);
        Task Save();
    }

    public interface ISupplierRepository
    {
        Task<IEnumerable<SupplierViewModel>> GetAll();
        Task<SupplierViewModel> GetById(int id);
        Task<SupplierViewModel> Insert(SupplierViewModel id);
        Task<SupplierViewModel> Update(SupplierViewModel id);
        Task Delete(int id);
        Task Save();
    }
    public interface ICategoryRepository
    {
        Task<IEnumerable<CategoryViewModel>> GetAll();
        Task<CategoryViewModel> GetById(int id);
        Task<CategoryViewModel> Insert(CategoryViewModel id);
        Task<CategoryViewModel> Update(CategoryViewModel id);
        Task Delete(int id);
        Task Save();
    }
    public interface IProductRepository
    {
        Task<IEnumerable<ProductViewModel>> GetAll();
        Task<ProductViewModel> GetById(int id);
        Task<IEnumerable<ProductViewModel>> GetProductByCategoryId(int categoryid);
        Task<IEnumerable<SupplierViewModel>> GetAllSupplierById(int supplier);
        Task<ProductViewModel> Insert(ProductViewModel id);
        Task<ProductViewModel> Update(ProductViewModel id);
        Task Delete(int id);
        Task Save();
    }

    public interface IProduct_In_The_OrderRepository
    {
        Task<IEnumerable<Product_In_The_OrderViewModel>> GetAll();
        Task<Product_In_The_OrderViewModel> GetById(int id);

        Task<Product_In_The_OrderViewModel> Insert(Product_In_The_OrderViewModel id);
        Task<Product_In_The_OrderViewModel> Update(Product_In_The_OrderViewModel id);
        Task Delete(int id);
        Task Save();
    }
    public interface IOrderRepository
    {
        Task<IEnumerable<OrderViewModel>> GetAll();
        Task<OrderViewModel> GetById(int id);
        Task<OrderViewModel> Insert(OrderViewModel id);
        Task<OrderViewModel> Update(OrderViewModel id);
        Task Delete(int id);
        Task Save();
    }

    public interface IDepartmentRepository
    {
        Task<IEnumerable<DepartmentViewModel>> GetAll();
        Task<DepartmentViewModel> GetById(int id);
        Task<DepartmentViewModel> Insert(DepartmentViewModel e);
        Task<DepartmentViewModel> Update(DepartmentViewModel e);
        Task Delete(int id);
        Task Save();
    }
    public interface IDesignationRepository
    {
        Task<IEnumerable<DesignationViewModel>> GetAll();
        Task<DesignationViewModel> GetById(int id);
        Task<DesignationViewModel> Insert(DesignationViewModel e);
        Task<DesignationViewModel> Update(DesignationViewModel e);
        Task Delete(int id);
        Task Save();
    }
    public interface IEducationRepository
    {
        Task<IEnumerable<EducationViewModel>> GetAll();
        Task<EducationViewModel> GetById(int id);
        Task<IEnumerable<EducationViewModel>> GetEduByEmpId(int empId);
        Task<EducationViewModel> Insert(EducationViewModel e);
        Task<EducationViewModel> Update(EducationViewModel e);
        Task Delete(int id);
        Task Save();
    }
    public interface IExperienceRepository
    {
        Task<IEnumerable<ExperienceViewModel>> GetAll();
        Task<ExperienceViewModel> GetById(int id);
        Task<IEnumerable<ExperienceViewModel>> GetExpByEmpId(int empId);
        Task<ExperienceViewModel> Insert(ExperienceViewModel e);
        Task<ExperienceViewModel> Update(ExperienceViewModel e);
        Task Delete(int id);
        Task Save();
    }
    public interface IEmployeeRepository
    {
        Task<IEnumerable<EmployeeViewModel>> GetAll();
        Task<EmployeeViewModel> GetById(int id);
        Task<EmployeeViewModel> Insert(EmployeeViewModel e);
        Task<EmployeeViewModel> Update(EmployeeViewModel e);
        Task<DepartmentViewModel> GetDepartmentById(int id);
        Task<DesignationViewModel> GetDesignationById(int id);
        Task Delete(int id);
        Task Save();
    }
   

}
