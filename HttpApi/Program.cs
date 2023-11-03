using Api.Infrastructure.Interfaces;
using Api.Infrastructure.Profiles;
using Api.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient();
builder.Services.AddControllers();
builder.Services.AddApiVersioning();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(MappingProfile))
    .AddSingleton<IStorageService, StorageService>()
    .AddSingleton<IMemoryCacheProvider,MemoryCacheProvider>()
    .AddMemoryCache();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
