﻿using System;
using System.Reflection;
using Faker;

namespace Laba_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Faker.Faker faker = new Faker.Faker();

            FirstClass first = faker.Create<FirstClass>();

            Console.WriteLine(first.ToString());
        }
    }
}
