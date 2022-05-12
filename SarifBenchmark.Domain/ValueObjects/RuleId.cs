using SecBench.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace SecBench.Domain.ValueObjects
{
    public sealed class RuleId : ValueObject
    {
        public string Id { get; }

        public RuleId(string id)
        {
            Id = id;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            // Using a yield return statement to return each element one at a time.
            yield return Id;
        }
    }
}
