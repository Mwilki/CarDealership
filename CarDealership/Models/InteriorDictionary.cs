using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealership.Models
{
    public class InteriorDictionary
    {
        public SelectList InteriorSelectList
        {
            get { return new SelectList(AllInteriors, "Value", "Key"); }
        }
        public static readonly IDictionary<string, string>
            AllInteriors = new Dictionary<string, string> {
                //this needs to be a storedproc on the db to get all the unique interiors in inventory table
                { "Leather","Leather" },
                { "Faux Leather","Faux Leather" },
                { "Cloth","Cloth" }
            };
    }
}