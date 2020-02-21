using Bitmex.NET.Authorization;
using Bitmex.NET.Dtos;
using Bitmex.NET.Dtos.Socket;
using Bitmex.NET.Models.Socket;
using Bitmex.NET.Models.Socket.Events;
using Bitmex.NET.Models.Socket.Responses;
using Bitmex.NET.Models.Socket.Responses.OperationResponses;
using Bitmex.NET.Models.Socket.Responses.RawResponses;
using Bitmex.NET.Models.Socket.Responses.TableResponses;
using Microsoft.Extensions.Logging;
using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging.Abstractions;

namespace Bitmex.NET
{
    public interface IBitmexApiSocketService
    {
        //IBitmexApiSocketProxy BitmexApiSocketProxy { get; }

        /// <summary>
        /// Sends provided API key and a message encrypted using provided Secret to the server and waits for a response.
        /// </summary>
        /// <exception cref="BitmexSocketAuthorizationException">Throws when either timeout is reached or server retured an error.</exception>
        /// <returns>Returns value of IsAuthorized property.</returns>
        bool Connect();

        /// <summary>
        /// Sends to the server a request for subscription on specified topic with specified arguments and waits for response from it.
        /// If you ok to use provided DTO mdoels for socket communication please use <see cref="BitmetSocketSubscriptions"/> static methods to avoid Subscription->Model mapping mistakes.
        /// </summary>
        /// <exception cref="BitmexSocketSubscriptionException">Throws when either timeout is reached or server retured an error.</exception>
        /// <param name="subscription">Specific subscription details. Check out <see cref="BitmetSocketSubscriptions"/>.</param>
        void Subscribe(SubscriptionRequest subscription);

        void Unsubscribe(UnsubscriptionRequest subscription);

        Task UnsubscribeAsync(UnsubscriptionRequest subscription);

        event EventHandler<ResponseEventArgs<WelcomeInfoResponse>> WelcomeInfoResponseReceived;

        event EventHandler<ResponseEventArgs<UnsubscribeResponse>> UnsubscribeResponseReceived;

        event EventHandler<ResponseEventArgs<SubscribeResponse>> SubscribeResponseReceived;

        event EventHandler<ResponseEventArgs<CancelAllAfterResponse>> CancelAllAfterResponseReceived;

        event EventHandler<ResponseEventArgs<AuthenticationResponse>> AuthenticationReceived;

        event EventHandler<ResponseEventArgs<PongResponse>> PongResponseReceived;

        event EventHandler<ResponseEventArgs<TableResponse<WalletDto>>> WalletResponseReceived;

        event EventHandler<ResponseEventArgs<TableResponse<TransactionDto>>> TransactionResponseReceived;

        event EventHandler<ResponseEventArgs<TableResponse<SettlementDto>>> SettlementResponseReceived;

        event EventHandler<ResponseEventArgs<TableResponse<QuoteDto>>> Quote5MResponseReceived;

        event EventHandler<ResponseEventArgs<TableResponse<QuoteDto>>> Quote1MResponseReceived;

        event EventHandler<ResponseEventArgs<TableResponse<QuoteDto>>> Quote1HResponseReceived;

        event EventHandler<ResponseEventArgs<TableResponse<QuoteDto>>> Quote1DResponseReceived;

        event EventHandler<ResponseEventArgs<TableResponse<QuoteDto>>> QuoteResponseReceived;

        event EventHandler<ResponseEventArgs<TableResponse<NotificationDto>>> PublicNotificationResponseReceived;

        event EventHandler<ResponseEventArgs<TableResponse<NotificationDto>>> PrivateNotificationResponseReceived;

        event EventHandler<ResponseEventArgs<TableResponse<OrderBookDto>>> OrderBookL225ResponseReceived;

        event EventHandler<ResponseEventArgs<TableResponse<OrderBookDto>>> OrderBookL2ResponseReceived;

        event EventHandler<ResponseEventArgs<TableResponse<OrderBook10Dto>>> OrderBook10ResponseReceived;

        event EventHandler<ResponseEventArgs<TableResponse<OrderDto>>> OrderResponseReceived;

