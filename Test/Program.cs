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
            users = userdb.SelectAll();
            foreach (Users u in users)
            {
                Console.WriteLine($"{u.Id},{u.Name},{u.Email},{u.Pass},{u.IsActive}");
            }

            Users userToUpdate = users[0];
            userToUpdate.Name += "א";
            userToUpdate.Email += "א";
            userToUpdate.Pass += "א";
            userToUpdate.IsActive = false;
            userdb.Update(userToUpdate);
            int x = userdb.SaveChanges();
            Console.WriteLine($"{x} rows were update");

            Console.WriteLine("==========================");
            CountryList country;
            CountryDB countrydb = new CountryDB();
            country = countrydb.SelectAll();
            foreach (Country c in country)
            {
                Console.WriteLine($"{c.Id},{c.CountryName}");
            }

            Country countryToUpdate = country[0];
            countryToUpdate.CountryName = "Israel";
            countrydb.Update(countryToUpdate);
            int y = countrydb.SaveChanges();
            Console.WriteLine($"{y} rows were update");


            Console.WriteLine("==========================");
            PlanesList planes;
            PlanesDB planesdb = new PlanesDB();
            planes = planesdb.SelectAll();
            foreach (Planes p in planes)
            {
                Console.WriteLine($"{p.Id},{p.Model},{p.TotalSeats}");
            }

            Planes planesToUpdate = planes[0];
            planesToUpdate.Model += 1;
            planesToUpdate.TotalSeats += 1;
            planesdb.Update(planesToUpdate);
            int z = planesdb.SaveChanges();
            Console.WriteLine($"{z} rows were update");

            Console.WriteLine("==========================");
            AirportsList airports;
            AirportsDB airportsdb = new AirportsDB();
            airports = airportsdb.SelectAll();
            foreach (Airports a in airports)
            {
                Console.WriteLine($"{a.Id},{a.AirportName},{a.Country.CountryName}");
            }

            Airports airportToUpdate = airports[0];
            airportToUpdate.AirportName += "א";
            airportToUpdate.Country.Id += 1;
            airportsdb.Update(airportToUpdate);
            int l = airportsdb.SaveChanges();
            Console.WriteLine($"{l} rows were update");

            Console.WriteLine("==========================");
            FlightList flight;
            FlightDB flightdb = new FlightDB();
            flight = flightdb.SelectAll();
            foreach (Flight f in flight)
            {
                Console.WriteLine($"{f.Id},{f.OriginId.AirportName},{f.DestinationId.AirportName},{f.DepartureTime},{f.ArrivalTime},{f.PlaneId.Id},{f.IsCanceled},{f.PriceInDolar}");


            }
            Flight flightToUpdate = flight[0];
            flightToUpdate.OriginId.Id += 1;
            flightToUpdate.DestinationId.Id += 1;
            flightToUpdate.DepartureTime = DateTime.Now;
            flightToUpdate.ArrivalTime = DateTime.Now;
            flightToUpdate.PlaneId.Id = 1;
            flightToUpdate.IsCanceled = false;
            flightToUpdate.PriceInDolar += 1;
            flightdb.Update(flightToUpdate);
            int v = flightdb.SaveChanges();
            Console.WriteLine($"{v} rows were update");

            Console.WriteLine("==========================");
            BookingsList bookings;
            BookingsDB bookingssdb = new BookingsDB();
            bookings = bookingssdb.SelectAll();
            foreach (Bookings b in bookings)
            {
                Console.WriteLine($"{b.Id},{b.UserId.Id},{b.FlightId.Id},{b.SeatNumber},{b.Rating}");
            }
            Bookings bookingToUpdate = bookings[0];
            bookingToUpdate.UserId.Id += 1;
            bookingToUpdate.FlightId.Id += 1;
            bookingToUpdate.SeatNumber += 1;
            bookingToUpdate.Rating += 1;
            bookingssdb.Update(bookingToUpdate);
            int q = bookingssdb.SaveChanges();
            Console.WriteLine($"{q} rows were update");

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
