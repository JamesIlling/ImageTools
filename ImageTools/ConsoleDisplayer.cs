namespace ImageTools
{
    using System;
    using System.Linq;

    public class ConsoleDisplayer : IDisplay
    {
        public void Display<T>(T obj)
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