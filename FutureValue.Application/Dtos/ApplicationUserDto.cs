using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FutureValue.Application.Dtos
{
    public class ApplicationUserDto
    {
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Username must be at least 6 characters.")]
        public string Username { get; set; }
        [StringLength(30, MinimumLength = 8, ErrorMessage = "Password must be at least 8 characters.")]
        public string Password { get; set; }
        [StringLength(150)]
        public string FullName { get; set; }
    }
}
