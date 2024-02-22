using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WEBKITTER.UI.Context;
using WEBKITTER.UI.Models;

namespace WEBKITTER.UI.Controllers
{
    //[Authorize(Roles = "ClientManager")]
    public class UserController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public UserController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet("/User/GetUsers")]
        public async Task<IActionResult>? GetUsersAsync()
        {
            var users = _userManager.Users.ToList();
            if (users == null) users = new List<ApplicationUser>();
            List<ViewUser> viewUsers = new List<ViewUser>();

            foreach (var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user);
                string? role = roles != null && roles.Count > 0 ? roles[0].ToString() : null;
                viewUsers.Add(new ViewUser
                {
                    Id = user.Id,
                    Email = user.Email,
                    UserName = user.UserName,
                    Role = role
                });
            }
            return Json(viewUsers);
        }

        [HttpPost("/User/Add")]
        public async Task<IActionResult> AddUser([FromBody] ViewUser userModel)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = userModel.UserName, Email = userModel.Email };
                var result = await _userManager.CreateAsync(user, userModel.Password);

                if (result.Succeeded)
                {
                    try
                    {
                        await _userManager.AddToRoleAsync(user, userModel.Role);

                        return StatusCode(200, "User added sucsessfuly");
                    }
                    catch
                    {
                        var newUser = await _userManager.FindByNameAsync(user.UserName);
                        if (newUser != null) await _userManager.DeleteAsync(newUser);
                        return StatusCode(500, "Unable to add role to user.");
                    }
                }

                string errorText = "Some errors were occured while trying to ADD user:" + Environment.NewLine;

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                    errorText += error.Description + Environment.NewLine;
                }

                return StatusCode(500, errorText);
            }
            else
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                var errorText = "The data you have specified is not correct:" + Environment.NewLine;
                foreach (var error in errors) errorText += error + Environment.NewLine;

                return StatusCode(500, errorText);
            }
        }

        [HttpPut("User/Update/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateUser(string id, [FromBody] ViewUser userModel)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
            {
                return NotFound($"User with id: {id} was not found.");
            }

            if (ModelState.IsValid)
            {
                user.UserName = userModel.UserName;
                user.Email = userModel.Email;

                var result = await _userManager.UpdateAsync(user);

                if (result.Succeeded)
                {
                    bool isInRole = await _userManager.IsInRoleAsync(user, userModel.Role);
                    if (!isInRole)
                    {
                        var roles = await _userManager.GetRolesAsync(user);
                        string? role = roles.Count > 0 ? roles[0].ToString() : null;
                        if (role != null)
                        {
                            await _userManager.RemoveFromRoleAsync(user, role);
                            await _userManager.AddToRoleAsync(user, userModel.Role);
                        }
                    }

                    if (userModel.Password != null)
                    {
                        await _userManager.RemovePasswordAsync(user);
                        await _userManager.AddPasswordAsync(user, userModel.Password);
                    }

                    // Пользователь успешно обновлен
                    return StatusCode(200, "The user was successfully updated.");
                }

                string errorText = "Some errors were occured while trying to EDIT user:" + Environment.NewLine;

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                    errorText += error.Description + Environment.NewLine;
                }

                return StatusCode(500, errorText);
            }
            else
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                var errorText = "The data you have specified is not correct:" + Environment.NewLine;
                foreach (var error in errors) errorText += error + Environment.NewLine;

                return StatusCode(500, errorText);
            }
        }

        [HttpDelete("User/Delete/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user != null)
            {
                var result = await _userManager.DeleteAsync(user);

                if (result.Succeeded)
                {
                    // Пользователь успешно удален
                    return StatusCode(200, "User deleted successfully.");
                }

                string errorText = "Some errors were occured while trying to DELETE user:" + Environment.NewLine;

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                    errorText += error.Description + Environment.NewLine;
                }

                return StatusCode(500, errorText);
            }
            else
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                var errorText = "The error while deleting user was occured:" + Environment.NewLine;
                foreach (var error in errors) errorText += error + Environment.NewLine;

                return StatusCode(500, errorText);
            }
        }

        [AllowAnonymous]
        [HttpPost("/User/Login")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LoginUser(string username, string password)
        {
            var result = await _signInManager.PasswordSignInAsync(username, password, false, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                var user = await _userManager.FindByNameAsync(username);
                var roles = await _userManager.GetRolesAsync(user);
                var role = roles.FirstOrDefault(); // Получаем первую роль пользователя

                var response = new
                {
                    Message = "Login successful",
                    Role = role
                };

                Console.OpenStandardOutput();
                Console.WriteLine($"Response: {JsonConvert.SerializeObject(response)}");

                return Ok(response); // Убедитесь, что используется JsonResult или что-то аналогичное
            }
            else
            {
                return BadRequest("Invalid login attempt");
            }
        }


        [AllowAnonymous]
        [HttpGet("/User/Logout")]
        public async Task<IActionResult> Logout()
        {
            try
            {
                await _signInManager.SignOutAsync();
            }
            catch { }
            return RedirectToAction("Login", "Home");
        }
    }
}

public class LoginResponse
{
    public string Message { get; set; }
    public string Role { get; set; }
}