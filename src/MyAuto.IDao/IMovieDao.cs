using MyAuto.Entity;
using MyAutofac.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAuto.IDao
{
    public interface IMovieDao : IDependency
    {
        IList<Movie> GetList();
        Movie Get(Movie movie);
        Movie Get(int movid);
        bool Del(Movie movie);
        bool Update(Movie movie);
        int Add(Movie movie);
    }
}
