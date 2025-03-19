using FS0924_BE_S6_L1.Data;
using FS0924_BE_S6_L1.Models;
using FS0924_BE_S6_L1.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<PraticaS6L1>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
    options.Password.RequiredLength = 8;               //lunghezza minima psw
    options.Password.RequireDigit = false;             //se nella password deve esserci almeno un numero
    options.Password.RequireLowercase = false;         //Se nella password deve esserci almeno una lettera minuscola
    options.Password.RequireUppercase = false;         //Se nella password deve esserci almeno una lettera Maiuscola
    options.Password.RequireNonAlphanumeric = false;   //Se nella password deve esserci almeno un carattene NON-alfanumerico
}).AddEntityFrameworkStores<PraticaS6L1>()
.AddDefaultTokenProviders();
//SERVIZIO PER AUTENTICAZIONE
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
})
.AddCookie(options =>
{
    options.LoginPath = "/Account/Login";
    options.AccessDeniedPath = "/Account/Login";
    options.Cookie.Name = "LoginCookie";
    options.Cookie.HttpOnly = true;
    options.ExpireTimeSpan = TimeSpan.FromDays(1);
});
 builder.Services.AddScoped<UserManager<ApplicationUser>>();
builder.Services.AddScoped<SignInManager<ApplicationUser>>();
builder.Services.AddScoped<RoleManager<ApplicationRole>>();


builder.Services.AddScoped<StudentiServices>();
builder.Services.AddScoped<LoggerServices>();

LoggerServices.ConfigureLogger();
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

//QUI INSERIAMO I DUE MIDDLEWARE DI AUTHn E AUTHz IN QUESTO ORDINE SEMPRE
app.UseAuthentication();
app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
