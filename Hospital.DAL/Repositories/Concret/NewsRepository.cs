using Hospital.DAL.DataContext;
using Hospital.DAL.DataContext.Entities;
using Hospital.DAL.Repositories.Abstract;
namespace Hospital.DAL.Repositories.Concret
{
    public class NewsRepository:GenericRepository<News> ,INewsRepository
    {
        public NewsRepository(AppDbContext context) : base(context) { }
    }
}
