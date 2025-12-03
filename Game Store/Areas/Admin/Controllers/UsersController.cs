using GameStore.Core.Domain.IdentityEntities;
using GameStore.Core.DTO;
using GameStore.Core.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Game_Store.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]")]
    [Authorize(Roles = "Admin")]
    public class UsersController : Controller
    {
        UserManager<ApplicationUser> _userManager;

        public UsersController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet("")]
        public async Task<IActionResult> Index()
        {
            var users = await _userManager.Users.ToListAsync();

            var userDTOs = new List<UserResponseDTO>();

            foreach (var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user);
                userDTOs.Add(new UserResponseDTO
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    Id = user.Id,
                    PhoneNumber = user.PhoneNumber,
                    RegistrationDate = user.RegistrationDate,
                    Role = roles.FirstOrDefault()
                });
            }

            return View(userDTOs);
        }

        [HttpGet("Add")]
        public async Task<IActionResult> Add()
        {
            ViewBag.RolesList = RolesToSelectList();
            return View();
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add(RegisterDTO newUser)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.RolesList = RolesToSelectList();
                return View(newUser);
            }
            var user = new ApplicationUser
            {
                UserName = newUser.Email,
                Email = newUser.Email,
                FirstName = newUser.FirstName,
                LastName = newUser.LastName,
                PhoneNumber = newUser.PhoneNumber,
                RegistrationDate = DateTime.UtcNow
            };
            var result = await _userManager.CreateAsync(user, newUser.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, newUser.Role.ToString());
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                ViewBag.RolesList = RolesToSelectList();
                return View(newUser);
            }
        }


        [HttpGet("Edit/{id}")]
        public async Task<IActionResult> Edit(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return RedirectToAction("Index");
            }
            var roles = await _userManager.GetRolesAsync(user);
            var userDTO = new UserUpdateRequestDTO
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Role = Enum.Parse<UserRoleEnum>(roles.FirstOrDefault())
            };

            ViewBag.RolesList = RolesToSelectList();

            return View(userDTO);
        }

        [HttpPost("Edit/{id}")]
        public async Task<IActionResult> Edit(UserUpdateRequestDTO Updateduser)
        {
            ApplicationUser user = await _userManager.FindByIdAsync(Updateduser.Id);
            if (user == null)
            {
                return RedirectToAction("Index");
            }

            if (!ModelState.IsValid)
            {
                ViewBag.RolesList = RolesToSelectList();
                return View(Updateduser);
            }


            user.FirstName = Updateduser.FirstName;
            user.LastName = Updateduser.LastName;
            user.PhoneNumber = Updateduser.PhoneNumber;
            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                var currentRoles = await _userManager.GetRolesAsync(user);
                if (!currentRoles.Contains(Updateduser.Role.ToString()))
                {
                    await _userManager.RemoveFromRolesAsync(user, currentRoles);
                    await _userManager.AddToRoleAsync(user, Updateduser.Role.ToString());
                }
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }

                return RedirectToAction("Index");
            }

        }


        [HttpPost("Delete/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                var result = await _userManager.DeleteAsync(user);
            }
            return RedirectToAction("Index");
        }


        private IEnumerable<SelectListItem> RolesToSelectList() {
            return UserRoleEnum.GetValues(typeof(UserRoleEnum)).Cast<UserRoleEnum>().Select(c => new SelectListItem
            {
                Value = ((int)c).ToString(),
                Text = c.ToString()
            });
        }
    } 
}
