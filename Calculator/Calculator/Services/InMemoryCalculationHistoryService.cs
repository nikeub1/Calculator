using System.Collections.Generic;
using Calculator.Models;

namespace Calculator.Services
{
    public class InMemoryCalculationHistoryService : ICalculationHistoryService
    {
        private static readonly List<CalculationRecord> _history = new List<CalculationRecord>();

        public void Add(CalculationRecord record)
        {
            _history.Add(record);
        }

        public IEnumerable<CalculationRecord> GetAll()
        {
            return _history;
        }
    }
}
