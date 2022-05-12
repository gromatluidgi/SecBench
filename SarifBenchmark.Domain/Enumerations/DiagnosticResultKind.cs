using System;
using System.Collections.Generic;
using System.Text;

namespace SecBench.Domain.Enumerations
{
    /// <summary>
    /// See: https://docs.oasis-open.org/sarif/sarif/v2.0/sarif-v2.0.html
    /// 3.27.9 kind property
    /// </summary>
    public enum DiagnosticResultKind
    {
        Pass,

        Open,

        Fail,

        Informational,

        NotApplicable
    }
}
