using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Data.OleDb;
using System.Threading.Tasks;

namespace ViewModel
{
        public class BookingsDB : BaseDB
        {
            public override BaseEntity NewEntity()
            {
                return new Bookings();
            }
            public BookingsList SelectAll()
            {
                command.CommandText = $"SELECT * FROM Bookings";
                BookingsList BookingsLst = new BookingsList(base.Select());
                return BookingsLst;
            }
            static private BookingsList list = new BookingsList();
            public static Bookings SelectById(int id)
            {
                BookingsDB db = new BookingsDB();
                list = db.SelectAll();
                Bookings bo = list.Find(item => item.Id == id);
                return bo;
            }
            protected override BaseEntity CreateModel(BaseEntity entity)
            {
                Bookings b = entity as Bookings;
                b.UserId = UsersDB.SelectById((int)reader["UserId"]);
                b.FlightId = FlightDB.SelectById((int)reader["FlightId"]);
                b.SeatNumber = int.Parse(reader["SeatNumber"].ToString());
                b.Rating = int.Parse(reader["Rating"].ToString());  
                base.CreateModel(entity);
                return entity;
            }
        }
}
