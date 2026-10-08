using System;

namespace LambdaExpressions_ReportGenerator
{
    public class ReportService
    {
        public Func<int, int, int> CalculatePercentage = (part, total) => (part * 100) / total;

        public Func<int, string> ClassifyPercentage = percent =>
        {
            if (percent < 40)
            {
                return "низкий";
            }
            if (percent < 70)
            {
                return "средний";
            }
            return "высокий";
        };
    }
}