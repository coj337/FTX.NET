using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.IO;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using FtxApi.Enums;
using FtxApi.Logging;
using FtxApi.Models;
using FtxApi.Models.LeveragedTokens;
using FtxApi.Models.Markets;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace FtxApi
{
    public class FtxRestApi
    {
        private const string Url = "https://ftx.com/";

        private readonly Client _client;

        private readonly HttpClient _httpClient;

        private readonly HMACSHA256 _hashMaker;

        private readonly string _subAccount;

        private long _nonce;

        private static readonly ILog Log = LogProvider.GetCurrentClassLogger();

        public FtxRestApi(Client client)
        {
            _client = client;
            _subAccount = _client.Subaccount;
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(Url),
                Timeout = TimeSpan.FromMinutes(10)
            };

            _hashMaker = new HMACSHA256(Encoding.UTF8.GetBytes(_client.ApiSecret));
        }

        #region Coins

        public async Task<FtxResult<List<Coin>>> GetCoinsAsync()
        {
            var resultString = $"api/coins";

            var result = await CallAsync(HttpMethod.Get, resultString);

            return JsonConvert.DeserializeObject<FtxResult<List<Coin>>>(result);
        }

        #endregion

        #region Futures

        public async Task<FtxResult<List<Future>>> GetAllFuturesAsync()
        {
            var resultString = $"api/futures";

            var result = await CallAsync(HttpMethod.Get, resultString);
            return result != null ? JsonConvert.DeserializeObject<FtxResult<List<Future>>>(result) : null;
        }

        public async Task<FtxResult<Future>> GetFutureAsync(string future)
        {
            var resultString = $"api/futures/{future}";

            var result = await CallAsync(HttpMethod.Get, resultString);

            return result != null ? JsonConvert.DeserializeObject<FtxResult<Future>>(result) : null;
        }

        public async Task<FtxResult<FutureStats>> GetFutureStatsAsync(string future)
        {
            var resultString = $"api/futures/{future}/stats";

            var result = await CallAsync(HttpMethod.Get, resultString);

            return result != null ? JsonConvert.DeserializeObject<FtxResult<FutureStats>>(result) : null;
        }

        public async Task<FtxResult<List<ExpiredFutures>>> GetExpiredFutures()
        {
            var resultString = $"api/expired_futures";

            var result = await CallAsync(HttpMethod.Get, resultString);
            return result != null ? JsonConvert.DeserializeObject<FtxResult<List<ExpiredFutures>>>(result) : null;
        }

        public async Task<List<FundingRate>> GetFundingRatesAsync(string market, DateTime start, DateTime end)
        {
            List<FundingRate> allResults = new List<FundingRate>();
            int resultLength;

            do
            {
                var resultString =
                    $"api/funding_rates?future{market}&start_time={Util.Util.GetSecondsFromEpochStart(start)}&end_time={Util.Util.GetSecondsFromEpochStart(end)}";
                var result = await CallAsync(HttpMethod.Get, resultString);
                //var deserializedResult = JsonConvert.DeserializeAsync<FtxResult<List<FundingRate>>>(result);
                var deserializedResult = JsonConvert.DeserializeObject<FtxResult<List<FundingRate>>>(result);

                var rates = deserializedResult?.Result;
                resultLength = rates?.Count ?? 0;

                if (resultLength != 0)
                {
                    allResults.AddRange(rates);
                    end = rates.Last().Time.ToUniversalTime()
                        .AddMinutes(-1); //Set the end time to the earliest retrieved to get more
                }
            } while (resultLength == 500);

            return allResults;
        }

        public async Task<List<FundingRate>> GetFundingRatesAsync(DateTime start, DateTime end)
        {
            var allResults = new List<FundingRate>();
            var resultLength = 0;

            do
            {
                var resultString =
                    $"api/funding_rates?start_time={Util.Util.GetSecondsFromEpochStart(start)}&end_time={Util.Util.GetSecondsFromEpochStart(end)}";
                var result = await CallAsync(HttpMethod.Get, resultString);
                if (result == null) return null;
                var deserializedResult = JsonConvert.DeserializeObject<FtxResult<List<FundingRate>>>(result);

                if (deserializedResult == null) continue;

                var rates = deserializedResult.Result;
                resultLength = rates.Count();

                if (resultLength != 0)
                {
                    allResults.AddRange(rates);
                    end = rates.Last().Time.ToUniversalTime()
                        .AddMinutes(-1); //Set the end time to the earliest retrieved to get more
                }
            } while (resultLength == 500);

            return allResults;
        }

        public async Task<List<Candle>> GetHistoricalPricesAsync(string marketName, int resolution, DateTime start,
            DateTime end)
        {
            var allResults = new List<Candle>();
            var resultLength = 0;

            do
            {
                var resultString =
                    $"api/markets/{marketName}/candles?resolution={resolution}&start_time={Util.Util.GetSecondsFromEpochStart(start)}&end_time={Util.Util.GetSecondsFromEpochStart(end)}";
                var result = await CallAsync(HttpMethod.Get, resultString);

                if (result == null) throw new ArgumentNullException(nameof(result));

                var deserializedResult = JsonConvert.DeserializeObject<FtxResult<List<Candle>>>(result);

                if (deserializedResult == null) continue;

                var rates = deserializedResult.Result;
                resultLength = rates.Count();

                if (resultLength != 0)
                {
                    allResults.AddRange(rates);
                    end = rates.Last().StartTime.ToUniversalTime()
                        .AddMinutes(-1); //Set the end time to the earliest retrieved to get more
                }
            } while (resultLength == 500);

            return allResults;
        }

        public async Task<List<Candle>> GetHistoricalIndexAsync(string indexName, int resolution, DateTime start,
            DateTime end)
        {
            var allResults = new List<Candle>();
            var resultLength = 0;

            do
            {
                var resultString =
                    $"api/indexes/{indexName}/candles?resolution={resolution}&start_time={Util.Util.GetSecondsFromEpochStart(start)}&end_time={Util.Util.GetSecondsFromEpochStart(end)}";
                var result = await CallAsync(HttpMethod.Get, resultString);
                var deserializedResult = JsonConvert.DeserializeObject<FtxResult<List<Candle>>>(result);

                if (deserializedResult == null) continue;

                var rates = deserializedResult.Result;
                resultLength = rates.Count();

                if (resultLength != 0)
                {
                    allResults.AddRange(rates);
                    end = rates.Last().StartTime.ToUniversalTime()
                        .AddMinutes(-1); //Set the end time to the earliest retrieved to get more
                }
            } while (resultLength == 500);

            return allResults;
        }

        #endregion

        #region Markets

        public async Task<FtxResult<List<Market>>> GetMarketsAsync()
        {
            var resultString = $"api/markets";

            var result = await CallAsync(HttpMethod.Get, resultString);

            return JsonConvert.DeserializeObject<FtxResult<List<Market>>>(result);
        }

        public async Task<FtxResult<Market>> GetSingleMarketsAsync(string marketName)
        {
            var resultString = $"api/markets/{marketName}";

            var result = await CallAsync(HttpMethod.Get, resultString);

            return JsonConvert.DeserializeObject<FtxResult<Market>>(result);
        }

        public async Task<FtxResult<Orderbook>> GetMarketOrderBookAsync(string marketName, int depth = 20)
        {
            var resultString = $"api/markets/{marketName}/orderbook?depth={depth}";

            var result = await CallAsync(HttpMethod.Get, resultString);

            return JsonConvert.DeserializeObject<FtxResult<Orderbook>>(result);
        }

        public async Task<List<Trade>> GetMarketTradesAsync(string marketName, DateTime start,
            DateTime end)
        {
            List<Trade> allResults = new List<Trade>();
            int resultLength = 0;

            do
            {
                var resultString =
                    $"api/markets/{marketName}/trades?&start_time={Util.Util.GetSecondsFromEpochStart(start)}&end_time={Util.Util.GetSecondsFromEpochStart(end)}";
                var result = await CallAsync(HttpMethod.Get, resultString);

                if (result == null || !result.Any()) return allResults;

                var deserializedResult = JsonConvert.DeserializeObject<FtxResult<List<Trade>>>(result);

                var rates = deserializedResult?.Result;
                if (rates != null)
                {
                    resultLength = rates.Count;

                    if (resultLength != 0)
                    {
                        allResults.AddRange(rates);
                        end = rates.Last().Time.ToUniversalTime()
                            .AddMinutes(-1); //Set the end time to the earliest retrieved to get more
                    }
                }
            } while (resultLength == 5000);

            return allResults;
        }

        #endregion

        #region Account

        public async Task<FtxResult<AccountInfo>> GetAccountInfoAsync()
        {
            var resultString = $"api/account";
            var sign = GenerateSignature(HttpMethod.Get, "/api/account", "");
            var result = await CallAsyncSign(HttpMethod.Get, resultString, sign);
            if (result == null) return null;
            return JsonConvert.DeserializeObject<FtxResult<AccountInfo>>(result);
        }

        public async Task<FtxResult<List<Position>>> GetPositionsAsync()
        {
            var resultString = $"api/positions";

            var query = HttpUtility.ParseQueryString(string.Empty);
            query["showAvgPrice"] = "true";
            var queryString = query.ToString();

            var showAvgPriceEndpoint = $"{resultString}?{queryString}";

            var sign = GenerateSignature(HttpMethod.Get, $"/{showAvgPriceEndpoint}", "");

            var result = await CallAsyncSign(HttpMethod.Get, showAvgPriceEndpoint, sign, "");
            return result == null ? null : JsonConvert.DeserializeObject<FtxResult<List<Position>>>(result);
        }

        public async Task<AccountLeverage> ChangeAccountLeverageAsync(int leverage)
        {
            var resultString = $"api/account/leverage";

            var body = $"{{\"leverage\": {leverage}}}";

            var sign = GenerateSignature(HttpMethod.Post, "/api/account/leverage", body);

            var result = await CallAsyncSign(HttpMethod.Post, resultString, sign, body);

            return JsonConvert.DeserializeObject<AccountLeverage>(result);
        }

        #endregion

        #region Wallet

        public async Task<FtxResult<List<Coin>>> GetCoinAsync()
        {
            var resultString = $"api/wallet/coins";

            var sign = GenerateSignature(HttpMethod.Get, "/api/wallet/coins", "");

            var result = await CallAsyncSign(HttpMethod.Get, resultString, sign);

            return JsonConvert.DeserializeObject<FtxResult<List<Coin>>>(result);
        }

        public async Task<FtxResult<List<Balance>>> GetBalancesAsync()
        {
            var resultString = $"api/wallet/balances";

            var sign = GenerateSignature(HttpMethod.Get, "/api/wallet/balances", "");

            var result = await CallAsyncSign(HttpMethod.Get, resultString, sign);
            return result == null ? null : JsonConvert.DeserializeObject<FtxResult<List<Balance>>>(result);
        }

        public async Task<FtxResult<List<Balance>>> GetAllBalancesAsync()
        {
            var resultString = $"api/wallet/balances";

            var sign = GenerateSignature(HttpMethod.Get, "/api/wallet/all_balances", "");

            var result = await CallAsyncSign(HttpMethod.Get, resultString, sign);

            return JsonConvert.DeserializeObject<FtxResult<List<Balance>>>(result);
        }

        public async Task<FtxResult<DepositAddress>> GetDepositAddressAsync(string coin)
        {
            var resultString = $"api/wallet/deposit_address/{coin}";

            var sign = GenerateSignature(HttpMethod.Get, $"/api/wallet/deposit_address/{coin}", "");

            var result = await CallAsyncSign(HttpMethod.Get, resultString, sign);

            return JsonConvert.DeserializeObject<FtxResult<DepositAddress>>(result);
        }

        public async Task<FtxResult<List<DepositHistory>>> GetDepositHistoryAsync()
        {
            var resultString = $"api/wallet/deposits";

            var sign = GenerateSignature(HttpMethod.Get, "/api/wallet/deposits", "");

            var result = await CallAsyncSign(HttpMethod.Get, resultString, sign);

            return JsonConvert.DeserializeObject<FtxResult<List<DepositHistory>>>(result);
        }

        public async Task<FtxResult<List<WithdrawalHistory>>> GetWithdrawalHistoryAsync()
        {
            var resultString = $"api/wallet/withdrawals";

            var sign = GenerateSignature(HttpMethod.Get, "/api/wallet/withdrawals", "");

            var result = await CallAsyncSign(HttpMethod.Get, resultString, sign);

            return JsonConvert.DeserializeObject<FtxResult<List<WithdrawalHistory>>>(result);
        }

        public async Task<FtxResult<WithdrawalHistory>> RequestWithdrawalAsync(string coin, decimal size, string addr,
            string tag, string pass, string code)
        {
            var resultString = $"api/wallet/withdrawals";

            var body = $"{{" +
                       $"\"coin\": \"{coin}\"," +
                       $"\"size\": {size}," +
                       $"\"address\": \"{addr}\"," +
                       $"\"tag\": {tag}," +
                       $"\"password\": \"{pass}\"," +
                       $"\"code\": {code}" +
                       "}";

            var sign = GenerateSignature(HttpMethod.Post, "/api/wallet/withdrawals", body);

            var result = await CallAsyncSign(HttpMethod.Post, resultString, sign, body);

            return JsonConvert.DeserializeObject<FtxResult<WithdrawalHistory>>(result);
        }

        #endregion

        #region Orders

        public async Task<FtxResult<Order>> PlaceOrderAsync(string instrument, SideType side, decimal? price,
            OrderType orderType, decimal amount, string clientId = "", bool ioc = false, bool postOnly = false,
            bool reduceOnly = false)
        {
            var path = $"api/orders";

            var body = new CreateOrder(
                instrument,
                side,
                price,
                orderType,
                amount,
                clientId,
                ioc,
                postOnly,
                reduceOnly);

            var serialize = JsonConvert.SerializeObject(body, new StringEnumConverter(true));

            var sign = GenerateSignature(HttpMethod.Post, "/api/orders", serialize);
            var result = await CallAsyncSign(HttpMethod.Post, path, sign, serialize);

            return JsonConvert.DeserializeObject<FtxResult<Order>>(result);
        }

        public async Task<FtxResult<TriggerOrder>> PlaceStopOrderAsync(string instrument, SideType side,
            OrderType orderType,
            decimal triggerPrice, decimal amount, bool reduceOnly = false)
        {
            var path = $"api/conditional_orders";

            var body = new CreateOrder
            {
                Market = instrument,
                Side = side,
                TriggerPrice = triggerPrice,
                Type = orderType,
                Size = amount,
                ReduceOnly = reduceOnly,
                RetryUntilFilled = false
            };

            var serialize = JsonConvert.SerializeObject(body, new StringEnumConverter(true));

            var sign = GenerateSignature(HttpMethod.Post, "/api/conditional_orders", serialize);
            var result = await CallAsyncSign(HttpMethod.Post, path, sign, serialize);

            return JsonConvert.DeserializeObject<FtxResult<TriggerOrder>>(result);
        }

        public async Task<FtxResult<TriggerOrder>> PlaceStopLimitOrderAsync(string instrument, SideType side,
            OrderType orderType,
            decimal triggerPrice, decimal orderPrice, decimal amount, bool reduceOnly = false)
        {
            var path = $"api/conditional_orders";
            var body = new CreateOrder
            {
                Market = instrument,
                Side = side,
                TriggerPrice = triggerPrice,
                OrderPrice = orderPrice,
                Type = orderType,
                Size = amount,
                ReduceOnly = reduceOnly,
                RetryUntilFilled = false
            };

            var serialize = JsonConvert.SerializeObject(body, new StringEnumConverter(true));

            var sign = GenerateSignature(HttpMethod.Post, "/api/conditional_orders", serialize);
            var result = await CallAsyncSign(HttpMethod.Post, path, sign, serialize);

            return JsonConvert.DeserializeObject<FtxResult<TriggerOrder>>(result);
        }

        public async Task<FtxResult<TriggerOrder>> PlaceTrailingStopOrderAsync(string instrument, SideType side,
            OrderType orderType,
            decimal trailValue, decimal amount, bool reduceOnly = false)
        {
            var path = $"api/conditional_orders";

            var body = new CreateOrder
            {
                Market = instrument,
                Side = side,
                TrailValue = trailValue,
                Type = orderType,
                Size = amount,
                ReduceOnly = reduceOnly,
                RetryUntilFilled = false
            };

            var serialize = JsonConvert.SerializeObject(body, new StringEnumConverter(true));

            var sign = GenerateSignature(HttpMethod.Post, "/api/conditional_orders", serialize);
            var result = await CallAsyncSign(HttpMethod.Post, path, sign, serialize);

            return JsonConvert.DeserializeObject<FtxResult<TriggerOrder>>(result);
        }

        public async Task<FtxResult<TriggerOrder>> PlaceTakeProfitOrderAsync(string instrument, SideType side,
            OrderType orderType,
            decimal triggerPrice, decimal amount, bool reduceOnly = false)
        {
            var path = $"api/conditional_orders";
            var body = new CreateOrder
            (
                instrument,
                side,
                orderType,
                triggerPrice,
                amount,
                reduceOnly
            );

            var serialize = JsonConvert.SerializeObject(body, new StringEnumConverter(true));

            var sign = GenerateSignature(HttpMethod.Post, "/api/conditional_orders", serialize);
            var result = await CallAsyncSign(HttpMethod.Post, path, sign, serialize);

            return JsonConvert.DeserializeObject<FtxResult<TriggerOrder>>(result);
        }

        public async Task<FtxResult<TriggerOrder>> PlaceTakeProfitLimitOrderAsync(string instrument, SideType side,
            OrderType orderType,
            decimal triggerPrice, decimal orderPrice, decimal amount, bool reduceOnly = false)
        {
            var path = $"api/conditional_orders";

            var body = new CreateOrder
            {
                Market = instrument,
                Side = side,
                TriggerPrice = triggerPrice,
                OrderPrice = orderPrice,
                Type = orderType,
                Size = amount,
                ReduceOnly = reduceOnly,
                RetryUntilFilled = false
            };

            var serialize = JsonConvert.SerializeObject(body, new StringEnumConverter(true));

            var sign = GenerateSignature(HttpMethod.Post, "/api/conditional_orders", serialize);
            var result = await CallAsyncSign(HttpMethod.Post, path, sign, serialize);

            return JsonConvert.DeserializeObject<FtxResult<TriggerOrder>>(result);
        }

        public async Task<FtxResult<List<Order>>> GetOpenOrdersAsync(string instrument)
        {
            var path = $"api/orders?Market={instrument}";

            var sign = GenerateSignature(HttpMethod.Get, $"/api/orders?Market={instrument}", "");

            var result = await CallAsyncSign(HttpMethod.Get, path, sign);

            return result == null ? null : JsonConvert.DeserializeObject<FtxResult<List<Order>>>(result);
        }

        public async Task<FtxResult<OrderStatus>> GetOrderStatusAsync(string id)
        {
            var resultString = $"api/orders/{id}";

            var sign = GenerateSignature(HttpMethod.Get, $"/api/orders/{id}", "");

            var result = await CallAsyncSign(HttpMethod.Get, resultString, sign);

            return result == null ? null : JsonConvert.DeserializeObject<FtxResult<OrderStatus>>(result);
        }

        public async Task<FtxResult<Order>> GetOrderStatusByClientIdAsync(string clientOrderId)
        {
            var resultString = $"api/orders/by_client_id/{clientOrderId}";

            var sign = GenerateSignature(HttpMethod.Get, $"/api/orders/by_client_id/{clientOrderId}", "");

            var result = await CallAsyncSign(HttpMethod.Get, resultString, sign);

            return JsonConvert.DeserializeObject<FtxResult<Order>>(result);
        }

        public async Task<FtxResult<string>> CancelOrderAsync(string id)
        {
            var resultString = $"api/orders/{id}";

            var sign = GenerateSignature(HttpMethod.Delete, $"/api/orders/{id}", "");

            var result = await CallAsyncSign(HttpMethod.Delete, resultString, sign);

            return JsonConvert.DeserializeObject<FtxResult<string>>(result);
        }

        public async Task<FtxResult<string>> CancelTriggerOrderAsync(string id)
        {
            var resultString = $"api/conditional_orders/{id}";

            var sign = GenerateSignature(HttpMethod.Delete, $"/api/conditional_orders/{id}", "");

            var result = await CallAsyncSign(HttpMethod.Delete, resultString, sign);

            return JsonConvert.DeserializeObject<FtxResult<string>>(result);
        }

        public async Task<FtxResult<string>> CancelOrderByClientIdAsync(string clientOrderId)
        {
            var resultString = $"api/orders/by_client_id/{clientOrderId}";

            var sign = GenerateSignature(HttpMethod.Delete, $"/api/orders/by_client_id/{clientOrderId}", "");

            var result = await CallAsyncSign(HttpMethod.Delete, resultString, sign);

            return JsonConvert.DeserializeObject<FtxResult<string>>(result);
        }

        public async Task<FtxResult<string>> CancelAllOrdersAsync(string instrument, SideType? side,
            bool? limitOrdersOnly, bool? conditionalOrdersOnly)
        {
            var resultString = $"api/orders";

            //var body = $"{{\"Market\": \"{instrument}\"}}";

            var body = new CancelOrder
            {
                Market = instrument,
                Side = side,
                LimitOrdersOnly = limitOrdersOnly,
                ConditionalOrdersOnly = conditionalOrdersOnly
            };

            var serialize = JsonConvert.SerializeObject(body, new StringEnumConverter(true));

            var sign = GenerateSignature(HttpMethod.Delete, $"/api/orders", serialize);

            var result = await CallAsyncSign(HttpMethod.Delete, resultString, sign, serialize);

            return JsonConvert.DeserializeObject<FtxResult<string>>(result);
        }

        #endregion

        #region Fills

        public async Task<FtxResult<List<Fill>>> GetFillsAsync(string market, int limit, DateTime start, DateTime end)
        {
            var resultString =
                $"api/fills?Market={market}&Limit={limit}&start_time={Util.Util.GetSecondsFromEpochStart(start)}&end_time={Util.Util.GetSecondsFromEpochStart(end)}";

            var sign = GenerateSignature(HttpMethod.Get, $"/{resultString}", "");

            var result = await CallAsyncSign(HttpMethod.Get, resultString, sign);

            return result == null ? null : JsonConvert.DeserializeObject<FtxResult<List<Fill>>>(result);
        }

        #endregion

        #region Funding

        public async Task<FtxResult<List<FundingPayment>>> GetFundingPaymentAsync(DateTime start, DateTime end)
        {
            var resultString =
                $"api/funding_payments?start_time={Util.Util.GetSecondsFromEpochStart(start)}&end_time={Util.Util.GetSecondsFromEpochStart(end)}";

            var sign = GenerateSignature(HttpMethod.Get, $"/{resultString}", "");

            var result = await CallAsyncSign(HttpMethod.Get, resultString, sign);

            return result == null ? null : JsonConvert.DeserializeObject<FtxResult<List<FundingPayment>>>(result);
        }

        #endregion

        #region Leveraged Tokens

        public async Task<FtxResult<RequestQuoteResponse>> ConvertRequestQuote(string fromCoin, string toCoin,
            decimal sizeOfFromCoin)
        {
            var resultString = $"api/otc/quotes";

            var body = new ConvertCoinRequest()
            {
                FromCoin = fromCoin,
                ToCoin = toCoin,
                Size = sizeOfFromCoin
            };

            var serialize = JsonConvert.SerializeObject(body, new StringEnumConverter(true));

            var sign = GenerateSignature(HttpMethod.Post, $"/{resultString}", serialize);

            var result = await CallAsyncSign(HttpMethod.Post, resultString, sign, serialize);

            return JsonConvert.DeserializeObject<FtxResult<RequestQuoteResponse>>(result);
        }

        public async Task<FtxResult<GetQuoteStatusResponse>> ConvertGetQuoteStatus(long quoteId, string market = null)
        {
            var resultString = $"api/otc/quotes/{quoteId}";

            var body = new QuoteStatusRequest()
            {
                Market = market
            };

            if (market == null)
            {
                body = null;
            }

            var serialize = JsonConvert.SerializeObject(body, new StringEnumConverter(true));

            var sign = GenerateSignature(HttpMethod.Get, $"/{resultString}", serialize);

            var result = await CallAsyncSign(HttpMethod.Get, resultString, sign, serialize);

            return JsonConvert.DeserializeObject<FtxResult<GetQuoteStatusResponse>>(result);
        }

        public async Task<FtxResult<AcceptQuoteResponse>> ConvertAcceptQuote(long? quoteId)
        {
            var resultString = $"api/otc/quotes/{quoteId}/accept";

            var sign = GenerateSignature(HttpMethod.Post, $"/{resultString}", "");

            var result = await CallAsyncSign(HttpMethod.Post, resultString, sign);

            return JsonConvert.DeserializeObject<FtxResult<AcceptQuoteResponse>>(result);
        }

        public async Task<FtxResult<List<LeveragedToken>>> GetLeveragedTokensListAsync()
        {
            var resultString = $"api/lt/tokens";

            var result = await CallAsync(HttpMethod.Get, resultString);

            return JsonConvert.DeserializeObject<FtxResult<List<LeveragedToken>>>(result);
        }

        public async Task<FtxResult<LeveragedToken>> GetTokenInfoAsync(string tokenName)
        {
            var resultString = $"api/lt/{tokenName}";

            var result = await CallAsync(HttpMethod.Get, resultString);

            return JsonConvert.DeserializeObject<FtxResult<LeveragedToken>>(result);
        }

        public async Task<FtxResult<List<LeveragedTokenBalance>>> GetLeveragedTokenBalancesAsync()
        {
            var resultString = $"api/lt/balances";

            var sign = GenerateSignature(HttpMethod.Get, $"/api/lt/balances", "");

            var result = await CallAsyncSign(HttpMethod.Get, resultString, sign);

            return JsonConvert.DeserializeObject<FtxResult<List<LeveragedTokenBalance>>>(result);
        }

        public async Task<FtxResult<List<LeveragedTokenCreation>>> GetLeveragedTokenCreationListAsync()
        {
            var resultString = $"api/lt/creations";

            var sign = GenerateSignature(HttpMethod.Get, $"/api/lt/creations", "");

            var result = await CallAsyncSign(HttpMethod.Get, resultString, sign);

            return JsonConvert.DeserializeObject<FtxResult<List<LeveragedTokenCreation>>>(result);
        }

        public async Task<FtxResult<LeveragedTokenCreationRequest>> RequestLeveragedTokenCreationAsync(string tokenName,
            decimal size)
        {
            var resultString = $"api/lt/{tokenName}/create";

            var body = $"{{\"size\": {size}}}";

            var sign = GenerateSignature(HttpMethod.Post, $"/api/lt/{tokenName}/create", body);

            var result = await CallAsyncSign(HttpMethod.Post, resultString, sign, body);

            return JsonConvert.DeserializeObject<FtxResult<LeveragedTokenCreationRequest>>(result);
        }

        public async Task<FtxResult<List<LeveragedTokenRedemptionRequest>>> GetLeveragedTokenRedemptionListAsync()
        {
            var resultString = $"api/lt/redemptions";

            var sign = GenerateSignature(HttpMethod.Get, $"/api/lt/redemptions", "");

            var result = await CallAsyncSign(HttpMethod.Get, resultString, sign);

            return JsonConvert.DeserializeObject<FtxResult<List<LeveragedTokenRedemptionRequest>>>(result);
        }

        public async Task<FtxResult<LeveragedTokenRedemption>> RequestLeveragedTokenRedemptionAsync(string tokenName,
            decimal size)
        {
            var resultString = $"api/lt/{tokenName}/redeem";

            var body = $"{{\"size\": {size}}}";

            var sign = GenerateSignature(HttpMethod.Post, $"/api/lt/{tokenName}/redeem", body);

            var result = await CallAsyncSign(HttpMethod.Post, resultString, sign, body);

            return JsonConvert.DeserializeObject<FtxResult<LeveragedTokenRedemption>>(result);
        }

        #endregion

        #region Util

        public async Task<FtxResult<List<ExpiredFutures>>> GetExpiredFuturesAsync(CancellationToken cancellationToken)
        {
            var endPoint = $"api/expired_futures";
            var request = CreateRequest(HttpMethod.Get, endPoint);

            var options = new JsonSerializerOptions();

            using var result = await _httpClient
                .SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
            await using var contentStream = await result.Content.ReadAsStreamAsync(cancellationToken);
            return await JsonSerializer.DeserializeAsync<FtxResult<List<ExpiredFutures>>>(contentStream,
                cancellationToken: cancellationToken);
        }

        private static HttpRequestMessage CreateRequest(HttpMethod method, string endpoint, string body = null)
        {
            var request = new HttpRequestMessage(method, $"{endpoint}");

            if (body != null)
                request.Content = new StringContent(body, Encoding.UTF8, "application/json");

            return request;
        }

        private async Task<string> CallAsync(HttpMethod method, string endpoint, string body = null)
        {
            var request = new HttpRequestMessage(method, endpoint);

            if (body != null)
            {
                request.Content = new StringContent(body, Encoding.UTF8, "application/json");
            }

            var cts = new CancellationTokenSource();

            try
            {
                var response =
                    await _httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cts.Token);
                return await response.Content.ReadAsStringAsync(cts.Token);
            }
            // If the token has been canceled, it is not a timeout.
            catch (TaskCanceledException ex) when (cts.IsCancellationRequested)
            {
                // Handle cancellation.
                Log.Debug("Canceled: " + ex.Message);
            }
            catch (TaskCanceledException ex)
            {
                // Handle timeout.
                Log.Debug("Timed out: " + ex.Message);
            }
            catch (Exception ex)
            {
                // Handle timeout.
                Log.Debug("Error: " + ex.Message);
            }

            return null;
        }

        private async Task<string> CallAsyncSign(HttpMethod method, string endpoint, string sign, string body = null)
        {
            var request = new HttpRequestMessage(method, endpoint);

            if (body != null)
                request.Content = new StringContent(body, Encoding.UTF8, "application/json");

            request.Headers.Add("FTX-KEY", _client.ApiKey);
            request.Headers.Add("FTX-SIGN", sign);
            request.Headers.Add("FTX-TS", _nonce.ToString());

            if (_subAccount != null)
                request.Headers.Add("FTX-SUBACCOUNT", Uri.EscapeUriString(_subAccount));

            var cts = new CancellationTokenSource();

            try
            {
                var response =
                    await _httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cts.Token);
                return await response.Content.ReadAsStringAsync(cts.Token);
            }
            // If the token has been canceled, it is not a timeout.
            catch (TaskCanceledException ex) when (cts.IsCancellationRequested)
            {
                // Handle cancellation.
                Log.Debug("Canceled: " + ex.Message);
            }
            catch (TaskCanceledException ex)
            {
                // Handle timeout.
                Log.Debug("Timed out: " + ex.Message);
            }
            catch (Exception ex)
            {
                // Handle timeout.
                Log.Debug("Error: " + ex.Message);
            }

            return null;
        }

        private string GenerateSignature(HttpMethod method, string url, string requestBody)
        {
            _nonce = GetNonce();
            var signature = $"{_nonce}{method.ToString().ToUpper()}{url}{requestBody}";
            string hashStringBase64;
            try
            {
                var hash = _hashMaker.ComputeHash(Encoding.UTF8.GetBytes(signature));
                hashStringBase64 = BitConverter.ToString(hash).Replace("-", string.Empty);
            }
            catch (AccessViolationException e)
            {
                Log.Error(e, "Hash maker access violation error AGAIN??");
                throw;
            }
            return hashStringBase64.ToLower();
        }

        private long GetNonce()
        {
            return Util.Util.GetMillisecondsFromEpochStart();
        }

        #endregion
    }
}