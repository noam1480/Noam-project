using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class FlightList : List<Flight>
    {
        public FlightList() { }
        public FlightList(IEnumerable<Flight> list) : base(list) { }
        public FlightList(IEnumerable<BaseEntity> list) : base(list.Cast<Flight>().ToList()) { }
    }
}
