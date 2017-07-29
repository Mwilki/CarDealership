using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealership.Models
{
    public class UserListVM
    {
        public List<AppUser> Users { get; set; }
        public List<IdentityRole> Roles { get; set; }
    }
}