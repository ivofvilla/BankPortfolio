using BankPortfolio.Core.Domain;
using BankPortfolio.Core.Interface;
using BankPortfolio.Core.Application;

public class Program
{
    private static void Main(string[] args)
    {
        List<ITrade> testTrades = new() {
            new Trade(2000000, "Private"),
            new Trade(400000, "Public"),
            new Trade(500000, "Public"),
            new Trade(3000000, "Public")
        };

        var riskResults = testTrades.ProcessTrades().OrderBy(p => p);
        
        foreach (var risk in riskResults)
            Console.WriteLine("{0}", risk);
    }
}