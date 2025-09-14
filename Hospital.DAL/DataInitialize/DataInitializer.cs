using Hospital.DAL.DataContext;
using Hospital.DAL.DataContext.Entities;

namespace Hospital.DAL.DataInitialize
{
    public static class DataInitializer
    {
        public static void Seed(AppDbContext context)
        {
            try
            { 
                var existingDepartments = context.Departments.ToList();
                foreach (var dept in existingDepartments)
                {
                    Console.WriteLine($"Mevcut: {dept.Name}");
                }

               
                var targetDepartments = new List<string>
                {
                    "Neurology",
                    "Pediatrics",
                    "Orthopedics",
                    "Cardiology",
                    "Emergency Medicine"
                };

               
                foreach (var departmentName in targetDepartments)
                {
                    var exists = context.Departments.Any(d => d.Name == departmentName);
                    if (!exists)
                    {
                        var description = GetDepartmentDescription(departmentName);
                        var newDepartment = new Department
                        {
                            Name = departmentName,
                            Description = description
                        };

                        context.Departments.Add(newDepartment);
                    }
                }

               
                var savedCount = context.SaveChanges();
                Console.WriteLine($"{savedCount} departman eklendi.");

               
                var finalCount = context.Departments.Count();
                Console.WriteLine($"Toplam departman sayısı: {finalCount}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hata oluştu: {ex.Message}");
            }
        }

        private static string GetDepartmentDescription(string departmentName)
        {
            return departmentName switch
            {
                "Neurology" => "Brain and nervous system disorders",
                "Pediatrics" => "Child healthcare and development",
                "Orthopedics" => "Bones, joints and musculoskeletal system",
                "Cardiology" => "Heart and cardiovascular system",
                "Emergency Medicine" => "Emergency and critical care",
                _ => "Medical department"
            };
        }
    }
}