using Bitmex.NET.Dtos.Socket;
using System;
using System.Buffers;
using System.Linq;
using Bitmex.NET.Dtos;
using Bitmex.NET.Models.Socket.Events;
using Bitmex.NET.Models.Socket.Responses;
using Bitmex.NET.Models.Socket.Responses.OperationResponses;
using Bitmex.NET.Models.Socket.Responses.RawResponses;
using Bitmex.NET.Models.Socket.Responses.TableResponses;

namespace Bitmex.NET
{
    public partial class BitmexApiSocketService
    {
        public event EventHandler<ResponseEventArgs<WelcomeInfoResponse>>? WelcomeInfoResponseReceived;

        public event EventHandler<ResponseEventArgs<UnsubscribeResponse>>? UnsubscribeResponseReceived;

        public event EventHandler<ResponseEventArgs<SubscribeResponse>>? SubscribeResponseReceived;

        //public event EventHandler<ResponseEventArgs<ErrorResponse>>? ErrorResponseReceived;

        public event EventHandler<ResponseEventArgs<CancelAllAfterResponse>>? CancelAllAfterResponseReceived;

        public event EventHandler<ResponseEventArgs<AuthenticationResponse>>? AuthenticationReceived;

        public event EventHandler<ResponseEventArgs<PongResponse>>? PongResponseReceived;

        public event EventHandler<ResponseEventArgs<TableResponse<WalletDto>>>? WalletResponseReceived;

        public event EventHandler<ResponseEventArgs<TableResponse<TransactionDto>>>? TransactionResponseReceived;

        public event EventHandler<ResponseEventArgs<TableResponse<SettlementDto>>>? SettlementResponseReceived;

        public event EventHandler<ResponseEventArgs<TableResponse<QuoteDto>>>? Quote5MResponseReceived;

        public event EventHandler<ResponseEventArgs<TableResponse<QuoteDto>>>? Quote1MResponseReceived;

        public event EventHandler<ResponseEventArgs<TableResponse<QuoteDto>>>? Quote1HResponseReceived;

        public event EventHandler<ResponseEventArgs<TableResponse<QuoteDto>>>? Quote1DResponseReceived;

        public event EventHandler<ResponseEventArgs<TableResponse<QuoteDto>>>? QuoteResponseReceived;

        public event EventHandler<ResponseEventArgs<TableResponse<NotificationDto>>>? PublicNotificationResponseReceived;

        public event EventHandler<ResponseEventArgs<TableResponse<NotificationDto>>>? PrivateNotificationResponseReceived;

        public event EventHandler<ResponseEventArgs<TableResponse<OrderBookDto>>>? OrderBookL225ResponseReceived;

        public event EventHandler<ResponseEventArgs<TableResponse<OrderBookDto>>>? OrderBookL2ResponseReceived;

        public event EventHandler<ResponseEventArgs<TableResponse<OrderBook10Dto>>>? OrderBook10ResponseReceived;

        public event EventHandler<ResponseEventArgs<TableResponse<OrderDto>>>? OrderResponseReceived;

        public event EventHandler<ResponseEventArgs<TableResponse<MarginDto>>>? MarginResponseReceived;

        public event EventHandler<ResponseEventArgs<TableResponse<LiquidationDto>>>? LiquidationResponseReceived;

        public event EventHandler<ResponseEventArgs<TableResponse<InsuranceDto>>>? InsuranceResponseReceived;

        public event EventHandler<ResponseEventArgs<TableResponse<InstrumentDto>>>? InstrumentResponseReceived;

        public event EventHandler<ResponseEventArgs<TableResponse<FundingDto>>>? FundingResponseReceived;

        public event EventHandler<ResponseEventArgs<TableResponse<ExecutionDto>>>? ExecutionResponseReceived;

        public event EventHandler<ResponseEventArgs<TableResponse<ChatConnectedDto>>>? ChatConnectedResponseReceived;

        public event EventHandler<ResponseEventArgs<TableResponse<ChatDto>>>? ChatResponseReceived;

        public event EventHandler<ResponseEventArgs<TableResponse<AnnouncementDto>>>? AnnouncementResponseReceived;

        public event EventHandler<ResponseEventArgs<TableResponse<AffiliateDto>>>? AffiliateResponseReceived;

        public event EventHandler<ResponseEventArgs<TableResponse<TradeBucketedDto>>>? TradeBucketed1DResponseReceived;

        public event EventHandler<ResponseEventArgs<TableResponse<TradeBucketedDto>>>? TradeBucketed1HResponseReceived;

