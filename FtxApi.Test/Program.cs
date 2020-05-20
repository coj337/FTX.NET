using FtxApi.Enums;
using FtxApi.Models;
using System;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace FtxApi.Test
{
    class Program
    {
        static async Task Main()
        {
            var client = new Client("pbDsAcGhQZNBHETPvQ0u0t1qxX7ix5ffJizBrACKb5fdj5jbppBTY4b2ME9ILIub", "xajiKUGcV53jtWlVwNjtx5WMIMJ3ckH1eykqpZ2WM76xGaq18aDW5XnqMTQdtyJk");
            var api = new FtxRestApi(client);
            var wsApi = new FtxWebSocketApi("wss://ftx.com/ws/");

            await RestTests(api);
            await WebSocketTests(wsApi, client);
        }

        private static async Task RestTests(FtxRestApi api)
        {
            var ins = "BTC-PERP";

            var dateStart = DateTime.UtcNow.AddMinutes(-100);
            var dateEnd = DateTime.UtcNow.AddMinutes(-10);

            var t11 = (await api.GetAccountInfoAsync()).Result;
            Console.WriteLine(JsonSerializer.Serialize(t11));

            var t18 = await api.GetWithdrawalHistoryAsync();
            Console.WriteLine(JsonSerializer.Serialize(t18.Result.First()));

            var t15 = await api.GetBalancesAsync();
            Console.WriteLine(JsonSerializer.Serialize(t15));

            var r1 = await api.GetCoinsAsync();
            var r2 = await api.GetAllFuturesAsync();
            var r3 = (await api.GetFutureAsync(ins)).Result;
            var r4 = (await api.GetFutureStatsAsync(ins)).Result;
            var r5 = await api.GetFundingRatesAsync(dateStart, dateEnd);
            var r6 = (await api.GetHistoricalPricesAsync(ins, 300, 30, dateStart, dateEnd)).Result;
            var r7 = await api.GetMarketsAsync();
            var r8 = (await api.GetSingleMarketsAsync(ins)).Result;
            var r9 = (await api.GetMarketOrderBookAsync(ins, 20)).Result;
            var r10 = (await api.GetMarketTradesAsync(ins, 20, dateStart, dateEnd)).Result;
            var r11 = await api.GetAccountInfoAsync();
            var r12 = await api.GetPositionsAsync();
            var r13 = await api.ChangeAccountLeverageAsync(20);
            var r14 = await api.GetCoinAsync();
            var r15 = await api.GetBalancesAsync();
            var r16 = (await api.GetDepositAddressAsync("BTC")).Result;
            var r17 = await api.GetDepositHistoryAsync();
            var r18 = await api.GetWithdrawalHistoryAsync();
            var r19 = (await api.RequestWithdrawalAsync("USDTBEAR", 20.2m, "0x83a127952d266A6eA306c40Ac62A4a70668FE3BE", "", "", "")).Result;
            var r21 = (await api.GetOpenOrdersAsync(ins)).Result;
            var r20 = (await api.PlaceOrderAsync(ins, SideType.buy, 1000, OrderType.limit, 0.001m, false)).Result;
            var r20_1 = (await api.PlaceStopOrderAsync(ins, SideType.buy, 1000, 0.001m, false)).Result;
            var r20_2 = (await api.PlaceTrailingStopOrderAsync(ins, SideType.buy, 0.05m, 0.001m, false)).Result;
            var r20_3 = (await api.PlaceTakeProfitOrderAsync(ins, SideType.buy, 1000, 0.001m, false)).Result;
            var r23 = (await api.GetOrderStatusAsync("12345")).Result;
            var r24 = (await api.GetOrderStatusByClientIdAsync("12345")).Result;
            var r25 = (await api.CancelOrderAsync("1234")).Result;
            var r26 = (await api.CancelOrderByClientIdAsync("12345")).Result;
            var r27 = (await api.CancelAllOrdersAsync(ins)).Result;
            var r28 = (await api.GetFillsAsync(ins, 20, dateStart, dateEnd)).Result;
            var r29 = (await api.GetFundingPaymentAsync(dateStart, dateEnd)).Result;
            var r30 = await api.GetLeveragedTokensListAsync();
            var r31 = (await api.GetTokenInfoAsync("HEDGE")).Result;
            var r32 = (await api.GetLeveragedTokenBalancesAsync()).Result;
            var r33 = (await api.GetLeveragedTokenCreationListAsync()).Result;
            var r34 = (await api.RequestLeveragedTokenCreationAsync("HEDGE", 100)).Result;
            var r35 = (await api.GetLeveragedTokenRedemptionListAsync()).Result;
            var r36 = (await api.RequestLeveragedTokenRedemptionAsync("HEDGE", 100)).Result;

            foreach(var a in r15.Result)
            {
                Console.WriteLine($"{a.Coin} {a.Total}");
            }
        }

        private static async Task WebSocketTests(FtxWebSocketApi wsApi, Client client)
        {
            var ins = "BTC-PERP";

            wsApi.OnWebSocketConnect += () =>
            {
                wsApi.SendCommand(FtxWebSockerRequestGenerator.GetAuthRequest(client));
                wsApi.SendCommand(FtxWebSockerRequestGenerator.GetSubscribeRequest("orderbook", ins));
                wsApi.SendCommand(FtxWebSockerRequestGenerator.GetSubscribeRequest("trades", ins));
                wsApi.SendCommand(FtxWebSockerRequestGenerator.GetSubscribeRequest("ticker", ins));
                wsApi.SendCommand(FtxWebSockerRequestGenerator.GetSubscribeRequest("fills"));
                wsApi.SendCommand(FtxWebSockerRequestGenerator.GetSubscribeRequest("orders"));
            };

            await wsApi.Connect();
        }
    }
}
