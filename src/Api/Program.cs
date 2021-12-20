using Application;
using Domain.Contracts.Application;
using Domain.Contracts.Repositories;
using Domain.Contracts.Services;
using Domain.Service;
using Infra.Provider;
using Infra.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.ResponseCompression;
using Newtonsoft.Json;
using System.IO.Compression;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<IOrderApplication,OrderApplication>();

builder.Services.AddScoped<IOrderService, OrderService>();

builder.Services.AddTransient(typeof(IBaseRepository<,>), typeof(BaseRepository<,>));
builder.Services.AddScoped<IOrderRepository,OrderRepository>();

builder.Services.AddScoped<ContextDb>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGenNewtonsoftSupport();


builder.Services.Configure<GzipCompressionProviderOptions>(
    options => options.Level = CompressionLevel.Optimal);

builder.Services.AddResponseCompression(options =>
{
    options.Providers.Add<GzipCompressionProvider>();
    options.EnableForHttps = true;
});

builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.DateFormatHandling = DateFormatHandling.IsoDateFormat;
        options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
        options.SerializerSettings.TypeNameHandling = TypeNameHandling.None;
        options.SerializerSettings.MissingMemberHandling = MissingMemberHandling.Ignore;
        options.SerializerSettings.Formatting = Formatting.None;
        options.SerializerSettings.FloatFormatHandling = FloatFormatHandling.DefaultValue;
        options.SerializerSettings.FloatParseHandling = FloatParseHandling.Double;
        options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
        options.SerializerSettings.PreserveReferencesHandling = PreserveReferencesHandling.None;
        options.SerializerSettings.Culture = new System.Globalization.CultureInfo("en-US");
        options.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Local;
    });

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
