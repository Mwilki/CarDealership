using CarDealership.Data.Interfaces;
using CarDealership.Data.Repositories;
using CarDealership.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealership.Controllers
{
    public class AdminController : Controller
    {
        private IRepository _repo;

        public AdminController(IRepository repo)
        {
            _repo = repo;
        }
        // GET: Admin
        public ActionResult Index()
        {
            return View(_repo.GetAllVehicles());
        }

        public ActionResult Specials()
        {
            AdminSpecialsViewModel vm = new AdminSpecialsViewModel(_repo.GetSpecials());
            return View(vm);
        }

        [HttpPost]
        public ActionResult CreateSpecial(AdminSpecialsViewModel special)
        {
            //method to add special to table of current specials in the db here
            _repo.CreateSpecial(special.NewSpecial);
            return RedirectToAction("Specials");
        }

        [Route("admin/deletespecial/{id}")]
        public ActionResult DeleteSpecial(int id)
        {
            _repo.DeleteSpecialById(id);
            return RedirectToAction("Specials");
        }

        public ActionResult AddVehicle()
        {
            AdminAddVehicleViewModel vm = new AdminAddVehicleViewModel();
            vm.Vehicle = new Vehicle();
            vm.AllColors = _repo.GetAllColors().Select(c => new SelectListItem() { Text = c.ColorName, Value = c.ColorName.ToString() }).ToList();
            vm.AllInteriors = _repo.GetAllInteriors().Select(i => new SelectListItem() { Text = i.InteriorName, Value = i.InteriorId.ToString() }).ToList();
            vm.AllMakes = _repo.GetAllMakes().Select(m => new SelectListItem() { Text = m.MakeName, Value = m.MakeName.ToString() }).ToList();
            vm.AllModels = _repo.GetAllModels().Select(m => new SelectListItem() { Text = m.ModelName, Value = m.ModelName.ToString() }).ToList();
            vm.AllTransmissions = _repo.GetAllTransmissions().Select(t => new SelectListItem() { Text = t.TransmissionName, Value = t.TransmissionId.ToString() }).ToList();
            vm.AllBodyStyles = _repo.GetAllBodyTypes().Select(b => new SelectListItem() { Text = b.BodyTypeName, Value = b.BodyTypeName.ToString() }).ToList();
            return View(vm);
        }

        [HttpPost]
        public ActionResult AddVehicle(AdminAddVehicleViewModel vm)
        {
            // Make sure u use the edit method and an edit controller.  Thanks
            var fileName = Path.GetFileName(vm.File.FileName);
            var path = Path.Combine(Server.MapPath("~/imgs/"), fileName);
            vm.Vehicle.Image = "./imgs/" + fileName;
            vm.File.SaveAs(path);

            _repo.CreateVehicle(vm.Vehicle);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult EditVehicle(AdminEditVehicleViewModel vm)
        {
            if (vm.File != null)
            {
                var fileName = Path.GetFileName(vm.File.FileName);
                var path = Path.Combine(Server.MapPath("~/imgs/"), fileName);
                vm.Vehicle.Image = "imgs/" + fileName;
                vm.File.SaveAs(path);
            }

            _repo.EditVehicle(vm.Vehicle);
            return RedirectToAction("Index");
        }


        [Route("admin/editvehicle/{id}")]
        public ActionResult EditVehicle(int id)
        {
            AdminEditVehicleViewModel vm = new AdminEditVehicleViewModel();
            vm.Vehicle = _repo.GetVehicleById(id);
            vm.AllColors = _repo.GetAllColors().Select(c => new SelectListItem() { Text = c.ColorName, Value = c.ColorName.ToString() }).ToList();
            vm.AllInteriors = _repo.GetAllInteriors().Select(i => new SelectListItem() { Text = i.InteriorName, Value = i.InteriorId.ToString() }).ToList();
            vm.AllMakes = _repo.GetAllMakes().Select(m => new SelectListItem() { Text = m.MakeName, Value = m.MakeName.ToString() }).ToList();
            vm.AllModels = _repo.GetAllModels().Select(m => new SelectListItem() { Text = m.ModelName, Value = m.ModelName.ToString() }).ToList();
            vm.AllTransmissions = _repo.GetAllTransmissions().Select(t => new SelectListItem() { Text = t.TransmissionName, Value = t.TransmissionId.ToString() }).ToList();
            vm.AllBodyStyles = _repo.GetAllBodyTypes().Select(b => new SelectListItem() { Text = b.BodyTypeName, Value = b.BodyTypeName.ToString() }).ToList();
            return View(vm);
        }

        public ActionResult Makes()
        {
            var allMakes = _repo.GetAllMakes();
            AdminAddMakeViewModel vm = new AdminAddMakeViewModel();

            vm.AllMakes = allMakes;

            return View(vm);
        }

        [HttpPost]
        public ActionResult AddMake(Make newmake)
        {
            _repo.AddCarMake(newmake);
            return RedirectToAction("Makes");
        }

        [Route("admin/deletemake/{id}")]
        public ActionResult DeleteMake(int id)
        {
            _repo.DeleteCarMake(id);
            return RedirectToAction("Makes");
        }

        public ActionResult Models()
        {

            var allModels = _repo.GetAllModels();
            AdminAddModelViewModel vm = new AdminAddModelViewModel();
            vm.Makes = _repo.GetAllMakes().Select(m => new SelectListItem() { Text = m.MakeName, Value = m.MakeId.ToString() }).ToList();
            vm.AllModels = allModels;

            return View(vm);
        }

        [HttpPost]
        public ActionResult AddModel(Model newmodel)
        {
            _repo.AddCarModel(newmodel);
            return RedirectToAction("Models");
        }

        [Route("admin/deletemodel/{id}")]
        public ActionResult DeleteModel(int id)
        {
            _repo.DeleteCarModel(id);
            return RedirectToAction("Models");
        }

        [Authorize(Roles = "admin")]
        public ActionResult Users()

        {
            var model = new UserListVM();

            model.Users = _repo.GetUsers();

            model.Roles = _repo.GetRoles();

            return View(model);

        }

        [Authorize(Roles = "admin")]
        public ActionResult DeleteUser(string id)
        {
            return View(_repo.GetUserById(id));
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public ActionResult DeleteUser(AppUser data, string submitButton)
        {
            if (submitButton == "Delete")
            {
                _repo.DeleteUser(data.Id);

            }
            return RedirectToAction("Users", "Admin");
        }

        [Authorize(Roles = "admin")]
        public ActionResult AddUser()
        {
            var model = new UserVM();
            model.Roles = _repo.GetRoles().Select(m => new SelectListItem() { Text = m.Name, Value = m.Name }).ToList();
            return View(model);
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public ActionResult AddUser(UserVM data)
        {
            var selectedRole = data.AppRoleId;
            _repo.AddUser(data.User, data.NewPassword, selectedRole);
            return RedirectToAction("Users", "Admin");
        }

        [Authorize(Roles = "admin")]
        public ActionResult EditUser(string id)
        {
            var model = new UserVM();
            model.User = _repo.GetUserById(id);
            model.Roles = _repo.GetRoles().Select(r => new SelectListItem() { Text = r.Name, Value = r.Name }).ToList();
            return View(model);
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public ActionResult EditUser(UserVM data)
        {
            if (!ModelState.IsValid)
            {
                var model = new UserVM();
                model.User = _repo.GetUserById(data.User.Id);
                model.RoleList = _repo.GetRoles();
                return View(model);
            }
            if (data.NewPassword == data.ConfirmPass)
            {
                var selectedRole = data.AppRoleId;
                _repo.EditUser(data.User, selectedRole, data.NewPassword);
            }
            else
            {
                ModelState.AddModelError("Password", "Password fields must match");
                var model = new UserVM();
                model.User = _repo.GetUserById(data.User.Id);
                model.RoleList = _repo.GetRoles();
                return View(model);
            }
            return RedirectToAction("Users", "Admin");
        }

        [Authorize(Roles = "admin, sales")]
        public ActionResult ChangePassword()
        {
            var model = new ChangePassVM();
            return View(model);
        }

        [Authorize(Roles = "admin, sales")]
        [HttpPost]
        public ActionResult ChangePassword(ChangePassVM data)
        {
            if (!ModelState.IsValid)
            {
                var model = new ChangePasswordVM();
                return View(model);
            }
            if (data.NewPassword == data.ConfirmPassword)
            {
                var AutheticationManager = HttpContext.GetOwinContext().Authentication;
                AutheticationManager.SignOut();
                var userId = User.Identity.GetUserId();
                _repo.ChangePassword(userId, data.NewPassword);
            }
            else
            {
                ModelState.AddModelError("Password", "Password fields must match");
                var model = new ChangePasswordVM();
                return View(model);
            }
            return RedirectToAction("Index", "Home");
        }
    }
}