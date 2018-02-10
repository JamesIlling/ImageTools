namespace DependencyFactory
{
    using System;
    using Unity;

    public static class DependencyInjection
    {
        private static readonly IUnityContainer Container = new UnityContainer();

        public static void RegisterType<TInterface, TType>() where TType : TInterface
        {
            Container.RegisterType<TInterface, TType>();
        }

        public static TType Resolve<TType>()
        {
            return Container.Resolve<TType>();
        }

        public static object Resolve(Type type)
        {
            return Container.Resolve(type);
        }
    }
}