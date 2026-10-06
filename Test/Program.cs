using ViewModel;
using Model;
namespace Test
{
    public class Program
    {
        static void Main(string[] args)
        {
            UsersList users;
            UsersDB userdb = new UsersDB();
            users=userdb.SelectAll();
            foreach(Users u in users)
            {
                Console.WriteLine($"{u.Id},{u.Name},{u.Email},{u.Pass},{u.IsActive}");
            }
            Console.WriteLine("==========================");
            CountryList country;
            CountryDB countrydb = new CountryDB();
            country = countrydb.SelectAll();
            foreach(Country c in country)
            {
                Console.WriteLine($"{c.Id},{c.CountryName}");
            }
            Console.WriteLine("==========================");
            PlanesList planes;
            PlanesDB planesdb = new PlanesDB();
            planes = planesdb.SelectAll();
            foreach (Planes p in planes)
            {
                Console.WriteLine($"{p.Id},{p.Model},{p.TotalSeats}");
            }
            Console.WriteLine("==========================");
            AirportsList airports;
            AirportsDB airportsdb = new AirportsDB();
            airports = airportsdb.SelectAll();
            foreach (Airports a in airports)
            {
                Console.WriteLine($"{a.Id},{a.AirportName},{a.Country.CountryName}");
            }
            Console.WriteLine("==========================");
            FlightList flight;
            FlightDB flightdb = new FlightDB();
            flight = flightdb.SelectAll();
            foreach (Flight f in flight)
            {
                Console.WriteLine($"{f.Id},{f.OriginId.AirportName},{f.DestinationId.AirportName},{f.DepartureTime},{f.ArrivalTime},{f.PlaneId.Id},{f.IsCanceled},{f.PriceInDolar}");
            }
            Console.WriteLine("==========================");
            BookingsList bookings;
            BookingsDB bookingssdb = new BookingsDB();
            bookings = bookingssdb.SelectAll();
            foreach (Bookings b in bookings)
            {
                Console.WriteLine($"{b.Id},{b.UserId.Name},{b.FlightId.Id},{b.SeatNumber},{b.Rating}");
            }
            Console.WriteLine("==========================");
            ManagerList manager;
            ManagerDB managerdb = new ManagerDB();
            manager = managerdb.SelectAll();
            foreach (Manager m in manager)
            {
                Console.WriteLine($"{m.Id}");
            }
        }
    }
}