        event EventHandler<ResponseEventArgs<TableResponse<MarginDto>>> MarginResponseReceived;

        event EventHandler<ResponseEventArgs<TableResponse<LiquidationDto>>> LiquidationResponseReceived;

        event EventHandler<ResponseEventArgs<TableResponse<InsuranceDto>>> InsuranceResponseReceived;

        event EventHandler<ResponseEventArgs<TableResponse<InstrumentDto>>> InstrumentResponseReceived;

        event EventHandler<ResponseEventArgs<TableResponse<FundingDto>>> FundingResponseReceived;

        event EventHandler<ResponseEventArgs<TableResponse<ExecutionDto>>> ExecutionResponseReceived;

        event EventHandler<ResponseEventArgs<TableResponse<ChatConnectedDto>>> ChatConnectedResponseReceived;

        event EventHandler<ResponseEventArgs<TableResponse<ChatDto>>> ChatResponseReceived;

        event EventHandler<ResponseEventArgs<TableResponse<AnnouncementDto>>> AnnouncementResponseReceived;

        event EventHandler<ResponseEventArgs<TableResponse<AffiliateDto>>> AffiliateResponseReceived;

        event EventHandler<ResponseEventArgs<TableResponse<TradeBucketedDto>>> TradeBucketed1DResponseReceived;

        event EventHandler<ResponseEventArgs<TableResponse<TradeBucketedDto>>> TradeBucketed1HResponseReceived;

        event EventHandler<ResponseEventArgs<TableResponse<TradeBucketedDto>>> TradeBucketed5MResponseReceived;

        event EventHandler<ResponseEventArgs<TableResponse<TradeBucketedDto>>> TradeBucketed1MResponseReceived;

        event EventHandler<ResponseEventArgs<TableResponse<PositionDto>>> PositionResponseReceived;

        event EventHandler<ResponseEventArgs<TableResponse<TradeDto>>> TradeResponseReceived;
    }

    public partial class BitmexApiSocketService : IBitmexApiSocketService, IDisposable
    {
        private readonly ILogger _logger;
        private const int SocketMessageResponseTimeout = 5000;

        private readonly IBitmexAuthorization _bitmexAuthorization;
        private readonly IExpiresTimeProvider _expiresTimeProvider;
        private readonly ISignatureProvider _signatureProvider;
        private readonly IBitmexApiSocketProxy _bitmexApiSocketProxy;
        //private readonly IDictionary<string, IList<BitmexApiSubscriptionInfo>> _actions;

        private bool _isAuthorized;
        public bool IsAuthorized => _bitmexApiSocketProxy.IsAlive && _isAuthorized;
        //public IBitmexApiSocketProxy BitmexApiSocketProxy => _bitmexApiSocketProxy;

        public BitmexApiSocketService(IBitmexAuthorization bitmexAuthorization, IExpiresTimeProvider expiresTimeProvider, ISignatureProvider signatureProvider, IBitmexApiSocketProxy bitmexApiSocketProxy, ILogger<BitmexApiSocketService>? logger = null)
        {
            _bitmexAuthorization = bitmexAuthorization;
            _expiresTimeProvider = expiresTimeProvider;
            _signatureProvider = signatureProvider;
            _bitmexApiSocketProxy = bitmexApiSocketProxy;
            _logger = logger ?? NullLogger<BitmexApiSocketService>.Instance;
            //_actions = new Dictionary<string, IList<BitmexApiSubscriptionInfo>>();
            _bitmexApiSocketProxy.MessageReceived += MessageReceived;
        }

        public BitmexApiSocketService(IBitmexAuthorization bitmexAuthorization, IBitmexApiSocketProxy bitmexApiSocketProxy, ILogger<BitmexApiSocketService>? logger = null) : this(bitmexAuthorization, new ExpiresTimeProvider(), new SignatureProvider(), bitmexApiSocketProxy, logger)
        {
        }

