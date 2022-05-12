using System;
using System.Collections.Generic;
using System.Text;

namespace SecBench.Domain.Entities.Violations
{
    public class Violation
    {
        public Violation(string ruleCode, int iterationId, CodePosition location)
        {
            RuleCode = ruleCode;
            IterationId = iterationId;
            Location = location;
        }

        public string RuleCode { get; set; }

        public int IterationId { get; set; }

        public CodePosition Location {  get; set; }
    }
}
