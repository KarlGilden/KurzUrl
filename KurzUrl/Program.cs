using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using KurzUrl.Contexts;
using KurzUrl.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration.AzureKeyVault;
using Microsoft.Extensions.Options;
using MySqlConnector;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);

// Key Vault
var keyVaultURL = builder.Configuration.GetSection("KeyVault:KeyVaultURL");
var keyVaultClientId = builder.Configuration.GetSection("KeyVault:ClientId");
var keyVaultClientSecret = builder.Configuration.GetSection("KeyVault:ClientSecret");
var keyVaultDirectoryId = builder.Configuration.GetSection("KeyVault:DirectoryId");

var credential = new ClientSecretCredential(keyVaultDirectoryId.Value!.ToString(), keyVaultClientId.Value!.ToString(), keyVaultClientSecret.Value!.ToString());

builder.Configuration.AddAzureKeyVault(keyVaultURL.Value!.ToString(), keyVaultClientId.Value!.ToString(), keyVaultClientSecret.Value!.ToString(), new DefaultKeyVaultSecretManager());

var client = new SecretClient(new Uri(keyVaultURL.Value!.ToString()), credential);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseMySql(client.GetSecret("ConnectionString").Value.Value.ToString(), ServerVersion.AutoDetect(client.GetSecret("ConnectionString").Value.Value.ToString()));

});
builder.Services.AddScoped<IUrlService, UrlService>();
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("*");
                      });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(MyAllowSpecificOrigins);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
