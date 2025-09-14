using Hospital.Business.Services.Abstract;
using Hospital.DAL.DataContext;
using Hospital.DAL.DataContext.Entities;
using Hospital.DAL.Repositories.Abstract;
namespace Hospital.Business.Services.Concrete
{
    public class DoctorService : GenericService<Doctor>, IDoctorService
    {
        public DoctorService(IGenericRepository<Doctor> repository, AppDbContext dbContext)
            : base(repository, dbContext)
        {
        }
    }
}
