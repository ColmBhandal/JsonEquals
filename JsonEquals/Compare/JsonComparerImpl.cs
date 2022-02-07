using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonEquals.Compare
{
    internal class JsonComparerImpl : IJsonComparer
    {
        public IJsonComparison JsonEquals(object leftObj, object rightObj)
        {
            string leftJson = JsonConvert.SerializeObject(leftObj);
            string rightJson = JsonConvert.SerializeObject(rightObj);
            return new JsonComparisonImpl(leftJson, rightJson);
        }
    }
}
