using Hospital.Business.Services.Abstract;
using Hospital.DAL.DataContext;
using Hospital.DAL.DataContext.Entities;
using Hospital.DAL.Repositories.Abstract;
namespace Hospital.Business.Services.Concrete
{
    public class RoomService : GenericService<Room>, IRoomService
    {
        public RoomService(IRoomRepository roomRepository, AppDbContext dbContext)
            : base(roomRepository, dbContext)
        {
        }
    }
}
