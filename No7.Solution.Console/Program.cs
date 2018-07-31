using System.Reflection;

namespace No7.Solution.Console
{
    class Program
    {
        //Вызов не изменился
        static void Main(string[] args)
        {
            var tradeStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("No7.Solution.Console.trades.txt");

            var tradeProcessor = new TradeHandler();

            tradeProcessor.HandleTrades(tradeStream);
        }
    }
}