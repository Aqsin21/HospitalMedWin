using Hospital.DAL.DataContext;
using Hospital.DAL.DataContext.Entities;
using Hospital.DAL.Repositories.Abstract;
namespace Hospital.DAL.Repositories.Concret
{
    public class DoctorRepository:GenericRepository<Doctor> ,IDoctorRepository
    {
        public DoctorRepository(AppDbContext context) : base(context) { }
    }
}
