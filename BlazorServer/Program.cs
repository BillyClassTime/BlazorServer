using BlazorServer.Configuration.Interfaces;
using BlazorServer.Infrastructure.Interfaces;
using BlazorServer.Infrastructure;
using BlazorServer.Services.Interfaces;
using BlazorServer.Services;
using BlazorServer.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<ICaptchaService, CaptchaService>();
builder.Services.AddSingleton<IAppVersionInfo, AppVersionInfo>();
builder.Services.AddSingleton<IGraphClientWrapper, GraphClientWrapper>();
builder.Services.Configure<EntraIdGraphSettings>(builder.Configuration.GetSection("EntraIdGraphSettings"));
builder.Services.AddTransient<IEmailGraphService, EmailGraphService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
