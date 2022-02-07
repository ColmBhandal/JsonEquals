using JsonEquals.Extension.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonEquals.Compare
{
    internal class JsonComparisonImpl : IJsonComparison
    {
        public string Left { get; }
        public string Right { get; }

        public JsonComparisonImpl(string leftOrNull, string rightOrNull)
        {
            Left = leftOrNull ?? throw new ArgumentNullException(nameof(leftOrNull));
            Right = rightOrNull ?? throw new ArgumentNullException(nameof(rightOrNull));
        }

        private bool? _isEqual;
        public bool IsEqual => _isEqual ??= Left == Right;

        private string? _message;
        public string Message => _message ??= ComputeMessage();

        private string ComputeMessage()
        {
            if (IsEqual)
            {
                return "Serialized JSON for objects is the same => Objects are equal.";
            }
            return $"Serialized JSON for objects differ. Left: {Left}. Right: {Right}";
        }
    }
}
