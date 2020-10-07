using System;
using System.Collections.Generic;
using System.Text;

namespace Faker
{
    public class ListGenerator<T> : TypedValueGenerator<List<T>>
    {
        protected override List<T> Generate(GeneratorContext context)
        {
            List<T> list = new List<T>();

            for (int i = 0; i < context.Random.Next(5); i++)
            {
                list.Add(context.Faker.Create<T>());
            }

            return list;
        }
    }
}
