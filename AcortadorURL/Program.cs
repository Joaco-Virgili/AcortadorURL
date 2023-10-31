using AcortadorURL.Data;
using AcortadorURL.Helpers;
using AcortadorURL.Services;
using Microsoft.EntityFrameworkCore;

namespace AcortadorURL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddScoped<IUrlService, UrlService>();
            builder.Services.AddScoped<UrlHelper>();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<UrlContext>(DbContextOptions => DbContextOptions.UseSqlite(
                builder.Configuration["ConnectionStrings:AcortadorURLDBConnectionString"]));

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