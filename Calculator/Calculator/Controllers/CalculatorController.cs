using System.Web.Mvc;
using Calculator.Services;

namespace Calculator.Controllers
{
    public class CalculatorController : Controller
    {
        private static readonly InMemoryCalculationHistoryService _historyService = new InMemoryCalculationHistoryService();
        private readonly CalculatorService _calculator;

        public CalculatorController()
        {
            _calculator = new CalculatorService(_historyService);
        }

        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.History = _calculator.GetHistory();
            return View();
        }

        [HttpPost]
        public ActionResult Index(string expression)
        {
            if (!string.IsNullOrWhiteSpace(expression))
            {
                try
                {
                    ViewBag.Result = _calculator.Calculate(expression);
                }
                catch
                {
                    ViewBag.Result = "Invalid expression";
                }
            }

            ViewBag.History = _calculator.GetHistory();
            return View();
        }
    }
}
