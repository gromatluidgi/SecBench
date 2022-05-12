using SecBench.Domain.Aggregates.Analyzers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SecBench.Application.Services
{
    internal interface IExecutableRunner
    {
        Task Execute(Executable executable);
    }
}
