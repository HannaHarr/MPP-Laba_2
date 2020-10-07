using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Faker
{
    public class Faker : IFaker
    {
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
