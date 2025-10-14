
using FluentValidation;
using IsubuSatis.KatalogServiceNew.Dtos;
using IsubuSatis.KatalogServiceNew.EfCore;
using IsubuSatis.KatalogServiceNew.Services;
using IsubuSatis.KatalogServiceNew.Validators;
using IsubuSatis.Ortak;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using System;

namespace IsubuSatis.KatalogServiceNew
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var config = builder.Configuration.GetSection("MongoDbSettings");
            builder.Services.AddSingleton<IMongoClient, MongoClient>(sp =>
            {
                return new MongoClient(config["ConnectionUrl"]);
            });

            builder.Services.AddScoped(sp =>
            {
                var mongoClient = sp.GetRequiredService<IMongoClient>();
                
                var database = mongoClient.GetDatabase(config["Database"]);

                var optionsBuilder = new DbContextOptionsBuilder<KategoriDbContext>().UseMongoDB(database.Client,
                    database.DatabaseNamespace.DatabaseName);

                
                return new KategoriDbContext(optionsBuilder.Options);
            });
            // Add services to the container.

            //builder.Services.AddScoped<IValidator<KategoriOlusturDto>, KategoriOlusturDtoValidator>();
            builder.Services.AddValidatorsFromAssemblyContaining<KategoriOlusturDtoValidator>();
            builder.Services.AddScoped<IKategoriService, KategoriService>();
            //builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            
            builder.Services.AddAutoMapper(cfg => { }, typeof(Program));


            var app = builder.Build();

            app.MapGet("/api/kategoriler", async ([FromServices]  IKategoriService _kategoriService) =>
            {
                var kategoriler = await _kategoriService.GetKategoriler();

                return ServisSonuc<List<KategoriDto>>.Basarili(kategoriler);

            });

            app.MapPost("/api/kategoriler", async ([FromBody] KategoriOlusturDto input, [FromServices] IKategoriService _kategoriService) =>
            {
                await _kategoriService.KategoriOlustur(input);

                return ServisSonuc<string>.Basarili("");
            }).AddEndpointFilter<IsubuValidationFilter<KategoriOlusturDto>>();


            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();

                app.MapGet("/", context =>
                {
                    context.Response.Redirect("/swagger");
                    return Task.CompletedTask;
                });
            }

            //app.MapControllers();

           
            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseHttpsRedirection();


            


            //app.MapGroup("")
            //    .KategoriOlusturGroupItemEndpoint()
            //    .GetAllCategoryGroupItemEndpoint()

            //    .GetByIdCategoryGroupItemEndpoint();
            app.Run();
        }
    }
}
