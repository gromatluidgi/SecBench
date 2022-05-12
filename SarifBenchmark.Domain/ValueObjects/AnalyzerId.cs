using SecBench.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace SecBench.Domain.ValueObjects
{
    public sealed class AnalyzerId : ValueObject
    {
        public AnalyzerId()
        {
            Id = Guid.NewGuid();
        }

        public AnalyzerId(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Id;
        }
    }
}
