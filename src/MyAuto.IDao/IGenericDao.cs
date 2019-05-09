using MyAutofac.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAuto.IDao
{
    public interface IGenericDao<T> : IDependency
    {
        IList<T> GetList();
        T Get(T blogArticle);
        T Get(int id);
        bool Del(T t);
        bool Update(T t);
        int Add(T t);
    }
}
