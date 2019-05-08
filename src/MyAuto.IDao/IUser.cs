using MyAuto.Entity;
using MyAutofac.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAuto.IDao
{
    public interface IUser : IDependency
    {
        Task<User> Get(User user);
        Task<bool> Del(User user);
        Task<bool> Update(User user);
        Task<int> Add(User user);
    }
}
