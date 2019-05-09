using MyAuto.Entity;
using MyAuto.IDao;
using MyAuto.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAuto.Service
{
    public class BlogArticleService : IBlogArticleService
    {
        private readonly IBlogArticleDao  _blogArticleDao;
        //构造器注入
        public BlogArticleService(IBlogArticleDao blogArticleDao)
        {
            this._blogArticleDao = blogArticleDao;
        }



        public int Add(BlogArticle blogArticle)
        {
           return _blogArticleDao.Add(blogArticle);
        }

        public bool Del(BlogArticle blogArticle)
        {
           return _blogArticleDao.Del(blogArticle);
        }

        public BlogArticle Get(BlogArticle blogArticle)
        {
            return _blogArticleDao.Get(blogArticle);
        }

        public BlogArticle Get(int blogID)
        {
            return _blogArticleDao.Get(blogID);
        }

        public IList<BlogArticle> GetList()
        {
            return _blogArticleDao.GetList();
        }

        public bool Update(BlogArticle blogArticle)
        {
            return _blogArticleDao.Update(blogArticle);
        }
    }
}
