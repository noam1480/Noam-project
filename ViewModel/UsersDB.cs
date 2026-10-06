using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.OleDb;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class UsersDB : BaseDB
    {
        public override BaseEntity NewEntity()
        {
            return new Users();
        }
        public UsersList SelectAll()
        {
            command.CommandText = $"SELECT * FROM Users";
            UsersList UsersLst = new UsersList(base.Select());
            return UsersLst;
        }
        static private UsersList list = new UsersList();
        public static Users SelectById(int id)
        {
            UsersDB db = new UsersDB();
            list = db.SelectAll();
            Users us = list.Find(item => item.Id == id);
            return us;
        }
        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Users u = entity as Users;
            u.Name = reader["Name"].ToString();
            u.Email = reader["Email"].ToString();
            u.Pass = reader["Pass"].ToString();
            u.IsActive =bool.Parse( reader["IsActive"].ToString());
            base.CreateModel(entity);
            return entity;
        }
    
    }
}
