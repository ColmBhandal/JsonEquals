using JsonEquals.Compare;
using JsonEquals.Extension.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonEquals.Extension
{
    /// <summary>
    /// Extension methods for object
    /// </summary>
    public static class ObjectExtension
    {
        /// <summary>
        /// Compares two objects for JSON equality. 
        /// </summary>
        /// <param name="leftObj">First object to compare</param>
        /// <param name="rightObj">Other object with which to compare</param>
        /// <returns>A result determining if the objects are equal. <see cref="IEqualityResult"/>
        /// Note: two null objects are considered equal by this method.</returns>
        public static IEqualityResult JsonEquals(this object leftObj, object rightObj)
        {
            if (ReferenceEquals(leftObj, rightObj))
            {
                return new ReferenceEqualsResultImpl();
            }

            bool isLeftNull = leftObj == null;
            bool isRightNull = rightObj == null;
            if (isLeftNull || isRightNull)
            {
                return new LeftRightNullEqualityResultImpl(isLeftNull, isRightNull);
            }

            Type leftObjType = leftObj!.GetType();
            Type rightObjType = rightObj!.GetType();
            if(leftObjType != rightObjType)
            {
                return new TypeInequalityResultImpl(leftObjType, rightObjType);
            }

            IJsonComparer comparer = new JsonComparerImpl();
            var jsonComparison = comparer.JsonEquals(leftObj, rightObj);

            return jsonComparison;
        }

        /// <summary>
        /// Determines whether this object is equal to the other in terms of its serialized JSON content
        /// </summary>
        /// <param name="leftObj">The left object to compare</param>
        /// <param name="rightObj">The right object to compare</param>
        /// <returns>True iff the objects are equal, either referentially or by their serialized body</returns>
        public static bool IsJsonEqual(this object leftObj, object rightObj)
        {
            return leftObj.JsonEquals(rightObj).IsEqual;
        }
    }
}
