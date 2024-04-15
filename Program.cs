using Microsoft.EntityFrameworkCore;
using TopStyleAPI.Core.Interfaces;
using TopStyleAPI.Core.Services;
using TopStyleAPI.Data;
using TopStyleAPI.Data.Interfaces;
using TopStyleAPI.Data.Repository;
using TopStyleAPI.Endpoints;

namespace TopStyleAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(policy =>
                {
                    policy.WithOrigins("http://localhost:5175")
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                });
            });

            builder.Services.AddDbContext<TopStyleContext>(
                options => options.UseSqlServer(@"Data Source=localhost;Initial Catalog=TopStyle;Integrated Security=SSPI;TrustServerCertificate=True;")
            );
            builder.Services.AddScoped<IProductService, ProductService>();
            builder.Services.AddScoped<IOrderService, OrderService>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IOrderRepo, OrderRepo>();
            builder.Services.AddScoped<IProductRepo, ProductRepo>();
            builder.Services.AddScoped<IUserRepo, UserRepo>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseCors();

            app.UseAuthorization();

            ProductEndpoints.RegisterEndpoints(app);
            OrderEndpoints.RegisterEndpoints(app);
            UserEndpoints.RegisterEndpoints(app);

            app.Run();
        }
    }
}
