using System.Linq;
using System.Reflection;
using System.Web.Compilation;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using AutoMapper;
using LotteryNumbersWriter;

namespace LotteryNumbersGenerator.Web
{
    public class AutofacConfig
    {
        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            builder.RegisterType<LotteryNumbersGenerator>().As<ILotteryNumbersGenerator>();
            builder.RegisterType<LotteryNumbersWriter.LotteryNumbersWriter>().As<ILotteryNumbersWriter>();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

        }
    }
}