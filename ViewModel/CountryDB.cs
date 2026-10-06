using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Data.OleDb;
using System.Threading.Tasks;

namespace ViewModel
{
    public class CountryDB:BaseDB
    {
        public override BaseEntity NewEntity()
        {
            return new Country();
        }
        public CountryList SelectAll()
        {
            command.CommandText = $"SELECT * FROM Country";
            CountryList CountryLst = new CountryList(base.Select());
            return CountryLst;
        }
        static private CountryList list = new CountryList();
        public static Country SelectById(int id)
        {
            CountryDB db = new CountryDB();
            list = db.SelectAll();
            Country co = list.Find(item => item.Id == id);
            return co;
        }
        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Country c = entity as Country;
            c.CountryName = reader["CountryName"].ToString();
            base.CreateModel(entity);
            return entity;
        }
    }
}
