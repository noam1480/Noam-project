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

        protected override void CreateDeletedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Users u = entity as Users;
            if (u != null)
            {
                string sqlStr = $"UPDATE Users  SET IsActive={false} WHERE ID=@id";

                command.CommandText = sqlStr;
                command.Parameters.Add(new OleDbParameter("@id", u.Id));
            }
        }

        protected override void CreateInsertdSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Users u = entity as Users;
            if (u != null)
            {
                string sqlStr = $"Insert INTO Users (Name,Email,Pass,IsActive) VALUES (@Name,@Email,@Pass,@IsActive)";

                command.CommandText = sqlStr;
                command.Parameters.Add(new OleDbParameter("@Name", u.Name));
                command.Parameters.Add(new OleDbParameter("@Email", u.Email));
                command.Parameters.Add(new OleDbParameter("@Pass", u.Pass));
                command.Parameters.Add(new OleDbParameter("@IsActive", u.IsActive));
            }
        }

        protected override void CreateUpdatedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Users u = entity as Users;
            if (u != null)
            {
                string sqlStr = $"UPDATE Users  SET Name=@Name , Email=@Email , Pass=@Pass , IsActive=@IsActive WHERE ID=@id";

                command.CommandText = sqlStr;
                command.Parameters.Add(new OleDbParameter("@Name", u.Name));
                command.Parameters.Add(new OleDbParameter("@Email", u.Email));
                command.Parameters.Add(new OleDbParameter("@Pass", u.Pass));
                command.Parameters.Add(new OleDbParameter("@IsActive", u.IsActive));
                command.Parameters.Add(new OleDbParameter("@id", u.Id));
            }
        }
    }
}