        public event EventHandler<ResponseEventArgs<TableResponse<TradeBucketedDto>>>? TradeBucketed5MResponseReceived;

        public event EventHandler<ResponseEventArgs<TableResponse<TradeBucketedDto>>>? TradeBucketed1MResponseReceived;

        public event EventHandler<ResponseEventArgs<TableResponse<PositionDto>>>? PositionResponseReceived;

        public event EventHandler<ResponseEventArgs<TableResponse<TradeDto>>>? TradeResponseReceived;

        protected virtual void OnWalletResponse(TableResponse<WalletDto> response)
        {
            WalletResponseReceived?.Invoke(this, new ResponseEventArgs<TableResponse<WalletDto>>(response));
        }

        protected virtual void OnTransactionResponse(TableResponse<TransactionDto> response)
        {
            TransactionResponseReceived?.Invoke(this, new ResponseEventArgs<TableResponse<TransactionDto>>(response));
        }

        protected virtual void OnSettlementResponse(TableResponse<SettlementDto> response)
        {
            SettlementResponseReceived?.Invoke(this, new ResponseEventArgs<TableResponse<SettlementDto>>(response));
        }

        protected virtual void OnQuote5MResponse(TableResponse<QuoteDto> response)
        {
            Quote5MResponseReceived?.Invoke(this, new ResponseEventArgs<TableResponse<QuoteDto>>(response));
        }

        protected virtual void OnQuote1MResponse(TableResponse<QuoteDto> response)
        {
            Quote1MResponseReceived?.Invoke(this, new ResponseEventArgs<TableResponse<QuoteDto>>(response));
        }

        protected virtual void OnQuote1HResponse(TableResponse<QuoteDto> response)
        {
            Quote1HResponseReceived?.Invoke(this, new ResponseEventArgs<TableResponse<QuoteDto>>(response));
        }

        protected virtual void OnQuote1DResponse(TableResponse<QuoteDto> response)
        {
            Quote1DResponseReceived?.Invoke(this, new ResponseEventArgs<TableResponse<QuoteDto>>(response));
        }

        protected virtual void OnQuoteResponse(TableResponse<QuoteDto> response)
        {
            QuoteResponseReceived?.Invoke(this, new ResponseEventArgs<TableResponse<QuoteDto>>(response));
        }

        protected virtual void OnPublicNotificationResponse(TableResponse<NotificationDto> response)
        {
            PublicNotificationResponseReceived?.Invoke(this, new ResponseEventArgs<TableResponse<NotificationDto>>(response));
        }

        protected virtual void OnPrivateNotificationResponse(TableResponse<NotificationDto> response)
        {
            PrivateNotificationResponseReceived?.Invoke(this, new ResponseEventArgs<TableResponse<NotificationDto>>(response));
        }

        protected virtual void OnOrderBookL225Response(TableResponse<OrderBookDto> response)
        {
            OrderBookL225ResponseReceived?.Invoke(this, new ResponseEventArgs<TableResponse<OrderBookDto>>(response));
        }

        protected virtual void OnOrderBookL2Response(TableResponse<OrderBookDto> response)
        {
            OrderBookL2ResponseReceived?.Invoke(this, new ResponseEventArgs<TableResponse<OrderBookDto>>(response));
        }

        protected virtual void OnOrderBook10Response(TableResponse<OrderBook10Dto> response)
        {
            OrderBook10ResponseReceived?.Invoke(this, new ResponseEventArgs<TableResponse<OrderBook10Dto>>(response));
        }

        protected virtual void OnOrderResponse(TableResponse<OrderDto> response)
        {
            OrderResponseReceived?.Invoke(this, new ResponseEventArgs<TableResponse<OrderDto>>(response));
        }

        protected virtual void OnMarginResponse(TableResponse<MarginDto> response)
        {
            MarginResponseReceived?.Invoke(this, new ResponseEventArgs<TableResponse<MarginDto>>(response));
        }

        protected virtual void OnLiquidationResponse(TableResponse<LiquidationDto> response)
        {
            LiquidationResponseReceived?.Invoke(this, new ResponseEventArgs<TableResponse<LiquidationDto>>(response));
        }

        protected virtual void OnInsuranceResponse(TableResponse<InsuranceDto> response)
        {
            InsuranceResponseReceived?.Invoke(this, new ResponseEventArgs<TableResponse<InsuranceDto>>(response));
        }

