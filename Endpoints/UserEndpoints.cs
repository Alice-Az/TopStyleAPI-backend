using TopStyleAPI.Core.Interfaces;
using TopStyleAPI.Domain.Models.User;

namespace TopStyleAPI.Endpoints
{
    public class UserEndpoints
    {
        public static void RegisterEndpoints(WebApplication app)
        {

            app.MapPost("/user", async (UserRequest userRequest, IUserService userService) =>
            {
                var userResponse = await userService.CreateUser(userRequest);
                if (userResponse is null) return Results.BadRequest("User already exists");

                return Results.Ok(userResponse);
            })
            .WithName("CreateUser")
            .WithOpenApi();

            app.MapPost("/login", async (LoginRequest loginRequest, IUserService userService) =>
            {
                var loginResponse = await userService.Login(loginRequest);
                if (loginResponse is null) return Results.BadRequest();

                return Results.Ok(loginResponse);
            })
            .WithName("GetUser")
            .WithOpenApi();

        }
    }
}
