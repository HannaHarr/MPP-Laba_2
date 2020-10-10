using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Faker
{
    public class Faker
    {
        private const string PLUGINS = @"Plugins";
        private Random random;
        private Stack<Type> Parents = new Stack<Type>();

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
            random = new Random();
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
        // Процедура создания и инициализации объекта
        internal object Create(Type type)
        {
            object obj;

            // Попробовать подобрать генератор
            if (TryChooseGenerator(type, out obj))
            {
                return obj;
            }

            if (Parents.Contains(type))
            {
                return GetDefaultValue(type);
            }

            Parents.Push(type);

            // Получить конструкторы 
            ConstructorInfo[] constructors = type.GetConstructors();

            // Отсортировать конструкторы по количеству параметров
            foreach (ConstructorInfo maxParamConstructor in constructors.OrderByDescending(item => item.GetParameters().Length))
            {
                try
                {
                    // Получить параметры
                    ParameterInfo[] parameters = maxParamConstructor.GetParameters();

                    // Создать параметры
                    object[] parametersArray = new object[parameters.Length];
                    for (int i = 0; i < parameters.Length; i++)
                    {
                        parametersArray[i] = Create(parameters[i].ParameterType);
                    }

                    // Создать объект
                    obj = maxParamConstructor.Invoke(parametersArray);
                    FillFields(obj);
                    FillProperties(obj);

                    Parents.Pop();
                    return obj;
                }
                catch { }
            }

            Parents.Pop();
            return null;
        }

        // Заполнить поля
        private void FillFields(object obj)
        {
            //BindingFlags.Public | BindingFlags.Instance
            FieldInfo[] fields = obj.GetType().GetFields();
            foreach (FieldInfo field in fields)
            {
                if (Equals(field.GetValue(obj), GetDefaultValue(field.FieldType)))
                {
                    field.SetValue(obj, Create(field.FieldType));
                }
            }
        }

        // Заполнить свойства
        private void FillProperties(object obj)
        {
            PropertyInfo[] properties = obj.GetType().GetProperties();
            foreach (PropertyInfo property in properties)
            {
                if (property.CanWrite && property.SetMethod.IsPublic && Equals(property.GetValue(obj), GetDefaultValue(property.PropertyType)))
                {
                    property.SetValue(obj, Create(property.PropertyType));
                }
            }
        }

        // Подобрать генератор
        private bool TryChooseGenerator(Type type, out object obj)
        {
            foreach (IValueGenerator generator in Generators)
            {
                if (generator.CanGenerate(type))
                {
                    GeneratorContext context = new GeneratorContext(random, type, this);
                    obj = generator.Generate(context);
                    return true;
                }
            }

            obj = null;
            return false;
        }

        // Получить дефолтное значение
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
