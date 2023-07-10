using QuanLy_DaiHoc.BusinessLogic.Interface;
using QuanLy_DaiHoc.BusinessLogic.Services;
using QuanLy_DaiHoc.Models;
using QuanLy_DaiHoc.Controllers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<QuanLyDaiHocContext, QuanLyDaiHocContext>();
builder.Services.AddScoped<IKhoaServices, KhoaServices>();
builder.Services.AddScoped<ITblBanServices, TblBanServices>();
builder.Services.AddScoped<IQuanLyPhongServices, QuanLyPhongServices>();
builder.Services.AddScoped<ILopTinChi, LopTinChiServices>();
builder.Services.AddScoped<ILopSinhVien, LopSinhVienServices>();
builder.Services.AddScoped<ILopNienKhoa, LopNienKhoaServices>();
builder.Services.AddScoped<ILopSinhVienNienKhoa, LopSinhVienNienKhoaServices>();


builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
{
    builder.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader();
}));
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                      });
});


//builder.Services.AddScoped<KhoaServices, KhoaServices>();




//builder.Services.AddScoped<IKhoaServices, KhoaServicesUpgrade>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();
app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");



app.UseDeveloperExceptionPage();
app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "EmailServices v1"));

//app.MapGiamHieuEndpoints();
app.Run("http://localhost:6054");
//app.Run();
