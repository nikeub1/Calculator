using Calculator.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace Calculator.Services
{
    public class CalculatorService
    {
        private readonly ICalculationHistoryService _historyService;

        public CalculatorService(ICalculationHistoryService historyService)
        {
            _historyService = historyService;
        }

        public double Calculate(string expression)
        {
            double result = Evaluate(expression);
            _historyService.Add(new CalculationRecord
            {
                Expression = expression,
                Result = result,
                Timestamp = DateTime.Now
            });
            return result;
        }

        private double Evaluate(string expression)
        {
            var table = new DataTable();
            return Convert.ToDouble(table.Compute(expression, ""));
        }

        public IEnumerable<CalculationRecord> GetHistory()
        {
            return _historyService.GetAll();
        }
    }
}
