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

        protected override void CreateDeletedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            throw new NotImplementedException();
        }

        protected override void CreateInsertdSQL(BaseEntity entity, OleDbCommand cmd)
        {
            throw new NotImplementedException();
        }

        protected override void CreateUpdatedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Flight c = entity as Flight;
            if (c != null)
            {
                string sqlStr = $"UPDATE Flight  SET OriginId=@OriginId , DestinationId=@DestinationId , DepartureTime=@DepartureTime , ArrivalTime=@ArrivalTime , PlaneId=@PlaneId , IsCanceled=@IsCanceled , PriceInDolar=@PriceInDolar WHERE ID=@id";

                command.CommandText = sqlStr;
                command.Parameters.Add(new OleDbParameter("@OriginId", c.OriginId.AirportName));
                command.Parameters.Add(new OleDbParameter("@OriginId", c.DestinationId.AirportName));
                command.Parameters.Add(new OleDbParameter("@DepartureTime", c.DepartureTime));
                command.Parameters.Add(new OleDbParameter("@ArrivalTime", c.ArrivalTime));
                command.Parameters.Add(new OleDbParameter("@PlaneId", c.PlaneId.Id));
                command.Parameters.Add(new OleDbParameter("@IsCanceled", c.IsCanceled));
                command.Parameters.Add(new OleDbParameter("@PriceInDolar", c.PriceInDolar));
                command.Parameters.Add(new OleDbParameter("@id", c.Id));
            }
        }
    }
}
