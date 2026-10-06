using Model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class FlightDB:BaseDB
    {
        public override BaseEntity NewEntity()
        {
            return new Flight();
        }
        public FlightList SelectAll()
        {
            command.CommandText = $"SELECT * FROM Flight";
            FlightList FlightLst = new FlightList(base.Select());
            return FlightLst;
        }
        static private FlightList list = new FlightList();
        public static Flight SelectById(int id)
        {
            FlightDB db = new FlightDB();
            list = db.SelectAll();
            Flight f = list.Find(item => item.Id == id);
            return f;
        }
        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Flight f = entity as Flight;
            f.OriginId = AirportsDB.SelectById((int)reader["OriginId"]);       
            f.DestinationId = AirportsDB.SelectById((int)reader["DestinationId"]);
            f.DepartureTime = DateTime.Parse(reader["DepartureTime"].ToString());
            f.ArrivalTime = DateTime.Parse(reader["ArrivalTime"].ToString());
            f.PlaneId = PlanesDB.SelectById((int)reader["PlaneId"]);
            f.IsCanceled = bool.Parse(reader["IsCanceled"].ToString());
            f.PriceInDolar = int.Parse(reader["PriceInDolar"].ToString());
            base.CreateModel(entity);
            return entity;
        }
    }
}
