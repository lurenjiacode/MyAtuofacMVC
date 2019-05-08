using MyAuto.Entity;
using MyAutofac.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAuto.IService
{
    public interface IMovieService : IDependency
    {
        IList<Movie> GetList();
        Movie Get(Movie movie);
        Movie Get(int movID);
        bool Del(Movie movie);
        bool Update(Movie movie);
        int Add(Movie movie);
    }
}
