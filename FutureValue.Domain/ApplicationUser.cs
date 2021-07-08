using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace FutureValue.Domain
{
    public class ApplicationUser : IdentityUser
    {
        [Column("nvarchar(150)")]
        public string FullName { get; set; }
    }
}
