namespace CarDealership.Models.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CarDealership.Models.CarDealershipEntities>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CarDealership.Models.CarDealershipEntities context)
        {

            context.VehicleMakers.AddOrUpdate(ma => ma.MakeId,
                new Make
                {
                    MakeId = 1,
                    MakeName = "Bowser",
                    Models = new List<Model>() {
                        new Model { ModelId = 1, ModelName = "Koopa" },
                        new Model { ModelId = 2, ModelName = "Goomba" },
                        new Model { ModelId = 3, ModelName = "Hammer Head" }
                    }
                },
                new Make
                {
                    MakeId = 2,
                    MakeName = "Yoshi",
                    Models = new List<Model>() {
                        new Model { ModelId = 1, ModelName = "Green Shell" },
                        new Model { ModelId = 2, ModelName = "Red Shell" },
                        new Model { ModelId = 3, ModelName = "Blue Shell" }
                    }
                },
                new Make
                {
                    MakeId = 2,
                    MakeName = "Mario",
                    Models = new List<Model>() {
                        new Model { ModelId = 1, ModelName = "C 100" },
                        new Model { ModelId = 2, ModelName = "CC 200" },
                        new Model { ModelId = 3, ModelName = "CCC 300" }
                    }
                }
            );
            context.SaveChanges();


            context.VehicleModels.AddOrUpdate(m => m.ModelId,
            new Model { ModelId = 1, ModelName = "Koopa" },
            new Model { ModelId = 2, ModelName = "Goomba" },
            new Model { ModelId = 3, ModelName = "Hammer Head" },
            new Model { ModelId = 4, ModelName = "Green Shell" },
            new Model { ModelId = 5, ModelName = "Red Shell" },
            new Model { ModelId = 6, ModelName = "Blue Shell" },
            new Model { ModelId = 7, ModelName = "C 100" },
            new Model { ModelId = 8, ModelName = "CC 200" },
            new Model { ModelId = 9, ModelName = "CCC 300" }
            );
            context.SaveChanges();



            context.Vehicles.AddOrUpdate(v => v.Id,
                new Vehicle
                {
                    Id = 1,
                    Make = context.VehicleMakers.Single(e => e.MakeId == 1).MakeName,
                    Model = context.VehicleModels.Single(e => e.ModelId == 1).ModelName,
                    Year = 2010,
                    Image = "imgs/2010ChevyCamaro.jpg",
                    IsNew = true,
                    BodyStyle = "Coupe",
                    Trans = "Auto",
                    Color = "Blue",
                    Interior = "Crocodile",
                    Mileage = 100000,
                    VinNumber = "1HGCM82633A004352",
                    SalePrice = 21000,
                    MSRP = 24000,
                    Description = "Runs Great, Leather Interior, Vroom",
                    InStock = true,
                    IsFeatured = true
                },
                new Vehicle
                {
                    Id = 2,
                    Make = context.VehicleMakers.Single(e => e.MakeId == 1).MakeName,
                    Model = context.VehicleModels.Single(e => e.ModelId == 2).ModelName,
                    Year = 2010,
                    Image = "imgs/2015ToyotaCamry.jpg",
                    IsNew = false,
                    BodyStyle = "Coupe",
                    Trans = "Auto",
                    Color = "Blue",
                    Interior = "Crocodile",
                    Mileage = 100000,
                    VinNumber = "1HGCM82633A004352",
                    SalePrice = 21000,
                    MSRP = 24000,
                    Description = "Runs Great, Leather Interior, Vroom",
                    InStock = true,
                    IsFeatured = true
                },
                new Vehicle
                {
                    Id = 3,
                    Make = context.VehicleMakers.Single(e => e.MakeId == 1).MakeName,
                    Model = context.VehicleModels.Single(e => e.ModelId == 3).ModelName,
                    Year = 2010,
                    Image = "imgs/2012Bboy.jpg",
                    IsNew = true,
                    BodyStyle = "Coupe",
                    Trans = "Auto",
                    Color = "Blue",
                    Interior = "Crocodile",
                    Mileage = 100000,
                    VinNumber = "1HGCM82633A004352",
                    SalePrice = 21000,
                    MSRP = 24000,
                    Description = "Runs Great, Leather Interior, Vroom",
                    InStock = false,
                    IsFeatured = false
                },
                new Vehicle
                {
                    Id = 4,
                    Make = context.VehicleMakers.Single(e => e.MakeId == 2).MakeName,
                    Model = context.VehicleModels.Single(e => e.ModelId == 1).ModelName,
                    Year = 2010,
                    Image = "imgs/2016Boned.jpg",
                    IsNew = false,
                    BodyStyle = "Coupe",
                    Trans = "Auto",
                    Color = "Blue",
                    Interior = "Crocodile",
                    Mileage = 100000,
                    VinNumber = "1HGCM82633A004352",
                    SalePrice = 21000,
                    MSRP = 24000,
                    Description = "Runs Great, Leather Interior, Vroom",
                    InStock = false,
                    IsFeatured = false
                },
                new Vehicle
                {
                    Id = 5,
                    Make = context.VehicleMakers.Single(e => e.MakeId == 2).MakeName,
                    Model = context.VehicleModels.Single(e => e.ModelId == 2).ModelName,
                    Year = 2010,
                    Image = "imgs/futuristic.jpg",
                    IsNew = false,
                    BodyStyle = "Coupe",
                    Trans = "Auto",
                    Color = "Blue",
                    Interior = "Crocodile",
                    Mileage = 100000,
                    VinNumber = "1HGCM82633A004352",
                    SalePrice = 21000,
                    MSRP = 24000,
                    Description = "Runs Great, Leather Interior, Vroom",
                    InStock = true,
                    IsFeatured = true
                },
                new Vehicle
                {
                    Id = 6,
                    Make = context.VehicleMakers.Single(e => e.MakeId == 2).MakeName,
                    Model = context.VehicleModels.Single(e => e.ModelId == 3).ModelName,
                    Year = 2010,
                    Image = "imgs/2023yoshi.jpg",
                    IsNew = true,
                    BodyStyle = "Coupe",
                    Trans = "Auto",
                    Color = "Blue",
                    Interior = "Crocodile",
                    Mileage = 100000,
                    VinNumber = "1HGCM82633A004352",
                    SalePrice = 21000,
                    MSRP = 24000,
                    Description = "Runs Great, Leather Interior, Vroom",
                    InStock = false,
                    IsFeatured = false
                },
                new Vehicle
                {
                    Id = 7,
                    Make = context.VehicleMakers.Single(e => e.MakeId == 3).MakeName,
                    Model = context.VehicleModels.Single(e => e.ModelId == 1).ModelName,
                    Year = 2010,
                    Image = "imgs/nostalgi1954.jpg",
                    IsNew = false,
                    BodyStyle = "Coupe",
                    Trans = "Auto",
                    Color = "Blue",
                    Interior = "Crocodile",
                    Mileage = 100000,
                    VinNumber = "1HGCM82633A004352",
                    SalePrice = 21000,
                    MSRP = 24000,
                    Description = "Runs Great, Leather Interior, Vroom",
                    InStock = true,
                    IsFeatured = true
                },
                new Vehicle
                {
                    Id = 8,
                    Make = context.VehicleMakers.Single(e => e.MakeId == 3).MakeName,
                    Model = context.VehicleModels.Single(e => e.ModelId == 2).ModelName,
                    Year = 2010,
                    Image = "imgs/2019bowbow.jpg",
                    IsNew = false,
                    BodyStyle = "Coupe",
                    Trans = "Auto",
                    Color = "Blue",
                    Interior = "Crocodile",
                    Mileage = 100000,
                    VinNumber = "1HGCM82633A004352",
                    SalePrice = 21000,
                    MSRP = 24000,
                    Description = "Runs Great, Leather Interior, Vroom",
                    InStock = true,
                    IsFeatured = false
                },
                new Vehicle
                {
                    Id = 9,
                    Make = context.VehicleMakers.Single(e => e.MakeId == 3).MakeName,
                    Model = context.VehicleModels.Single(e => e.ModelId == 3).ModelName,
                    Year = 2018,
                    Image = "imgs/2019bowbow.jpg",
                    IsNew = false,
                    BodyStyle = "Coupe",
                    Trans = "Auto",
                    Color = "Blue",
                    Interior = "Crocodile",
                    Mileage = 100000,
                    VinNumber = "1HGCM82633A004352",
                    SalePrice = 21000,
                    MSRP = 24000,
                    Description = "Runs Great, Leather Interior, Vroom",
                    InStock = false,
                    IsFeatured = false
                }
            );
            context.SaveChanges();

            context.Interiors.AddOrUpdate(i => i.InteriorId,
            new Interior { InteriorId = 1, InteriorName = "Leather" },
            new Interior { InteriorId = 2, InteriorName = "Cloth" },
            new Interior { InteriorId = 2, InteriorName = "Mooncloth" },
            new Interior { InteriorId = 2, InteriorName = "Jerkin" }
            );
            context.SaveChanges();


            context.BodyTypes.AddOrUpdate(b => b.BodyTypeId,
            new BodyType { BodyTypeId = 1, BodyTypeName = "Shell" },
            new BodyType { BodyTypeId = 2, BodyTypeName = "Metal" },
            new BodyType { BodyTypeId = 3, BodyTypeName = "Granite" },
            new BodyType { BodyTypeId = 4, BodyTypeName = "Steel" },
            new BodyType { BodyTypeId = 5, BodyTypeName = "Diamond" }
            );
            context.SaveChanges();

            context.Colors.AddOrUpdate(c => c.ColorId,
            new Color { ColorId = 1, ColorName = "Yellow" },
            new Color { ColorId = 2, ColorName = "Black" },
            new Color { ColorId = 3, ColorName = "White" },
            new Color { ColorId = 4, ColorName = "Green" },
            new Color { ColorId = 5, ColorName = "Red" },
            new Color { ColorId = 6, ColorName = "Blue" }
            );
            context.SaveChanges();

            context.Specials.AddOrUpdate(s => s.Id,
            new Special { Title = "Holy shit", Details = "What a shitty special lol" },
            new Special { Title = "Meh", Details = "It's an alright special" },
            new Special { Title = "Fine", Details = "This is fine." }
            );
            context.SaveChanges();

            context.Transmissions.AddOrUpdate(t => t.TransmissionId,
            new Transmission { TransmissionId = 1, TransmissionName = "3 Core Single" },
            new Transmission { TransmissionId = 1, TransmissionName = "6 Core Double" },
            new Transmission { TransmissionId = 1, TransmissionName = "Dual Exhaust" },
            new Transmission { TransmissionId = 1, TransmissionName = "Millenium Horse" }
            );
            context.SaveChanges();

            var userMgr = new UserManager<AppUser>(new UserStore<AppUser>(context));
            var roleMgr = new RoleManager<AppRole>(new RoleStore<AppRole>(context));

            if (roleMgr.RoleExists("admin") || roleMgr.RoleExists("salesperson"))
            {
                roleMgr.Delete(roleMgr.Roles.SingleOrDefault(r => r.Name == "admin"));
                roleMgr.Delete(roleMgr.Roles.SingleOrDefault(r => r.Name == "salesperson"));
            }

            if (userMgr.Users.Count() > 0)
            {
                userMgr.Delete(userMgr.Users.SingleOrDefault(u => u.UserName == "admin"));
                userMgr.Delete(userMgr.Users.SingleOrDefault(u => u.UserName == "sally"));
            }

            roleMgr.Create(new AppRole() { Name = "admin" });
            roleMgr.Create(new AppRole() { Name = "salesperson" });

            var user = new AppUser()
            {
                UserName = "admin"
            };

            var user2 = new AppUser()
            {
                UserName = "sally"
            };

            userMgr.Create(user, "admin123");
            userMgr.Create(user2, "sales123");
            userMgr.AddToRole(user.Id, "admin");
            userMgr.AddToRole(user2.Id, "salesperson");
        }
    }
}
