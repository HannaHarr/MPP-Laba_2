using System;
using System.Collections.Generic;
using System.Text;

namespace Faker
{
    public class BoolGenerator : TypedValueGenerator<bool>
    {
        protected override bool Generate(GeneratorContext context)
        {
            return context.Random.Next() > (int.MaxValue / 2);
        }
    }
    public class CharGenerator : TypedValueGenerator<char>
    {
        protected override char Generate(GeneratorContext context)
        {
            return (char)context.Random.Next(char.MinValue, char.MaxValue);
        }
    }
    public class ByteGenerator : TypedValueGenerator<byte>
    {
        protected override byte Generate(GeneratorContext context)
        {
            return (byte)context.Random.Next();
        }
    }
    public class DecimalGenerator : TypedValueGenerator<decimal>
    {
        protected override decimal Generate(GeneratorContext context)
        {
            return (decimal)context.Random.NextDouble();
        }
    }
    public class DoubleGenerator : TypedValueGenerator<double>
    {
        protected override double Generate(GeneratorContext context)
        {
            return context.Random.NextDouble();
        }
    }
    public class FloatGenerator : TypedValueGenerator<float>
    {
        protected override float Generate(GeneratorContext context)
        {
            return (float)context.Random.NextDouble();
        }
    }
    public class IntegerGenerator : TypedValueGenerator<int>
    {
        protected override int Generate(GeneratorContext context)
        {
            return context.Random.Next();
        }
    }
    public class LongGenerator : TypedValueGenerator<long>
    {
        protected override long Generate(GeneratorContext context)
        {
            return (long)context.Random.Next();
        }
    }
    public class SbyteGenerator : TypedValueGenerator<sbyte>
    {
        protected override sbyte Generate(GeneratorContext context)
        {
            return (sbyte)context.Random.Next();
        }
    }
    public class ShortGenerator : TypedValueGenerator<short>
    {
        protected override short Generate(GeneratorContext context)
        {
            return (short)context.Random.Next();
        }
    }
    public class StringGenerator : TypedValueGenerator<string>
    {
        protected override string Generate(GeneratorContext context)
        {
            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < context.Random.Next(126); i++)
            {
                builder.Append((char)context.Random.Next(char.MinValue, char.MaxValue));
            }

            return builder.ToString();
        }
    }
    public class UintGenerator : TypedValueGenerator<uint>
    {
        protected override uint Generate(GeneratorContext context)
        {
            return (uint)context.Random.Next();
        }
    }
    public class UlongGenerator : TypedValueGenerator<ulong>
    {
        protected override ulong Generate(GeneratorContext context)
        {
            return (ulong)context.Random.Next();
        }
    }
    public class UshortGenerator : TypedValueGenerator<ushort>
    {
        protected override ushort Generate(GeneratorContext context)
        {
            return (ushort)context.Random.Next();
        }
    }
}
