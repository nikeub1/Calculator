using System.Collections.Generic;
using Calculator.Models;

namespace Calculator.Services
{
    public interface ICalculationHistoryService
    {
        void Add(CalculationRecord record);
        IEnumerable<CalculationRecord> GetAll();
    }
}

