using Dapper;
using MyAuto.Entity;
using MyAuto.IDao;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAuto.Dao
{
    public class UserDao : IUser
    {
        
        string connString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
        private IDbConnection _conn;

        private IDbConnection Conn
        {
            get
            {
                return _conn = new SqlConnection(connString);
            }
        }

        public int Add(User user)
        {
            throw new NotImplementedException();
        }

        public bool Del(User user)
        {
            throw new NotImplementedException();
        }

        public User Get(User user)
        {
            throw new NotImplementedException();
        }

        public User Get(int id)
        {
            throw new NotImplementedException();
        }

        public IList<User> GetList()
        {
            throw new NotImplementedException();
        }

        public bool Update(User user)
        {
            throw new NotImplementedException();
        }

    }
}
