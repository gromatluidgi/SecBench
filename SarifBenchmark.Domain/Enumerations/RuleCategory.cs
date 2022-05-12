using SecBench.Domain.Common;

namespace SecBench.Domain.Enumerations
{
    public sealed class RuleCategory : Enumeration
    {
        /// <summary>
        /// Category definition for naming rules.
        /// </summary>
        public static readonly RuleCategory Naming = new RuleCategory("NamingRules");

        private RuleCategory(string name) : base(name)
        {
        }
    }
}
