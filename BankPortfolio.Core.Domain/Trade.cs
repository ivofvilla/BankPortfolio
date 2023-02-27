using BankPortfolio.Core.Interface;

namespace BankPortfolio.Core.Domain;

public sealed class Trade : ITrade
{
    public double Value { get; }
    public string ClientSector { get; }

    public Trade(double value, string group)
    {
        Value = value;
        ClientSector = group;
    }
}
