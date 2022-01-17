using Autofac;
using SwissClean.Dal;
using SwissClean.MVP.Login;
using SwissClean.MVP.MainView;

namespace SwissClean.Ioc
{
	public static class IocContainerBuilder
	{
		public static IResolver Build()
		{
			IContainer container = null;

			var builder = new ContainerBuilder();
			var resolver = new Resolver(() => container);

			builder.Register(a => resolver)
				.As<IResolver>()
				.SingleInstance();

			builder.RegisterType<DataAccessService>().As<IDataAccessService>().SingleInstance();

			builder.RegisterType<LoginModel>().As<ILoginModel>().SingleInstance();
			builder.RegisterType<MainModel>().As<MainModel>().SingleInstance();

			container = builder.Build();

			return resolver;
		}
	}
}
