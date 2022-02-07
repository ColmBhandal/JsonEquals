using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonEquals.Extension.Result
{
    internal class TypeInequalityResultImpl : IEqualityResult
    {
        private readonly Type _leftType;
        private readonly Type _rightType;

        public TypeInequalityResultImpl(Type leftType, Type rightType)
        {
            _leftType = leftType ?? throw new ArgumentNullException(nameof(leftType));
            _rightType = rightType ?? throw new ArgumentNullException(nameof(rightType));
        }

        public bool IsEqual => false;

        private string? _message;
        public string Message => _message ??=
            $"Left and right types differ, therefore objects are not equal. " +
            $"Left type: {_leftType.FullName}. Right type: {_rightType.FullName}";
    }
}
