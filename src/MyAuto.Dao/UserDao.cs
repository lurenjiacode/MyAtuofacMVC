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

        public async Task<int> Add(User user)
        {
            using (Conn)
            {
                string query = "INSERT INTO WF_HjxtBatch(Bgmc,Bgzsbh,IsCopy,IsZip,CopyTime,UnderFolderName,ZipName,KjbgSpareA,KjbgSpareB,KjbgSpareC)VALUES(@bgmc,@bgzsbh,@isCopy,@isZip,@copyTime,@underFolderName,@zipName,@kjbgSpareA,@kjbgSpareB,@kjbgSpareC)";
                return await new Task<int>(() => Conn.Execute(query, user));
            }
        }                                                                                                                                                                                     

        public Task<bool> Del(User user)
        {
            throw new NotImplementedException();
        }

        public Task<User> Get(User user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(User user)
        {
            throw new NotImplementedException();
        }
    }
}