        protected virtual void OnInstrumentResponse(TableResponse<InstrumentDto> response)
        {
            InstrumentResponseReceived?.Invoke(this, new ResponseEventArgs<TableResponse<InstrumentDto>>(response));
        }

        protected virtual void OnFundingResponse(TableResponse<FundingDto> response)
        {
            FundingResponseReceived?.Invoke(this, new ResponseEventArgs<TableResponse<FundingDto>>(response));
        }

        protected virtual void OnExecutionResponse(TableResponse<ExecutionDto> response)
        {
            ExecutionResponseReceived?.Invoke(this, new ResponseEventArgs<TableResponse<ExecutionDto>>(response));
        }

        protected virtual void OnChatConnectedResponse(TableResponse<ChatConnectedDto> response)
        {
            ChatConnectedResponseReceived?.Invoke(this, new ResponseEventArgs<TableResponse<ChatConnectedDto>>(response));
        }

        protected virtual void OnChatResponse(TableResponse<ChatDto> response)
        {
            ChatResponseReceived?.Invoke(this, new ResponseEventArgs<TableResponse<ChatDto>>(response));
        }

        protected virtual void OnAnnouncementResponse(TableResponse<AnnouncementDto> response)
        {
            AnnouncementResponseReceived?.Invoke(this, new ResponseEventArgs<TableResponse<AnnouncementDto>>(response));
        }

        protected virtual void OnAffiliateResponse(TableResponse<AffiliateDto> response)
        {
            AffiliateResponseReceived?.Invoke(this, new ResponseEventArgs<TableResponse<AffiliateDto>>(response));
        }

        protected virtual void OnTradeBucketed1DResponse(TableResponse<TradeBucketedDto> response)
        {
            TradeBucketed1DResponseReceived?.Invoke(this, new ResponseEventArgs<TableResponse<TradeBucketedDto>>(response));
        }

        protected virtual void OnTradeBucketed1HResponse(TableResponse<TradeBucketedDto> response)
        {
            TradeBucketed1HResponseReceived?.Invoke(this, new ResponseEventArgs<TableResponse<TradeBucketedDto>>(response));
        }

        protected virtual void OnTradeBucketed5MResponse(TableResponse<TradeBucketedDto> response)
        {
            TradeBucketed5MResponseReceived?.Invoke(this, new ResponseEventArgs<TableResponse<TradeBucketedDto>>(response));
        }

        protected virtual void OnTradeBucketed1MResponse(TableResponse<TradeBucketedDto> response)
        {
            TradeBucketed1MResponseReceived?.Invoke(this, new ResponseEventArgs<TableResponse<TradeBucketedDto>>(response));
        }

        protected virtual void OnPositionResponse(TableResponse<PositionDto> response)
        {
            PositionResponseReceived?.Invoke(this, new ResponseEventArgs<TableResponse<PositionDto>>(response));
        }

        protected virtual void OnTradeResponse(TableResponse<TradeDto> response)
        {
            TradeResponseReceived?.Invoke(this, new ResponseEventArgs<TableResponse<TradeDto>>(response));
        }

        protected virtual void OnWelcomeInfoResponse(WelcomeInfoResponse response)
        {
            WelcomeInfoResponseReceived?.Invoke(this, new ResponseEventArgs<WelcomeInfoResponse>(response));
        }

        protected virtual void OnUnsubscribeResponse(UnsubscribeResponse response)
        {
            UnsubscribeResponseReceived?.Invoke(this, new ResponseEventArgs<UnsubscribeResponse>(response));
        }

        protected virtual void OnSubscribeResponse(SubscribeResponse response)
        {
            SubscribeResponseReceived?.Invoke(this, new ResponseEventArgs<SubscribeResponse>(response));
        }

        //protected virtual void OnErrorResponse(ErrorResponse response)
        //{
        //    ErrorResponseReceived?.Invoke(this, new ResponseEventArgs<ErrorResponse>(response));
        //}

        protected virtual void OnCancelAllAfterResponse(CancelAllAfterResponse response)
        {
            CancelAllAfterResponseReceived?.Invoke(this, new ResponseEventArgs<CancelAllAfterResponse>(response));
        }

        protected virtual void OnAuthenticationResponse(AuthenticationResponse response)
        {
            AuthenticationReceived?.Invoke(this, new ResponseEventArgs<AuthenticationResponse>(response));
        }

        protected virtual void OnPongResponse(PongResponse response)
        {
            PongResponseReceived?.Invoke(this, new ResponseEventArgs<PongResponse>(response));
        }
    }
}