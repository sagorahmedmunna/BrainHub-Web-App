using BrainHub.DomainLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BrainHub.DomainLayer.Data
{
    public static class ApplicationDbContextSeeder
    {
        public static void Seed(ModelBuilder builder)
        {
            // Seed Roles
            builder.Entity<IdentityRole<int>>().HasData(
                new IdentityRole<int> { Id = 1, Name = "Admin", NormalizedName = "ADMIN" },
                new IdentityRole<int> { Id = 2, Name = "Employee", NormalizedName = "EMPLOYEE" }
            );

            // password hasher instance
            var hasher = new PasswordHasher<IdentityUser<int>>();

            // Seed Admin User
            var adminId = 1;
            var adminUser = new IdentityUser<int>
            {
                Id = adminId,
                UserName = "admin@brainhub.com",
                NormalizedUserName = "ADMIN@BRAINHUB.COM",
                Email = "admin@brainhub.com",
                NormalizedEmail = "ADMIN@BRAINHUB.COM",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "admin123"),
                SecurityStamp = Guid.NewGuid().ToString()
            };
            builder.Entity<IdentityUser<int>>().HasData(adminUser);
            // Assign Admin Role
            builder.Entity<IdentityUserRole<int>>().HasData(
                new IdentityUserRole<int> { UserId = adminId, RoleId = 1 }
            );

            // Seed SBUs
            builder.Entity<Sbu>().HasData(
                new Sbu { Id = 1, Name = "Admin", ImageUrl = null },
                new Sbu { Id = 2, Name = "Finance", ImageUrl = null },
                new Sbu { Id = 3, Name = "IT", ImageUrl = null },
                new Sbu { Id = 4, Name = "HR", ImageUrl = null },
                new Sbu { Id = 5, Name = "Marketing", ImageUrl = null },
                new Sbu { Id = 6, Name = "Sales", ImageUrl = null },
                new Sbu { Id = 7, Name = "Operations", ImageUrl = null },
                new Sbu { Id = 8, Name = "Customer Support", ImageUrl = null },
                new Sbu { Id = 9, Name = "Research & Development", ImageUrl = null },
                new Sbu { Id = 10, Name = "Legal", ImageUrl = null },
                new Sbu { Id = 11, Name = "Procurement", ImageUrl = null },
                new Sbu { Id = 12, Name = "Logistics", ImageUrl = null },
                new Sbu { Id = 13, Name = "Quality Assurance", ImageUrl = null },
                new Sbu { Id = 14, Name = "Business Intelligence", ImageUrl = null },
                new Sbu { Id = 15, Name = "Training & Development", ImageUrl = null }
            );

            // Seed Employees
            var employees = new List<Employee>
            {
                new Employee { Id = 1, Name = "Admin", Number = "01111111111", SbuId = 1, UserId = 1 }, // Admin employee

                new Employee { Id = 2, Name = "John Doe", Number = "01710000001", SbuId = 2, UserId = 101, CustomRoleId = 4 },
                new Employee { Id = 3, Name = "Jane Smith", Number = "01710000002", SbuId = 3, UserId = 102, CustomRoleId = 4 },
                new Employee { Id = 4, Name = "Michael Johnson", Number = "01710000003", SbuId = 4, UserId = 103, CustomRoleId = 4 },
                new Employee { Id = 5, Name = "Emily Davis", Number = "01710000004", SbuId = 2, UserId = 104, CustomRoleId = 4 },
                new Employee { Id = 6, Name = "Daniel Brown", Number = "01710000005", SbuId = 3, UserId = 105, CustomRoleId = 4 },
                new Employee { Id = 7, Name = "Sophia Wilson", Number = "01710000006", SbuId = 4, UserId = 106, CustomRoleId = 4 },
                new Employee { Id = 8, Name = "David Miller", Number = "01710000007", SbuId = 2, UserId = 107, CustomRoleId = 4 },
                new Employee { Id = 9, Name = "Olivia Anderson", Number = "01710000008", SbuId = 3, UserId = 108, CustomRoleId = 4 },
                new Employee { Id = 10, Name = "James Thomas", Number = "01710000009", SbuId = 4, UserId = 109, CustomRoleId = 4 },
                new Employee { Id = 11, Name = "Isabella Martinez", Number = "01710000010", SbuId = 2, UserId = 110, CustomRoleId = 4 },
                new Employee { Id = 12, Name = "Liam Carter", Number = "01710000012", SbuId = 3, UserId = 112, CustomRoleId = 4 },
                new Employee { Id = 13, Name = "Charlotte Evans", Number = "01710000013", SbuId = 4, UserId = 113, CustomRoleId = 4 },
                new Employee { Id = 14, Name = "Benjamin Scott", Number = "01710000014", SbuId = 2, UserId = 114, CustomRoleId = 4 },
                new Employee { Id = 15, Name = "Amelia Wright", Number = "01710000015", SbuId = 3, UserId = 115, CustomRoleId = 4 },
                new Employee { Id = 16, Name = "Elijah Harris", Number = "01710000016", SbuId = 4, UserId = 116, CustomRoleId = 4 },
                new Employee { Id = 17, Name = "Mia Clark", Number = "01710000017", SbuId = 2, UserId = 117, CustomRoleId = 4 },
                new Employee { Id = 18, Name = "William Lewis", Number = "01710000018", SbuId = 3, UserId = 118, CustomRoleId = 4 },
                new Employee { Id = 19, Name = "Evelyn King", Number = "01710000019", SbuId = 4, UserId = 119, CustomRoleId = 4 },
                new Employee { Id = 20, Name = "Henry Baker", Number = "01710000020", SbuId = 2, UserId = 120, CustomRoleId = 4 },
                new Employee { Id = 21, Name = "Ava Rivera", Number = "01710000021", SbuId = 3, UserId = 121, CustomRoleId = 4 },
                new Employee { Id = 22, Name = "Lucas Campbell", Number = "01710000022", SbuId = 4, UserId = 122, CustomRoleId = 4 },
                new Employee { Id = 23, Name = "Harper Mitchell", Number = "01710000023", SbuId = 2, UserId = 123, CustomRoleId = 4 },
                new Employee { Id = 24, Name = "Alexander Perez", Number = "01710000024", SbuId = 3, UserId = 124, CustomRoleId = 4 },
                new Employee { Id = 25, Name = "Ella Roberts", Number = "01710000025", SbuId = 4, UserId = 125, CustomRoleId = 4 },
                new Employee { Id = 26, Name = "Jackson Turner", Number = "01710000026", SbuId = 2, UserId = 126, CustomRoleId = 4 },
                new Employee { Id = 27, Name = "Scarlett Phillips", Number = "01710000027", SbuId = 3, UserId = 127, CustomRoleId = 4 },
                new Employee { Id = 28, Name = "Sebastian Parker", Number = "01710000028", SbuId = 4, UserId = 128, CustomRoleId = 4 },
                new Employee { Id = 29, Name = "Grace Collins", Number = "01710000029", SbuId = 2, UserId = 129, CustomRoleId = 4 },
                new Employee { Id = 30, Name = "Matthew Edwards", Number = "01710000030", SbuId = 3, UserId = 130, CustomRoleId = 4 },
                new Employee { Id = 31, Name = "Chloe Stewart", Number = "01710000031", SbuId = 4, UserId = 131, CustomRoleId = 4 },
                new Employee { Id = 32, Name = "user", Number = "01710000032", SbuId = 4, UserId = 132, CustomRoleId = 4 }
            };
            builder.Entity<Employee>().HasData(employees);

            // Seed Identity Users for Employees (except admin)
            var employeeUsers = new List<IdentityUser<int>>();
            foreach (var emp in employees)
            {
                if (emp.UserId == 1) continue; // Skip admin, already created above
                var email = $"{emp.Name.Replace(" ", "").ToLower()}@brainhub.com";
                var normalizedEmail = email.ToUpper();
                var user = new IdentityUser<int>
                {
                    Id = emp.UserId!.Value,
                    UserName = email,
                    NormalizedUserName = normalizedEmail,
                    Email = email,
                    NormalizedEmail = normalizedEmail,
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "employee123"), // default password
                    SecurityStamp = Guid.NewGuid().ToString()
                };
                employeeUsers.Add(user);
                // Assign Employee role
                builder.Entity<IdentityUserRole<int>>().HasData(
                    new IdentityUserRole<int> { UserId = emp.UserId.Value, RoleId = 2 }
                );
            }
            builder.Entity<IdentityUser<int>>().HasData(employeeUsers);

            // Seed Custom Roles
            builder.Entity<CustomRole>().HasData(
                new CustomRole
                {
                    Id = 1,
                    Name = "Employee Manager",
                    Permissions = "EmployeeIndex,EmployeeAdd,EmployeeUpdate,EmployeeDelete"
                },
                new CustomRole
                {
                    Id = 2,
                    Name = "Sbu Manager",
                    Permissions = "SbuIndex,SbuAdd,SbuUpdate,SbuDelete"
                },
                new CustomRole
                {
                    Id = 3,
                    Name = "CustomRole Manager",
                    Permissions = "CustomRoleIndex,CustomRoleAdd,CustomRoleUpdate,CustomRoleDelete"
                },
                new CustomRole
                {
                    Id = 4,
                    Name = "View Everything",
                    Permissions = "EmployeeIndex,SbuIndex,CustomRoleIndex"
                }
            );
        }
    }
}
