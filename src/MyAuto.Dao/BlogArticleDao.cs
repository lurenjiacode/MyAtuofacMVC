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
    public class BlogArticleDao : IBlogArticle
    {

        string connString = ConfigurationManager.AppSettings["ConnectionString"];
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
                string query = "INSERT INTO WF_HjxtBatch(Bgmc,Bgzsbh,IsCopy,IsZip,CopyTime,UnderFolderName,ZipName,KjbgSpareA,KjbgSpareB,KjbgSpareC)VALUES(@bgmc,@bgzsbh,@isCopy,@isZip,@copyTime,@underFolderName,@zipName,@kjbgSpareA,@kjbgSpareB,@kjbgSpareC)";
                return Conn.Execute(query, blogArticle);
            }
        }

        public bool Del(BlogArticle blogArticle)
        {
            throw new NotImplementedException();
        }

        public Task<BlogArticle> Get(BlogArticle blogArticle)
        {
            throw new NotImplementedException();
        }

        public bool Update(BlogArticle blogArticle)
        {
            throw new NotImplementedException();
        }
    }
}
