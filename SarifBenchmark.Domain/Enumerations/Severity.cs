using System;
using System.Collections.Generic;
using System.Text;

namespace SecBench.Domain.Enumerations
{
    /// <summary>
    /// See : https://docs.oasis-open.org/sarif/sarif/v2.0/sarif-v2.0.html
    /// 3.27.10 level property
    /// </summary>
    public enum Severity
    {
        /// <summary>
        ///  The concept of “severity” does not apply to this result because <see cref="DiagnosticResultKind"/> has a value other than "fail".
        /// </summary>
        None,

        /// <summary>
        /// 
        /// </summary>
        Warning,

        /// <summary>
        /// 
        /// </summary>
        Note,

        /// <summary>
        /// 
        /// </summary>
        Error
    }
}
