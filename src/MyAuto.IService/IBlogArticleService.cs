using MyAuto.Entity;
using MyAutofac.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAuto.IService
{
    public interface IBlogArticleService : IDependency
    {
        IList<BlogArticle> GetList();

        BlogArticle Get(BlogArticle blogArticle);
        BlogArticle Get(int blogID);

        bool Del(BlogArticle blogArticle);

        bool Update(BlogArticle blogArticle);

        int Add(BlogArticle blogArticle);
    }
}
