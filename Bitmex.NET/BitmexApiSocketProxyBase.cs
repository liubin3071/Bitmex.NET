using System;
using System.Text.Json;
using System.Threading;
using Bitmex.NET.Dtos;
using Bitmex.NET.Dtos.Socket;
using Bitmex.NET.Logging;
using Bitmex.NET.Models;
using Bitmex.NET.Models.Socket;
using Bitmex.NET.Models.Socket.Events;
using Bitmex.NET.Models.Socket.Responses;
using Bitmex.NET.Models.Socket.Responses.OperationResponses;
using Bitmex.NET.Models.Socket.Responses.RawResponses;
using Bitmex.NET.Models.Socket.Responses.TableResponses;
using SuperSocket.ClientEngine;
using WebSocket4Net;

namespace Bitmex.NET
{
    public class BitmexApiSocketProxy : IBitmexApiSocketProxy
    {
        private static readonly ILog Log = LogProvider.GetCurrentClassLogger();
        private const int SocketMessageResponseTimeout = 10000;
        private readonly ManualResetEvent _welcomeReceived = new ManualResetEvent(false);
        private readonly IBitmexAuthorization _bitmexAuthorization;

        public event EventHandler<BitmexSocketMessageEventArgs>? MessageReceived;

        public event EventHandler<BitmextErrorEventArgs>? ErrorOccurred;

        public event EventHandler<BitmexCloseEventArgs>? Closed;

        private WebSocket? _socketConnection;

        public bool IsAlive => _socketConnection?.State == WebSocketState.Open;

        public BitmexApiSocketProxy(IBitmexAuthorization bitmexAuthorization)
        {
            _bitmexAuthorization = bitmexAuthorization;
        }

        public bool Connect()
        {
            CloseConnectionIfItsNotNull();
            _socketConnection = new WebSocket($"wss://{Environments.Values[_bitmexAuthorization.BitmexEnvironment]}/realtime") { EnableAutoSendPing = true, AutoSendPingInterval = 2 };
            BitmexWelcomeMessage welcomeData = null;
            EventHandler<MessageReceivedEventArgs> welcomeMessageReceived = (sender, e) =>
            {
                Log.Debug($"Welcome Data Received {e.Message}");
                welcomeData = BitmexJsonSerializer.Deserialize<BitmexWelcomeMessage>(e.Message);
                _welcomeReceived.Set();
            };
            _socketConnection.MessageReceived += welcomeMessageReceived;
            _socketConnection.Open();
            var waitResult = _welcomeReceived.WaitOne(SocketMessageResponseTimeout);
            _socketConnection.MessageReceived -= welcomeMessageReceived;
            if (waitResult && (welcomeData?.Limit?.Remaining ?? 0) == 0)
            {
                Log.Error("Bitmext connection limit reached");
                throw new BitmexWebSocketLimitReachedException();
            }

            if (!waitResult)
            {
                Log.Error("Open connection timeout. Welcome message is not received");
                return false;
            }

            if (IsAlive)
            {
                Log.Info("Bitmex web socket connection opened");
                _socketConnection.MessageReceived += SocketConnectionOnMessageReceived;
                _socketConnection.Closed += SocketConnectionOnClosed;
                _socketConnection.Error += SocketConnectionOnError;
            }

            return IsAlive;
        }

        private void CloseConnectionIfItsNotNull()
        {
            if (_socketConnection != null)
            {
                Log.Debug("Closing existing connection");
                using (_socketConnection)
                {
                    _socketConnection.MessageReceived -= SocketConnectionOnMessageReceived;
                    _socketConnection.Closed -= SocketConnectionOnClosed;
                    _socketConnection.Error -= SocketConnectionOnError;
                    _welcomeReceived.Reset();
                    _socketConnection.Close();
                    _socketConnection = null;
                }
            }
        }

        private void SocketConnectionOnMessageReceived(object sender, MessageReceivedEventArgs e)
        {
            Log.Debug($"Message received {e.Message}");
            OnMessage(new BitmexSocketMessageEventArgs(e.Message));
        }

        protected virtual void OnMessage(BitmexSocketMessageEventArgs args)
        {
            MessageReceived?.Invoke(this, args);
        }

        private void SocketConnectionOnError(object sender, ErrorEventArgs e)
        {
            OnConnectionErrorReceived(e);
        }

        private void SocketConnectionOnClosed(object sender, EventArgs e)
        {
            OnConnectionClosed();
        }

        public void Send<TRequest>(TRequest request)
            where TRequest : SocketRequest
        {
            //var json = BitmexJsonSerializer.Serialize(message);
            Log.Debug($"Sending message : {request.GetContent()}");
            _socketConnection.Send(request.GetContent());
        }

        protected virtual void OnConnectionErrorReceived(ErrorEventArgs args)
        {
            Log.Error(args.Exception, "Socket connection");
            ErrorOccurred?.Invoke(this, new BitmextErrorEventArgs(args.Exception));
        }

        protected virtual void OnConnectionClosed()
        {
            Log.Debug("Connection closed");
            Closed?.Invoke(this, new BitmexCloseEventArgs());
        }

        #region IDisposable Support

        private bool _disposedValue = false; // 要检测冗余调用

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    // TO DO: 释放托管状态(托管对象)。
                    CloseConnectionIfItsNotNull();
                    _welcomeReceived?.Dispose();
                    _socketConnection?.Dispose();
                    Log.Info("Disposed...");
                }

                // TO DO: 释放未托管的资源(未托管的对象)并在以下内容中替代终结器。
                // TO DO: 将大型字段设置为 null。

                _disposedValue = true;
            }
        }

        // TO DO: 仅当以上 Dispose(bool disposing) 拥有用于释放未托管资源的代码时才替代终结器。
        // ~BitmexApiSocketProxy()
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

    public class BitmexSocketMessageEventArgs : EventArgs
    {
        public BitmexSocketMessageEventArgs(string message)
        {
            Message = message;
        }

        public string Message { get; }
    }
}