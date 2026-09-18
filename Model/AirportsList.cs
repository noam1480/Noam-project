using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class AirportsList : List<Airports>
    {
        public AirportsList() { }
        public AirportsList(IEnumerable<Airports> list) : base(list) { }
        public AirportsList(IEnumerable<BaseEntity> list) : base(list.Cast<Airports>().ToList()) { }
    }
}
