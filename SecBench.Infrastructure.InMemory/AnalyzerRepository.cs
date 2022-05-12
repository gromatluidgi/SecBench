using SecBench.Domain.Aggregates.Analyzers;
using SecBench.Domain.Repositories;
using SecBench.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecBench.Infrastructure.InMemory
{
    public class AnalyzerRepository : IAnalyzerRepository
    {
        private readonly ICollection<Analyzer> _analyzers;

        public AnalyzerRepository()
        {
            _analyzers = new Collection<Analyzer>
            {
                new Analyzer(new AnalyzerId(), "SecurityCodeScan", "5.6.2", Executable.FromAbsolutePath(@"C:\opt\security-scan5.6.2", "security-scan.exe")),
                new Analyzer(new AnalyzerId(), "SecurityCodeScan", "5.2.1", Executable.FromAbsolutePath(@"C:\opt\security-scan5.2.1", "security-scan.exe")),
            };
        }

        public async Task Add(Analyzer analyzer)
        {
            _analyzers.Add(analyzer);

            await Task.CompletedTask.ConfigureAwait(false);
        }

        public async Task<Analyzer> GeById(AnalyzerId analyzerId)
        {
            var analyzer = _analyzers
                .Where(a => a.AnalyzerId.Equals(analyzerId))
                .SingleOrDefault();

            return await Task.FromResult(analyzer).ConfigureAwait(false);
        }

        public async Task<ICollection<Analyzer>> GetAll()
        {
            return await Task.FromResult(_analyzers.ToList()).ConfigureAwait(false);
        }
    }
}
