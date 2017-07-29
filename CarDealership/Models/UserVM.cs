using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealership.Models
{
    public class UserVM
    {
        public AppUser User { get; set; }
        public string AppRoleId { get; set; }
        public List<IdentityRole> RoleList { get; set; }
        public List<SelectListItem> Roles { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmPass { get; set; }
    }
}