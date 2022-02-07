using JsonEquals.Extension;
using JsonEquals.Extension.Result;
using NUnit.Framework;
using System.Text;

namespace JsonEquals.assert
{
    /// <summary>
    /// Extension methods for the Assert class. Useful for unit tests.
    /// </summary>
    public static class JsonAssert
    {
        /// <summary>
        /// Asserts that the objects are equal in terms of their serialized JSON content
        /// </summary>
        /// <param name="leftObj">The left object to compare</param>
        /// <param name="rightObj">The right object to compare</param>
        public static void AreJsonEqual(object leftObj, object rightObj)
        {
            IEqualityResult equality = leftObj.JsonEquals(rightObj);
            Assert.IsTrue(equality.IsEqual, equality.Message);
        }

        /// <summary>
        /// Asserts that the objects are equal in terms of their serialized JSON content
        /// </summary>
        /// <param name="leftObj">The left object to compare</param>
        /// <param name="rightObj">The right object to compare</param>
        /// <param name="customFailureMessage">A custom message to add to the assertion, in the case of failure</param>
        public static void AreJsonEqual(object leftObj, object rightObj, string customFailureMessage)
        {
            IEqualityResult equality = leftObj.JsonEquals(rightObj);
            StringBuilder sb = new StringBuilder()
                .AppendLine(customFailureMessage)
                .AppendLine(equality.Message);
            Assert.IsTrue(equality.IsEqual, sb.ToString());
        }
    }
}