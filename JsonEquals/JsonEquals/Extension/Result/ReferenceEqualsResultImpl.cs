using JsonEquals.Compare;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonEquals.Extension.Result
{
    internal class ReferenceEqualsResultImpl : IEqualityResult
    {
        public bool IsEqual => true;

        public string Message => "Objects are the same i.e. the objects are equal by reference.";
    }
}
