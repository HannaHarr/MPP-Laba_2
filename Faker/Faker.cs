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

        private List<IValueGenerator> Generators = new List<IValueGenerator>
        {
            new IntegerGenerator(),
            new BoolGenerator(),
            new ByteGenerator(),
            new DecimalGenerator(),
            new FloatGenerator(),
            new LongGenerator(),
            new SbyteGenerator(),
            new ShortGenerator(),
            new StringGenerator(),
            new UintGenerator(),
            new UlongGenerator(),
            new UshortGenerator(),
            new DateTimeGenerator(),
            new ListGenerator()
        };

        public Faker()
        {
            LoadPlagins();
        }

        private void LoadPlagins()
        {
            if (!Directory.Exists(PLUGINS))
            {
                return;
            }

            DirectoryInfo dir = new DirectoryInfo(PLUGINS);

            foreach (FileInfo file in dir.GetFiles())
            {
                string fileName = Path.GetFileName(file.FullName);
                if (fileName.Contains(".dll"))
                {
                    Assembly asm = Assembly.LoadFrom(PLUGINS + "/" + fileName);
                    foreach (Type t in asm.GetTypes())
                    {
                        if (t.GetInterface("IValueGenerator") != null)
                        {
                            Generators.Add((IValueGenerator)Activator.CreateInstance(t));
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
        internal object Create(Type t) 
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
