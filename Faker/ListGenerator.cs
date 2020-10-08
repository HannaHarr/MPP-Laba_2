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
        /*
         *  Array values = Array.CreateInstance(t, 50);

        // and fill it with values of the required type
        for (int i = 0; i < 50; i++)
        {
            values.SetValue(CreateFooFromType(t), i);
        }

        // Create a list of the required type, passing the values to the constructor
        Type genericListType = typeof(List<>);
        Type concreteListType = genericListType.MakeGenericType(t);

        object list = Activator.CreateInstance(concreteListType, new object[] { values }); 

        // DO something with list which is now an List<t> filled with 50 ts
        return list;
         * */
        public object Generate(GeneratorContext context)
        {
            // targetType = List<int>
            object obj = Activator.CreateInstance(context.TargetType);
            //targetType = int
            /*  Type genericListType = typeof(List<>);
                Type concreteListType = genericListType.MakeGenericType(t);
            */

            MethodInfo add = context.TargetType.GetMethod("Add");
            
            for (int i = 0; i < context.Random.Next(1, 16); i++)
            {
                add.Invoke(obj, new object[1] { context.Faker.Create(context.TargetType.GetGenericArguments()[0]) });
            }

            return obj;
        }
    }
}
