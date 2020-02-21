using System;
using System.Threading.Tasks;
using Bitmex.NET.Dtos;
using Bitmex.NET.Dtos.Socket;
using Bitmex.NET.Models.Socket;
using Bitmex.NET.Models.Socket.Events;
using Bitmex.NET.Models.Socket.Responses;
using Bitmex.NET.Models.Socket.Responses.OperationResponses;
using Bitmex.NET.Models.Socket.Responses.RawResponses;
using Bitmex.NET.Models.Socket.Responses.TableResponses;

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
}