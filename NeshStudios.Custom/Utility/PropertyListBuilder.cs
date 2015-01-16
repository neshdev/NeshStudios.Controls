using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NeshStudios.Custom.Utility
{
    public class PropBuilder<T>
    {
        public void fluent()
        {
            //PropertyBuilder.Entity<Person>()                
            //    .MapProperty(x => x.Address)
            //    .ToType<Address>(x=> x.Person)
            //    .Create();
        }
    }


    public class PropertyListBuilder
    {
        public static List<string> CreatePropertyList<T>(string baseName = "")
        {
            if (!string.IsNullOrEmpty(baseName)) baseName = baseName + ".";

            List<string> values = new List<string>();

            foreach (var item in typeof(T).GetProperties())
            {
                var propertyName = item.Name;

                if (item.PropertyType.IsClass && !(item.PropertyType.Module.ScopeName == "CommonLanguageRuntimeLibrary"))
                {
                    continue;
                }
                if (!typeof(string).Equals(item.PropertyType) &&
                        typeof(IEnumerable).IsAssignableFrom(item.PropertyType))
                {
                    continue;
                }
                else
                {
                    values.Add(baseName + propertyName);
                }
            }

            return values;
        }
    }
}
