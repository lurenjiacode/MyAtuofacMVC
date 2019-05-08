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
    public class BlogArticleDao : IBlogArticleDao
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

        public int Add(BlogArticle blogArticle)
        {
            using (Conn)
            {
                string query = "INSERT INTO BlogArticle(Title,Keywords,Creator,BlogContent,BlogCreateTime)VALUES(@Title,@Keywords,@Creator,@BlogContent,@BlogCreateTime)";
                return Conn.Execute(query, blogArticle);
            }
        }

        public bool Del(BlogArticle blogArticle)
        {
            using (Conn)
            {
                string deletestr = "DELETE FROM BlogArticle WHERE BlogID = @BlogID";
                return Conn.Execute(deletestr, blogArticle) > 0 ? true : false;
            }
        }
        public IList<BlogArticle> GetList()
        {
            using (Conn)
            {
                string query = "SELECT * FROM BlogArticle";
                return Conn.Query<BlogArticle>(query).ToList();
            }
        }
        public BlogArticle Get(BlogArticle blogArticle)
        {
            return this.Get(blogArticle.BlogID);
        }
        public BlogArticle Get(int blogID)
        {
            using (Conn)
            {
                string query = "SELECT * FROM BlogArticle WHERE BlogID = @BlogID ";
                return Conn.Query<BlogArticle>(query, new { BlogID = blogID }).SingleOrDefault();
            }
        }

        public bool Update(BlogArticle blogArticle)
        {
            using (Conn)
            {
                string query = "UPDATE BlogArticle SET Title=@Title,Keywords=@Keywords,Creator=@Creator,BlogContent=@BlogContent,BlogCreateTime=@BlogCreateTime,";
                return Conn.Execute(query, blogArticle) > 0 ? true : false;
            }
        }
    }

}
