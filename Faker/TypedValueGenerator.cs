using System;
using System.Collections.Generic;
using System.Text;

namespace Faker
{
    // Типизированный абстрактный класс для простых случаев (для примитивных типов,
    // чтобы не реализовывать каждый раз одинаковый метод CanGenerate).
    public abstract class TypedValueGenerator<T> : IValueGenerator
    {
        object IValueGenerator.Generate(GeneratorContext context)
        {
            return Generate(context);
        }

        public bool CanGenerate(Type type)
        {
            return type == typeof(T);
        }

        protected abstract T Generate(GeneratorContext context);
    }
}
