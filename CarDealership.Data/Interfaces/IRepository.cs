using CarDealership.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data.Interfaces
{
    public interface IRepository
    {
        // vehicle - crud
        Vehicle GetVehicleById(int id);
        void CreateVehicle(Vehicle vehicle);
        void EditVehicle(Vehicle vehicle);
        void DeleteVehicleById(int id);

        // special - crud
        List<Special> GetSpecials();
        void CreateSpecial(Special special);
        void DeleteSpecialById(int id);
        // model - crud
        List<Model> GetAllModels();
        void AddCarModel(Model model);
        void DeleteCarModel(int id);
        List<Vehicle> GetAllNewVehicles(string quicksearch, int pricelow, int pricehigh, int yearlow, int yearhigh);
        void AddContactDetails(Contact data);

        // make - crud
        List<Make> GetAllMakes();
        void DeleteCarMake(int id);
        void AddCarMake(Make make);

        // get all 
        List<Color> GetAllColors();
        List<Statistic> GetStatistics();
        List<Vehicle> GetAllFeatured();
        List<BodyType> GetAllBodyTypes();
        List<Interior> GetAllInteriors();
        List<Transmission> GetAllTransmissions();
        List<Vehicle> GetAllVehicles();
        List<Vehicle> GetVehiclesInStock(string quicksearch, int pricelow, int pricehigh, int yearlow, int yearhigh);
        void VehicleOutOfStock(int id);
        List<Vehicle> GetAllUsedVehicles(string quicksearch, int pricelow, int pricehigh, int yearlow, int yearhigh);

        // identity
        List<AppUser> GetUsers();
        List<IdentityRole> GetRoles();
        AppUser GetUserById(string id);
        void EditUser(AppUser user, string selectedRole, string newPassword);
        void MakePurchase(string salesperson, Sale sale, Vehicle vehicle);
        void DeleteUser(string id);
        void AddUser(AppUser user, string newPassword, string selectedRole);
        void ChangePassword(string userId, string newPassword);
    }
}
