using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Faker
{
    public class Faker : IFaker
    {
        private const string PLUGINS = @"Plugins";

        private Dictionary<Type, IValueGenerator> Generators = new Dictionary<Type, IValueGenerator>
        {
            [typeof(int)] = new IntegerGenerator(),
            [typeof(bool)] = new BoolGenerator(),
            [typeof(byte)] = new ByteGenerator(),
            [typeof(decimal)] = new DecimalGenerator(),
            [typeof(float)] = new FloatGenerator(),
            [typeof(long)] = new LongGenerator(),
            [typeof(sbyte)] = new SbyteGenerator(),
            [typeof(short)] = new ShortGenerator(),
            [typeof(string)] = new StringGenerator(),
            [typeof(uint)] = new UintGenerator(),
            [typeof(ulong)] = new UlongGenerator(),
            [typeof(ushort)] = new UshortGenerator(),
            [typeof(DateTime)] = new DateTimeGenerator()
        };

        public Faker()
        {

        }

        private void LoadPlagins()
        {
            if (!Directory.Exists(PLUGINS))
            {
                return;
            }
            var dir = new DirectoryInfo(PLUGINS);

            foreach (FileInfo file in dir.GetFiles())
            {
                string fileName = Path.GetFileName(file.FullName);
                if (fileName.Contains(".dll") && fileName.Contains("Generator"))
                {
                    Assembly asm = Assembly.LoadFrom(PLUGINS + "/" + fileName);
                    Type[] types = asm.GetTypes();
                    foreach (Type t in types)
                    {
                        if (t.Name.Contains("Generator"))
                        {
                            Generators.Add(t.BaseType.GetGenericArguments()[0], (IValueGenerator)Activator.CreateInstance(t));
                        }
                    }
                }
            }
        }

        // Публичный метод для пользователя
        public T Create<T>() 
        {
            return (T)Create(typeof(T));
        }

        // Метод для внутреннего использования
        private object Create(Type t) 
        {
            // Процедура создания и инициализации объекта.
            object obj = null;
            return obj;
        }
        private static object GetDefaultValue(Type t)
        {
            if (t.IsValueType)
                // Для типов-значений вызов конструктора по умолчанию даст default(T).
                return Activator.CreateInstance(t);
            else
                // Для ссылочных типов значение по умолчанию всегда null.
                return null;
        }
    }
}
