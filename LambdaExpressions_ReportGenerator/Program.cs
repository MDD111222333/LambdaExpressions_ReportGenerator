using System;
using System.Collections.Generic;

namespace LambdaExpressions_ReportGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            ReportService service = new ReportService();

            int percentResult = service.CalculatePercentage(45, 60);
            Console.WriteLine($"вычисление процента (45, 60): {percentResult}");

            string category = service.ClassifyPercentage(percentResult);
            Console.WriteLine($"классификация {percentResult}: \"{category}\"");

            Console.WriteLine();

            string reportTitle = "Первоначальный отчёт";
            Action printTitle = () => Console.WriteLine($"Заголовок отчёта: {reportTitle}");
            reportTitle = "Изменённый отчёт";
            Console.Write("Демонстрация изменения внешней переменной: ");
            printTitle();

            Console.WriteLine();

            Console.WriteLine("до исправления: 3 лямбды из цикла for");
            List<Action> faultyActions = new List<Action>();
            for (int i = 0; i < 3; i++)
            {
                faultyActions.Add(() => Console.WriteLine($"Номер отчёта: {i}"));
            }

            foreach (Action action in faultyActions)
            {
                action();
            }

            Console.WriteLine();

            Console.WriteLine("после исправления: те же 3 лямбды");
            List<Action> fixedActions = new List<Action>();
            for (int i = 0; i < 3; i++)
            {
                int indexCopy = i;
                fixedActions.Add(() => Console.WriteLine($"Номер отчёта: {indexCopy}"));
            }

            foreach (Action action in fixedActions)
            {
                action();
            }

            Console.WriteLine();
            Console.WriteLine("--- Интерактивный расчет процента ---");

            try
            {
                Console.Write("Введите значение части (числитель): ");
                string partInput = Console.ReadLine();
                int part = int.Parse(partInput);

                Console.Write("Введите общее значение (знаменатель): ");
                string totalInput = Console.ReadLine();
                int total = int.Parse(totalInput);

                if (total == 0)
                {
                    throw new DivideByZeroException("Знаменатель не может быть равен 0.");
                }

                int userPercent = service.CalculatePercentage(part, total);
                string userCategory = service.ClassifyPercentage(userPercent);

                Console.WriteLine($"Результат: {userPercent}% (Категория: \"{userCategory}\")");
            }
            catch (FormatException)
            {
                Console.WriteLine("Ошибка: вводимые данные должны быть целыми числами.");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка ввода: {ex.Message}");
            }
        }
    }
}