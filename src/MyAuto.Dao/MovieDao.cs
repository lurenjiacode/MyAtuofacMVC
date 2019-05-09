using Dapper;
using MyAuto.Entity;
using MyAuto.IDao;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace MyAuto.Dao
{

    public class MovieDao : IMovieDao
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

        public int Add(Movie movie)
        {
            using (Conn)
            {
                string query = "INSERT INTO Movie(MovName,Classify,Performer,CollectionNum,FileName,ImgPath,MovieCreateTime)VALUES(@MovName,@Classify,@Performer,@CollectionNum,@FileName,@ImgPath,@MovieCreateTime)";
                return Conn.Execute(query, movie);
            }
        }

        public bool Del(Movie movie)
        {
            using (Conn)
            {
                string deletestr = "DELETE FROM Movie WHERE MovID = @MovID";
                return Conn.Execute(deletestr, movie) > 0 ? true : false;
            }
        }

        public Movie Get(Movie movie)
        {
            return this.Get(movie.MovID);
        }

        public Movie Get(int movid)
        {
            using (Conn)
            {
                string query = "SELECT * FROM Movie WHERE MovID = @MovID";
                return Conn.Query<Movie>(query, new { MovID = movid }).SingleOrDefault();
            }
        }

        public IList<Movie> GetList()
        {
            using (Conn)
            {
                string query = "SELECT * FROM Movie";
                return Conn.Query<Movie>(query).ToList();
            }
        }

        public bool Update(Movie movie)
        {
            using (Conn)
            {
                string query = "UPDATE Movie SET MovName=@MovName,Classify=@Classify,Performer=@Performer,CollectionNum=@CollectionNum,FileName=@FileName,ImgPath=@ImgPath,MovieCreateTime=@MovieCreateTime";
                return Conn.Execute(query, movie) > 0 ? true : false;
            }
        }
    }
}
