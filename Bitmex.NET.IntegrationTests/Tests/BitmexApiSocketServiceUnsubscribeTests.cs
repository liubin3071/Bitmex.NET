using Bitmex.NET.Dtos;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Bitmex.NET.Models.Socket;

namespace Bitmex.NET.IntegrationTests.Tests
{
    [TestClass]
    [TestCategory("WebSocket")]
    public class BitmexApiSocketServiceUnsubscribeTests : BaseBitmexIntegrationTests<IBitmexApiSocketService>
    {
        [TestMethod]
        public void should_unsubscribe()
        {
            try
            {
                // arrange
                var connected = Sut.Connect();
                IEnumerable<InstrumentDto> dtos = null;
                var dataReceived = new ManualResetEvent(false);
                Sut.InstrumentResponseReceived += (sender, args) =>
                {
                    dtos = args.Response.Data;
                    dataReceived.Set();
                };
                var subscription = new SubscriptionRequest(SubscriptionType.instrument);

                Sut.Subscribe(subscription);
                var received = dataReceived.WaitOne(TimeSpan.FromSeconds(5));

                // intermediate assert
                // no exception raised
                connected.Should().BeTrue();
                received.Should().BeTrue();
                dtos.Should().NotBeNull();
                dtos.Count().Should().BeGreaterThan(0);

                // act
                Sut.Unsubscribe(subscription.CreateUnsubscriptionRequest());

                // assert
                // no exceptions raised
            }
            catch (BitmexWebSocketLimitReachedException)
            {
                Assert.Fail("connection limit reached");
            }
        }
    }
}