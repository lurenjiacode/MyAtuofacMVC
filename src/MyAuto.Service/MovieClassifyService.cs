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
    public class MovieClassifyService : IMovieClassifyService
    {
        private IMovieClassifyDao _movieClassifyDao;
        //构造器注入
        public MovieClassifyService(IMovieClassifyDao movieClassifyDao)
        {
            this._movieClassifyDao = movieClassifyDao;
        }

        public int Add(MovieClassify movieClassify)
        {
            return _movieClassifyDao.Add(movieClassify);
        }

        public bool Del(MovieClassify movieClassify)
        {
            return _movieClassifyDao.Del(movieClassify);
        }

        public MovieClassify Get(MovieClassify movieClassify)
        {
            return _movieClassifyDao.Get(movieClassify);
        }

        public MovieClassify Get(int id)
        {
            return _movieClassifyDao.Get(id);
        }

        public IList<MovieClassify> GetList()
        {
            return _movieClassifyDao.GetList();
        }
    }
}
