using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Core.DTO
{
    public class SignInDTO
    {
        [Required (ErrorMessage = "Email is required.")]
        [EmailAddress (ErrorMessage = "Invalid email address.")]
        public string? Email { get; set; }

        [Required (ErrorMessage = "Password is required.")]
        [DataType (DataType.Password)]
        public string? Password { get; set; }


        [DefaultValue (false)]
        public bool RememberMe { get; set; }
    }
}
