namespace MetadataExtractor
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class ReflectionHelper
    {
        public static List<T> GetAll<T>()
        {
            var asms = AppDomain.CurrentDomain.GetAssemblies();
            return (from asm in asms
                from implementation in asm.GetTypes()
                    .Where(x => !x.IsAbstract && x.IsClass && x.GetInterfaces().Contains(typeof(T)))
                select (T) Activator.CreateInstance(implementation)).ToList();
        }

        public static void Display<T>(T obj)
        {
            if (obj != null)
            {
                foreach (var property in typeof(T).GetProperties().OrderBy(x => x.Name))
                {
                    var value = property.GetValue(obj);
                    if (value != null)
                    {
                        Console.Write(property.Name);
                        Console.Write(":");
                        Console.WriteLine(value.ToString());
                    }
                }
            }
        }
    }
}