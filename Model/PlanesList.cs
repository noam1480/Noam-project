using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class PlanesList : List<Planes>
    {
        public PlanesList() { }
        public PlanesList(IEnumerable<Planes> list) : base(list) { }
        public PlanesList(IEnumerable<BaseEntity> list) : base(list.Cast<Planes>().ToList()) { }
    }
}
