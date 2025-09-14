using Hospital.Business.Services.Abstract;
using Hospital.DAL.DataContext;
using Hospital.DAL.DataContext.Entities;
using Hospital.DAL.Repositories.Abstract;
namespace Hospital.Business.Services.Concrete
{
    public class DepartmentService : GenericService<Department>, IDepartmentService
    {
        public DepartmentService(IGenericRepository<Department> departmentRepository, AppDbContext dbContext)
            : base(departmentRepository, dbContext)
        {
        }
    }
}
