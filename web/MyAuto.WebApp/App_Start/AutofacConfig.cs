using Autofac;
using Autofac.Integration.Mvc;
using MyAuto.Dao;
using MyAuto.IDao;
using MyAuto.IService;
using MyAuto.Service;
using MyAutofac.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Compilation;
using System.Web.Mvc;

namespace MyAuto.WebApp
{
    public class AutofacConfig
    {
        public static void Register4()
        {
            //实例化一个autofac的创建容器
            var builder = new ContainerBuilder();

            //注册MVC控制器（注册所有到控制器）
            //builder.RegisterControllers(Assembly.GetExecutingAssembly());//生成具体的实例


            builder.RegisterType<BlogArticleDao>().As<IBlogArticleDao>();
            builder.RegisterType<BlogArticleService>().As<IBlogArticleService>();

            //注册MVC控制器（注册所有到控制器）
            builder.RegisterControllers(Assembly.GetExecutingAssembly());//生成具体的实例

            //设置依赖解析器
            var _container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(_container));
            //DependencyResolver.SetResolver(new AutofacDependencyResolver(builder.Build()));

        }

        public static void Register()
        {
            //实例化一个autofac的创建容器
            var builder = new ContainerBuilder();

            var baseType = typeof(IDependency);

            //扫描IService和Service相关的程序集
            var assemblys = BuildManager.GetReferencedAssemblies().Cast<Assembly>()
                .Where(m => m.FullName.Contains("MyAuto")).ToList();
            
            //注册类型
            builder.RegisterAssemblyTypes(assemblys.ToArray())
                  .Where(t => baseType.IsAssignableFrom(t) && t != baseType)
                  .AsImplementedInterfaces().InstancePerLifetimeScope();

            //注册MVC控制器（注册所有到控制器）
            builder.RegisterControllers(assemblys.ToArray());

            //设置依赖解析器
            var _container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(_container));
        }
    }
}