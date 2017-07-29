using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealership.Models
{
    public class ModelsDictionary
    {
        public SelectList ModelsSelectList
        {
            get { return new SelectList(AllModels, "Value", "Key"); }
        }
        public static readonly IDictionary<string, string>
            AllModels = new Dictionary<string, string> {
                //this needs to be a storedproc on the db to get all the unique models in inventory table
                { "Corolla","Corolla" },
                { "F150","F150" },
                { "Jeep Cherokee","Jeep Cherokee" },
                { "Impala","Impala" }
            };
    }
}