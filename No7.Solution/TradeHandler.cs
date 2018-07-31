using System.Collections.Generic;
using System.IO;
using System.Globalization;
using System.Configuration;
using System.Data.SqlClient;

namespace No7.Solution
{
    public class TradeHandler
    {
        private readonly static float _lotSize = 100000f;

        public void HandleTrades(Stream stream)
        {
            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("en-US");
            Writer storage = new Writer();
            storage.Write(CreateRecords(StreamReader(stream)));
        }
        private List<string> StreamReader(Stream stream)
        {
            List<string> lines = new List<string>();
            using (var reader = new StreamReader(stream))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    lines.Add(line);
                }
            }
            return lines;
        }
        private List<TradeRecord> CreateRecords(List<string> lines)
        {
            List<TradeRecord> trades = new List<TradeRecord>();
            foreach (var line in lines)
            {
                string[] fields = line.Split(new char[] { ',' });

                if (fields.Length != 3)
                {
                    System.Console.WriteLine("WARN: Line malformed. Only {0} field(s) found.", fields.Length);
                    continue;
                }

                if (fields[0].Length != 6)
                {
                    System.Console.WriteLine("WARN: Trade currencies malformed: '{0}'", fields[0]);
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
