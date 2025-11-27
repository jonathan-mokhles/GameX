using GameStore.Core.Enums;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Core.DTO
{
    public class RegisterDTO
    {
        [Required (ErrorMessage = "First name is required.")]
        public string? FirstName { get; set; }

        [Required (ErrorMessage = "Last name is required.")]
        public string? LastName { get; set; }

        [Required (ErrorMessage = "Email is required.")]
        [EmailAddress (ErrorMessage = "Invalid email address.")]
        [Remote (action: "IsEmailInUse", controller: "Account", ErrorMessage = "Email is already in use.")]
        public string? Email { get; set; }

        [Required (ErrorMessage = "Password is required.")]
        [DataType (DataType.Password)]
        public string? Password { get; set; }

        [Required (ErrorMessage = "Confirm Password is required.")]
        [DataType (DataType.Password)]
        [Compare ("Password", ErrorMessage = "Passwords do not match.")]
        public string? ConfirmPassword { get; set; }

        [Required (ErrorMessage = "Phone is required.")]
        [Phone (ErrorMessage = "Invalid phone number.")]
        public string? PhoneNumber { get; set; }

        public UserRole Role { get; set; } = UserRole.Customer;

    }
}
