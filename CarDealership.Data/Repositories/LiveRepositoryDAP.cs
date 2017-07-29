using CarDealership.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarDealership.Models;

namespace CarDealership.Data.Repositories
{
    public class LiveRepositoryDAP : IRepository
    {
        public void CreateVehicle(Vehicle vehicle)
        {
            throw new NotImplementedException();
        }

        public void DeleteVehicleById(int id)
        {
            throw new NotImplementedException();
        }

        public void EditVehicle(Vehicle vehicle)
        {
            throw new NotImplementedException();
        }

        public List<Vehicle> GetAllVehicles()
        {
            throw new NotImplementedException();
        }

        public Vehicle GetVehicleById(int id)
        {
            throw new NotImplementedException();
        }

        public void MakePurchase(Sale sale, Vehicle vehicle)
        {
            throw new NotImplementedException();
        }
    }
}
