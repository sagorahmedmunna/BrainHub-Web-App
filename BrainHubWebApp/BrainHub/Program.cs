using BrainHub.DomainLayer.Data;
using BrainHub.RepositoryLayer.IRepositories;
using BrainHub.RepositoryLayer.Repositories;
using BrainHub.ServiceLayer.IServices;
using BrainHub.ServiceLayer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// for SQL Server database
//builder.Services.AddDbContext<ApplicationDbContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// for PostgreSQL database
//builder.Services.AddDbContext<ApplicationDbContext>(options =>
//    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// for inMemory database testing
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseInMemoryDatabase("BrainHub"));


builder.Services.AddScoped<ISbuRepository, SbuRepository>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<ICustomRoleRepository, CustomRoleRepository>();

builder.Services.AddScoped<ISbuService, SbuService>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<ICustomRoleService, CustomRoleService>();
builder.Services.AddIdentity<IdentityUser<int>, IdentityRole<int>>(options =>
    {
        options.Password.RequireDigit = false;
        options.Password.RequireLowercase = false;
        options.Password.RequireUppercase = false;
        options.Password.RequiredLength = 1;
        options.Password.RequireNonAlphanumeric = false;
    })
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddControllersWithViews(options =>
{
    var policy = new AuthorizationPolicyBuilder()
                     .RequireAuthenticatedUser()
                     .Build();
    options.Filters.Add(new AuthorizeFilter(policy));
});


// Define policies and Authorization handlers
builder.Services.AddAuthorization(options =>
{
    var policies = new[]
    {
        "SbuIndex", "SbuAdd", "SbuUpdate", "SbuDelete",
        "EmployeeIndex", "EmployeeProfile", "EmployeeProfileUpdate", "EmployeeAdd", "EmployeeUpdate", "EmployeeDelete",
        "CustomRoleIndex", "CustomRoleAdd", "CustomRoleUpdate", "CustomRoleDelete"
    };

    foreach (var policy in policies)
    {
        options.AddPolicy(policy, policyBuilder =>
        {
            policyBuilder.RequireAssertion(context =>
            {
                // Admin bypass
                if (context.User.IsInRole("Admin"))
                    return true;
                if (policy == "EmployeeProfileUpdate" || policy == "EmployeeUpdate")
                {
                    return context.User.HasClaim("permission", "EmployeeProfileUpdate") ||
                           context.User.HasClaim("permission", "EmployeeUpdate");
                }
                // direct permission to Users to update their profile
                if (policy.StartsWith("EmployeeP"))
                    return true;

                // Check permission claims
                return context.User.HasClaim("permission", policy);
            });
        });
    }
});

// if unauthorized then go Account Index
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Account/Index";
    options.LogoutPath = "/Account/Logout";
    options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
    // options.ExpireTimeSpan = TimeSpan.FromMilliseconds(1);
    options.SlidingExpiration = false;

    options.AccessDeniedPath = "/Home/AccessDenied";
});

var app = builder.Build();

// for inMemory database seeding
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    db.Database.EnsureCreated();   // Necessary for seeding
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Index}/{id?}");


app.Run();
