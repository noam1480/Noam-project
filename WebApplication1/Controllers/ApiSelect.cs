using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using ViewModel;
namespace WebApplication1.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ApiSelect : ControllerBase
    {
        [HttpGet]
        public UsersList SelectAllUsers()
        {
            UsersDB db = new UsersDB();
            UsersList users = db.SelectAll();
            return users;
        }
        [HttpGet]
        public PlanesList SelectAllPlanes()
        {
            PlanesDB db = new PlanesDB();
            PlanesList planes = db.SelectAll();
            return planes;
        }
        [HttpGet]
        public ManagerList SelectAllManager()
        {
            ManagerDB db = new ManagerDB();
            ManagerList managers = db.SelectAll();
            return managers;
        }
        [HttpGet]
        public FlightList SelectAllFlight()
        {
            FlightDB db = new FlightDB();
            FlightList flights = db.SelectAll();
            return flights;
        }
        [HttpGet]
        public CountryList SelectAllCountry()
        {
            CountryDB db = new CountryDB();
            CountryList countries = db.SelectAll();
            return countries;
        }
        [HttpGet]
        public BookingsList SelectAllBookings()
        {
            BookingsDB db = new BookingsDB();
            BookingsList bookings = db.SelectAll();
            return bookings;
        }
        [HttpGet]
        public AirportsList SelectAllAirPorts()
        {
            AirportsDB db = new AirportsDB();
            AirportsList airports = db.SelectAll();
            return airports;
        }
    }
}
