using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chater.Models
{
    public class ApplicationUser : IdentityUser
    {
        public List<UserGroups> Groups { get; set; }
    }
}
