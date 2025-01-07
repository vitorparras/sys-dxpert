using Application.DTOs;
using Application.DTOs.User;
using Application.UseCases.User;
using Core.Shared.Helpers;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UserController : ControllerBase
    {
        private readonly IGetAllUsersUseCase _getAllUsersUseCase;
        private readonly ICreateUserUseCase _createUserUseCase;
        private readonly IUpdateUserUseCase _updateUserUseCase;
        private readonly IDeleteUserUseCase _deleteUserUseCase;
        private readonly IGetUserMetricsUseCase _getUserMetricsUseCase;
        private readonly ILogger<UserController> _logger;

        public UserController(
            IGetAllUsersUseCase getAllUsersUseCase,
            ICreateUserUseCase createUserUseCase,
            IUpdateUserUseCase updateUserUseCase,
            IDeleteUserUseCase deleteUserUseCase,
            IGetUserMetricsUseCase getUserMetricsUseCase,
            ILogger<UserController> logger)
        {
            _getAllUsersUseCase = getAllUsersUseCase;
            _createUserUseCase = createUserUseCase;
            _updateUserUseCase = updateUserUseCase;
            _deleteUserUseCase = deleteUserUseCase;
            _getUserMetricsUseCase = getUserMetricsUseCase;
            _logger = logger;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Fetch all users", Description = "Fetch all users with optional filters")]
        [SwaggerResponse(200, "Users retrieved successfully", typeof(List<UserDto>))]
        [SwaggerResponse(400, "Invalid filter parameters")]
        public async Task<IActionResult> GetAllUsers([FromQuery] UserFilterDto filters)
        {
            if (!ModelState.IsValid)
                return ResponseHelper.CreateResponse("Invalid filter parameters.", HttpStatusCode.BadRequest);

            try
            {
                var users = await _getAllUsersUseCase.ExecuteAsync(filters);
                return ResponseHelper.CreateResponse("Users retrieved successfully", HttpStatusCode.OK, users);
            }
            catch (FormatException ex)
            {
                _logger.LogWarning(ex, "Invalid filter format provided");
                return ResponseHelper.CreateResponse(ex.Message, HttpStatusCode.BadRequest);
            }
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Create a new user", Description = "Creates a new user and returns the created entity")]
        [SwaggerResponse(201, "User created successfully", typeof(UserDto))]
        [SwaggerResponse(400, "Invalid request payload or validation error")]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserDto request)
        {
            if (!ModelState.IsValid)
                return ResponseHelper.CreateResponse("Invalid request payload.", HttpStatusCode.BadRequest);

            try
            {
                var result = await _createUserUseCase.ExecuteAsync(request);
                return ResponseHelper.CreateResponse("User created successfully", HttpStatusCode.Created, result);
            }
            catch (ArgumentException ex)
            {
                _logger.LogWarning(ex, "Validation error while creating user");
                return ResponseHelper.CreateResponse(ex.Message, HttpStatusCode.BadRequest);
            }
        }

        [HttpPut]
        [SwaggerOperation(Summary = "Update a user", Description = "Updates user data by ID")]
        [SwaggerResponse(204, "User updated successfully")]
        [SwaggerResponse(400, "Invalid request payload")]
        [SwaggerResponse(404, "User not found")]
        public async Task<IActionResult> UpdateUser(Guid id, [FromBody] UpdateUserDto request)
        {
            if (!ModelState.IsValid)
                return ResponseHelper.CreateResponse("Invalid request payload.", HttpStatusCode.BadRequest);

            try
            {
                await _updateUserUseCase.ExecuteAsync(id, request);
                return ResponseHelper.CreateResponse("User updated successfully", HttpStatusCode.NoContent);
            }
            catch (KeyNotFoundException ex)
            {
                _logger.LogWarning(ex, "User not found for update");
                return ResponseHelper.CreateResponse(ex.Message, HttpStatusCode.NotFound);
            }
        }

        [HttpDelete]
        [SwaggerOperation(Summary = "Delete a user", Description = "Deletes a user by ID")]
        [SwaggerResponse(204, "User deleted successfully")]
        [SwaggerResponse(404, "User not found")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            try
            {
                await _deleteUserUseCase.ExecuteAsync(id);
                return ResponseHelper.CreateResponse("User deleted successfully", HttpStatusCode.NoContent);
            }
            catch (KeyNotFoundException ex)
            {
                _logger.LogWarning(ex, "User not found for deletion");
                return ResponseHelper.CreateResponse(ex.Message, HttpStatusCode.NotFound);
            }
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Fetch user metrics", Description = "Fetches metrics for a specific user")]
        [SwaggerResponse(200, "User metrics retrieved successfully", typeof(UserMetricsDto))]
        [SwaggerResponse(404, "User not found")]
        public async Task<IActionResult> GetUserMetrics(Guid id)
        {
            try
            {
                var metrics = await _getUserMetricsUseCase.ExecuteAsync(id);
                return ResponseHelper.CreateResponse("User metrics retrieved successfully", HttpStatusCode.OK, metrics);
            }
            catch (KeyNotFoundException ex)
            {
                _logger.LogWarning(ex, "User not found for metrics");
                return ResponseHelper.CreateResponse(ex.Message, HttpStatusCode.NotFound);
            }
        }
    }

}
