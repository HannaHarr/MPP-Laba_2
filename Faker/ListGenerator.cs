using System;
using System.Collections;
using System.Collections.Generic;

namespace Faker
{
    public class ListGenerator : IValueGenerator
    {
        public bool CanGenerate(Type type)
        {
            if (type.IsGenericType)
            {
                return type.GetGenericTypeDefinition().Equals(typeof(List<>));
            }

            return false;
        }
        
        public object Generate(GeneratorContext context)
        {
            // targetType = List<int>
            IList obj = (IList) Activator.CreateInstance(context.TargetType);

            Type elementType = context.TargetType.GetGenericArguments()[0];
            int count = context.Random.Next(1, 16);
            for (int i = 0; i < count; i++)
            {
                obj.Add(context.Faker.Create(elementType));
            }

            return obj;
        }
    }
}
