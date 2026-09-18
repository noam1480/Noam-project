using System;
using System.Collections.Generic;
using System.Linq;
using Model;
using System.Text;
using System.Data.OleDb;
using System.Threading.Tasks;

namespace ViewModel
{
    public class PlanesDB: BaseDB
    {
        public override BaseEntity NewEntity()
        {
            return new Users();
        }
        public PlanesList SelectAll()
        {
            command.CommandText = $"SELECT * FROM Planes";
            PlanesList PlanesLst = new PlanesList(base.Select());
            return PlanesLst;
        }

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Planes p = entity as Planes;
            p.Model = int.Parse(reader["Model"].ToString());
            p.TotalSeats = int.Parse(reader["TotalSeats"].ToString());
            base.CreateModel(entity);
            return entity;
        }
    }
}
