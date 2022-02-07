using JsonEquals.Extension;
using JsonEquals.Extension.Result;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonEqualsTest.Extension
{
    [TestFixture, Category("Unit")]
    public class ObjectExtensionTest
    {
        [Test]
        public void GIVEN_EqualData_WHEN_JsonEquals_THEN_True()
        {
            //Assemble
            IDictionary<string, int> leftDictionary = new Dictionary<string, int>
            {
                {"Hello", 1 },
                {"Goodbye", 2 },
            };
            IDictionary<string, int> rightDictionary = new Dictionary<string, int>
            {
                {"Hello", 1 },
                {"Goodbye", 2 },
            };

            //Act
            IEqualityResult comparison = leftDictionary.JsonEquals(rightDictionary);

            //Assert
            Assert.IsTrue(comparison.IsEqual, comparison.Message);
        }

        [Test]
        public void GIVEN_DifferingData_WHEN_JsonEquals_THEN_False()
        {
            //Assemble
            IDictionary<string, int> leftDictionary = new Dictionary<string, int>
            {
                {"Hello", 1 },
                {"Goodbye", 2 },
            };
            IDictionary<string, int> rightDictionary = new Dictionary<string, int>
            {
                {"Hello", 1 },
                {"Goodbye", 3 },
            };

            //Act
            IEqualityResult comparison = leftDictionary.JsonEquals(rightDictionary);

            //Assert
            Assert.IsFalse(comparison.IsEqual, comparison.Message);
        }

        [Test]
        public void GIVEN_DifferingType_WHEN_JsonEquals_THEN_False()
        {
            //Assemble
            object objLeft = "I'm a string";
            object objRight = 400;

            //Act
            IEqualityResult comparison = objLeft.JsonEquals(objRight);

            //Assert
            Assert.IsFalse(comparison.IsEqual, comparison.Message);
        }

        [Test]
        public void GIVEN_BothNull_WHEN_JsonEquals_THEN_True()
        {
            //Assemble
            object objLeft = null;
            object objRight = null;

            //Act
            IEqualityResult comparison = objLeft.JsonEquals(objRight);

            //Assert
            Assert.IsTrue(comparison.IsEqual, comparison.Message);
        }

        [Test]
        public void GIVEN_RightNullLeftNotNull_WHEN_JsonEquals_THEN_False()
        {
            //Assemble
            object objLeft = new();
            object objRight = null;

            //Act
            IEqualityResult comparison = objLeft.JsonEquals(objRight);

            //Assert
            Assert.IsFalse(comparison.IsEqual, comparison.Message);
        }

        [Test]
        public void GIVEN_LeftNullRightNotNull_WHEN_JsonEquals_THEN_False()
        {
            //Assemble
            object objLeft = null;
            object objRight = new();

            //Act
            IEqualityResult comparison = objLeft.JsonEquals(objRight);

            //Assert
            Assert.IsFalse(comparison.IsEqual, comparison.Message);
        }

        [Test]
        public void GIVEN_ReferenceEquals_WHEN_JsonEquals_THEN_True()
        {
            //Assemble
            object objLeft = new();
            object objRight = objLeft;

            //Act
            IEqualityResult comparison = objLeft.JsonEquals(objRight);

            //Assert
            Assert.IsTrue(comparison.IsEqual, comparison.Message);
        }
    }
}
