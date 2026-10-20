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
            //foreach (Users u in users)
            //{
            //    Console.WriteLine($"{u.Id},{u.Name},{u.Email},{u.Pass},{u.IsActive}");
            //}

            ////Users userToUpdate = users[0];
            ////userToUpdate.Name += "א";
            ////userToUpdate.Email += "א";
            ////userToUpdate.Pass += "א";
            ////userToUpdate.IsActive = false;
            ////userdb.Update(userToUpdate);
            ////int x = userdb.SaveChanges();
            ////Console.WriteLine($"{x} rows were update");

            //UsersDB udb = new();
            //Users myusers = new Users() { Name = "ravid ohayon" , Email = "ravidohayon@gmail.com",Pass = "ro23211",IsActive = true};
            //udb.Insert(myusers);
            //int uin = udb.SaveChanges();
            //Console.WriteLine($"{uin} rows were inserted");

            //Console.WriteLine("==========================");
            //CountryList country;
            //CountryDB countrydb = new CountryDB();
            //country = countrydb.SelectAll();
            //foreach (Country c in country)
            //{
            //    Console.WriteLine($"{c.Id},{c.CountryName}");
            //}

            //Country countryToUpdate = country[0];
            //countryToUpdate.CountryName = "Israel";
            //countrydb.Update(countryToUpdate);
            //int y = countrydb.SaveChanges();
            //Console.WriteLine($"{y} rows were update");

            //CountryDB cdb = new();
            //Country myCountry = new Country() { CountryName = "Mexico" };
            //cdb.Insert(myCountry);
            //int cin = cdb.SaveChanges();
            //Console.WriteLine($"{cin} rows were inserted");

            //Console.WriteLine("==========================");
            PlanesList planes;
            PlanesDB planesdb = new PlanesDB();
            planes = planesdb.SelectAll();
            //foreach (Planes p in planes)
            //{
            //    Console.WriteLine($"{p.Id},{p.Model},{p.TotalSeats}");
            //}

            //Planes planesToUpdate = planes[0];
            //planesToUpdate.Model += 1;
            //planesToUpdate.TotalSeats += 1;
            //planesdb.Update(planesToUpdate);
            //int z = planesdb.SaveChanges();
            //Console.WriteLine($"{z} rows were update");

            //PlanesDB pdb = new();
            //Planes myPlanes = new Planes() { Model = 999,TotalSeats = 60 };
            //pdb.Insert(myPlanes);
            //int pin = pdb.SaveChanges();
            //Console.WriteLine($"{pin} rows were inserted");

            //Console.WriteLine("==========================");
            AirportsList airports;
            AirportsDB airportsdb = new AirportsDB();
            airports = airportsdb.SelectAll();
            //foreach (Airports a in airports)
            //{
            //    Console.WriteLine($"{a.Id},{a.AirportName},{a.Country.CountryName}");
            //}

            //Airports airportToUpdate = airports[0];
            //airportToUpdate.AirportName += "א";
            //airportToUpdate.Country.Id += 1;
            //airportsdb.Update(airportToUpdate);
            //int l = airportsdb.SaveChanges();
            //Console.WriteLine($"{l} rows were update");

            //AirportsDB apdb = new();
            //Airports myAirports = new Airports() { AirportName = "MiamiAP", Country = country[2] };
            //apdb.Insert(myAirports);
            //int apin = apdb.SaveChanges();
            //Console.WriteLine($"{apin} rows were inserted");

            Console.WriteLine("==========================");
            FlightList flight;
            FlightDB flightdb = new FlightDB();
            flight = flightdb.SelectAll();
            //foreach (Flight f in flight)
            //{
            //    Console.WriteLine($"{f.Id},{f.OriginId.AirportName},{f.DestinationId.AirportName},{f.DepartureTime},{f.ArrivalTime},{f.PlaneId.Id},{f.IsCanceled},{f.PriceInDolar}");
            //}
            //Flight flightToUpdate = flight[0];
            //flightToUpdate.OriginId.Id += 1;
            //flightToUpdate.DestinationId.Id += 1;
            //flightToUpdate.DepartureTime = DateTime.Now;
            //flightToUpdate.ArrivalTime = DateTime.Now;
            //flightToUpdate.PlaneId.Id = 1;
            //flightToUpdate.IsCanceled = false;
            //flightToUpdate.PriceInDolar += 1;
            //flightdb.Update(flightToUpdate);
            //int v = flightdb.SaveChanges();
            //Console.WriteLine($"{v} rows were update");

            FlightDB fdb = new();
            Flight myFlight = new Flight() { OriginId = airports[1], DestinationId = airports[2], DepartureTime = DateTime.Now, ArrivalTime = DateTime.Now, PlaneId = planes[3], IsCanceled = false, PriceInDolar = 1000};
            fdb.Insert(myFlight);
            int fin = fdb.SaveChanges();
            Console.WriteLine($"{fin} rows were inserted");


            //Console.WriteLine("==========================");
            //BookingsList bookings;
            //BookingsDB bookingssdb = new BookingsDB();
            //bookings = bookingssdb.SelectAll();
            //foreach (Bookings b in bookings)
            //{
            //    Console.WriteLine($"{b.Id},{b.UserId.Id},{b.FlightId.Id},{b.SeatNumber},{b.Rating}");
            //}
            //Bookings bookingToUpdate = bookings[0];
            //bookingToUpdate.UserId.Id += 1;
            //bookingToUpdate.FlightId.Id += 1;
            //bookingToUpdate.SeatNumber += 1;
            //bookingToUpdate.Rating += 1;
            //bookingssdb.Update(bookingToUpdate);
            //int q = bookingssdb.SaveChanges();
            //Console.WriteLine($"{q} rows were update");

            //BookingsDB bdb = new();
            //Bookings myBookings = new Bookings() { UserId = users[1], FlightId = flight[1], SeatNumber=1, Rating=2 };
            //bdb.Insert(myBookings);
            //int bin = bdb.SaveChanges();
            //Console.WriteLine($"{bin} rows were inserted");

            //Console.WriteLine("==========================");
            //ManagerList manager;
            //ManagerDB managerdb = new ManagerDB();
            //manager = managerdb.SelectAll();
            //foreach (Manager m in manager)
            //{
            //    Console.WriteLine($"{m.Id}");
            //}

            //ManagerDB mdb = new();
            //Manager myManager = new Manager() { Id=2,Name="Noam roz",Email = "noamroz@gmail.com",Pass= "nr12515",IsActive=true};
            //mdb.Insert(myManager);
            //int min = mdb.SaveChanges();
            //Console.WriteLine($"{min} rows were inserted");
            //Console.WriteLine("==========================");

        }
    }
}
