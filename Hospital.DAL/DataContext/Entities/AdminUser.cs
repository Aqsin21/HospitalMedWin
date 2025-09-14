namespace Hospital.DAL.DataContext.Entities
{
    public enum AdminRole
    {
        Admin,
        SuperAdmin
    }
    public class AdminUser:BaseEntity
    {
        public required string UserName { get; set; }
        public required string Password { get; set; }
        public AdminRole Role { get; set; }
    }
}
