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
    public class MovieClassifyDao : IMovieClassifyDao
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

        public int Add(MovieClassify movieClassify)
        {
            using (Conn)
            {
                string query = "INSERT INTO MovieClassify(MovClassify,ClassifyInfo)VALUES(@MovClassify,@ClassifyInfo)";
                return Conn.Execute(query, movieClassify);
            }
        }

        public bool Del(MovieClassify movieClassify)
        {
            using (Conn)
            {
                string deletestr = "DELETE FROM MovieClassify WHERE ID = @ID";
                return Conn.Execute(deletestr, movieClassify) > 0 ? true : false;
            }
        }

        public MovieClassify Get(MovieClassify movieClassify)
        {
            return this.Get(movieClassify.ID);
        }

        public MovieClassify Get(int id)
        {
            using (Conn)
            {
                string query = "SELECT * FROM MovieClassify WHERE ID = @ID ";
                return Conn.Query<MovieClassify>(query, new { BlogID = id }).SingleOrDefault();
            }
        }

        public IList<MovieClassify> GetList()
        {
            using (Conn)
            {
                string query = "SELECT * FROM MovieClassify";
                return Conn.Query<MovieClassify>(query).ToList();
            }
        }

        public bool Update(MovieClassify movieClassify)
        {
            throw new NotImplementedException();
        }
    }
}
