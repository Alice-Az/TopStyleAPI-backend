using TopStyleAPI.Core.Interfaces;
using TopStyleAPI.Domain.Models.User;

namespace TopStyleAPI.Endpoints
{
    public class UserEndpoints
    {
        public static void RegisterEndpoints(WebApplication app)
        {

            app.MapPost("/user", (UserRequest userRequest, IUserService userService) =>
            {
                var userResponse = userService.CreateUser(userRequest);
                if (userResponse is null) return Results.BadRequest("User already exists");

                return Results.Ok(userResponse);
            })
            .WithName("CreateUser")
            .WithOpenApi();

            app.MapPost("/login", (LoginRequest loginRequest, IUserService userService) =>
            {
                var loginResponse = userService.GetUser(loginRequest);
                if (loginResponse is null) return Results.BadRequest("Email or password incorrect");

                return Results.Ok(loginResponse);
            })
            .WithName("GetUser")
            .WithOpenApi();

        }
    }
}
