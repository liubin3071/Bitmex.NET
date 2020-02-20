using Bitmex.NET.Dtos;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Bitmex.NET.Dtos.Socket;
using Bitmex.NET.Models.Socket;

namespace Bitmex.NET.IntegrationTests.Tests
{
    [TestClass]
    [TestCategory("WebSocket")]
    public class BitmexApiSocketServiceTradesTests : BaseBitmexSocketIntegrationTests
    {
        [TestMethod]
        public void should_subscribe_on_trades()
        {
            try
            {
                // arrange
                var connected = Sut.Connect();
                IEnumerable<TradeDto> dtos = null;
                var dataReceived = new ManualResetEvent(false);
                Sut.TradeResponseReceived += (sender, args) =>
                {
                    dtos = args.Response.Data;
                    dataReceived.Set();
                };
                var subscription = new SubscriptionRequest(SubscriptionType.trade);

                Subscription = subscription;
                // act

                Sut.Subscribe(subscription);
                var received = dataReceived.WaitOne(TimeSpan.FromSeconds(20));

                // assert
                // no exception raised
                connected.Should().BeTrue();
                received.Should().BeTrue();
                dtos.Should().NotBeNull();
                dtos.Count().Should().BeGreaterThan(0);
            }
            catch (BitmexWebSocketLimitReachedException)
            {
                Assert.Fail("connection limit reached");
            }
        }

        [TestMethod]
        public void should_subscribe_on_trades_with_arguments()
        {
            try
            {
                // arrange
                var connected = Sut.Connect();
                IEnumerable<TradeDto> dtos = null;
                var dataReceived = new ManualResetEvent(false);
                Sut.TradeResponseReceived += (sender, args) =>
                {
                    dtos = args.Response.Data;
                    dataReceived.Set();
                };
                var subscription = new SubscriptionRequest(SubscriptionType.trade, "XBTUSD");

                Subscription = subscription;

                // act
                Sut.Subscribe(subscription);
                var received = dataReceived.WaitOne(TimeSpan.FromSeconds(20));

                // assert
                // no exception raised
                connected.Should().BeTrue();
                received.Should().BeTrue();
                dtos.Should().NotBeNull();
                dtos.Count().Should().BeGreaterThan(0);
                dtos.All(a => a.Symbol == "XBTUSD").Should().BeTrue();
            }
            catch (BitmexWebSocketLimitReachedException)
            {
                Assert.Fail("connection limit reached");
            }
        }

        [TestMethod]
        public void should_subscribe_on_trades1m_with_arguments()
        {
            try
            {
                // arrange
                var connected = Sut.Connect();
                IEnumerable<TradeBucketedDto> dtos = null;
                var dataReceived = new ManualResetEvent(false);
                Sut.TradeBucketed1MResponseReceived += (sender, args) =>
                {
                    dtos = args.Response.Data;
                    dataReceived.Set();
                };
                var subscription = new SubscriptionRequest(SubscriptionType.tradeBin1m, "XBTUSD");

                Subscription = subscription;

                // act
                Sut.Subscribe(subscription);
                var received = dataReceived.WaitOne(TimeSpan.FromSeconds(60));

                // assert
                // no exception raised
                connected.Should().BeTrue();
                received.Should().BeTrue();
                dtos.Should().NotBeNull();
                dtos.Count().Should().BeGreaterThan(0);
                dtos.All(a => a.Symbol == "XBTUSD").Should().BeTrue();
            }
            catch (BitmexWebSocketLimitReachedException)
            {
                Assert.Fail("connection limit reached");
            }
        }
    }
}