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
            Flight f = entity as Flight;
            if (f != null)
            {
                string sqlStr = $"Insert INTO Flight (OriginId,DestinationId,DepartureTime,ArrivalTime,PlaneId,IsCanceled,PriceInDolar) VALUES (@originId,@destinationId,@departureTime,@arrivalTime,@planeId,@isCanceled,@priceInDolar)";

                command.CommandText = sqlStr;
                command.Parameters.Add(new OleDbParameter("@originId", f.OriginId.Id));
                command.Parameters.Add(new OleDbParameter("@destinationId", f.DestinationId.Id));
                command.Parameters.Add("@DepartureTime", System.Data.OleDb.OleDbType.Date).Value = f.DepartureTime;
                command.Parameters.Add("@ArrivalTime", System.Data.OleDb.OleDbType.Date).Value = f.ArrivalTime;
                command.Parameters.Add(new OleDbParameter("@planeId", f.PlaneId.Id));
                command.Parameters.Add(new OleDbParameter("@isCanceled", f.IsCanceled));
                command.Parameters.Add(new OleDbParameter("@priceInDolar", f.PriceInDolar));
            }
        }

        protected override void CreateUpdatedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Flight c = entity as Flight;
            if (c != null)
            {
               
                string sqlStr = $"UPDATE Flight  SET OriginId=@OriginId , DestinationId=@DestinationId" +
                    $" , DepartureTime=@DepartureTime , ArrivalTime=@ArrivalTime ," +
                    $" PlaneId=@PlaneId , IsCanceled=@IsCanceled , PriceInDolar=@PriceInDolar" +
                    $" WHERE ID=@id";

                command.CommandText = sqlStr;
                command.Parameters.Add(new OleDbParameter("@OriginId", c.OriginId.Id));
                command.Parameters.Add(new OleDbParameter("@DestinationId", c.DestinationId.Id));
                command.Parameters.Add("@DepartureTime", System.Data.OleDb.OleDbType.Date).Value = c.DepartureTime;
                command.Parameters.Add("@ArrivalTime", System.Data.OleDb.OleDbType.Date).Value = c.ArrivalTime;
                command.Parameters.Add(new OleDbParameter("@PlaneId", c.PlaneId.Id));
                command.Parameters.Add(new OleDbParameter("@IsCanceled", c.IsCanceled));
                command.Parameters.Add(new OleDbParameter("@PriceInDolar", c.PriceInDolar));
                command.Parameters.Add(new OleDbParameter("@id", c.Id));
            }
        }
    }
}
