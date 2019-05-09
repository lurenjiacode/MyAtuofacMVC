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
    public class MovieService : IMovieService
    {
        private IMovieDao _movieDao;
        //构造器注入
        public MovieService(IMovieDao movieDao)
        {
            this._movieDao = movieDao;
        }

        public int Add(Movie movie)
        {
            return _movieDao.Add(movie);
        }

        public bool Del(Movie movie)
        {
            return _movieDao.Del(movie);
        }

        public Movie Get(Movie movie)
        {
            return _movieDao.Get(movie);
        }

        public Movie Get(int movID)
        {
            return _movieDao.Get(movID);
        }

        public IList<Movie> GetList()
        {
            return _movieDao.GetList();
        }

        public bool Update(Movie movie)
        {
            return _movieDao.Update(movie);
        }
    }
}
