using SecBench.Domain.Aggregates.Analyzers;
using SecBench.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SecBench.Domain.Repositories
{
    public interface IAnalyzerRepository
    {
        Task Add(Analyzer analyzer);

        Task<Analyzer> GeById(AnalyzerId analyzerId);

        Task<ICollection<Analyzer>> GetAll();
    }
}
