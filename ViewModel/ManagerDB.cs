using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Data.OleDb;
using System.Threading.Tasks;

namespace ViewModel
{
    public class ManagerDB:UsersDB
    {
        public ManagerList SelectAll()
        {
            command.CommandText = $"SELECT Users.Id, Users.Name, Users.Email, Users.Pass, Users.IsActive FROM (Manager INNER JOIN Users ON Manager.Id = Users.Id)";
            ManagerList mlist = new ManagerList(base.Select());
            return mlist;
        }
        public override BaseEntity NewEntity()
        {
            return new Manager();
        }
        static private ManagerList list = new ManagerList();
        public static Manager SelectById(int id)
        {
            ManagerDB db = new ManagerDB();
            list = db.SelectAll();
            Manager ma = list.Find(item => item.Id == id);
            return ma;
        }
        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Manager m = entity as Manager;
            base.CreateModel(entity);
            return entity;
        }
        protected override void CreateDeletedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            throw new NotImplementedException();
        }

        protected override void CreateInsertdSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Manager m = entity as Manager;
            if (m != null)
            {
                string sqlStr = $"Insert INTO Manager (Id) VALUES (@id)";

                command.CommandText = sqlStr;
                command.Parameters.Add(new OleDbParameter("@id", m.Id));
            }
        }

        protected override void CreateUpdatedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            throw new NotImplementedException();
        }
        public override void Insert(BaseEntity entity)
        {
            BaseEntity reqEntity = this.NewEntity();
            if(entity!=null & entity.GetType()==reqEntity.GetType())
            {
                inserted.Add(new ChangeEntity(base.CreateInsertdSQL, entity));
                inserted.Add(new ChangeEntity(this.CreateInsertdSQL, entity));
            }
        }


    }
}
