using System;
using Faker;

namespace DoubleGeneratorPlagin
{
    public class DoubleGenerator : TypedValueGenerator<double>
    {
        protected override double Generate(GeneratorContext context)
        {
            return context.Random.NextDouble();
        }
    }
}
