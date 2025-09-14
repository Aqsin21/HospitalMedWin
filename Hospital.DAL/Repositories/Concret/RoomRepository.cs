using Hospital.DAL.DataContext;
using Hospital.DAL.DataContext.Entities;
using Hospital.DAL.Repositories.Abstract;
namespace Hospital.DAL.Repositories.Concret
{
    public class RoomRepository:GenericRepository<Room> ,IRoomRepository
    {
        public RoomRepository(AppDbContext context) : base(context) { }
    }
}