        /// <summary>
        /// Sends provided API key and a message encrypted using provided Secret to the server and waits for a response.
        /// </summary>
        /// <exception cref="BitmexSocketAuthorizationException">Throws when either timeout is reached or server retured an error.</exception>
        /// <returns>Returns value of IsAuthorized property.</returns>
        public bool Connect()
        {
            _isAuthorized = false;

            var connectionResult = _bitmexApiSocketProxy.Connect();
            if (!connectionResult)
            {
                _logger.LogInformation("WebSocket connection failed");
                return false;
            }

            return Authorize();
        }

        /// <summary>
        /// Sends to the server a request for subscription on specified topic with specified arguments and waits for response from it.
        /// If you ok to use provided DTO mdoels for socket communication please use <see cref="BitmetSocketSubscriptions"/> static methods to avoid Subscription->Model mapping mistakes.
        /// </summary>
        /// <exception cref="BitmexSocketSubscriptionException">Throws when either timeout is reached or server retured an error.</exception>
        /// <typeparam name="T">Expected type</typeparam>
        /// <param name="request">Specific subscription details.</param>
        public void Subscribe(SubscriptionRequest request)
        {
            var topic = request.SubscriptionType.ToString().FirstToLower() + (string.IsNullOrEmpty(request.Symbol) ? string.Empty : ":" + request.Symbol);
            var respReceived = new ManualResetEvent(false);
            SubscribeResponse? response = null;
            void ResultReceived(object sender, ResponseEventArgs<SubscribeResponse> e)
            {
                if (e.Response.Subscribe == topic)
                {
                    response = e.Response;
                    respReceived.Set();
                }
            }

            this.SubscribeResponseReceived += ResultReceived;
            //_bitmexApiSocketProxy.OperationResultReceived += ResultReceived;
            _logger.LogInformation($"Subscribing on {topic}...");
            _bitmexApiSocketProxy.Send(request);
            var waitReuslt = respReceived.WaitOne(SocketMessageResponseTimeout);
            this.SubscribeResponseReceived -= ResultReceived;
            //_bitmexApiSocketProxy.OperationResultReceived -= ResultReceived;
            if (!waitReuslt)
            {
                throw new BitmexSocketSubscriptionException("Subscription failed: timeout waiting subscription response");
            }

            if (response?.Success ?? false)
            {
                _logger.LogInformation($"Successfully subscribed on {topic} ");
            }
            else
            {
                var error = response?.Error ?? "Unknown error.";
                _logger.LogError($"Failed to subscribe on {topic} {error} ");
                throw new BitmexSocketSubscriptionException(error, new[] { topic });
            }
        }

        public async Task UnsubscribeAsync(UnsubscriptionRequest request)
        {
            var topic = $"{request.UnsubscriptionType}:{request.Symbol ?? "All"}";

            using (var semafore = new SemaphoreSlim(0, 1))
            {
                UnsubscribeResponse? response = null;
                void ResultReceived(object sender, ResponseEventArgs<UnsubscribeResponse> e)
                {
                    response = e.Response;
                    semafore.Release(1);
                }

                this.UnsubscribeResponseReceived += ResultReceived;
                //_bitmexApiSocketProxy.OperationResultReceived += ResultReceived;
                _logger.LogInformation($"Unsubscribing on {topic}...");
                _bitmexApiSocketProxy.Send(request);
                var waitReuslt = await semafore.WaitAsync(SocketMessageResponseTimeout);
                this.UnsubscribeResponseReceived -= ResultReceived;
                //_bitmexApiSocketProxy.OperationResultReceived -= ResultReceived;
                if (!waitReuslt)
                {
                    throw new BitmexSocketSubscriptionException("Unsubscription failed: timeout waiting unsubscription response");
                }

                if (response?.Success ?? false)
                {
                    _logger.LogInformation($"Successfully unsubscribed on {topic} ");
                }
                else
                {
                    var error = response?.Error ?? "Unknown error.";
                    _logger.LogError($"Failed to unsubscribe on {topic} {error} ");
                    throw new BitmexSocketSubscriptionException(error, new[] { topic });
                }
            }
        }

        public void Unsubscribe(UnsubscriptionRequest subscription)
        {
            var task = UnsubscribeAsync(subscription);
            task.ConfigureAwait(false);
            task.Wait();
        }

