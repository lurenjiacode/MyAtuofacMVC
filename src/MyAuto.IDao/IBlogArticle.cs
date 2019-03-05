using MyAuto.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAuto.IDao
{
    public interface IBlogArticle
    {
        Task<BlogArticle> Get(BlogArticle blogArticle);
        bool Del(BlogArticle blogArticle);
        bool Update(BlogArticle blogArticle);
        int Add(BlogArticle blogArticle);
    }
}
