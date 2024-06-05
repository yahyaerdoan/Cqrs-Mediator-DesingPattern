using CqrsDesing.WebUserInterface.CQRS.Handlers.Category.Read;
using CqrsDesing.WebUserInterface.CQRS.Handlers.Category.Write;
using CqrsDesing.WebUserInterface.CQRS.Handlers.Product.Read;
using CqrsDesing.WebUserInterface.CQRS.Handlers.Product.Write;
using CqrsDesing.WebUserInterface.CqrsDesing.DataAccessLayer.Contetx;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<CqrsDesingDb>();
builder.Services.AddScoped<GetCategoryQueryHandler>();
builder.Services.AddScoped<GetProductQueryHandler>();

builder.Services.AddScoped<CreateCategoryCommandHandler>();
builder.Services.AddScoped<DeleteCategoryCommandHandler>();

builder.Services.AddScoped<CreateProductCommandHandler>();
builder.Services.AddScoped<DeleteProductCommandHandler>();
builder.Services.AddControllersWithViews();

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
