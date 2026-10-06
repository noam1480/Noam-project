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
            return new Planes();
        }
        public PlanesList SelectAll()
        {
            command.CommandText = $"SELECT * FROM Planes";
            PlanesList PlanesLst = new PlanesList(base.Select());
            return PlanesLst;
        }
        static private PlanesList list = new PlanesList();
        public static Planes SelectById(int id)
        {
            PlanesDB db = new PlanesDB();
            list = db.SelectAll();
            Planes pl = list.Find(item => item.Id == id);
            return pl;
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
