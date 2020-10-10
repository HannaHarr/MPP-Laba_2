using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Faker
{
    public class ListGenerator : IValueGenerator
    {
        public bool CanGenerate(Type type)
        {
            if (type.IsGenericType)
            {
                return type.GetGenericTypeDefinition() == typeof(List<>);
            }

            return false;
        }
        
        public object Generate(GeneratorContext context)
        {
            // targetType = List<int>
            object obj = Activator.CreateInstance(context.TargetType);

            MethodInfo add = context.TargetType.GetMethod("Add");
            
            for (int i = 0; i < context.Random.Next(1, 16); i++)
            {
                add.Invoke(obj, new object[1] { context.Faker.Create(context.TargetType.GetGenericArguments()[0]) });
            }

            return obj;
        }
    }
}
