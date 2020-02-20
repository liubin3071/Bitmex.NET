using Bitmex.NET.Dtos;
using Bitmex.NET.Dtos.Socket;
using Bitmex.NET.Models.Socket;
using Bitmex.NET.Models.Socket.Events;
using Bitmex.NET.Models.Socket.Responses;
using Bitmex.NET.Models.Socket.Responses.OperationResponses;
using Bitmex.NET.Models.Socket.Responses.RawResponses;
using Bitmex.NET.Models.Socket.Responses.TableResponses;
using System;

namespace Bitmex.NET
{
    public interface IBitmexApiSocketProxy : IDisposable
    {
        event EventHandler<BitmexSocketMessageEventArgs> MessageReceived;

        event EventHandler<BitmextErrorEventArgs> ErrorOccurred;

        event EventHandler<BitmexCloseEventArgs> Closed;

        bool Connect();

        void Send<TRequest>(TRequest message)
            where TRequest : SocketRequest;

        bool IsAlive { get; }
    }
}