using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Shop.ApplicationServices.Services;
using Shop.Core.Domain;
using Shop.Core.ServiceInterface;
using Shop.Data;
using ShopTARge24.ApplicationServices.Services;
using ShopTARge24.Core.ServiceInterface;
using ShopTARge24.Hubs;




var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSignalR();
builder.Services.AddHttpClient();

builder.Services.AddScoped<ISpaceshipServices, SpaceshipServices>();
builder.Services.AddScoped<IFileServices, FileServices>();
builder.Services.AddScoped<IRealEstateServices, RealEstateServices>();
builder.Services.AddScoped<IWeatherForecastServices, WeatherForecastServices>();
builder.Services.AddScoped<IChuckNorrisServcies, ChuckNorrisServcies>();
builder.Services.AddScoped<ICocktailService, CocktailService>();
builder.Services.AddScoped<IEmailServices, EmailServices>();

builder.Services.AddDbContext<ShopContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
    options.SignIn.RequireConfirmedAccount = true;
    options.Password.RequiredLength = 3;

    options.Tokens.EmailConfirmationTokenProvider = "CustomEmailConfirmation";
    options.Lockout.MaxFailedAccessAttempts = 3;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(1);
})
    .AddEntityFrameworkStores<ShopContext>()
    .AddDefaultTokenProviders()
 .AddTokenProvider<DataProtectorTokenProvider<ApplicationUser>>("CustomEmailConfirmation");


builder.Services.AddAuthentication().AddGoogle(googleOptions =>
{
    googleOptions.ClientId = builder.Configuration["Authentication:Google:ClientId"];
    googleOptions.ClientSecret = builder.Configuration["Authentication:Google:ClientSecret"];
    googleOptions.CallbackPath = "/signin-google";
})
    .AddFacebook(facebookOptions =>
{
    facebookOptions.AppId = builder.Configuration["Authentication:Facebook:AppId"];
    facebookOptions.AppSecret = builder.Configuration["Authentication:Facebook:AppSecret"];
    facebookOptions.CallbackPath = "/signin-facebook";

    // Request email and public profile
    facebookOptions.Scope.Add("email");
    facebookOptions.Scope.Add("public_profile");

    // Map the email claim
    facebookOptions.Fields.Add("email");
    facebookOptions.Fields.Add("name");
});

var app = builder.Build();

app.MapControllers();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapStaticAssets();

app.UseStaticFiles();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.MapHub<ChatHub>("/chatHub");

app.Run();
