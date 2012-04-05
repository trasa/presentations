using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IoCDemo.Model;

namespace IoCDemo
{
    /// <summary>
    /// Note: this is truly hideous code.
    /// </summary>
    public class SuperController
    {



        public void DoIt(Order o, User u)
        {
            if (!(ValidateUser(u) && ValidateOrder(o)))
            {
                throw new ArgumentException("...");
            }
            Save(u);
            Save(o);
        }





        public bool ValidateOrder(Order o)
        {
            return false;
        }

        public bool ValidateUser(User u)
        {
            return true;
        }

        public void Save(User u)
        {
            OpenDatabase();
            string sql;
            if (u.IsNew)
            {
                sql = GetUserInsertSql();
            } 
            else
            {
                sql = GetUserUpdateSql();
            }
            Execute(sql, u);
            CloseDatabase();
        }

       


        public void Save(Order o)
        {
            OpenDatabase();
            string sql;
            if (o.IsNew)
            {
                sql = GetOrderInsertSql();
            } else
            {
                sql = GetOrderUpdateSql();
            }
            Execute(sql, o);
            CloseDatabase();
        }



        private void OpenDatabase()
        {
            // Connection = new Connection() or whatever.
        }


        private void Execute(string sql, object o)
        {
            // somehow matches up parameters between sql and o, and executes
            // them on our open database connection.
        }

        private void CloseDatabase()
        {
            // conn.Dispose();
        }


        private string GetUserUpdateSql()
        {
            return "UPDATE ...";
        }

        private string GetUserInsertSql()
        {
            return "INSERT INTO...";
        }


        private string GetOrderUpdateSql()
        {
            return "UPDATE ...";
        }

        private string GetOrderInsertSql()
        {
            return "INSERT INTO...";
        }
    }
}
