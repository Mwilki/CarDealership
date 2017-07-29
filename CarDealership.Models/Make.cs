using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Models
{
    public class Make
    {
        public int MakeId { get; set; }
        public string MakeName { get; set; }
        public List<Model> Models { get; set; }
    }
}
