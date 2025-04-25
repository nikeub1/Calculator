using System;

namespace Calculator.Models
{
    public class CalculationRecord
    {
        public string Expression { get; set; }
        public double Result { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
