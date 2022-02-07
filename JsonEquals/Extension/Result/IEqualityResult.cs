using JsonEquals.Compare;

namespace JsonEquals.Extension.Result
{
    /// <summary>
    /// Object for encapsulating the result of comparing two objects
    /// </summary>
    public interface IEqualityResult
    {
        /// <summary>
        /// True iff the underlying objects being compared are equal
        /// </summary>
        bool IsEqual { get; }

        /// <summary>
        /// A message giving more context to this result.
        /// In the case of inequality, this can help explain in more detail why objects are not equal.
        /// </summary>
        string Message { get; }
    }
}