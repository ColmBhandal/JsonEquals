using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonEquals.Extension.Result
{
    internal class LeftRightNullEqualityResultImpl : IEqualityResult
    {
        private readonly bool _isLeftNull;
        private readonly bool _isRightNull;
        private readonly bool _doesNullabilityMatch;

        public LeftRightNullEqualityResultImpl(bool isLeftNull, bool isRightNull)
        {
            _isLeftNull = isLeftNull;
            _isRightNull = isRightNull;
            if(!isLeftNull && !isRightNull)
            {
                throw new ArgumentException("Left/Right null equality result requires at least left or right to be null");
            }
            _doesNullabilityMatch = _isLeftNull == _isRightNull;
        }

        public bool IsEqual => _doesNullabilityMatch;

        private string? _message;
        public string Message => _message ??= _message = ComputeMessage();

        private string ComputeMessage()
        {
            if (IsEqual)
            {
                return "Both objects are null, therefore they are considered equal.";             
            }
            if (_isLeftNull)
            {
                return "Left object is null, right object is not null, therefore objects differ.";
            }
            return "Right object is null, left object is not null, therefore objects differ.";
        }
    }
}
