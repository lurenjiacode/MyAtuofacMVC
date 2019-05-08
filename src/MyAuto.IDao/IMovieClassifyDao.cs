using MyAuto.Entity;
using MyAutofac.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAuto.IDao
{
    public interface IMovieClassifyDao : IDependency
    {
        IList<MovieClassify> GetList();
        MovieClassify Get(MovieClassify movieClassify);
        MovieClassify Get(int id);
        bool Del(MovieClassify movieClassify);
        int Add(MovieClassify movieClassify);
    }
}
