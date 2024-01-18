using Microsoft.EntityFrameworkCore;
using SoftmassTech.Data;
using SoftmassTech.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


//Register DbContext.
var connectionString = builder.Configuration.GetConnectionString("EmpMngtConnection");
builder.Services.AddDbContext<AppDbContext>(options =>options.UseSqlServer(connectionString));


// We also call this as LOOSE COUPLING.
// Register Department Services
builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
// Register Employee Services
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();





var app = builder.Build();

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

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
