using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sklad.Models
{
    public class Thing
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SerialNumber { get; set; }
        public DateTime ProduceDate { get; set; }
    }
}