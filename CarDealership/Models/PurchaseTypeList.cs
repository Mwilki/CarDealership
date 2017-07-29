using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealership.Models
{
    public class PurchaseTypeList
    {
        public SelectList PurchaseTypeSelectList
        {
            get { return new SelectList(StateDictionary, "Value", "Key"); }
        }
        public static readonly IDictionary<string, string>
            StateDictionary = new Dictionary<string, string> {
                {"BankFinance","Bank Finance" },
                {"DealerFinance","Dealer Finance" },
                {"Cash","Cash" }
            };
    }
}