        private bool Authorize()
        {
            var expiresTime = _expiresTimeProvider.Get();
            var respReceived = new ManualResetEvent(false);
            var data = new string[0];
            var error = string.Empty;
            AuthenticationResponse? response = null;
            void AuthenticationReceived(object sender, ResponseEventArgs<AuthenticationResponse> e)
            {
                response = e.Response;
                respReceived.Set();
            };

            var signatureString = _signatureProvider.CreateSignature(_bitmexAuthorization.Secret, $"GET/realtime{expiresTime}");
            var message = new AuthorizationRequest(_bitmexAuthorization.Key, expiresTime, signatureString);
            this.AuthenticationReceived += AuthenticationReceived;
            _logger.LogInformation("Authorizing...");
            _bitmexApiSocketProxy.Send(message);
            var waitResult = respReceived.WaitOne(SocketMessageResponseTimeout);
            this.AuthenticationReceived -= AuthenticationReceived;

            if (!waitResult)
            {
                _logger.LogError("Timeout waiting authorization response");
                throw new BitmexSocketAuthorizationException("Authorization Failed: timeout waiting authorization response");
            }

            if (response?.Success ?? false)
            {
                _logger.LogInformation("Authorized successfully...");
                _isAuthorized = true;
                return IsAuthorized;
            }
            else
            {
                _logger.LogError($"Not authorized {error}");
                throw new BitmexSocketAuthorizationException(error, data);
            }
        }

        private void MessageReceived(object sender, BitmexSocketMessageEventArgs e)
        {
            if (PongResponse.TryParse(e.Message, OnPongResponse)) return;

            var jsonElement = JsonDocument.Parse(e.Message).RootElement;
            if (jsonElement.TryGetProperty("table", out _))
            {
                if (TableResponse<AffiliateDto>.TryHandle(jsonElement, OnAffiliateResponse, SubscriptionType.affiliate)) return;
                if (TableResponse<AnnouncementDto>.TryHandle(jsonElement, OnAnnouncementResponse, SubscriptionType.announcement)) return;
                if (TableResponse<ChatDto>.TryHandle(jsonElement, OnChatResponse, SubscriptionType.chat)) return;
                if (TableResponse<ChatConnectedDto>.TryHandle(jsonElement, OnChatConnectedResponse, SubscriptionType.connected)) return;
                if (TableResponse<ExecutionDto>.TryHandle(jsonElement, OnExecutionResponse, SubscriptionType.execution)) return;
                if (TableResponse<FundingDto>.TryHandle(jsonElement, OnFundingResponse, SubscriptionType.funding)) return;
                if (TableResponse<InstrumentDto>.TryHandle(jsonElement, OnInstrumentResponse, SubscriptionType.instrument)) return;
                if (TableResponse<InsuranceDto>.TryHandle(jsonElement, OnInsuranceResponse, SubscriptionType.insurance)) return;
                if (TableResponse<LiquidationDto>.TryHandle(jsonElement, OnLiquidationResponse, SubscriptionType.liquidation)) return;
                if (TableResponse<MarginDto>.TryHandle(jsonElement, OnMarginResponse, SubscriptionType.margin)) return;
                if (TableResponse<OrderDto>.TryHandle(jsonElement, OnOrderResponse, SubscriptionType.order)) return;
                if (TableResponse<OrderBook10Dto>.TryHandle(jsonElement, OnOrderBook10Response, SubscriptionType.orderBook10)) return;
                if (TableResponse<OrderBookDto>.TryHandle(jsonElement, OnOrderBookL2Response, SubscriptionType.orderBookL2)) return;
                if (TableResponse<OrderBookDto>.TryHandle(jsonElement, OnOrderBookL225Response, SubscriptionType.orderBookL2_25)) return;
                if (TableResponse<PositionDto>.TryHandle(jsonElement, OnPositionResponse, SubscriptionType.position)) return;
                if (TableResponse<NotificationDto>.TryHandle(jsonElement, OnPrivateNotificationResponse, SubscriptionType.privateNotifications)) return;
                if (TableResponse<NotificationDto>.TryHandle(jsonElement, OnPublicNotificationResponse, SubscriptionType.publicNotifications)) return;
                if (TableResponse<QuoteDto>.TryHandle(jsonElement, OnQuoteResponse, SubscriptionType.quote)) return;
                if (TableResponse<QuoteDto>.TryHandle(jsonElement, OnQuote1DResponse, SubscriptionType.quoteBin1d)) return;
                if (TableResponse<QuoteDto>.TryHandle(jsonElement, OnQuote1HResponse, SubscriptionType.quoteBin1h)) return;
                if (TableResponse<QuoteDto>.TryHandle(jsonElement, OnQuote1MResponse, SubscriptionType.quoteBin1m)) return;
                if (TableResponse<QuoteDto>.TryHandle(jsonElement, OnQuote5MResponse, SubscriptionType.quoteBin5m)) return;
                if (TableResponse<SettlementDto>.TryHandle(jsonElement, OnSettlementResponse, SubscriptionType.settlement)) return;
                if (TableResponse<TradeDto>.TryHandle(jsonElement, OnTradeResponse, SubscriptionType.trade)) return;
                if (TableResponse<TradeDto>.TryHandle(jsonElement, OnTradeResponse, SubscriptionType.trade)) return;
                if (TableResponse<TradeBucketedDto>.TryHandle(jsonElement, OnTradeBucketed1DResponse, SubscriptionType.tradeBin1d)) return;
                if (TableResponse<TradeBucketedDto>.TryHandle(jsonElement, OnTradeBucketed1HResponse, SubscriptionType.tradeBin1h)) return;
                if (TableResponse<TradeBucketedDto>.TryHandle(jsonElement, OnTradeBucketed1MResponse, SubscriptionType.tradeBin1m)) return;
                if (TableResponse<TradeBucketedDto>.TryHandle(jsonElement, OnTradeBucketed5MResponse, SubscriptionType.tradeBin5m)) return;
                if (TableResponse<TransactionDto>.TryHandle(jsonElement, OnTransactionResponse, SubscriptionType.transact)) return;
                if (TableResponse<WalletDto>.TryHandle(jsonElement, OnWalletResponse, SubscriptionType.wallet)) return;
            }
            if (AuthenticationResponse.TryParse(jsonElement, OnAuthenticationResponse)) return;
            if (CancelAllAfterResponse.TryHandle(jsonElement, OnCancelAllAfterResponse)) return;
            //if (ErrorResponse.TryParse(jsonElement, OnErrorResponse)) return;
            if (SubscribeResponse.TryParse(jsonElement, OnSubscribeResponse)) return;
            if (UnsubscribeResponse.TryParse(jsonElement, OnUnsubscribeResponse)) return;
            if (WelcomeInfoResponse.TryParse(jsonElement, OnWelcomeInfoResponse)) return;

            _logger.LogWarning($"Unknown type message.{e.Message}");
        }

