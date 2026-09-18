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

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Country c = entity as Country;
            c.CountryName = reader["CountryName"].ToString();
            base.CreateModel(entity);
            return entity;
        }
    }
}
