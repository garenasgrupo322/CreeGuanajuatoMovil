using System;
using System.Collections.Generic;

namespace CreeGuanajuatoMovil.Models
{
    public class GoogleAPI
    {
        public List<Results> results { get; set; }
        public string status { get; set; }
    }

    public class Results
    {
        public List<AddressComponents> address_components { get; set; }
    }

    public class AddressComponents
    {
        public string long_name { get; set; }
        public string short_name { get; set; }
        public string[] types { get; set; }
    }
}
