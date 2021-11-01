using System;
using System.Reflection;
using Autofac;
using Tools.Infrastructure;

namespace Tools.Testing
{
    public class Substitutor
    {
        private static readonly MethodInfo SubstituteMethodInfo = typeof(Substitutor).GetMethod(
            nameof(Substitute),
            BindingFlags.Static | BindingFlags.NonPublic)!;

        public static object Substitute(Type type)
        {
            var substitute = SubstituteMethodInfo.MakeGenericMethod(type).Invoke(new Substitutor(), null);
            return substitute!;
        }

        private static T Substitute<T>() where T : class
        {
            return NSubstitute.Substitute.For<T>();
        }
    }

    // public class SubstituteDefault : IRegistrationSource
    // {
    //     private readonly MethodInfo substituteMethodInfo =
    //         typeof(DomainHooks).GetMethod(nameof(Sub), BindingFlags.Static | BindingFlags.NonPublic)!;
    //
    //     private static T Sub<T>() where T : class
    //     {
    //         return NSubstitute.Substitute.For<T>();
    //     }
    //
    //     public IEnumerable<IComponentRegistration> RegistrationsFor(
    //         Service                                         service,
    //         Func<Service, IEnumerable<ServiceRegistration>> registrationAccessor)
    //     {
    //         if (service == null)
    //             throw new ArgumentNullException(nameof(service));
    //
    //         if (registrationAccessor == null)
    //             throw new ArgumentNullException(nameof(registrationAccessor));
    //
    //         IServiceWithType? ts = service as IServiceWithType;
    //         if (ts == null || !ts.ServiceType.IsGenericType)
    //             yield break;
    //
    //         var a = this.substituteMethodInfo.MakeGenericMethod(typeof(IRepository<>)).Invoke(this, null);
    //
    //         ts.ServiceType.GetGenericTypeDefinition() == typeof(DataContext<>)))
    //
    //         yield return RegistrationBuilder.ForType(ts.ServiceType)
    //                                         .AsSelf()
    //                                         .WithParameter(new NamedParameter("databaseName", "test"))
    //                                         .WithParameter(new NamedParameter("serverName",   "test2"))
    //                                         .CreateRegistration();
    //     }
    //
    //     public bool IsAdapterForIndividualComponents => false;
    // }

    public class DomainHooks : Hooks
    {
        protected override void OverrideRegister(ContainerBuilder containerBuilder)
        {
            var type = Substitutor.Substitute(typeof(IRepository<>));
            containerBuilder.RegisterGeneric(typeof(SchoolRepository<>))
                            .As(typeof(IReadRepository<>))
                            .As(typeof(IWriteRepository<>))
                            .As(typeof(IRepository<>))
                            .InstancePerLifetimeScope();

            containerBuilder.RegisterInstance(Substitutor.Substitute(typeof(IRepository<>)))
                            .As(typeof(IRepository<>))
                            .InstancePerLifetimeScope();
        }
    }
}
