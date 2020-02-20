﻿using Bitmex.NET.Dtos;
using Bitmex.NET.Dtos.Socket;
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
    public class BitmexApiSocketServiceOrdersBookTests : BaseBitmexSocketIntegrationTests
    {
        [TestMethod]
        public void should_subscribe_on_orders_book_10()
        {
            try
            {
                // arrange
                var connected = Sut.Connect();

                // act
                IEnumerable<OrderBook10Dto> dtos = null;
                var dataReceived = new ManualResetEvent(false);
                Sut.OrderBook10ResponseReceived += (sender, args) =>
                {
                    dtos = args.Response.Data;
                    dataReceived.Set();
                };

                var subscription = new SubscriptionRequest(SubscriptionType.orderBook10);

                Subscription = subscription;

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
        public void should_subscribe_on_orders_book_10_with_arguments()
        {
            try
            {
                // arrange
                var connected = Sut.Connect();

                // act
                IEnumerable<OrderBook10Dto> dtos = null;
                var dataReceived = new ManualResetEvent(false);
                Sut.OrderBook10ResponseReceived += (sender, args) =>
                {
                    dtos = args.Response.Data;
                    dataReceived.Set();
                };

                var subscription = new SubscriptionRequest(SubscriptionType.orderBook10, "XBTUSD");

                Subscription = subscription;

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
        public void should_subscribe_on_orders_book_L2()
        {
            try
            {
                // arrange
                var connected = Sut.Connect();

                // act
                IEnumerable<OrderBookDto> dtos = null;
                var dataReceived = new ManualResetEvent(false);
                Sut.OrderBookL2ResponseReceived += (sender, args) =>
                {
                    dtos = args.Response.Data;
                    dataReceived.Set();
                };

                var subscription = new SubscriptionRequest(SubscriptionType.orderBookL2);

                Subscription = subscription;

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
        public void should_subscribe_on_orders_book_L2_with_arguments()
        {
            try
            {
                // arrange
                var connected = Sut.Connect();

                // act
                IEnumerable<OrderBookDto> dtos = null;
                var dataReceived = new ManualResetEvent(false);
                Sut.OrderBookL2ResponseReceived += (sender, args) =>
                {
                    dtos = args.Response.Data;
                    dataReceived.Set();
                };

                var subscription = new SubscriptionRequest(SubscriptionType.orderBookL2, "XBTUSD");
                Subscription = subscription;

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
    }
}