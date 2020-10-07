using System;
using Faker;

namespace CharGeneratorPlagin
{
    public class CharGenerator : TypedValueGenerator<char>
    {
        protected override char Generate(GeneratorContext context)
        {
            return (char)context.Random.Next(char.MinValue, char.MaxValue);
        }
    }
}
