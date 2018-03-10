namespace MetadataExtractor
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using DependencyFactory;

    public class ReflectionHelper : IGetProcessors
    {     
        public List<T> GetAll<T>()
        {
            var asms = AppDomain.CurrentDomain.GetAssemblies();
            return (from asm in asms
                from implementation in asm.GetTypes()
                    .Where(x => !x.IsAbstract && x.IsClass && x.GetInterfaces().Contains(typeof(T)))
                select (T) DependencyInjection.Resolve(implementation)).ToList();
        }
    }
}