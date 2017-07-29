using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealership.Models
{
    public class TransmissionDictionary
    {
        public SelectList TransmissionSelectList
        {
            get { return new SelectList(AllTransmissions, "Value", "Key"); }
        }
        public static readonly IDictionary<string, string>
            AllTransmissions = new Dictionary<string, string> {
                //this needs to be a storedproc on the db to get all the unique colors in inventory table
                { "Automatic","Automatic" },
                { "Manual","Manual" },
                { "Manual 4-Speed","Manual 4-Speed" },
                { "Manual 5-Speed","Manual 5-Speed" },
                { "Manual 6-Speed","Manual 5-Speed" }
                
            };
    }
}
