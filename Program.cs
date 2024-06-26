using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TopStyleAPI.Configuration;
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

            builder.Services.AddHealthChecks();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(policy =>
                {
                    policy.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                });
            });

            var connectionString = builder.Configuration.GetConnectionString("topstyledb");
            builder.Services.AddDbContext<TopStyleContext>(
                options => options.UseSqlServer(connectionString)
            );

            builder.Services.AddAutoMapper(typeof(Program).Assembly);

            builder.Services.AddScoped<IProductService, ProductService>();
            builder.Services.AddScoped<IOrderService, OrderService>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IOrderRepo, OrderRepo>();
            builder.Services.AddScoped<IProductRepo, ProductRepo>();
            builder.Services.AddScoped<IUserRepo, UserRepo>();

            SecurityOptions security = builder.Configuration.GetSection("Security").Get<SecurityOptions>() ?? new();
            builder.Services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(opt => {
                    opt.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = security.Issuer,
                        ValidAudience = security.Audience,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(security.Key))
                    };
                });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseCors();

            app.UseAuthorization();

            app.MapHealthChecks("/health_check");

            ProductEndpoints.RegisterEndpoints(app);
            OrderEndpoints.RegisterEndpoints(app);
            UserEndpoints.RegisterEndpoints(app);

            app.Run();
        }
    }
}
