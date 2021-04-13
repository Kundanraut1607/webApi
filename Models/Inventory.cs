using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopBridgeWebAPI.Models
{
    public class Inventory
    {
        
            public int Id { get; set; }
            public string name { get; set; }
            public string description { get; set; }
            public double price { get; set; }
            public DateTime AddedDate { get; set; }

    }
}