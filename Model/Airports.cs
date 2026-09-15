using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Airports:BaseEntity
    {
        private string airportName;
        private Country country;

        public string AirportName { get => airportName; set => airportName = value; }
        public Country Country { get => country; set => country = value; }
    }
}
