using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealership.Models
{
    public class ColorDictionary
    {
        public SelectList ColorSelectList
        {
            get { return new SelectList(AllColors, "Value", "Key"); }
        }
        public static readonly IDictionary<string, string>
            AllColors = new Dictionary<string, string> {
                //this needs to be a storedproc on the db to get all the unique colors in inventory table
                { "White","White" },
                { "Black","Black" },
                { "Red","Red" },
                { "Blue","Blue" },
                {"Green","Green" }
            };
    }
}