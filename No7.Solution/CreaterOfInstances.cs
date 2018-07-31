using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace No7.Solution
{
    //Генератор Trade Records
    internal static class CreaterOfInstances
    {
        private readonly static float _lotSize = 100000f;

        internal static List<TradeRecord> CreateRecords(List<string> lines)
        {
            List<TradeRecord> trades = new List<TradeRecord>();
            foreach (var line in lines)
            {
                string[] fields = line.Split(new char[] { ',' });

                if (fields.Length != 3)
                {
                    Console.WriteLine("WARN: Line malformed. Only {0} field(s) found.", fields.Length);
                    continue;
                }

                if (fields[0].Length != 6)
                {
                    Console.WriteLine("WARN: Trade currencies malformed: '{0}'", fields[0]);
                    continue;
                }

                if (!int.TryParse(fields[1], out var tradeAmount))
                {
                }

                if (!decimal.TryParse(fields[2], out var tradePrice))
                {
                }

                string sourceCurrencyCode = fields[0].Substring(0, 3);
                string destinationCurrencyCode = fields[0].Substring(3, 3);

                TradeRecord trade = new TradeRecord
                {
                    SourceCurrency = sourceCurrencyCode,
                    DestinationCurrency = destinationCurrencyCode,
                    Lots = tradeAmount / _lotSize,
                    Price = tradePrice
                };
                trades.Add(trade);
            }
            return trades;
        }
    }
}
