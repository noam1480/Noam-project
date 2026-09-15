using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Planes:BaseEntity
    {
        private int model;
        private int totalSeats;

        public int Model { get => model; set => model = value; }
        public int TotalSeats { get => totalSeats; set => totalSeats = value; }
    }
}
