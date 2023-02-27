using BankPortfolio.Core.Interface;

namespace BankPortfolio.Core.Application;

public static class ProcessRisk
{
    private const double RISK_VALUE = 1_000_000.00d;
    private const string PUBLIC_GROUP = "PUBLIC";
    private const string PRIVATE_GROUP = "PRIVATE";

    private static string SetRisk(double value, string group) => value switch
    {
        _ when value > RISK_VALUE && group.ToUpper().Equals(PUBLIC_GROUP) => "MEDIUMRISK",
        _ when value > RISK_VALUE && group.ToUpper().Equals(PRIVATE_GROUP) => "HIGHRISK",
        _ => "LOWRISK"
    };

    public static IEnumerable<string> ProcessTrades(this IEnumerable<ITrade> trades)
    {
        var riskResults = new List<string>();

        Parallel.ForEach(trades, trade =>
        {
            var risk = SetRisk(trade.Value, trade.ClientSector);
            riskResults.Add(risk);
        });

        return riskResults;
    }
}
