using Microsoft.EntityFrameworkCore;
using KoiFishDeliverySystem.Models;
using KoiFishDeliverySystem.Repositories.Interfaces;
using KoiFishDeliverySystem.Repositories;
using KoiFishDeliverySystem.Services.Interfaces;
using KoiFishDeliverySystem.Services;
using KoiFishDeliverySystem.Repositoies;

namespace KoiFishDeliverySystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Register DbContext
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Register Repository
            builder.Services.AddScoped<IUsersRepository, UsersRepository>();

            // Register Service
            builder.Services.AddScoped<IUsersService, UsersService>();

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
        }
    }
}