        public static IBitmexApiSocketService CreateDefaultApi(IBitmexAuthorization bitmexAuthorization)
        {
            return new BitmexApiSocketService(bitmexAuthorization, new BitmexApiSocketProxy(bitmexAuthorization));
        }

        #region IDisposable Support

        private bool disposedValue = false; // 要检测冗余调用

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TO DO: 释放托管状态(托管对象)。
                    _bitmexApiSocketProxy?.Dispose();
                    _logger.LogInformation("Disposed...");
                }

                // TO DO: 释放未托管的资源(未托管的对象)并在以下内容中替代终结器。
                // TO DO: 将大型字段设置为 null。

                disposedValue = true;
            }
        }

        // TO DO: 仅当以上 Dispose(bool disposing) 拥有用于释放未托管资源的代码时才替代终结器。
        // ~BitmexApiSocketService()
        // {
        //   // 请勿更改此代码。将清理代码放入以上 Dispose(bool disposing) 中。
        //   Dispose(false);
        // }

        // 添加此代码以正确实现可处置模式。
        public void Dispose()
        {
            // 请勿更改此代码。将清理代码放入以上 Dispose(bool disposing) 中。
            Dispose(true);
            // TO DO: 如果在以上内容中替代了终结器，则取消注释以下行。
            // GC.SuppressFinalize(this);
        }

        #endregion IDisposable Support
    }
}