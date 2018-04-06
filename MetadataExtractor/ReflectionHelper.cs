namespace MetadataExtractor
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using DependencyFactory;

    public class ReflectionHelper : IGetProcessors
    {
        public IEnumerable<T> GetAll<T>()
        {
            var asms = Assembly.GetExecutingAssembly();
            return
                asms.GetTypes()
                    .Where(x => !x.IsAbstract && x.IsClass)
                    .Where(x => x.GetInterfaces().Contains(typeof(T)))
                    .Select(implementation=> (T) DependencyInjection.Resolve(implementation));
        }
    }
}