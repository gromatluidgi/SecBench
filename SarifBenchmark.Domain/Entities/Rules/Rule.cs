using System;
using System.Collections.Generic;
using System.Text;

namespace SecBench.Domain.Entities.Rules
{
    public class Rule
    {
        public Rule(string id, string? description)
        {
            Id = id;
            Description = description;
        }

        public string Id { get;}

        public string? Description { get; }
    }
}
