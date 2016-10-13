using System;
using System.Collections.Generic;

namespace Recipe_13_04
{
    public class CountryCollection : List<Country> { }

    public class Country
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Capital { get; set; }
    }
}
