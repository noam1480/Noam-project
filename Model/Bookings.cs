using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Bookings:BaseEntity
    {
        private Users userId;
        private Flight flightId;
        private int seatNumber;
        private int rating;

        public Users UserId { get => userId; set => userId = value; }
        public Flight FlightId { get => flightId; set => flightId = value; }
        public int SeatNumber { get => seatNumber; set => seatNumber = value; }
        public int Rating { get => rating; set => rating = value; }
    }
}
