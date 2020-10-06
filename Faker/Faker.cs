using System;

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

        }
    }
}
