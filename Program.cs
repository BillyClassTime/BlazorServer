using BlazorServer.Services.Interfaces;
using BlazorServer.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<IAppVersionInfo, AppVersionInfo>();
builder.Services.Configure<AzureAdGraphSettings>(builder.Configuration.GetSection("AzureAdGraphSettings"));
builder.Services.AddTransient<EmailServiceGraph>();
Console.WriteLine("SMTP User desde config: " + builder.Configuration["AzureAdGraphSettings:Sender"]);


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
