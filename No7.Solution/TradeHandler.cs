using System.Collections.Generic;
using System.IO;
using System.Globalization;
using System.Configuration;
using System.Data.SqlClient;

namespace No7.Solution
{
    public class TradeHandler
    {
        //Весь функционал убран из осноовного класса
        public void HandleTrades(Stream stream)
        {
            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("en-US");

            List<TradeRecord> trades = CreaterOfInstances.CreateRecords(Reader.GetLines(stream));

            Writer.Write(trades);
        }        
    }
}
