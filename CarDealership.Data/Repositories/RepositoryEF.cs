using CarDealership.Data.Interfaces;
using CarDealership.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data.Repositories
{
    public class RepositoryEF : IRepository
    {
        CarDealershipEntities _repo = new CarDealershipEntities();

        public void AddCarMake(Make make)
        {
            make.MakeId = _repo.VehicleMakers.Max(e => e.MakeId) + 1;
            _repo.VehicleMakers.Add(make);
            _repo.SaveChanges();
        }

        public void AddCarModel(Model model)
        {
            model.ModelId = _repo.VehicleModels.Max(e => e.ModelId) + 1;
            _repo.VehicleModels.Add(model);
            _repo.SaveChanges();
        }

        public void AddContactDetails(Contact data)
        {
            if (_repo.Contacts.Count() == 0)
            {
                data.ContactId = 1;
            } else
            {
                data.ContactId = _repo.Contacts.Max(e => e.ContactId) + 1;
            }
            _repo.Contacts.Add(data);
            _repo.SaveChanges();
        }

        public void DeleteUser(string id)
        {
            var userMgr = new UserManager<AppUser>(new UserStore<AppUser>(_repo));
            userMgr.Delete(_repo.Users.SingleOrDefault(u => u.Id == id));
        }

        public void AddUser(AppUser user, string pass, string role)
        {
            var userMgr = new UserManager<AppUser>(new UserStore<AppUser>(_repo));
            var roleMgr = new RoleManager<AppRole>(new RoleStore<AppRole>(_repo));
            if (!_repo.Users.Any(u => u.UserName == user.UserName))
            {
                IdentityResult test = userMgr.Create(user, pass);
                userMgr.AddToRole(_repo.Users.SingleOrDefault(u => u.UserName == user.UserName).Id, role);
            }
        }

        public void CreateSpecial(Special special)
        {
            special.Id = _repo.Specials.Max(e => e.Id) + 1;
            _repo.Specials.Add(special);
            _repo.SaveChanges();
        }

        public void CreateVehicle(Vehicle vehicle)
        {
            vehicle.Id = _repo.Vehicles.Max(e => e.Id) + 1;
            _repo.Vehicles.Add(vehicle);
            _repo.SaveChanges();
        }

        public void DeleteCarMake(int id)
        {
            var make = _repo.VehicleMakers.FirstOrDefault(e => e.MakeId == id);
            _repo.VehicleMakers.Remove(make);
            _repo.SaveChanges();
        }

        public void DeleteCarModel(int id)
        {
            var model = _repo.VehicleModels.FirstOrDefault(e => e.ModelId == id);
            _repo.VehicleModels.Remove(model);
            _repo.SaveChanges();
        }

        public void DeleteSpecialById(int id)
        {
            var special = _repo.Specials.FirstOrDefault(e => e.Id == id);
            _repo.Specials.Remove(special);
            _repo.SaveChanges();
        }

        public void DeleteVehicleById(int id)
        {
            var vehicle = _repo.Vehicles.FirstOrDefault(e => e.Id == id);
            _repo.Vehicles.Remove(vehicle);
            _repo.SaveChanges();
        }

        public void EditUser(AppUser user, string selectedRole, string newPassword)
        {
            var userMgr = new UserManager<AppUser>(new UserStore<AppUser>(_repo));
            var found = _repo.Users.SingleOrDefault(u => u.Id == user.Id);
            userMgr.RemoveFromRole(user.Id, "salesperson");
            userMgr.Update(found);
            userMgr.AddToRole(found.Id, selectedRole);
            userMgr.RemovePassword(found.Id);
            userMgr.Update(found);
        }

        public void EditVehicle(Vehicle vehicle)
        {
            var found = _repo.Vehicles.FirstOrDefault(v => v.Id == vehicle.Id);
            found.Make = vehicle.Make;
            found.Model = vehicle.Model;
            found.Year = vehicle.Year;
            found.Image = vehicle.Image;
            found.IsNew = vehicle.IsNew;
            found.BodyStyle = vehicle.BodyStyle;
            found.Trans = vehicle.Trans;
            found.Color = vehicle.Color;
            found.Interior = vehicle.Interior;
            found.Mileage = vehicle.Mileage;
            found.VinNumber = vehicle.VinNumber;
            found.SalePrice = vehicle.SalePrice;
            found.MSRP = vehicle.MSRP;
            found.Description = vehicle.Description;
            found.IsFeatured = vehicle.IsFeatured;
            found.InStock = vehicle.InStock;
            _repo.SaveChanges();
        }

        public List<BodyType> GetAllBodyTypes()
        {
            return _repo.BodyTypes.ToList();
        }

        public List<Color> GetAllColors()
        {
            return _repo.Colors.ToList();
        }

        public List<Vehicle> GetAllFeatured()
        {
            return _repo.Vehicles.ToList().FindAll(e => e.IsFeatured == true && e.InStock == true );
        }

        public List<Interior> GetAllInteriors()
        {
            return _repo.Interiors.ToList();
        }

        public List<Make> GetAllMakes()
        {
            return _repo.VehicleMakers.ToList();
        }

        public List<Model> GetAllModels()
        {
            return _repo.VehicleModels.ToList();
        }

        public List<Vehicle> GetAllNewVehicles(string quicksearch, int pricehigh, int pricelow, int yearlow, int yearhigh)
        {
            if (pricehigh <= 0)
            {
                pricehigh = 999999;
            }
            if (yearhigh <= 0)
            {
                yearhigh = 3000;
            }
            var newCars = _repo.Vehicles.ToList().FindAll(e => e.IsNew != false);
            var priceRange = newCars.FindAll(e => e.SalePrice >= pricelow && e.SalePrice <= pricehigh);
            var yearRange = priceRange.FindAll(e => e.Year >= yearlow && e.Year <= yearhigh);
            if (quicksearch != null)
            {
                return yearRange.FindAll(e => e.Make.ToUpper().Contains(quicksearch) || e.Model.ToUpper().Contains(quicksearch) || e.Year.ToString() == quicksearch);

            }
            return yearRange;
        }

        public List<Transmission> GetAllTransmissions()
        {
            return _repo.Transmissions.ToList();
        }

        public List<Vehicle> GetAllVehicles()
        {
            return _repo.Vehicles.ToList();
        }

        public List<IdentityRole> GetRoles()
        {
            return _repo.Roles.ToList();
        }

        public List<Special> GetSpecials()
        {
            return _repo.Specials.ToList();
        }

        public AppUser GetUserById(string id)
        {
            return _repo.Users.FirstOrDefault(u => u.Id == id);
        }

        public List<AppUser> GetUsers()
        {
            return _repo.Users.ToList();
        }

        public Vehicle GetVehicleById(int id)
        {
            return _repo.Vehicles.FirstOrDefault(e => e.Id == id);
        }

        public List<Vehicle> GetVehiclesInStock(string quicksearch, int pricehigh, int pricelow, int yearlow, int yearhigh)
        {
            if (pricehigh <= 0)
            {
                pricehigh = 999999;
            }
            if (yearhigh <= 0)
            {
                yearhigh = 3000;
            }
            var newCars = _repo.Vehicles.ToList().FindAll(c => c.InStock == true);
            var priceRange = newCars.FindAll(e => e.SalePrice >= pricelow && e.SalePrice <= pricehigh);
            var yearRange = priceRange.FindAll(e => e.Year >= yearlow && e.Year <= yearhigh);
            if (quicksearch != null)
            {
                return yearRange.FindAll(e => e.Make.ToUpper().Contains(quicksearch) || e.Model.ToUpper().Contains(quicksearch) || e.Year.ToString() == quicksearch);

            }
            return yearRange;
        }

        public void VehicleOutOfStock(int id)
        {
            var vehicle = _repo.Vehicles.FirstOrDefault(e => e.Id == id);
            vehicle.InStock = false;
        }

        public void ChangePassword(string userId, string newPassword)
        {
            var userMgr = new UserManager<AppUser>(new UserStore<AppUser>(_repo));
            var found = _repo.Users.SingleOrDefault(u => u.Id == userId);
            userMgr.RemovePassword(found.Id);
            userMgr.AddPassword(found.Id, newPassword);
            userMgr.Update(found);
        }

        public AppUser GetUserByGuid(string id)
        {
            return _repo.Users.SingleOrDefault(e => e.Id == id);
        }

        public void MakePurchase(string salespersonId, Sale sale, Vehicle vehicle)
        {
            var employee = GetUserByGuid(salespersonId).UserName;
            Statistic stats = new Statistic();
            if (_repo.Statistics.Count() != 0)
            {
                var found = _repo.Statistics.FirstOrDefault(e => e.SalesPerson == employee);
                found.SalesPerson = employee;
                found.TotalSales += sale.PurchasePrice;
                found.VehiclesSold += 1;
            }
            else
            {
                stats.SalesPerson = employee;
                stats.TotalSales = sale.PurchasePrice;
                stats.VehiclesSold = 1;
                _repo.Statistics.Add(stats);
            }
            _repo.SaveChanges();
        }

        public List<Statistic> GetStatistics()
        {
            return _repo.Statistics.ToList();
        }

        public List<Vehicle> GetAllUsedVehicles(string quicksearch, int pricehigh, int pricelow, int yearlow, int yearhigh)
        {
            if (pricehigh <= 0)
            {
                pricehigh = 999999;
            }
            if (yearhigh <= 0)
            {
                yearhigh = 3000;
            }
            var newCars = _repo.Vehicles.ToList().FindAll(e => e.IsNew == false);
            var priceRange = newCars.FindAll(e => e.SalePrice >= pricelow && e.SalePrice <= pricehigh);
            var yearRange = priceRange.FindAll(e => e.Year >= yearlow && e.Year <= yearhigh);
            if (quicksearch != null)
            {
                return yearRange.FindAll(e => e.Make.ToUpper().Contains(quicksearch) || e.Model.ToUpper().Contains(quicksearch) || e.Year.ToString() == quicksearch);

            }
            return yearRange;
        }
    }
}
