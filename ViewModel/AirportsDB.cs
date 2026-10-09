using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Data.OleDb;
using System.Threading.Tasks;
using System.Configuration;

namespace ViewModel
{
    public class AirportsDB:BaseDB
    {
        public override BaseEntity NewEntity()
        {
            return new Airports();
        }
        public AirportsList SelectAll()
        {
            command.CommandText = $"SELECT * FROM Airports";
            AirportsList AirportsLst = new AirportsList(base.Select());
            return AirportsLst;
        }
        static private AirportsList list = new AirportsList();
        public static Airports SelectById(int id)
        {
            AirportsDB db = new AirportsDB();
            list = db.SelectAll();
            Airports a = list.Find(item => item.Id == id);
            return a;
        }
        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Airports ap = entity as Airports;
            ap.AirportName = reader["AirportName"].ToString();
            ap.Country = CountryDB.SelectById((int)reader["Country"]);
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
            Airports c = entity as Airports;
            if (c != null)
            {
                string sqlStr = $"UPDATE Airports  SET AirportName=@AirportName , Country=@Country WHERE ID=@id";

                command.CommandText = sqlStr;
                command.Parameters.Add(new OleDbParameter("@AirportName", c.AirportName));
                command.Parameters.Add(new OleDbParameter("@Country", c.Country.CountryName));
                command.Parameters.Add(new OleDbParameter("@id", c.Id));
            }
        }
    }
}
