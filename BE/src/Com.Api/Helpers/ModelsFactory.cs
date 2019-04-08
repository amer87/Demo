using System;
using System.Collections.Generic;
using System.Reflection;

namespace Com.Api
{
    public class ModelsFactory
    {
        
        public TResult Create<TSource, TResult>(TSource entitySource)
            where TSource : class
            where TResult : class, new()
        {
            Type entitySourceType = entitySource.GetType();
            IList<PropertyInfo> propsSource = new List<PropertyInfo>(entitySourceType.GetProperties());

            TResult entityDist = new TResult();
            Type entityDistType = entityDist.GetType();

            foreach (PropertyInfo prop in propsSource)
            {
                if (!prop.CanRead)
                {
                    continue;
                }

                PropertyInfo targetProperty = entityDistType.GetProperty(prop.Name);
                if (targetProperty == null)
                {
                    continue;
                }
                if (!targetProperty.CanWrite)
                {
                    continue;
                }
                if (targetProperty.GetSetMethod(true) != null && targetProperty.GetSetMethod(true).IsPrivate)
                {
                    continue;
                }
                if (!targetProperty.PropertyType.IsAssignableFrom(prop.PropertyType))
                {
                    continue;
                }
                // Passed all tests, lets set the value
                targetProperty.SetValue(entityDist, prop.GetValue(entitySource, null), null);
            }

            return entityDist;
        }

    }
}
