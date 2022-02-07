using JsonEquals.Extension.Result;

namespace JsonEquals.Compare
{
    /// <summary>
    /// A comparison between two objects, comparing the objects serialized as JSON strings
    /// </summary>
    public interface IJsonComparison : IEqualityResult
    {
        /// <summary>
        /// The left JSON string
        /// </summary>
        string Left { get; }

        /// <summary>
        /// The right JSON string
        /// </summary>
        string Right { get; }
    }
}