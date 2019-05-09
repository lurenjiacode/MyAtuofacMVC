using MyAuto.Dao;
using MyAuto.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class DateAdd
    {
        public void BlogArticleAdd()
        {
            BlogArticle blogArticle = new BlogArticle();
            blogArticle.BlogID = 2;
            blogArticle.Title = "Autofac搭建指南";
            blogArticle.Keywords = "Autofac";
            blogArticle.Creator = "lurenJ";
            blogArticle.BlogContent = "搭建步骤";
            blogArticle.BlogCreateTime = DateTime.Now;

            BlogArticleDao blogArticleDao = new BlogArticleDao();
            //BlogArticle a = blogArticleDao.Get(23);
            //Console.WriteLine("AAAOver:" + a.Title);
            //BlogArticleDao blogArticleDao = new BlogArticleDao();
            ////blogArticleDao.Add(blogArticle);

            ////var aaaa = blogArticleDao.GetList();
            for (int i = 0; i < 100; i++)
            {
                BlogArticle blogArticle2 = new BlogArticle();
                blogArticle2.BlogID = i;
                blogArticle2.Title = "Autofac搭建" + i;
                blogArticle2.Keywords = "Autofac" + i;
                blogArticle2.Creator = "lurenJ" + i;
                blogArticle2.BlogContent = "搭建步骤" + i;
                blogArticle2.BlogCreateTime = DateTime.Now;
                blogArticleDao.Add(blogArticle2);
                Console.WriteLine(i + " Over");
            }
            //var a = blogArticleDao.Del(blogArticle);
            //Console.WriteLine("删除：" + a);
        }

        public void MovieAdd()
        {
            Movie movie = new Movie();
            movie.MovName = "第一滴血";
            movie.Classify = "1|2|3";
            movie.Performer = "史泰龙";
            movie.CollectionNum = "2019";
            movie.FileName = "第一滴血.mp4";
            movie.ImgPath = "";
            movie.MovieCreateTime = DateTime.Now;
        }
    }
}
