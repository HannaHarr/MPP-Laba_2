using NUnit.Framework;
using Laba_2;

namespace NUnitTestFaker
{
    public class Tests
    {
        private FirstClass first;
        [SetUp]
        public void Setup()
        {
            Faker.Faker faker = new Faker.Faker();
            first = faker.Create<FirstClass>();
        }

        [Test]
        public void ObjectNotEqualNull()
        {
            Assert.IsNotNull(first, "Error: object was not created");
        }

        [Test]
        public void IntegerValueNotDefault()
        {
            Assert.AreNotEqual(first.integerValue, 0, "Error: integerValue had default value");
        }

        [Test]
        public void IntegerPropertyNotDefault()
        {
            Assert.AreNotEqual(first.IntegerProperty, 0, "Error: IntegerProperty had default value");
        }

        [Test]
        public void CharPropertyNotDefault()
        {
            Assert.AreNotEqual(first.CharProperty, '\0', "Error: CharProperty had default value");
        }

        [Test]
        public void ListCreated()
        {
            Assert.IsNotNull(first.list, "Error: object was not created");
        }

        [Test]
        public void FirstEqualNull()
        {
            Assert.IsNull(first.first, "Error: object was created not default");
        }

        [Test]
        public void DecNotEqualNull()
        {
            Assert.AreNotEqual(first.dec, 0m, "Error: decimal had default value");
        }
    }
}