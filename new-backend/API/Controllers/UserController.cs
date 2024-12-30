using Application.DTOs.User;
using Core.Entities;
using Core.Enums;
using Core.Interfaces;
using Core.ValueObjects;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserService userService, ILogger<UserController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        /// <summary>
        /// Creates a new user
        /// </summary>
        /// <param name="createUserDto">The user data</param>
        /// <returns>The created user</returns>
        /// <response code="200">Returns the created user</response>
        /// <response code="400">If the user data is invalid</response>
        /// <response code="401">If the user is not authorized</response>
        [HttpPost]
        [ProducesResponseType(typeof(UserDetailsDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<UserDetailsDto>> CreateUser([FromBody] CreateUserDto createUserDto)
        {
            _logger.LogInformation("Creating new user: {Email}", createUserDto.Email);

            var createdUser = await _userService.CreateUserAsync(createUserDto);

            _logger.LogInformation("User created successfully: {Email}", createdUser.Email);

            return Ok(createdUser);
        }

        /// <summary>
        /// Gets a user by ID
        /// </summary>
        /// <param name="id">The user ID</param>
        /// <returns>The user details</returns>
        /// <response code="200">Returns the user details</response>
        /// <response code="401">If the user is not authorized</response>
        /// <response code="403">If the user is forbidden from accessing the resource</response>
        /// <response code="404">If the user is not found</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(UserDetailsDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<UserDetailsDto>> GetUser(Guid id)
        {
            var user = await _userService.GetUserByIdAsync(id);

            if (User.IsInRole(Role.User.ToString()) && User.Identity.Name != user.Email)
            {
                return Forbid();
            }

            return Ok(user);
        }

        /// <summary>
        /// Gets all users
        /// </summary>
        /// <returns>A list of all users</returns>
        /// <response code="200">Returns the list of users</response>
        /// <response code="401">If the user is not authorized</response>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<UserDetailsDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<IEnumerable<UserDetailsDto>>> GetAllUsers()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }

        /// <summary>
        /// Updates a user
        /// </summary>
        /// <param name="id">The user ID</param>
        /// <param name="updateUserDto">The updated user data</param>
        /// <returns>No content</returns>
        /// <response code="204">If the user was successfully updated</response>
        /// <response code="400">If the user data is invalid</response>
        /// <response code="401">If the user is not authorized</response>
        /// <response code="403">If the user is forbidden from accessing the resource</response>
        /// <response code="404">If the user is not found</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> UpdateUser(Guid id, [FromBody] UpdateUserDto updateUserDto)
        {
            var user = await _userService.GetUserByIdAsync(id);

            if (User.IsInRole(Role.User.ToString()) && User.Identity.Name != user.Email)
            {
                return Forbid();
            }

            await _userService.UpdateUserAsync(id, updateUserDto);

            _logger.LogInformation("User updated successfully: {Email}", user.Email);

            return NoContent();
        }

        /// <summary>
        /// Deletes a user
        /// </summary>
        /// <param name="id">The user ID</param>
        /// <returns>No content</returns>
        /// <response code="204">If the user was successfully deleted</response>
        /// <response code="401">If the user is not authorized</response>
        /// <response code="404">If the user is not found</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteUser(Guid id)
        {
            await _userService.DeleteUserAsync(id);

            _logger.LogInformation("User deleted successfully: {Id}", id);

            return NoContent();
        }
    }
}

