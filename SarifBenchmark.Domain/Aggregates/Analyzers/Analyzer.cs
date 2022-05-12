using SecBench.Domain.Entities.Rules;
using SecBench.Domain.ValueObjects;

namespace SecBench.Domain.Aggregates.Analyzers
{
    public class Analyzer
    {
        public Analyzer(AnalyzerId analyzerId, string name, string version, Executable executable)
        {
            AnalyzerId = analyzerId;
            Name = name;
            Version = version;
            Executable = executable;
        }

        public AnalyzerId AnalyzerId { get; }

        public string Name { get; }

        public string Version { get; }

        public Executable Executable { get; }

        public RulesCollection Rules { get; } = new RulesCollection();
    }
}
