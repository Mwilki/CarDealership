using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealership.Models
{
    public class MakesDictionary
    {
        public SelectList MakesSelectList
        {
            get { return new SelectList(AllMakes, "Value", "Key"); }
        }
        public static readonly IDictionary<string, string>
            AllMakes = new Dictionary<string, string> {
                //this needs to be a storedproc on the db to get all the unique makes in inventory table
                { "Toyota","Toyota" },
                { "Ford","Ford" },
                { "Chrysler","Chrysler" },
                { "Chevrolet","Chevrolet" }
            };
    }
}
